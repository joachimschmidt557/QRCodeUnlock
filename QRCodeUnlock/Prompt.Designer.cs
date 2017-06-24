namespace QRCodeUnlock
{
    partial class Prompt
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
            this.textBoxBackupPassword = new System.Windows.Forms.TextBox();
            this.labelBackupPassword = new System.Windows.Forms.Label();
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.labelQRCode = new System.Windows.Forms.Label();
            this.labelSecsToLogIn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxBackupPassword
            // 
            this.textBoxBackupPassword.Location = new System.Drawing.Point(12, 96);
            this.textBoxBackupPassword.Name = "textBoxBackupPassword";
            this.textBoxBackupPassword.PasswordChar = '*';
            this.textBoxBackupPassword.Size = new System.Drawing.Size(338, 20);
            this.textBoxBackupPassword.TabIndex = 0;
            // 
            // labelBackupPassword
            // 
            this.labelBackupPassword.AutoSize = true;
            this.labelBackupPassword.ForeColor = System.Drawing.Color.White;
            this.labelBackupPassword.Location = new System.Drawing.Point(9, 80);
            this.labelBackupPassword.Name = "labelBackupPassword";
            this.labelBackupPassword.Size = new System.Drawing.Size(138, 13);
            this.labelBackupPassword.TabIndex = 1;
            this.labelBackupPassword.Text = "Or enter backup password: ";
            // 
            // timerCountdown
            // 
            this.timerCountdown.Enabled = true;
            this.timerCountdown.Interval = 1000;
            this.timerCountdown.Tick += new System.EventHandler(this.timerCountdown_Tick);
            // 
            // labelQRCode
            // 
            this.labelQRCode.AutoSize = true;
            this.labelQRCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelQRCode.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQRCode.ForeColor = System.Drawing.Color.White;
            this.labelQRCode.Location = new System.Drawing.Point(9, 9);
            this.labelQRCode.Name = "labelQRCode";
            this.labelQRCode.Size = new System.Drawing.Size(288, 40);
            this.labelQRCode.TabIndex = 3;
            this.labelQRCode.Text = "Unlock with QR Code";
            // 
            // labelSecsToLogIn
            // 
            this.labelSecsToLogIn.AutoSize = true;
            this.labelSecsToLogIn.ForeColor = System.Drawing.Color.White;
            this.labelSecsToLogIn.Location = new System.Drawing.Point(12, 119);
            this.labelSecsToLogIn.Name = "labelSecsToLogIn";
            this.labelSecsToLogIn.Size = new System.Drawing.Size(87, 13);
            this.labelSecsToLogIn.TabIndex = 4;
            this.labelSecsToLogIn.Text = "1 minute to log in";
            // 
            // Prompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(362, 141);
            this.Controls.Add(this.labelSecsToLogIn);
            this.Controls.Add(this.labelQRCode);
            this.Controls.Add(this.labelBackupPassword);
            this.Controls.Add(this.textBoxBackupPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log in";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.Prompt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBackupPassword;
        private System.Windows.Forms.Label labelBackupPassword;
        private System.Windows.Forms.Timer timerCountdown;
        private System.Windows.Forms.Label labelQRCode;
        private System.Windows.Forms.Label labelSecsToLogIn;
    }
}