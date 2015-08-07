using Google.Authenticator;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CAESAR
{
    public partial class pinForm : Form
    {
        private bool VerifyPin(string pin)
        {
            var tfa = new TwoFactorAuthenticator();
            var verified =
                tfa.ValidateTwoFactorPIN(
                Encoding.ASCII.GetString(
                ProtectedData.Unprotect(
                System.IO.File.ReadAllBytes(@"tfbin"), null, DataProtectionScope.CurrentUser)), pin);

            return verified;
        }

        public pinForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, System.EventArgs e)
        {
            DialogResult = VerifyPin(PasswordTextBox.Text) ? DialogResult.OK : DialogResult.Abort;
        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
