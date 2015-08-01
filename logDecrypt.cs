using Google.Authenticator;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CAESAR
{
    public partial class logDecrypt : Form
    {
        private bool VerifyPin(string pin)
        {
            var tfa = new TwoFactorAuthenticator();
            bool verified =
                tfa.ValidateTwoFactorPIN(
                Encoding.ASCII.GetString(
                ProtectedData.Unprotect(
                System.IO.File.ReadAllBytes(@"tfbin"), null, DataProtectionScope.CurrentUser)), pin);

            return verified;
        }

        public logDecrypt()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, System.EventArgs e)
        {
            if (VerifyPin(PasswordTextBox.Text)) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Abort;
        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
