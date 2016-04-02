using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CAESAR
{
    public class Cryptor
    {
        // Size constants (in bytes)
        private const int BlockSize = 32;
        private const int KeySize = 32;
        private const int SaltSize = 16;
        
        private const int Iterations = 100000; // Takes ~850ms to derive a key with PBKDF2 at 100,000 iterations
        private const int minKeyLen = 16;
        private readonly byte[] key;

        public Cryptor(byte[] key)
        {
            if (key.Length < minKeyLen) throw new ArgumentException($"Must have a password of at least {minKeyLen} characters", nameof(key));
            this.key = key;
        }
        
        public byte[] Encrypt(byte[] plaintext, byte[] cryptKey, byte[] authKey, byte[] nonSecretPayload = null)
        {
            if (plaintext == null || plaintext.Length < 1) throw new ArgumentException(@"Plaintext required", nameof(plaintext));

            // non-secret payload optional
            nonSecretPayload = nonSecretPayload ?? new byte[] { };

            byte[] cipherText;
            byte[] iv;

            using (var aes = new RijndaelManaged {KeySize = KeySize * 8, BlockSize = BlockSize * 8, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7})
            {
                //Use random IV
                aes.GenerateIV();
                iv = aes.IV;

                using (var encrypter = aes.CreateEncryptor(cryptKey, iv))
                using (var cipherStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                    using (var binaryWriter = new BinaryWriter(cryptoStream))
                    {
                        //Encrypt Data
                        binaryWriter.Write(plaintext);
                    }

                    cipherText = cipherStream.ToArray();
                }

            }

            //Assemble encrypted message and add authentication
            using (var hmac = new HMACSHA512(authKey))
            using (var encryptedStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(encryptedStream))
                {
                    //Prefix non-secret payload if any
                    binaryWriter.Write(nonSecretPayload);
                    //Prefix IV
                    binaryWriter.Write(iv);
                    //Write Ciphertext
                    binaryWriter.Write(cipherText);
                    binaryWriter.Flush();

                    //Authenticate all data
                    var tag = hmac.ComputeHash(encryptedStream.ToArray());
                    //Postfix tag
                    binaryWriter.Write(tag);
                }

                return encryptedStream.ToArray();
            }

        }

        public byte[] Decrypt(byte[] encryptedMessage, byte[] cryptKey, byte[] authKey, int nonSecretPayloadLength = 0)
        {
            if (encryptedMessage == null || encryptedMessage.Length == 0) throw new ArgumentException(@"Encrypted Message Required!", nameof(encryptedMessage));

            using (var hmac = new HMACSHA512(authKey))
            {
                var sentTag = new byte[hmac.HashSize / 8];
                //Calculate Tag
                var calcTag = hmac.ComputeHash(encryptedMessage, 0, encryptedMessage.Length - sentTag.Length);
                var ivLength = BlockSize;

                //if message length is to small just return null
                if (encryptedMessage.Length < sentTag.Length + nonSecretPayloadLength + ivLength) return null;

                //Grab Sent Tag
                Array.Copy(encryptedMessage, encryptedMessage.Length - sentTag.Length, sentTag, 0, sentTag.Length);

                //Compare Tag with constant time comparison
                var compare = 0;
                for (var i = 0; i < sentTag.Length; i++) compare |= sentTag[i] ^ calcTag[i];

                //if message doesn't authenticate return null
                if (compare != 0) return null;

                using (var aes = new RijndaelManaged {KeySize = KeySize * 8, BlockSize = BlockSize * 8, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7})
                {
                    //Grab IV from message
                    var iv = new byte[ivLength];
                    Array.Copy(encryptedMessage, nonSecretPayloadLength, iv, 0, iv.Length);

                    using (var decrypter = aes.CreateDecryptor(cryptKey, iv))
                    using (var plainTextStream = new MemoryStream())
                    {
                        using (var decrypterStream = new CryptoStream(plainTextStream, decrypter, CryptoStreamMode.Write))
                        using (var binaryWriter = new BinaryWriter(decrypterStream))
                        {
                            //Decrypt Cipher Text from Message
                            binaryWriter.Write(encryptedMessage,nonSecretPayloadLength + iv.Length,encryptedMessage.Length - nonSecretPayloadLength - iv.Length - sentTag.Length);
                        }
                        //Return Plain Text
                        return plainTextStream.ToArray();
                    }
                }
            }
        }

        public byte[] EncryptWithPassword(byte[] plaintext, byte[] nonSecretPayload = null)
        {
            nonSecretPayload = nonSecretPayload ?? new byte[] { };

            if (plaintext?.Length == 0) throw new ArgumentException(@"Plaintext required", nameof(plaintext));

            var payload = new byte[SaltSize * 2 + nonSecretPayload.Length];
            Array.Copy(nonSecretPayload, payload, nonSecretPayload.Length);
            var payloadIndex = nonSecretPayload.Length;

            byte[] cryptKey;
            byte[] authKey;

            //Use Random Salt to prevent pre-generated weak password attacks.
            using (var generator = new Rfc2898DeriveBytes(Encoding.ASCII.GetString(key), SaltSize, Iterations))
            {
                var salt = generator.Salt;

                //Generate Keys
                cryptKey = generator.GetBytes(KeySize);

                //Create Non Secret Payload
                Array.Copy(salt, 0, payload, payloadIndex, salt.Length);
                payloadIndex += salt.Length;
            }

            using (var generator = new Rfc2898DeriveBytes(Encoding.ASCII.GetString(key), SaltSize, Iterations))
            {
                var salt = generator.Salt;

                //Generate Keys
                authKey = generator.GetBytes(KeySize);

                //Create Rest of Non Secret Payload
                Array.Copy(salt, 0, payload, payloadIndex, salt.Length);
            }
            return Encrypt(plaintext, cryptKey, authKey, payload);
        }

        public byte[] DecryptWithPassword(byte[] encryptedMessage, int nonSecretPayloadLength = 0)
        {
            if (encryptedMessage == null || encryptedMessage.Length == 0) throw new ArgumentException(@"Encrypted Message Required!", nameof(encryptedMessage));

            var cryptSalt = new byte[SaltSize];
            var authSalt = new byte[SaltSize];

            //Grab Salt from Non-Secret Payload
            Array.Copy(encryptedMessage, nonSecretPayloadLength, cryptSalt, 0, cryptSalt.Length);
            Array.Copy(encryptedMessage, nonSecretPayloadLength + cryptSalt.Length, authSalt, 0, authSalt.Length);

            byte[] cryptKey;
            byte[] authKey;

            using (var generator = new Rfc2898DeriveBytes(key, cryptSalt, Iterations)) cryptKey = generator.GetBytes(KeySize); //Generate crypt key
            using (var generator = new Rfc2898DeriveBytes(key, authSalt, Iterations))authKey = generator.GetBytes(KeySize); //Generate auth key

            return Decrypt(encryptedMessage, cryptKey, authKey, cryptSalt.Length + authSalt.Length + nonSecretPayloadLength);
        }
    }

}