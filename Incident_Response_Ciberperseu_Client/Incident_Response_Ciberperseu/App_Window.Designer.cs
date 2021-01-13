namespace Incident_Response_Ciberperseu
{
    partial class App_Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App_Window));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chatCounter = new System.Windows.Forms.Label();
            this.chat_button = new System.Windows.Forms.Button();
            this.nickname = new System.Windows.Forms.Label();
            this.configuraçoes_admin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.About_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.missoes_geral_button = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.outlook_button = new System.Windows.Forms.Button();
            this.Missoes_button = new System.Windows.Forms.Button();
            this.Window_Panel = new System.Windows.Forms.Panel();
            this.minimize_close_panel = new System.Windows.Forms.Panel();
            this.minimize_button = new System.Windows.Forms.PictureBox();
            this.close_button = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.minimize_close_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_button)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.chatCounter);
            this.panel1.Controls.Add(this.chat_button);
            this.panel1.Controls.Add(this.nickname);
            this.panel1.Controls.Add(this.configuraçoes_admin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.About_button);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.missoes_geral_button);
            this.panel1.Controls.Add(this.SidePanel);
            this.panel1.Controls.Add(this.outlook_button);
            this.panel1.Controls.Add(this.Missoes_button);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 568);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_Panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_Panel_MouseMove);
            // 
            // chatCounter
            // 
            this.chatCounter.AutoSize = true;
            this.chatCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatCounter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatCounter.ForeColor = System.Drawing.Color.Red;
            this.chatCounter.Location = new System.Drawing.Point(139, 296);
            this.chatCounter.Name = "chatCounter";
            this.chatCounter.Size = new System.Drawing.Size(18, 19);
            this.chatCounter.TabIndex = 12;
            this.chatCounter.Text = "0";
            this.chatCounter.Visible = false;
            // 
            // chat_button
            // 
            this.chat_button.FlatAppearance.BorderSize = 0;
            this.chat_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chat_button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chat_button.ForeColor = System.Drawing.SystemColors.Control;
            this.chat_button.Location = new System.Drawing.Point(1, 281);
            this.chat_button.Name = "chat_button";
            this.chat_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chat_button.Size = new System.Drawing.Size(173, 48);
            this.chat_button.TabIndex = 11;
            this.chat_button.TabStop = false;
            this.chat_button.Text = "Chat";
            this.chat_button.UseVisualStyleBackColor = true;
            this.chat_button.Click += new System.EventHandler(this.Chat_button_Click);
            // 
            // nickname
            // 
            this.nickname.AutoSize = true;
            this.nickname.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nickname.ForeColor = System.Drawing.Color.Yellow;
            this.nickname.Location = new System.Drawing.Point(47, 105);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(72, 17);
            this.nickname.TabIndex = 10;
            this.nickname.Text = "nickname";
            // 
            // configuraçoes_admin
            // 
            this.configuraçoes_admin.FlatAppearance.BorderSize = 0;
            this.configuraçoes_admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configuraçoes_admin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configuraçoes_admin.ForeColor = System.Drawing.SystemColors.Control;
            this.configuraçoes_admin.Location = new System.Drawing.Point(0, 389);
            this.configuraçoes_admin.Name = "configuraçoes_admin";
            this.configuraçoes_admin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.configuraçoes_admin.Size = new System.Drawing.Size(177, 48);
            this.configuraçoes_admin.TabIndex = 9;
            this.configuraçoes_admin.Text = "Admin Config";
            this.configuraçoes_admin.UseVisualStyleBackColor = true;
            this.configuraçoes_admin.Click += new System.EventHandler(this.Configuraçoes_admin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(46, 538);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Versão 1.0";
            // 
            // About_button
            // 
            this.About_button.FlatAppearance.BorderSize = 0;
            this.About_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.About_button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About_button.ForeColor = System.Drawing.SystemColors.Control;
            this.About_button.Location = new System.Drawing.Point(0, 443);
            this.About_button.Name = "About_button";
            this.About_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.About_button.Size = new System.Drawing.Size(176, 48);
            this.About_button.TabIndex = 7;
            this.About_button.Text = "Sobre";
            this.About_button.UseVisualStyleBackColor = true;
            this.About_button.Click += new System.EventHandler(this.About_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "User:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "Incident Response \r\nCiberperseu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // missoes_geral_button
            // 
            this.missoes_geral_button.FlatAppearance.BorderSize = 0;
            this.missoes_geral_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.missoes_geral_button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missoes_geral_button.ForeColor = System.Drawing.SystemColors.Control;
            this.missoes_geral_button.Location = new System.Drawing.Point(3, 230);
            this.missoes_geral_button.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.missoes_geral_button.Name = "missoes_geral_button";
            this.missoes_geral_button.Size = new System.Drawing.Size(174, 48);
            this.missoes_geral_button.TabIndex = 4;
            this.missoes_geral_button.Text = "Geral";
            this.missoes_geral_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.missoes_geral_button.UseVisualStyleBackColor = true;
            this.missoes_geral_button.Click += new System.EventHandler(this.Missoes_geral_Click);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.LimeGreen;
            this.SidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SidePanel.Location = new System.Drawing.Point(3, 176);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(14, 48);
            this.SidePanel.TabIndex = 1;
            // 
            // outlook_button
            // 
            this.outlook_button.FlatAppearance.BorderSize = 0;
            this.outlook_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.outlook_button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outlook_button.ForeColor = System.Drawing.SystemColors.Control;
            this.outlook_button.Location = new System.Drawing.Point(0, 335);
            this.outlook_button.Name = "outlook_button";
            this.outlook_button.Size = new System.Drawing.Size(174, 48);
            this.outlook_button.TabIndex = 3;
            this.outlook_button.Text = "Outlook";
            this.outlook_button.UseVisualStyleBackColor = true;
            this.outlook_button.Click += new System.EventHandler(this.Outlook_button_Click);
            // 
            // Missoes_button
            // 
            this.Missoes_button.FlatAppearance.BorderSize = 0;
            this.Missoes_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Missoes_button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Missoes_button.ForeColor = System.Drawing.SystemColors.Control;
            this.Missoes_button.Location = new System.Drawing.Point(1, 176);
            this.Missoes_button.Name = "Missoes_button";
            this.Missoes_button.Size = new System.Drawing.Size(175, 48);
            this.Missoes_button.TabIndex = 0;
            this.Missoes_button.Text = "Missão";
            this.Missoes_button.UseVisualStyleBackColor = true;
            this.Missoes_button.Click += new System.EventHandler(this.Missoes_button_Click);
            // 
            // Window_Panel
            // 
            this.Window_Panel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Window_Panel.Location = new System.Drawing.Point(174, 20);
            this.Window_Panel.Name = "Window_Panel";
            this.Window_Panel.Size = new System.Drawing.Size(805, 548);
            this.Window_Panel.TabIndex = 1;
            this.Window_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_Panel_MouseDown);
            this.Window_Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_Panel_MouseMove);
            // 
            // minimize_close_panel
            // 
            this.minimize_close_panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.minimize_close_panel.Controls.Add(this.minimize_button);
            this.minimize_close_panel.Controls.Add(this.close_button);
            this.minimize_close_panel.Location = new System.Drawing.Point(174, 0);
            this.minimize_close_panel.Name = "minimize_close_panel";
            this.minimize_close_panel.Size = new System.Drawing.Size(805, 23);
            this.minimize_close_panel.TabIndex = 2;
            this.minimize_close_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Minimize_close_panel_MouseDown);
            this.minimize_close_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Minimize_close_panel_MouseMove);
            // 
            // minimize_button
            // 
            this.minimize_button.Image = ((System.Drawing.Image)(resources.GetObject("minimize_button.Image")));
            this.minimize_button.Location = new System.Drawing.Point(747, 3);
            this.minimize_button.Name = "minimize_button";
            this.minimize_button.Size = new System.Drawing.Size(24, 16);
            this.minimize_button.TabIndex = 0;
            this.minimize_button.TabStop = false;
            this.minimize_button.Click += new System.EventHandler(this.Minimize_button_Click);
            // 
            // close_button
            // 
            this.close_button.Image = ((System.Drawing.Image)(resources.GetObject("close_button.Image")));
            this.close_button.Location = new System.Drawing.Point(777, 0);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(25, 20);
            this.close_button.TabIndex = 0;
            this.close_button.TabStop = false;
            this.close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // App_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(978, 568);
            this.Controls.Add(this.minimize_close_panel);
            this.Controls.Add(this.Window_Panel);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "App_Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ciberperseu IUEM";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.minimize_close_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minimize_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_button)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Panel minimize_close_panel;
        private System.Windows.Forms.PictureBox close_button;
        private System.Windows.Forms.PictureBox minimize_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nickname;
        public System.Windows.Forms.Label chatCounter;
        public System.Windows.Forms.Panel Window_Panel;
        public System.Windows.Forms.Button Missoes_button;
        public System.Windows.Forms.Button outlook_button;
        public System.Windows.Forms.Button missoes_geral_button;
        public System.Windows.Forms.Button About_button;
        public System.Windows.Forms.Button configuraçoes_admin;
        public System.Windows.Forms.Button chat_button;
    }
}

