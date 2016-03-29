using System.IO;
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

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void btnChangeCode_Click(object sender, System.EventArgs e) {
            switch (MessageBox.Show(Resources.PromptNewKey, Resources.MessageBoxCaption, MessageBoxButtons.OKCancel)) {
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
