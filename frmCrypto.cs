using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;
using Google.Authenticator;
using Microsoft.VisualBasic;

namespace CAESAR
{
    public partial class frmCrypto : Form
    {
        public frmCrypto() { InitializeComponent(); }

        // TODO: Begin phasing out this section of the project
        private void btnEnc_Click(object sender, System.EventArgs e)
        {
            // dlgCipherText.Default.ShowDialog();
            var input = Interaction.InputBox("Enter 6-digit PIN", "CAESAR", "PIN");
            MessageBox.Show(VerifyPin(input).ToString());
        }

        private void btnProcFolder_Click(object sender, System.EventArgs e)
        {
            // TODO: Custom MessageBox with "Encrypt" and "Decrypt" buttons
            if (fbdSelect.ShowDialog() != DialogResult.OK) return;
            switch (MessageBox.Show("Click 'Yes' for encryption and 'No' for decryption.", "Encryption Choice", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:

                    foreach (var f in System.IO.Directory.GetFiles(fbdSelect.SelectedPath)) lvwLoad.Items.Add(new ListViewItem(new[] {f, "ENCRYPT" }));
                    break;
						
                case DialogResult.No:

                    foreach (var f in System.IO.Directory.GetFiles(fbdSelect.SelectedPath)) lvwLoad.Items.Add(new ListViewItem(new[] {f, "DECRYPT"}));
                    break;

                case DialogResult.Cancel:
                    return;
            }
        }

        private void btnLoadEnc_Click(object sender, System.EventArgs e) { ofdEncWholeFile.ShowDialog(); }

        public void btnLoadDec_Click(object sender, System.EventArgs e) { ofdDecFile.ShowDialog(); }

        private void ofdDecFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var f in ofdDecFile.FileNames) lvwLoad.Items.Add(new ListViewItem(new[] {f, "DECRYPT"}));
        }

        private void btnProc_Click(object sender, System.EventArgs e)
        {
            if (lvwLoad.Items.Count < 1)
            {
                MessageBox.Show("There is nothing to process.", "CAESAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lvwLoad.Items.Cast<ListViewItem>().Select(_ => _.SubItems[1].Text).Contains("DECRYPT"))
            {
                var ld = new logDecrypt();
                switch (ld.ShowDialog(this))
                {
                    case DialogResult.OK:
                        break;
                    case DialogResult.Abort:
                        MessageBox.Show("Incorrect password.", "CAESAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case DialogResult.Cancel:
                        return;
                }
                ProcDecrypt();
            }

            if (lvwLoad.Items.Cast<ListViewItem>().Select(_ => _.SubItems[1].Text).Contains("ENCRYPT"))
            {
                ProcEncrypt();
            }
        }

        // TODO: Implement decryption method
        private void ProcDecrypt()
        {
            var decryptFiles = lvwLoad.Items.Cast<ListViewItem>().Where(i => i.SubItems[1].Text == "DECRYPT").Select(_ => _.Text);
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (lvwLoad.SelectedItems.Count < 1)
                MessageBox.Show("You have not selected anything to remove.", "CAESAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                foreach (ListViewItem lvi in lvwLoad.SelectedItems) lvwLoad.Items.Remove(lvi);
        }

        // TODO: Build Options dialog
        private void btnOptions_Click(object sender, System.EventArgs e)
        {
            // dlgOptions.Default.ShowDialog();
            var tfa = new TwoFactorAuthenticator();
            var info = tfa.GenerateSetupCode("CAESAR", "sceleris@protonmail.ch",
                Encoding.ASCII.GetString(
                ProtectedData.Unprotect(
                System.IO.File.ReadAllBytes(@"tfbin"), null, DataProtectionScope.CurrentUser)), 300, 300);
            MessageBox.Show("Here is your account code:\n" + info.ManualEntryKey, @"CAESAR", MessageBoxButtons.OK);

        }

        // TODO: Finish encryption method
        private void ProcEncrypt()
        {
            var encryptFiles = lvwLoad.Items.Cast<ListViewItem>().Where(i => i.SubItems[1].Text == "ENCRYPT").Select(_ => _.Text);

            

        }

        private void btnChPass_Click(object sender, System.EventArgs e)
        {
            switch (MessageBox.Show("Are you sure you want a new key? This will render all currently encrypted files indecipherable.", "CAESAR", MessageBoxButtons.OKCancel))
            {
                case DialogResult.OK:
                    string accountCode = Membership.GeneratePassword(16, 6);
                    byte[] key = Encoding.ASCII.GetBytes(accountCode);
                    System.IO.File.WriteAllBytes(@"tfbin", ProtectedData.Protect(key, null, DataProtectionScope.CurrentUser));

                    var tfa = new TwoFactorAuthenticator();
                    var info = tfa.GenerateSetupCode("CAESAR", "sceleris@protonmail.ch", accountCode, 300, 300);
                    
                    MessageBox.Show("Here is your new account code:\n\n" + info.ManualEntryKey, "CAESAR", MessageBoxButtons.OK);
                    break;
      
                case DialogResult.Cancel:
                    return;
            }
        }

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

        private void ofdEncWholeFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
