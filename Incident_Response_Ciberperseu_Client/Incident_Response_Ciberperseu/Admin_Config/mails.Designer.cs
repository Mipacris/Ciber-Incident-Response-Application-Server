namespace Incident_Response_Ciberperseu
{
    partial class mails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mails));
            this.mail_box = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lista_mails = new System.Windows.Forms.ComboBox();
            this.Add_mail = new System.Windows.Forms.PictureBox();
            this.delete = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Add_mail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).BeginInit();
            this.SuspendLayout();
            // 
            // mail_box
            // 
            this.mail_box.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail_box.Location = new System.Drawing.Point(96, 83);
            this.mail_box.Multiline = false;
            this.mail_box.Name = "mail_box";
            this.mail_box.Size = new System.Drawing.Size(497, 28);
            this.mail_box.TabIndex = 0;
            this.mail_box.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lista de Mails";
            // 
            // lista_mails
            // 
            this.lista_mails.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista_mails.FormattingEnabled = true;
            this.lista_mails.Location = new System.Drawing.Point(96, 275);
            this.lista_mails.Name = "lista_mails";
            this.lista_mails.Size = new System.Drawing.Size(446, 25);
            this.lista_mails.TabIndex = 3;
            // 
            // Add_mail
            // 
            this.Add_mail.Image = ((System.Drawing.Image)(resources.GetObject("Add_mail.Image")));
            this.Add_mail.Location = new System.Drawing.Point(599, 65);
            this.Add_mail.Name = "Add_mail";
            this.Add_mail.Size = new System.Drawing.Size(44, 46);
            this.Add_mail.TabIndex = 4;
            this.Add_mail.TabStop = false;
            this.Add_mail.Click += new System.EventHandler(this.Add_mail_Click);
            // 
            // delete
            // 
            this.delete.Image = ((System.Drawing.Image)(resources.GetObject("delete.Image")));
            this.delete.Location = new System.Drawing.Point(560, 271);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(45, 29);
            this.delete.TabIndex = 5;
            this.delete.TabStop = false;
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // mails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.delete);
            this.Controls.Add(this.Add_mail);
            this.Controls.Add(this.lista_mails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mail_box);
            this.Name = "mails";
            this.Size = new System.Drawing.Size(802, 503);
            ((System.ComponentModel.ISupportInitialize)(this.Add_mail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox mail_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox lista_mails;
        private System.Windows.Forms.PictureBox Add_mail;
        private System.Windows.Forms.PictureBox delete;
    }
}
