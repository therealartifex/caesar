using System.Windows.Forms;
using CAESAR.Properties;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrypto));
            this.ofdEncFile = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadDec = new System.Windows.Forms.Button();
            this.btnLoadEnc = new System.Windows.Forms.Button();
            this.btnProc = new System.Windows.Forms.Button();
            this.lvwLoad = new System.Windows.Forms.ListView();
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.icoList = new System.Windows.Forms.ImageList(this.components);
            this.fbdSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnProcFolder = new System.Windows.Forms.Button();
            this.ofdDecFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOptions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ofdEncFile
            // 
            resources.ApplyResources(this.ofdEncFile, "ofdEncFile");
            this.ofdEncFile.Multiselect = true;
            this.ofdEncFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdEncFile_FileOk);
            // 
            // btnLoadDec
            // 
            resources.ApplyResources(this.btnLoadDec, "btnLoadDec");
            this.btnLoadDec.Name = "btnLoadDec";
            this.btnLoadDec.UseVisualStyleBackColor = true;
            this.btnLoadDec.Click += new System.EventHandler(this.btnLoadDec_Click);
            // 
            // btnLoadEnc
            // 
            resources.ApplyResources(this.btnLoadEnc, "btnLoadEnc");
            this.btnLoadEnc.Name = "btnLoadEnc";
            this.btnLoadEnc.UseVisualStyleBackColor = true;
            this.btnLoadEnc.Click += new System.EventHandler(this.btnLoadEnc_Click);
            // 
            // btnProc
            // 
            resources.ApplyResources(this.btnProc, "btnProc");
            this.btnProc.Name = "btnProc";
            this.btnProc.UseVisualStyleBackColor = true;
            this.btnProc.Click += new System.EventHandler(this.btnProc_Click);
            // 
            // lvwLoad
            // 
            this.lvwLoad.AllowDrop = true;
            resources.ApplyResources(this.lvwLoad, "lvwLoad");
            this.lvwLoad.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFile,
            this.chType});
            this.lvwLoad.FullRowSelect = true;
            this.lvwLoad.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwLoad.Name = "lvwLoad";
            this.lvwLoad.SmallImageList = this.icoList;
            this.lvwLoad.UseCompatibleStateImageBehavior = false;
            this.lvwLoad.View = System.Windows.Forms.View.Details;
            // 
            // chFile
            // 
            resources.ApplyResources(this.chFile, "chFile");
            // 
            // chType
            // 
            resources.ApplyResources(this.chType, "chType");
            // 
            // icoList
            // 
            this.icoList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icoList.ImageStream")));
            this.icoList.TransparentColor = System.Drawing.Color.Transparent;
            this.icoList.Images.SetKeyName(0, "dec");
            this.icoList.Images.SetKeyName(1, "enc");
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnProcFolder
            // 
            resources.ApplyResources(this.btnProcFolder, "btnProcFolder");
            this.btnProcFolder.Name = "btnProcFolder";
            this.btnProcFolder.UseVisualStyleBackColor = true;
            this.btnProcFolder.Click += new System.EventHandler(this.btnProcFolder_Click);
            // 
            // ofdDecFile
            // 
            this.ofdDecFile.AddExtension = false;
            resources.ApplyResources(this.ofdDecFile, "ofdDecFile");
            this.ofdDecFile.Multiselect = true;
            this.ofdDecFile.SupportMultiDottedExtensions = true;
            this.ofdDecFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdDecFile_FileOk);
            // 
            // btnOptions
            // 
            resources.ApplyResources(this.btnOptions, "btnOptions");
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // frmCrypto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwLoad);
            this.Controls.Add(this.btnProc);
            this.Controls.Add(this.btnLoadEnc);
            this.Controls.Add(this.btnLoadDec);
            this.Controls.Add(this.btnProcFolder);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnRemove);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCrypto";
            this.ResumeLayout(false);

        }

        #endregion
        private OpenFileDialog ofdDecFile;
        private OpenFileDialog ofdEncFile;
        private Button btnLoadDec;
        private Button btnLoadEnc;
        private Button btnProc;
        private ListView lvwLoad;
        private ColumnHeader chFile;
        private ColumnHeader chType;
        private Button btnRemove;
        private Button btnProcFolder;
        private FolderBrowserDialog fbdSelect;
        private Button btnOptions;
        private ImageList icoList;
    }
}