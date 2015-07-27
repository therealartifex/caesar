using System.Windows.Forms;
using System.Linq;
using System;

namespace CAESAR
{
    public partial class frmCrypto : Form
    {
        public frmCrypto() { InitializeComponent(); }

        // TODO: Begin phasing out this section of the project
        private void btnEnc_Click(object sender, System.EventArgs e)
        {
            // dlgCipherText.Default.ShowDialog();
        }

        private void btnProcFolder_Click(object sender, System.EventArgs e)
        {
            if (fbdSelect.ShowDialog() != DialogResult.OK) return;
            switch (MessageBox.Show(@"Click 'Yes' for encryption and 'No' for decryption.", @"Encryption Choice", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:

                    // Add the ENCRYPT property to all the files within the specified folder
                    foreach (var f in System.IO.Directory.GetFiles(fbdSelect.SelectedPath)) lvwLoad.Items.Add(new ListViewItem(new[] {f, "ENCRYPT" }));
                    break;
						
                case DialogResult.No:

                    // Add the DECRYPT property to all the files within the specified folder
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
                MessageBox.Show(@"There is nothing to process.", @"CAESAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lvwLoad.Items.Cast<ListViewItem>().Select(_ => _.Text).Contains("DECRYPT"))
            {
                // TODO: Build authentication dialog
                switch (/*logDecrypt.Default.ShowDialog()*/)
				{
					case DialogResult.OK: //If the user clicked OK and the password is good, exit the switch block and run the decryption sub
						break;
					case DialogResult.Abort: //If the user clicked OK and the password is bad, exit the whole process with an error message
						MessageBox.Show(@"Incorrect password.", @"CAESAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					case DialogResult.Cancel: //If the user clicked Cancel, exit the whole process with an info message
                        MessageBox.Show(@"Incorrect password.", @"CAESAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
				}
                ProcDecrypt();
            }
            else
            {
                ProcEncrypt();
            }
        }

        // TODO: Implement decryption method
        private void ProcDecrypt()
        {
            var decryptFiles = lvwLoad.Items.Cast<ListViewItem>().Where(i => i.SubItems[1].Text == @"DECRYPT").Select(_ => _.Text);
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (lvwLoad.SelectedItems.Count < 1)
                MessageBox.Show(@"You have not selected anything to remove.", @"CAESAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                foreach (ListViewItem lvi in lvwLoad.SelectedItems) lvwLoad.Items.Remove(lvi);
        }

        // TODO: Build Options dialog
        private void btnOptions_Click(object sender, System.EventArgs e)
        {
            // dlgOptions.Default.ShowDialog();
        }

        // TODO: Finish encryption method
        private void ProcEncrypt()
        {
            var encryptFiles = lvwLoad.Items.Cast<ListViewItem>().Where(i => i.SubItems[1].Text == @"ENCRYPT").Select(_ => _.Text);

        }
    }
}
