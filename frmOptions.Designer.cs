using System.Windows.Forms;

namespace CAESAR
{
    partial class frmOptions
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
            this.btnClose = new System.Windows.Forms.Button();
            this.chkLogs = new System.Windows.Forms.CheckBox();
            this.chkObfuscate = new System.Windows.Forms.CheckBox();
            this.btnChangeCode = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(159, 109);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkLogs
            // 
            this.chkLogs.AutoSize = true;
            this.chkLogs.Checked = global::CAESAR.Properties.Settings.Default.keepLog;
            this.chkLogs.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CAESAR.Properties.Settings.Default, "keepLog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkLogs.Location = new System.Drawing.Point(12, 35);
            this.chkLogs.Name = "chkLogs";
            this.chkLogs.Size = new System.Drawing.Size(77, 17);
            this.chkLogs.TabIndex = 3;
            this.chkLogs.Text = "Keep a log";
            this.chkLogs.UseVisualStyleBackColor = true;
            // 
            // chkObfuscate
            // 
            this.chkObfuscate.AutoSize = true;
            this.chkObfuscate.Checked = global::CAESAR.Properties.Settings.Default.obfuscation;
            this.chkObfuscate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CAESAR.Properties.Settings.Default, "obfuscation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkObfuscate.Location = new System.Drawing.Point(12, 12);
            this.chkObfuscate.Name = "chkObfuscate";
            this.chkObfuscate.Size = new System.Drawing.Size(170, 17);
            this.chkObfuscate.TabIndex = 2;
            this.chkObfuscate.Text = "Obfuscate filename on encrypt";
            this.chkObfuscate.UseVisualStyleBackColor = true;
            // 
            // btnChangeCode
            // 
            this.btnChangeCode.Location = new System.Drawing.Point(12, 58);
            this.btnChangeCode.Name = "btnChangeCode";
            this.btnChangeCode.Size = new System.Drawing.Size(86, 34);
            this.btnChangeCode.TabIndex = 4;
            this.btnChangeCode.Text = "Change Account Code";
            this.btnChangeCode.UseVisualStyleBackColor = true;
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackup.Location = new System.Drawing.Point(148, 58);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(86, 34);
            this.btnBackup.TabIndex = 5;
            this.btnBackup.Text = "Back Up Data";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Visible = false;
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 144);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnChangeCode);
            this.Controls.Add(this.chkLogs);
            this.Controls.Add(this.chkObfuscate);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptions_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private Button btnClose;
        private CheckBox chkObfuscate;
        private CheckBox chkLogs;
        private Button btnChangeCode;
        private Button btnBackup;
    }
}