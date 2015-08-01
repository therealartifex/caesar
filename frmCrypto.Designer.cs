using System.Windows.Forms;

namespace CAESAR
{
    partial class frmCrypto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnc = new System.Windows.Forms.Button();
            this.btnChPass = new System.Windows.Forms.Button();
            this.ofdEncWholeFile = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadDec = new System.Windows.Forms.Button();
            this.btnLoadEnc = new System.Windows.Forms.Button();
            this.btnProc = new System.Windows.Forms.Button();
            this.lvwLoad = new System.Windows.Forms.ListView();
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fbdSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnProcFolder = new System.Windows.Forms.Button();
            this.ofdDecFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnEnc
            // 
            this.btnEnc.Location = new System.Drawing.Point(148, 179);
            this.btnEnc.Name = "btnEnc";
            this.btnEnc.Size = new System.Drawing.Size(125, 23);
            this.btnEnc.TabIndex = 0;
            this.btnEnc.Text = "Edit Encrypted File";
            this.btnEnc.UseVisualStyleBackColor = true;
            this.btnEnc.Click += new System.EventHandler(this.btnEnc_Click);
            // 
            // btnChPass
            // 
            this.btnChPass.Location = new System.Drawing.Point(412, 211);
            this.btnChPass.Name = "btnChPass";
            this.btnChPass.Size = new System.Drawing.Size(101, 23);
            this.btnChPass.TabIndex = 2;
            this.btnChPass.Text = "Change Password";
            this.btnChPass.UseVisualStyleBackColor = true;
            this.btnChPass.Click += new System.EventHandler(this.btnChPass_Click);
            // 
            // ofdEncWholeFile
            // 
            this.ofdEncWholeFile.DefaultExt = "txt";
            this.ofdEncWholeFile.Filter = "Text Files|*.txt|All files|*.*";
            this.ofdEncWholeFile.Multiselect = true;
            this.ofdEncWholeFile.Title = "Encryption: File";
            this.ofdEncWholeFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdEncWholeFile_FileOk);
            // 
            // btnLoadDec
            // 
            this.btnLoadDec.Location = new System.Drawing.Point(279, 179);
            this.btnLoadDec.Name = "btnLoadDec";
            this.btnLoadDec.Size = new System.Drawing.Size(127, 23);
            this.btnLoadDec.TabIndex = 5;
            this.btnLoadDec.Text = "Load for Decryption...";
            this.btnLoadDec.UseVisualStyleBackColor = true;
            this.btnLoadDec.Click += new System.EventHandler(this.btnLoadDec_Click);
            // 
            // btnLoadEnc
            // 
            this.btnLoadEnc.Location = new System.Drawing.Point(279, 211);
            this.btnLoadEnc.Name = "btnLoadEnc";
            this.btnLoadEnc.Size = new System.Drawing.Size(127, 23);
            this.btnLoadEnc.TabIndex = 6;
            this.btnLoadEnc.Text = "Load for Encryption...";
            this.btnLoadEnc.UseVisualStyleBackColor = true;
            this.btnLoadEnc.Click += new System.EventHandler(this.btnLoadEnc_Click);
            // 
            // btnProc
            // 
            this.btnProc.Location = new System.Drawing.Point(12, 179);
            this.btnProc.Name = "btnProc";
            this.btnProc.Size = new System.Drawing.Size(72, 55);
            this.btnProc.TabIndex = 7;
            this.btnProc.Text = "Process";
            this.btnProc.UseVisualStyleBackColor = true;
            this.btnProc.Click += new System.EventHandler(this.btnProc_Click);
            // 
            // lvwLoad
            // 
            this.lvwLoad.AllowDrop = true;
            this.lvwLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwLoad.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFile,
            this.chType});
            this.lvwLoad.FullRowSelect = true;
            this.lvwLoad.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwLoad.LabelWrap = false;
            this.lvwLoad.Location = new System.Drawing.Point(12, 12);
            this.lvwLoad.Name = "lvwLoad";
            this.lvwLoad.Size = new System.Drawing.Size(501, 161);
            this.lvwLoad.TabIndex = 8;
            this.lvwLoad.UseCompatibleStateImageBehavior = false;
            this.lvwLoad.View = System.Windows.Forms.View.Details;
            // 
            // chFile
            // 
            this.chFile.Text = "File Name";
            this.chFile.Width = 411;
            // 
            // chType
            // 
            this.chType.Text = "Process Type";
            this.chType.Width = 85;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(412, 179);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(101, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove From List";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(90, 179);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(52, 55);
            this.btnOptions.TabIndex = 10;
            this.btnOptions.Text = "Log Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnProcFolder
            // 
            this.btnProcFolder.Location = new System.Drawing.Point(148, 211);
            this.btnProcFolder.Name = "btnProcFolder";
            this.btnProcFolder.Size = new System.Drawing.Size(125, 23);
            this.btnProcFolder.TabIndex = 11;
            this.btnProcFolder.Text = "Load Folder";
            this.btnProcFolder.UseVisualStyleBackColor = true;
            this.btnProcFolder.Click += new System.EventHandler(this.btnProcFolder_Click);
            // 
            // ofdDecFile
            // 
            this.ofdDecFile.AddExtension = false;
            this.ofdDecFile.Filter = "Encrypted Files|*.aesx|Text Files|*.txt|All Files|*.*";
            this.ofdDecFile.Multiselect = true;
            this.ofdDecFile.SupportMultiDottedExtensions = true;
            this.ofdDecFile.Title = "Decryption: Text/File";
            this.ofdDecFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdDecFile_FileOk);
            // 
            // frmCrypto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 246);
            this.Controls.Add(this.btnEnc);
            this.Controls.Add(this.lvwLoad);
            this.Controls.Add(this.btnProc);
            this.Controls.Add(this.btnLoadEnc);
            this.Controls.Add(this.btnLoadDec);
            this.Controls.Add(this.btnChPass);
            this.Controls.Add(this.btnProcFolder);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnRemove);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCrypto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAESAR";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnEnc;
        private Button btnChPass;
        private OpenFileDialog ofdDecFile;
        private OpenFileDialog ofdEncWholeFile;
        private Button btnLoadDec;
        private Button btnLoadEnc;
        private Button btnProc;
        private ListView lvwLoad;
        private ColumnHeader chFile;
        private ColumnHeader chType;
        private Button btnRemove;
        private Button btnOptions;
        private Button btnProcFolder;
        private FolderBrowserDialog fbdSelect;

    }
}