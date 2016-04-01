using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;
using CAESAR.Properties;
using Google.Authenticator;

namespace CAESAR
{
    public partial class frmAccountIssuer : Form
    {
        private SetupCode info;
        private string accountCode;

        public frmAccountIssuer()
        {
            InitializeComponent();
        }

        private void frmAccountIssuer_Load(object sender, EventArgs e)
        {
            accountCode = Membership.GeneratePassword(16, 6);
            
            var tfa = new TwoFactorAuthenticator();
            info = tfa.GenerateSetupCode("CAESAR", accountCode, 300, 300);
            
        }

        private void picQRCode_MouseEnter(object sender, EventArgs e)
        {
            picQRCode.ImageLocation = info.QrCodeSetupImageUrl;
        }

        private void picQRCode_MouseLeave(object sender, EventArgs e)
        {
            picQRCode.Image = null;
        }

        private void lnlManualEntry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Resources.MessageAccountCode + info.ManualEntryKey, Resources.MessageBoxCaption, MessageBoxButtons.OK);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            var pf = new pinForm(accountCode);
            switch (pf.ShowDialog(this))
            {
                case DialogResult.OK:
                    var key = Encoding.ASCII.GetBytes(accountCode);
                    Settings.Default.tfbin = Convert.ToBase64String(ProtectedData.Protect(key, null, DataProtectionScope.CurrentUser));
                    break;
                case DialogResult.Abort:
                    MessageBox.Show(Resources.MessageWrongPIN, Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                case DialogResult.Cancel:
                    return;
            }
            Close();
        }

        private void frmAccountIssuer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
