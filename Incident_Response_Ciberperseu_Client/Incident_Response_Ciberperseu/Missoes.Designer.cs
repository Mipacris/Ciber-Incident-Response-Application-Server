namespace Incident_Response_Ciberperseu
{
    partial class Missoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Missoes));
            this.panel_missoes = new System.Windows.Forms.Panel();
            this.missao_texto = new System.Windows.Forms.Label();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.Refresh = new System.Windows.Forms.PictureBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remetente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Corpo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resposta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentários = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concluido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel_missoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_missoes
            // 
            this.panel_missoes.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_missoes.Controls.Add(this.missao_texto);
            this.panel_missoes.Location = new System.Drawing.Point(0, 0);
            this.panel_missoes.Name = "panel_missoes";
            this.panel_missoes.Size = new System.Drawing.Size(805, 63);
            this.panel_missoes.TabIndex = 0;
            // 
            // missao_texto
            // 
            this.missao_texto.AutoSize = true;
            this.missao_texto.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missao_texto.Location = new System.Drawing.Point(354, 15);
            this.missao_texto.Name = "missao_texto";
            this.missao_texto.Size = new System.Drawing.Size(90, 33);
            this.missao_texto.TabIndex = 0;
            this.missao_texto.Text = "TEXTO";
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
            this.Resposta,
            this.Comentários,
            this.Concluido});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DataGrid.Location = new System.Drawing.Point(3, 69);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(799, 428);
            this.DataGrid.TabIndex = 1;
            // 
            // Refresh
            // 
            this.Refresh.Image = ((System.Drawing.Image)(resources.GetObject("Refresh.Image")));
            this.Refresh.Location = new System.Drawing.Point(397, 500);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(47, 45);
            this.Refresh.TabIndex = 2;
            this.Refresh.TabStop = false;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // Remetente
            // 
            this.Remetente.HeaderText = "Remetente";
            this.Remetente.Name = "Remetente";
            this.Remetente.ReadOnly = true;
            // 
            // Titulo
            // 
            this.Titulo.HeaderText = "Titulo";
            this.Titulo.Name = "Titulo";
            this.Titulo.ReadOnly = true;
            this.Titulo.Width = 102;
            // 
            // Corpo
            // 
            this.Corpo.HeaderText = "Corpo";
            this.Corpo.Name = "Corpo";
            this.Corpo.ReadOnly = true;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // Resposta
            // 
            this.Resposta.HeaderText = "Resposta";
            this.Resposta.Name = "Resposta";
            this.Resposta.ReadOnly = true;
            this.Resposta.Width = 90;
            // 
            // Comentários
            // 
            this.Comentários.HeaderText = "Comentários";
            this.Comentários.Name = "Comentários";
            this.Comentários.ReadOnly = true;
            this.Comentários.Width = 130;
            // 
            // Concluido
            // 
            this.Concluido.HeaderText = "Concluido";
            this.Concluido.Name = "Concluido";
            this.Concluido.Width = 65;
            // 
            // Missoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.panel_missoes);
            this.Name = "Missoes";
            this.Size = new System.Drawing.Size(805, 548);
            this.panel_missoes.ResumeLayout(false);
            this.panel_missoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_missoes;
        private System.Windows.Forms.Label missao_texto;
        public System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.PictureBox Refresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remetente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Corpo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resposta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentários;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Concluido;
    }
}
