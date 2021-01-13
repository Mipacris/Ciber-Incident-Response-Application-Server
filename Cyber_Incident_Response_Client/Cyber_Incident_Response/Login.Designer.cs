namespace Cyber_Incident_Response
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.username_box = new System.Windows.Forms.TextBox();
            this.password_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ip_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.port_box = new System.Windows.Forms.TextBox();
            this.ip_memorizar = new System.Windows.Forms.CheckBox();
            this.close_login = new System.Windows.Forms.PictureBox();
            this.minimize_login = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.close_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(140, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Incident Response - Cyber";
            // 
            // username_box
            // 
            this.username_box.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_box.Location = new System.Drawing.Point(82, 110);
            this.username_box.Name = "username_box";
            this.username_box.Size = new System.Drawing.Size(346, 22);
            this.username_box.TabIndex = 1;
            // 
            // password_box
            // 
            this.password_box.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_box.Location = new System.Drawing.Point(82, 182);
            this.password_box.MaxLength = 50;
            this.password_box.Name = "password_box";
            this.password_box.PasswordChar = '*';
            this.password_box.Size = new System.Drawing.Size(346, 22);
            this.password_box.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(78, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username / Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(78, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(195, 347);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(140, 38);
            this.login_button.TabIndex = 9;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(89, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "IP";
            // 
            // ip_box
            // 
            this.ip_box.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip_box.Location = new System.Drawing.Point(118, 255);
            this.ip_box.MaxLength = 50;
            this.ip_box.Name = "ip_box";
            this.ip_box.Size = new System.Drawing.Size(121, 22);
            this.ip_box.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(74, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port";
            // 
            // port_box
            // 
            this.port_box.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.port_box.Location = new System.Drawing.Point(118, 283);
            this.port_box.MaxLength = 50;
            this.port_box.Name = "port_box";
            this.port_box.Size = new System.Drawing.Size(121, 22);
            this.port_box.TabIndex = 7;
            // 
            // ip_memorizar
            // 
            this.ip_memorizar.AutoSize = true;
            this.ip_memorizar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip_memorizar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ip_memorizar.Location = new System.Drawing.Point(246, 270);
            this.ip_memorizar.Name = "ip_memorizar";
            this.ip_memorizar.Size = new System.Drawing.Size(89, 21);
            this.ip_memorizar.TabIndex = 10;
            this.ip_memorizar.Text = "Memorizar";
            this.ip_memorizar.UseVisualStyleBackColor = true;
            // 
            // close_login
            // 
            this.close_login.Image = ((System.Drawing.Image)(resources.GetObject("close_login.Image")));
            this.close_login.Location = new System.Drawing.Point(518, 2);
            this.close_login.Name = "close_login";
            this.close_login.Size = new System.Drawing.Size(23, 20);
            this.close_login.TabIndex = 11;
            this.close_login.TabStop = false;
            this.close_login.Click += new System.EventHandler(this.Close_login_Click);
            // 
            // minimize_login
            // 
            this.minimize_login.Image = ((System.Drawing.Image)(resources.GetObject("minimize_login.Image")));
            this.minimize_login.Location = new System.Drawing.Point(481, 2);
            this.minimize_login.Name = "minimize_login";
            this.minimize_login.Size = new System.Drawing.Size(22, 16);
            this.minimize_login.TabIndex = 12;
            this.minimize_login.TabStop = false;
            this.minimize_login.Click += new System.EventHandler(this.Minimize_login_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(30, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 60);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(544, 408);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.minimize_login);
            this.Controls.Add(this.close_login);
            this.Controls.Add(this.ip_memorizar);
            this.Controls.Add(this.port_box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ip_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password_box);
            this.Controls.Add(this.username_box);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.close_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username_box;
        private System.Windows.Forms.TextBox password_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ip_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox port_box;
        private System.Windows.Forms.CheckBox ip_memorizar;
        private System.Windows.Forms.PictureBox close_login;
        private System.Windows.Forms.PictureBox minimize_login;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}