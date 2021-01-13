namespace Cyber_Incident_Response
{
    partial class outlook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remetente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Corpo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inject = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ms03_button = new System.Windows.Forms.Button();
            this.ms04_button = new System.Windows.Forms.Button();
            this.ms05_button = new System.Windows.Forms.Button();
            this.ms07_button = new System.Windows.Forms.Button();
            this.descartar_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Remetente,
            this.Titulo,
            this.Corpo,
            this.Data,
            this.Inject});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(805, 484);
            this.DataGrid.TabIndex = 0;
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 80;
            // 
            // Remetente
            // 
            this.Remetente.HeaderText = "Remetente";
            this.Remetente.Name = "Remetente";
            this.Remetente.ReadOnly = true;
            this.Remetente.Width = 161;
            // 
            // Titulo
            // 
            this.Titulo.HeaderText = "Titulo";
            this.Titulo.Name = "Titulo";
            this.Titulo.ReadOnly = true;
            this.Titulo.Width = 153;
            // 
            // Corpo
            // 
            this.Corpo.HeaderText = "Corpo";
            this.Corpo.Name = "Corpo";
            this.Corpo.ReadOnly = true;
            this.Corpo.Width = 200;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 110;
            // 
            // Inject
            // 
            this.Inject.HeaderText = "Inject";
            this.Inject.Name = "Inject";
            this.Inject.Width = 40;
            // 
            // ms03_button
            // 
            this.ms03_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ms03_button.FlatAppearance.BorderSize = 0;
            this.ms03_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ms03_button.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms03_button.Location = new System.Drawing.Point(126, 499);
            this.ms03_button.Name = "ms03_button";
            this.ms03_button.Size = new System.Drawing.Size(96, 37);
            this.ms03_button.TabIndex = 1;
            this.ms03_button.Text = "MS03";
            this.ms03_button.UseVisualStyleBackColor = false;
            this.ms03_button.Click += new System.EventHandler(this.Ms03_button_Click);
            // 
            // ms04_button
            // 
            this.ms04_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ms04_button.FlatAppearance.BorderSize = 0;
            this.ms04_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ms04_button.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms04_button.Location = new System.Drawing.Point(276, 499);
            this.ms04_button.Name = "ms04_button";
            this.ms04_button.Size = new System.Drawing.Size(96, 37);
            this.ms04_button.TabIndex = 2;
            this.ms04_button.Text = "MS04";
            this.ms04_button.UseVisualStyleBackColor = false;
            this.ms04_button.Click += new System.EventHandler(this.Ms04_button_Click);
            // 
            // ms05_button
            // 
            this.ms05_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ms05_button.FlatAppearance.BorderSize = 0;
            this.ms05_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ms05_button.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms05_button.Location = new System.Drawing.Point(417, 499);
            this.ms05_button.Name = "ms05_button";
            this.ms05_button.Size = new System.Drawing.Size(96, 37);
            this.ms05_button.TabIndex = 3;
            this.ms05_button.Text = "MS05";
            this.ms05_button.UseVisualStyleBackColor = false;
            this.ms05_button.Click += new System.EventHandler(this.Ms05_button_Click);
            // 
            // ms07_button
            // 
            this.ms07_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ms07_button.FlatAppearance.BorderSize = 0;
            this.ms07_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ms07_button.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms07_button.Location = new System.Drawing.Point(563, 499);
            this.ms07_button.Name = "ms07_button";
            this.ms07_button.Size = new System.Drawing.Size(96, 37);
            this.ms07_button.TabIndex = 4;
            this.ms07_button.Text = "MS07";
            this.ms07_button.UseVisualStyleBackColor = false;
            this.ms07_button.Click += new System.EventHandler(this.Ms07_button_Click);
            // 
            // descartar_button
            // 
            this.descartar_button.BackColor = System.Drawing.Color.Black;
            this.descartar_button.FlatAppearance.BorderSize = 0;
            this.descartar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.descartar_button.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descartar_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.descartar_button.Location = new System.Drawing.Point(714, 499);
            this.descartar_button.Name = "descartar_button";
            this.descartar_button.Size = new System.Drawing.Size(78, 37);
            this.descartar_button.TabIndex = 5;
            this.descartar_button.TabStop = false;
            this.descartar_button.Text = "Descartar";
            this.descartar_button.UseVisualStyleBackColor = false;
            this.descartar_button.Click += new System.EventHandler(this.Descartar_button_Click);
            // 
            // outlook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.descartar_button);
            this.Controls.Add(this.ms07_button);
            this.Controls.Add(this.ms05_button);
            this.Controls.Add(this.ms04_button);
            this.Controls.Add(this.ms03_button);
            this.Controls.Add(this.DataGrid);
            this.Name = "outlook";
            this.Size = new System.Drawing.Size(805, 548);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button ms03_button;
        private System.Windows.Forms.Button ms04_button;
        private System.Windows.Forms.Button ms05_button;
        private System.Windows.Forms.Button ms07_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remetente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Corpo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Inject;
        private System.Windows.Forms.Button descartar_button;
    }
}
