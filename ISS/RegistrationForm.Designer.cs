
namespace ISS
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.reg_button_enter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBackAuth = new System.Windows.Forms.PictureBox();
            this.reg_up = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackAuth)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLog.Location = new System.Drawing.Point(114, 143);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(428, 40);
            this.textBoxLog.TabIndex = 9;
            this.textBoxLog.Enter += new System.EventHandler(this.textBoxLog_Enter);
            this.textBoxLog.Leave += new System.EventHandler(this.textBoxLog_Leave);
            // 
            // textBoxPass
            // 
            this.textBoxPass.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPass.Location = new System.Drawing.Point(114, 203);
            this.textBoxPass.Multiline = true;
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(428, 40);
            this.textBoxPass.TabIndex = 10;
            this.textBoxPass.Enter += new System.EventHandler(this.textBoxPass_Enter);
            this.textBoxPass.Leave += new System.EventHandler(this.textBoxPass_Leave);
            // 
            // reg_button_enter
            // 
            this.reg_button_enter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reg_button_enter.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reg_button_enter.Location = new System.Drawing.Point(142, 443);
            this.reg_button_enter.Name = "reg_button_enter";
            this.reg_button_enter.Size = new System.Drawing.Size(372, 53);
            this.reg_button_enter.TabIndex = 8;
            this.reg_button_enter.Text = "Зарегистрироваться";
            this.reg_button_enter.UseVisualStyleBackColor = true;
            this.reg_button_enter.Click += new System.EventHandler(this.reg_button_enter_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(137)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.pictureBackAuth);
            this.panel1.Controls.Add(this.reg_up);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 137);
            this.panel1.TabIndex = 7;
            // 
            // pictureBackAuth
            // 
            this.pictureBackAuth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBackAuth.Image = ((System.Drawing.Image)(resources.GetObject("pictureBackAuth.Image")));
            this.pictureBackAuth.Location = new System.Drawing.Point(12, 12);
            this.pictureBackAuth.Name = "pictureBackAuth";
            this.pictureBackAuth.Size = new System.Drawing.Size(64, 64);
            this.pictureBackAuth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBackAuth.TabIndex = 2;
            this.pictureBackAuth.TabStop = false;
            this.pictureBackAuth.Click += new System.EventHandler(this.pictureBackAuth_Click);
            // 
            // reg_up
            // 
            this.reg_up.AutoSize = true;
            this.reg_up.Font = new System.Drawing.Font("Segoe Script", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.reg_up.ForeColor = System.Drawing.Color.Black;
            this.reg_up.Location = new System.Drawing.Point(189, 30);
            this.reg_up.Name = "reg_up";
            this.reg_up.Size = new System.Drawing.Size(303, 61);
            this.reg_up.TabIndex = 1;
            this.reg_up.Text = "Регистрация";
            this.reg_up.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxName.Location = new System.Drawing.Point(114, 263);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(428, 40);
            this.textBoxName.TabIndex = 11;
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxName.Leave += new System.EventHandler(this.textBoxName_Leave);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEmail.Location = new System.Drawing.Point(114, 383);
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(428, 40);
            this.textBoxEmail.TabIndex = 13;
            this.textBoxEmail.Enter += new System.EventHandler(this.textBoxEmail_Enter);
            this.textBoxEmail.Leave += new System.EventHandler(this.textBoxEmail_Leave);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPhone.Location = new System.Drawing.Point(114, 323);
            this.textBoxPhone.Multiline = true;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(428, 40);
            this.textBoxPhone.TabIndex = 12;
            this.textBoxPhone.Enter += new System.EventHandler(this.textBoxPhone_Enter);
            this.textBoxPhone.Leave += new System.EventHandler(this.textBoxPhone_Leave);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(150)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(684, 547);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.reg_button_enter);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistrationForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackAuth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Button reg_button_enter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label reg_up;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.PictureBox pictureBackAuth;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPhone;
    }
}