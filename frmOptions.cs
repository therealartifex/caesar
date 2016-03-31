using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;
using CAESAR.Properties;
using Google.Authenticator;

namespace CAESAR
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void btnChangeCode_Click(object sender, EventArgs e) {
            switch (MessageBox.Show(Resources.PromptNewKey, Resources.MessageBoxCaption, MessageBoxButtons.OKCancel)) {
                case DialogResult.OK:
                    var accountCode = Membership.GeneratePassword(16, 6);
                    var key = Encoding.ASCII.GetBytes(accountCode);
                    Settings.Default.tfbin = Convert.ToBase64String(ProtectedData.Protect(key, null, DataProtectionScope.CurrentUser));

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
