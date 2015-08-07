using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;
using CAESAR.Properties;
using Google.Authenticator;

namespace CAESAR
{
    public partial class frmCrypto : Form
    {
        public frmCrypto() { InitializeComponent(); } 

        private void btnProcFolder_Click(object sender, System.EventArgs e)
        {
            if (fbdSelect.ShowDialog() != DialogResult.OK) return;

            MessageBoxManager.Yes = "Encrypt";
            MessageBoxManager.No = "Decrypt";
            MessageBoxManager.Register();

            switch (MessageBox.Show("How would you like to process the files in this folder?", Resources.MessageBoxCaption, MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:

                    foreach (var f in System.IO.Directory.GetFiles(fbdSelect.SelectedPath)) lvwLoad.Items.Add(new ListViewItem(new[] {f, Resources.EncryptProperty }));
                    break;
						
                case DialogResult.No:

                    foreach (var f in System.IO.Directory.GetFiles(fbdSelect.SelectedPath)) lvwLoad.Items.Add(new ListViewItem(new[] {f, Resources.DecryptProperty}));
                    break;

                case DialogResult.Cancel:
                    break;
            }
            MessageBoxManager.Unregister();
        }

        private void btnLoadEnc_Click(object sender, System.EventArgs e) { ofdEncWholeFile.ShowDialog(); }

        public void btnLoadDec_Click(object sender, System.EventArgs e) { ofdDecFile.ShowDialog(); }

        private void ofdDecFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var f in ofdDecFile.FileNames) lvwLoad.Items.Add(new ListViewItem(new[] {f, Resources.DecryptProperty}));
        }

        private void btnProc_Click(object sender, System.EventArgs e)
        {
            if (lvwLoad.Items.Count < 1)
            {
                MessageBox.Show("There is nothing to process.", Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lvwLoad.Items.Cast<ListViewItem>().Select(_ => _.SubItems[1].Text).Contains(Resources.DecryptProperty))
            {
                var pf = new pinForm();
                switch (pf.ShowDialog(this))
                {
                    case DialogResult.OK:
                        break;
                    case DialogResult.Abort:
                        MessageBox.Show("Incorrect PIN.", Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case DialogResult.Cancel:
                        return;
                }
                ProcDecrypt();
            }

            if (lvwLoad.Items.Cast<ListViewItem>().Select(_ => _.SubItems[1].Text).Contains(Resources.EncryptProperty))
            {
                ProcEncrypt();
            }
        }

        // TODO: Implement decryption method
        private void ProcDecrypt()
        {
            var decryptFiles = lvwLoad.Items.Cast<ListViewItem>().Where(i => i.SubItems[1].Text == Resources.DecryptProperty).Select(_ => _.Text);
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (lvwLoad.SelectedItems.Count < 1)
                MessageBox.Show("You have not selected anything to remove.", Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            MessageBox.Show("Here is your account code:\n" + info.ManualEntryKey, Resources.MessageBoxCaption, MessageBoxButtons.OK);
        }


        // TODO: Finish encryption method
        private void ProcEncrypt()
        {
            var encryptFiles = lvwLoad.Items.Cast<ListViewItem>().Where(i => i.SubItems[1].Text == Resources.EncryptProperty).Select(_ => _.Text);
        }

        private void btnChPass_Click(object sender, System.EventArgs e)
        {
            switch (MessageBox.Show("Are you sure you want a new key? This will render all currently encrypted files indecipherable.", Resources.MessageBoxCaption, MessageBoxButtons.OKCancel))
            {
                case DialogResult.OK:
                    string accountCode = Membership.GeneratePassword(16, 6);
                    byte[] key = Encoding.ASCII.GetBytes(accountCode);
                    System.IO.File.WriteAllBytes(@"tfbin", ProtectedData.Protect(key, null, DataProtectionScope.CurrentUser));

                    var tfa = new TwoFactorAuthenticator();
                    var info = tfa.GenerateSetupCode("CAESAR", "sceleris@protonmail.ch", accountCode, 300, 300);
                    
                    MessageBox.Show("Here is your new account code:\n\n" + info.ManualEntryKey, Resources.MessageBoxCaption, MessageBoxButtons.OK);
                    break;
      
                case DialogResult.Cancel:
                    return;
            }
        }

        private void ofdEncWholeFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void frmCrypto_Load(object sender, System.EventArgs e)
        {
            
        }
    }
}
