
namespace ISS
{
    partial class Authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.panel1 = new System.Windows.Forms.Panel();
            this.auth_up = new System.Windows.Forms.Label();
            this.auth_button_enter = new System.Windows.Forms.Button();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureUser = new System.Windows.Forms.PictureBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.picturePassOn = new System.Windows.Forms.PictureBox();
            this.picturePassOff = new System.Windows.Forms.PictureBox();
            this.buttonReg = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassOff)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(137)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.auth_up);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 137);
            this.panel1.TabIndex = 0;
            // 
            // auth_up
            // 
            this.auth_up.AutoSize = true;
            this.auth_up.Font = new System.Drawing.Font("Segoe Script", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.auth_up.ForeColor = System.Drawing.Color.Black;
            this.auth_up.Location = new System.Drawing.Point(0, 9);
            this.auth_up.Name = "auth_up";
            this.auth_up.Size = new System.Drawing.Size(503, 122);
            this.auth_up.TabIndex = 0;
            this.auth_up.Text = "Авторизация\r\nВход или регистрация\r\n";
            this.auth_up.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // auth_button_enter
            // 
            this.auth_button_enter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.auth_button_enter.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.auth_button_enter.Location = new System.Drawing.Point(153, 390);
            this.auth_button_enter.Name = "auth_button_enter";
            this.auth_button_enter.Size = new System.Drawing.Size(160, 53);
            this.auth_button_enter.TabIndex = 1;
            this.auth_button_enter.Text = "Вход";
            this.auth_button_enter.UseVisualStyleBackColor = true;
            this.auth_button_enter.Click += new System.EventHandler(this.auth_button_enter_Click);
            // 
            // textBoxUser
            // 
            this.textBoxUser.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxUser.Location = new System.Drawing.Point(119, 193);
            this.textBoxUser.Multiline = true;
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(246, 40);
            this.textBoxUser.TabIndex = 2;
            this.textBoxUser.Enter += new System.EventHandler(this.textBoxUser_Enter);
            this.textBoxUser.Leave += new System.EventHandler(this.textBoxUser_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(50, 305);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 56);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureUser
            // 
            this.pictureUser.Image = ((System.Drawing.Image)(resources.GetObject("pictureUser.Image")));
            this.pictureUser.Location = new System.Drawing.Point(396, 184);
            this.pictureUser.Name = "pictureUser";
            this.pictureUser.Size = new System.Drawing.Size(64, 64);
            this.pictureUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureUser.TabIndex = 0;
            this.pictureUser.TabStop = false;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPass.Location = new System.Drawing.Point(119, 282);
            this.textBoxPass.Multiline = true;
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(246, 40);
            this.textBoxPass.TabIndex = 4;
            this.textBoxPass.Enter += new System.EventHandler(this.textBoxPass_Enter);
            this.textBoxPass.Leave += new System.EventHandler(this.textBoxPass_Leave);
            // 
            // picturePassOn
            // 
            this.picturePassOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picturePassOn.Image = ((System.Drawing.Image)(resources.GetObject("picturePassOn.Image")));
            this.picturePassOn.Location = new System.Drawing.Point(396, 270);
            this.picturePassOn.Name = "picturePassOn";
            this.picturePassOn.Size = new System.Drawing.Size(64, 64);
            this.picturePassOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePassOn.TabIndex = 5;
            this.picturePassOn.TabStop = false;
            this.picturePassOn.Click += new System.EventHandler(this.picturePassOn_Click);
            // 
            // picturePassOff
            // 
            this.picturePassOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picturePassOff.Image = ((System.Drawing.Image)(resources.GetObject("picturePassOff.Image")));
            this.picturePassOff.Location = new System.Drawing.Point(396, 270);
            this.picturePassOff.Name = "picturePassOff";
            this.picturePassOff.Size = new System.Drawing.Size(64, 64);
            this.picturePassOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePassOff.TabIndex = 6;
            this.picturePassOff.TabStop = false;
            this.picturePassOff.Visible = false;
            this.picturePassOff.Click += new System.EventHandler(this.picturePassOff_Click);
            // 
            // buttonReg
            // 
            this.buttonReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReg.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReg.Location = new System.Drawing.Point(49, 470);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(379, 53);
            this.buttonReg.TabIndex = 7;
            this.buttonReg.Text = "Зарегистрироваться";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(150)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(503, 544);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.pictureUser);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.auth_button_enter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picturePassOn);
            this.Controls.Add(this.picturePassOff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authorization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Authorization_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassOff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label auth_up;
        private System.Windows.Forms.Button auth_button_enter;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureUser;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.PictureBox picturePassOn;
        private System.Windows.Forms.PictureBox picturePassOff;
        private System.Windows.Forms.Button buttonReg;
    }
}