namespace Cyber_Incident_Response
{
    partial class chat
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
            this.chat_window = new System.Windows.Forms.RichTextBox();
            this.enviar_button = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.enviar_window = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chat_window
            // 
            this.chat_window.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chat_window.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chat_window.Location = new System.Drawing.Point(12, 12);
            this.chat_window.Name = "chat_window";
            this.chat_window.ReadOnly = true;
            this.chat_window.Size = new System.Drawing.Size(781, 406);
            this.chat_window.TabIndex = 0;
            this.chat_window.Text = "";
            // 
            // enviar_button
            // 
            this.enviar_button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.enviar_button.FlatAppearance.BorderSize = 0;
            this.enviar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enviar_button.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar_button.Location = new System.Drawing.Point(361, 488);
            this.enviar_button.Name = "enviar_button";
            this.enviar_button.Size = new System.Drawing.Size(90, 36);
            this.enviar_button.TabIndex = 2;
            this.enviar_button.Text = "Enviar";
            this.enviar_button.UseVisualStyleBackColor = false;
            this.enviar_button.Click += new System.EventHandler(this.Enviar_button_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.delete.FlatAppearance.BorderSize = 0;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(688, 482);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(90, 49);
            this.delete.TabIndex = 3;
            this.delete.Text = "Eliminar Conversa";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // enviar_window
            // 
            this.enviar_window.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar_window.Location = new System.Drawing.Point(12, 449);
            this.enviar_window.MaxLength = 3000;
            this.enviar_window.Name = "enviar_window";
            this.enviar_window.Size = new System.Drawing.Size(781, 22);
            this.enviar_window.TabIndex = 4;
            // 
            // chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.enviar_window);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.enviar_button);
            this.Controls.Add(this.chat_window);
            this.Name = "chat";
            this.Size = new System.Drawing.Size(801, 560);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button enviar_button;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TextBox enviar_window;
        public System.Windows.Forms.RichTextBox chat_window;
    }
}
