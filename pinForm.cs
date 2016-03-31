using System;
using Google.Authenticator;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using CAESAR.Properties;

namespace CAESAR
{
    public partial class pinForm : Form
    {
        public pinForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            var tfa = new TwoFactorAuthenticator();
            var verified =
                tfa.ValidateTwoFactorPIN(
                Encoding.ASCII.GetString(
                ProtectedData.Unprotect(
                Convert.FromBase64String(Settings.Default.tfbin), null, DataProtectionScope.CurrentUser)), PasswordTextBox.Text);

            DialogResult = verified ? DialogResult.OK : DialogResult.Abort;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
