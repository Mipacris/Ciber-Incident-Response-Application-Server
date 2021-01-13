namespace Incident_Response_Ciber
{
    partial class Admin_Config_Tab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.config_panel = new System.Windows.Forms.Panel();
            this.mails_button = new System.Windows.Forms.Button();
            this.logs_button = new System.Windows.Forms.Button();
            this.criar_perfil_button = new System.Windows.Forms.Button();
            this.config_window = new System.Windows.Forms.Panel();
            this.config_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // config_panel
            // 
            this.config_panel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.config_panel.Controls.Add(this.mails_button);
            this.config_panel.Controls.Add(this.logs_button);
            this.config_panel.Controls.Add(this.criar_perfil_button);
            this.config_panel.Location = new System.Drawing.Point(0, 0);
            this.config_panel.Name = "config_panel";
            this.config_panel.Size = new System.Drawing.Size(805, 44);
            this.config_panel.TabIndex = 1;
            // 
            // mails_button
            // 
            this.mails_button.BackColor = System.Drawing.Color.Coral;
            this.mails_button.FlatAppearance.BorderSize = 0;
            this.mails_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mails_button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mails_button.Location = new System.Drawing.Point(317, 0);
            this.mails_button.Name = "mails_button";
            this.mails_button.Size = new System.Drawing.Size(134, 43);
            this.mails_button.TabIndex = 4;
            this.mails_button.TabStop = false;
            this.mails_button.Text = "Mails";
            this.mails_button.UseVisualStyleBackColor = false;
            this.mails_button.Click += new System.EventHandler(this.Mails_button_Click);
            // 
            // logs_button
            // 
            this.logs_button.BackColor = System.Drawing.Color.MediumAquamarine;
            this.logs_button.FlatAppearance.BorderSize = 0;
            this.logs_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logs_button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logs_button.Location = new System.Drawing.Point(483, 0);
            this.logs_button.Name = "logs_button";
            this.logs_button.Size = new System.Drawing.Size(134, 43);
            this.logs_button.TabIndex = 3;
            this.logs_button.TabStop = false;
            this.logs_button.Text = "Consultar Logs";
            this.logs_button.UseVisualStyleBackColor = false;
            this.logs_button.Click += new System.EventHandler(this.Logs_button_Click);
            // 
            // criar_perfil_button
            // 
            this.criar_perfil_button.BackColor = System.Drawing.Color.PaleGreen;
            this.criar_perfil_button.FlatAppearance.BorderSize = 0;
            this.criar_perfil_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.criar_perfil_button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criar_perfil_button.Location = new System.Drawing.Point(149, 3);
            this.criar_perfil_button.Name = "criar_perfil_button";
            this.criar_perfil_button.Size = new System.Drawing.Size(134, 43);
            this.criar_perfil_button.TabIndex = 2;
            this.criar_perfil_button.TabStop = false;
            this.criar_perfil_button.Text = "Criar Perfil";
            this.criar_perfil_button.UseVisualStyleBackColor = false;
            this.criar_perfil_button.Click += new System.EventHandler(this.Criar_perfil_button_Click);
            // 
            // config_window
            // 
            this.config_window.Location = new System.Drawing.Point(3, 45);
            this.config_window.Name = "config_window";
            this.config_window.Size = new System.Drawing.Size(802, 503);
            this.config_window.TabIndex = 2;
            // 
            // Admin_Config_Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.config_window);
            this.Controls.Add(this.config_panel);
            this.Name = "Admin_Config_Tab";
            this.Size = new System.Drawing.Size(805, 548);
            this.config_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel config_panel;
        private System.Windows.Forms.Panel config_window;
        public System.Windows.Forms.Button criar_perfil_button;
        public System.Windows.Forms.Button logs_button;
        public System.Windows.Forms.Button mails_button;
    }
}
