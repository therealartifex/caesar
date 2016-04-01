using System;
using Google.Authenticator;
using System.Windows.Forms;

namespace CAESAR
{
    public partial class pinForm : Form
    {
        private readonly string account;

        public pinForm(string accountCode)
        {
            InitializeComponent();
            account = accountCode;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            var tfa = new TwoFactorAuthenticator();
            var verified = tfa.ValidateTwoFactorPIN(account, PasswordTextBox.Text);

            DialogResult = verified ? DialogResult.OK : DialogResult.Abort;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
