namespace Incident_Response_Ciberperseu
{
    partial class Resposta_ao_Incidente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resposta_ao_Incidente));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mail_comboBox = new System.Windows.Forms.ComboBox();
            this.enviar_button = new System.Windows.Forms.Button();
            this.resposta_incidente_box = new System.Windows.Forms.RichTextBox();
            this.coment_resposta_box = new System.Windows.Forms.RichTextBox();
            this.utilizador_resposta_box = new System.Windows.Forms.RichTextBox();
            this.titulo_resposta_box = new System.Windows.Forms.RichTextBox();
            this.missao_resposta_box = new System.Windows.Forms.RichTextBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.titulo_mail_box = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.id_box = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Missão";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Titulo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Utilizador | Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Comentário";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Resposta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 484);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Mail";
            // 
            // mail_comboBox
            // 
            this.mail_comboBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail_comboBox.FormattingEnabled = true;
            this.mail_comboBox.Location = new System.Drawing.Point(79, 481);
            this.mail_comboBox.Name = "mail_comboBox";
            this.mail_comboBox.Size = new System.Drawing.Size(398, 25);
            this.mail_comboBox.TabIndex = 8;
            // 
            // enviar_button
            // 
            this.enviar_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enviar_button.FlatAppearance.BorderSize = 0;
            this.enviar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enviar_button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar_button.Location = new System.Drawing.Point(311, 522);
            this.enviar_button.Name = "enviar_button";
            this.enviar_button.Size = new System.Drawing.Size(91, 33);
            this.enviar_button.TabIndex = 9;
            this.enviar_button.Text = "Enviar";
            this.enviar_button.UseVisualStyleBackColor = false;
            this.enviar_button.Click += new System.EventHandler(this.Enviar_button_Click);
            // 
            // resposta_incidente_box
            // 
            this.resposta_incidente_box.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resposta_incidente_box.Location = new System.Drawing.Point(42, 362);
            this.resposta_incidente_box.Name = "resposta_incidente_box";
            this.resposta_incidente_box.Size = new System.Drawing.Size(594, 113);
            this.resposta_incidente_box.TabIndex = 10;
            this.resposta_incidente_box.Text = "";
            // 
            // coment_resposta_box
            // 
            this.coment_resposta_box.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coment_resposta_box.Location = new System.Drawing.Point(42, 210);
            this.coment_resposta_box.Name = "coment_resposta_box";
            this.coment_resposta_box.ReadOnly = true;
            this.coment_resposta_box.Size = new System.Drawing.Size(594, 45);
            this.coment_resposta_box.TabIndex = 11;
            this.coment_resposta_box.Text = "";
            // 
            // utilizador_resposta_box
            // 
            this.utilizador_resposta_box.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilizador_resposta_box.Location = new System.Drawing.Point(153, 153);
            this.utilizador_resposta_box.Name = "utilizador_resposta_box";
            this.utilizador_resposta_box.ReadOnly = true;
            this.utilizador_resposta_box.Size = new System.Drawing.Size(480, 28);
            this.utilizador_resposta_box.TabIndex = 12;
            this.utilizador_resposta_box.Text = "";
            // 
            // titulo_resposta_box
            // 
            this.titulo_resposta_box.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo_resposta_box.Location = new System.Drawing.Point(153, 109);
            this.titulo_resposta_box.Name = "titulo_resposta_box";
            this.titulo_resposta_box.ReadOnly = true;
            this.titulo_resposta_box.Size = new System.Drawing.Size(480, 28);
            this.titulo_resposta_box.TabIndex = 13;
            this.titulo_resposta_box.Text = "";
            // 
            // missao_resposta_box
            // 
            this.missao_resposta_box.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missao_resposta_box.Location = new System.Drawing.Point(153, 66);
            this.missao_resposta_box.Name = "missao_resposta_box";
            this.missao_resposta_box.ReadOnly = true;
            this.missao_resposta_box.Size = new System.Drawing.Size(480, 28);
            this.missao_resposta_box.TabIndex = 14;
            this.missao_resposta_box.Text = "";
            // 
            // close
            // 
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.Location = new System.Drawing.Point(642, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(24, 21);
            this.close.TabIndex = 15;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // titulo_mail_box
            // 
            this.titulo_mail_box.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo_mail_box.Location = new System.Drawing.Point(39, 302);
            this.titulo_mail_box.Name = "titulo_mail_box";
            this.titulo_mail_box.Size = new System.Drawing.Size(594, 30);
            this.titulo_mail_box.TabIndex = 16;
            this.titulo_mail_box.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Titulo (Mail)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 10);
            this.panel1.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(72, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "ID";
            // 
            // id_box
            // 
            this.id_box.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_box.Location = new System.Drawing.Point(156, 24);
            this.id_box.Name = "id_box";
            this.id_box.ReadOnly = true;
            this.id_box.Size = new System.Drawing.Size(480, 28);
            this.id_box.TabIndex = 20;
            this.id_box.Text = "";
            // 
            // Resposta_ao_Incidente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(671, 567);
            this.Controls.Add(this.id_box);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.titulo_mail_box);
            this.Controls.Add(this.close);
            this.Controls.Add(this.missao_resposta_box);
            this.Controls.Add(this.titulo_resposta_box);
            this.Controls.Add(this.utilizador_resposta_box);
            this.Controls.Add(this.coment_resposta_box);
            this.Controls.Add(this.resposta_incidente_box);
            this.Controls.Add(this.enviar_button);
            this.Controls.Add(this.mail_comboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Resposta_ao_Incidente";
            this.Text = "Ciberperseu IUEM - Geral";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resposta_ao_Incidente_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resposta_ao_Incidente_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox mail_comboBox;
        private System.Windows.Forms.Button enviar_button;
        public System.Windows.Forms.RichTextBox resposta_incidente_box;
        public System.Windows.Forms.RichTextBox coment_resposta_box;
        public System.Windows.Forms.RichTextBox utilizador_resposta_box;
        public System.Windows.Forms.RichTextBox titulo_resposta_box;
        public System.Windows.Forms.RichTextBox missao_resposta_box;
        private System.Windows.Forms.PictureBox close;
        public System.Windows.Forms.RichTextBox titulo_mail_box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.RichTextBox id_box;
    }
}