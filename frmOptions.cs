using System.Windows.Forms;

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
            Properties.Settings.Default.Save();
        }
    }
}
