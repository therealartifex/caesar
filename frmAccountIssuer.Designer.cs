namespace CAESAR
{
    partial class frmAccountIssuer
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
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.lblShowCode = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnRevealCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // picQRCode
            // 
            this.picQRCode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQRCode.InitialImage = null;
            this.picQRCode.Location = new System.Drawing.Point(12, 37);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(300, 300);
            this.picQRCode.TabIndex = 0;
            this.picQRCode.TabStop = false;
            this.picQRCode.MouseEnter += new System.EventHandler(this.picQRCode_MouseEnter);
            this.picQRCode.MouseLeave += new System.EventHandler(this.picQRCode_MouseLeave);
            // 
            // lblShowCode
            // 
            this.lblShowCode.AutoSize = true;
            this.lblShowCode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowCode.Location = new System.Drawing.Point(49, 9);
            this.lblShowCode.Name = "lblShowCode";
            this.lblShowCode.Size = new System.Drawing.Size(222, 25);
            this.lblShowCode.TabIndex = 1;
            this.lblShowCode.Text = "Hover to Reveal QR Code";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(12, 343);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(145, 23);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnRevealCode
            // 
            this.btnRevealCode.Location = new System.Drawing.Point(167, 343);
            this.btnRevealCode.Name = "btnRevealCode";
            this.btnRevealCode.Size = new System.Drawing.Size(145, 23);
            this.btnRevealCode.TabIndex = 4;
            this.btnRevealCode.Text = "Show Account Code";
            this.btnRevealCode.UseVisualStyleBackColor = true;
            this.btnRevealCode.Click += new System.EventHandler(this.btnRevealCode_Click);
            // 
            // frmAccountIssuer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 378);
            this.Controls.Add(this.btnRevealCode);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblShowCode);
            this.Controls.Add(this.picQRCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAccountIssuer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Account Code";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountIssuer_FormClosing);
            this.Load += new System.EventHandler(this.frmAccountIssuer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picQRCode;
        private System.Windows.Forms.Label lblShowCode;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnRevealCode;
    }
}