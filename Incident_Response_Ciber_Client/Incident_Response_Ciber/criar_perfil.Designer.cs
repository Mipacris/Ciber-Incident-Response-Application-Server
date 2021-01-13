namespace Ciberperseu_Outlook
{
    partial class criar_perfil
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.missao_comboBox = new System.Windows.Forms.ComboBox();
            this.password_box = new System.Windows.Forms.RichTextBox();
            this.username_box = new System.Windows.Forms.RichTextBox();
            this.criar_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nickname_box = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Missão";
            // 
            // missao_comboBox
            // 
            this.missao_comboBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missao_comboBox.FormattingEnabled = true;
            this.missao_comboBox.Items.AddRange(new object[] {
            "MS03",
            "MS04",
            "MS05",
            "MS07",
            "ADMIN"});
            this.missao_comboBox.Location = new System.Drawing.Point(172, 266);
            this.missao_comboBox.Name = "missao_comboBox";
            this.missao_comboBox.Size = new System.Drawing.Size(127, 28);
            this.missao_comboBox.TabIndex = 4;
            // 
            // password_box
            // 
            this.password_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password_box.Location = new System.Drawing.Point(172, 133);
            this.password_box.Name = "password_box";
            this.password_box.Size = new System.Drawing.Size(283, 22);
            this.password_box.TabIndex = 2;
            this.password_box.Text = "";
            // 
            // username_box
            // 
            this.username_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username_box.Location = new System.Drawing.Point(172, 64);
            this.username_box.Name = "username_box";
            this.username_box.Size = new System.Drawing.Size(283, 22);
            this.username_box.TabIndex = 1;
            this.username_box.Text = "";
            // 
            // criar_button
            // 
            this.criar_button.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.criar_button.FlatAppearance.BorderSize = 0;
            this.criar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.criar_button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criar_button.ForeColor = System.Drawing.SystemColors.Control;
            this.criar_button.Location = new System.Drawing.Point(285, 399);
            this.criar_button.Name = "criar_button";
            this.criar_button.Size = new System.Drawing.Size(221, 53);
            this.criar_button.TabIndex = 4;
            this.criar_button.Text = "Criar";
            this.criar_button.UseVisualStyleBackColor = false;
            this.criar_button.Click += new System.EventHandler(this.Criar_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nickname";
            // 
            // nickname_box
            // 
            this.nickname_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nickname_box.Location = new System.Drawing.Point(172, 204);
            this.nickname_box.Name = "nickname_box";
            this.nickname_box.Size = new System.Drawing.Size(283, 22);
            this.nickname_box.TabIndex = 3;
            this.nickname_box.Text = "";
            // 
            // criar_perfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nickname_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.criar_button);
            this.Controls.Add(this.username_box);
            this.Controls.Add(this.password_box);
            this.Controls.Add(this.missao_comboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "criar_perfil";
            this.Size = new System.Drawing.Size(802, 503);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox missao_comboBox;
        private System.Windows.Forms.RichTextBox password_box;
        private System.Windows.Forms.RichTextBox username_box;
        private System.Windows.Forms.Button criar_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox nickname_box;
    }
}
