using System;
using System.IO;
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

        private void btnProcFolder_Click(object sender, EventArgs e)
        {
            if (fbdSelect.ShowDialog() != DialogResult.OK) return;

            MessageBoxManager.Yes = "Encrypt";
            MessageBoxManager.No = "Decrypt";
            MessageBoxManager.Register();

            switch (MessageBox.Show(Resources.ProcessFolderPrompt, Resources.MessageBoxCaption, MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:

                    foreach (var f in Directory.GetFiles(fbdSelect.SelectedPath, "*", SearchOption.AllDirectories)) lvwLoad.Items.Add(new ListViewItem(new[] {f, Resources.EncryptProperty}, 1));
                    break;
						
                case DialogResult.No:

                    foreach (var f in Directory.GetFiles(fbdSelect.SelectedPath, "*", SearchOption.AllDirectories)) lvwLoad.Items.Add(new ListViewItem(new[] {f, Resources.DecryptProperty}, 0));
                    break;

                case DialogResult.Cancel:
                    break;
            }
            MessageBoxManager.Unregister();
        }

        private void btnLoadEnc_Click(object sender, EventArgs e) { ofdEncFile.ShowDialog(); }

        public void btnLoadDec_Click(object sender, EventArgs e) { ofdDecFile.ShowDialog(); }

        private void ofdDecFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var f in ofdDecFile.FileNames) lvwLoad.Items.Add(new ListViewItem(new[] {f, Resources.DecryptProperty}, 0));
        }

        private void ofdEncFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var f in ofdEncFile.FileNames) lvwLoad.Items.Add(new ListViewItem(new[] { f, Resources.EncryptProperty }, 1));
        }

        private void btnProc_Click(object sender, EventArgs e)
        {
            if (lvwLoad.Items.Count < 1)
            {
                MessageBox.Show(Resources.MessageNoProcess, Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        MessageBox.Show(Resources.MessageWrongPIN, Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            lvwLoad.Items.Clear();

        }

        private void ProcDecrypt()
        {
            var crypt = new Cryptor();
            var decryptFiles = lvwLoad.Items.Cast<ListViewItem>().Where(i => i.SubItems[1].Text == Resources.DecryptProperty).Select(_ => _.Text);
            foreach (var f in decryptFiles)
            {
                var key = Encoding.ASCII.GetString(ProtectedData.Unprotect(File.ReadAllBytes(@"tfbin"), null, DataProtectionScope.CurrentUser));
                var plaintext = crypt.DecryptWithPassword(File.ReadAllBytes(f), key);
                File.WriteAllBytes(f, plaintext);
                File.Move(f, f.Substring(0, f.LastIndexOf(".", StringComparison.Ordinal)));
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvwLoad.SelectedItems.Count < 1)
                MessageBox.Show(Resources.MessageNoRemove, Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                foreach (ListViewItem lvi in lvwLoad.SelectedItems) lvwLoad.Items.Remove(lvi);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            var optf = new frmOptions();
            optf.ShowDialog(this);
        }


        private void ProcEncrypt()
        {
            var crypt = new Cryptor();
            var encryptFiles = lvwLoad.Items.Cast<ListViewItem>().Where(i => i.SubItems[1].Text == Resources.EncryptProperty).Select(_ => _.Text);
            foreach (var f in encryptFiles)
            {
                var key = Encoding.ASCII.GetString(ProtectedData.Unprotect(File.ReadAllBytes(@"tfbin"), null, DataProtectionScope.CurrentUser));
                var cipherText = crypt.EncryptWithPassword(File.ReadAllBytes(f), key);
                File.WriteAllBytes(f,cipherText);
                File.Move(f, f + ".aesx");
            }
        }

        private void btnChPass_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(Resources.PromptNewKey, Resources.MessageBoxCaption, MessageBoxButtons.OKCancel))
            {
                case DialogResult.OK:
                    string accountCode = Membership.GeneratePassword(16, 6);
                    byte[] key = Encoding.ASCII.GetBytes(accountCode);
                    File.WriteAllBytes(@"tfbin", ProtectedData.Protect(key, null, DataProtectionScope.CurrentUser));

                    var tfa = new TwoFactorAuthenticator();
                    var info = tfa.GenerateSetupCode("CAESAR", accountCode, 300, 300);
                    
                    MessageBox.Show(Resources.MessageAccountCode + info.ManualEntryKey, Resources.MessageBoxCaption, MessageBoxButtons.OK);
                    break;
      
                case DialogResult.Cancel:
                    return;
            }
        }

    }
}
