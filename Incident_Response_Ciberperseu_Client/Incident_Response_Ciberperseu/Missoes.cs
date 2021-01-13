using System;
using System.Drawing;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Incident_Response_Ciberperseu
{
    public partial class Missoes : UserControl
    {
        public static string Admin_Missao;
        Panel missoes_panel;
        Label label;

        // buttons variables for manipulation inside missoes
        private Button ms03_admin_button;
        private Button ms04_admin_button;
        private Button ms05_admin_button;
        private Button ms07_admin_button;

        public Missoes()
        {
            InitializeComponent();

            if (Login.MS_ID == "ADMIN")
            {
                DataGrid.CellContentClick += new DataGridViewCellEventHandler(DataGrid_CellContentClick);

                Missao_Admin_PanelChange();
                Disable_Buttons();

                missoes_panel = new Panel();
                missoes_panel.Location = new Point(3, 500);
                missoes_panel.Size = new Size(799, 50);
                missoes_panel.BackColor = Color.FromArgb(255, 192, 128);
                label = new Label();
                label.Text = "MS03";
                label.Font = new Font("Century Gothic", 14);
                label.Location = new Point(378, 12);
                missoes_panel.Controls.Add(label);
                Controls.Add(missoes_panel);
                missoes_panel.BringToFront();

                Missao_ReceiveMails("MS03_XML<EOF>");
                Admin_Missao = "Admin_MS03";

                App_Window.Enable_Buttons(); // Enable buttons again at the end...
                Enable_Buttons(); // Enable Admin mission buttons...
            }
            else
            {
                Missao_TextChange();

                DataGrid.CellContentClick += new DataGridViewCellEventHandler(DataGrid_CellContentClick);

                // Sending and Receive Mails data to Missoes
                byte[] buffer = new byte[2048];
                switch (Login.MS_ID)
                {
                    case ("MS03"):
                        Missao_ReceiveMails("MS03_XML<EOF>");
                        break;
                    case ("MS04"):
                        Missao_ReceiveMails("MS04_XML<EOF>");
                        break;
                    case ("MS05"):
                        Missao_ReceiveMails("MS05_XML<EOF>");
                        break;
                    case ("MS07"):
                        Missao_ReceiveMails("MS07_XML<EOF>");
                        break;
                }

                App_Window.Enable_Buttons(); // Enable buttons again at the end...
            }
        }

        private void Missao_ReceiveMails(string missão_XML)
        {
            Login.sslstream.Write(Encoding.UTF8.GetBytes(missão_XML));
            int i = 0;
            while (true)
            {
                try
                {
                    string check = ReadMessage(Login.sslstream);
                    if (check == "DONE<EOF>")
                    { break; }
                    string id = ReadMessage(Login.sslstream);
                    string remetente = ReadMessage(Login.sslstream);
                    string titulo = ReadMessage(Login.sslstream);
                    string corpo = ReadMessage(Login.sslstream);
                    string data = ReadMessage(Login.sslstream);
                    string resposta = ReadMessage(Login.sslstream);
                    string comentarios = ReadMessage(Login.sslstream);
                    string concluido = ReadMessage(Login.sslstream);

                    DataGrid.Rows.Add();
                    DataGrid.Rows[i].Cells["id"].Value = id.Substring(0, (id.Length - 5));
                    DataGrid.Rows[i].Cells["Remetente"].Value = remetente.Substring(0, (remetente.Length - 5));
                    DataGrid.Rows[i].Cells["Titulo"].Value = titulo.Substring(0, (titulo.Length - 5));
                    DataGrid.Rows[i].Cells["Corpo"].Value = corpo.Substring(0, (corpo.Length - 5));
                    DataGrid.Rows[i].Cells["Data"].Value = data.Substring(0, (data.Length - 5));
                    DataGrid.Rows[i].Cells["Resposta"].Value = resposta.Substring(0, (resposta.Length - 5));
                    DataGrid.Rows[i].Cells["Comentários"].Value = comentarios.Substring(0, (comentarios.Length - 5));
                    if (concluido.Substring(0, (concluido.Length - 5)).Equals("nao"))
                    {
                        DataGrid.Rows[i].Cells["Concluido"].Value = false;
                    }
                    else
                    {
                        DataGrid.Rows[i].Cells["Concluido"].Value = true;
                        DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }

                    i = i + 1;
                } catch (ArgumentOutOfRangeException)
                {
                    break;
                }
            }
        }

        private void Missao_Admin_PanelChange()
        {
            panel_missoes.Controls.Remove(missao_texto);
            Controls.Remove(Refresh);

            ms03_admin_button = new Button();
            ms04_admin_button = new Button();
            ms05_admin_button = new Button();
            ms07_admin_button = new Button();

            ms03_admin_button.Size = new Size(135, 63);
            ms04_admin_button.Size = new Size(135, 63);
            ms05_admin_button.Size = new Size(135, 63);
            ms07_admin_button.Size = new Size(135, 63);

            ms03_admin_button.Location = new Point(100, 0);
            ms04_admin_button.Location = new Point(250, 0);
            ms05_admin_button.Location = new Point(400, 0);
            ms07_admin_button.Location = new Point(550, 0);

            ms03_admin_button.Text = "MS03";
            ms04_admin_button.Text = "MS04";
            ms05_admin_button.Text = "MS05";
            ms07_admin_button.Text = "MS07";

            ms03_admin_button.Font = new Font("Century Gothic", 16);
            ms04_admin_button.Font = new Font("Century Gothic", 16);
            ms05_admin_button.Font = new Font("Century Gothic", 16);
            ms07_admin_button.Font = new Font("Century Gothic", 16);

            ms03_admin_button.FlatStyle = FlatStyle.Flat;
            ms04_admin_button.FlatStyle = FlatStyle.Flat;
            ms05_admin_button.FlatStyle = FlatStyle.Flat;
            ms07_admin_button.FlatStyle = FlatStyle.Flat;

            ms03_admin_button.FlatAppearance.BorderSize = 0;
            ms04_admin_button.FlatAppearance.BorderSize = 0;
            ms05_admin_button.FlatAppearance.BorderSize = 0;
            ms07_admin_button.FlatAppearance.BorderSize = 0;

            ms03_admin_button.BackColor = Color.FromArgb(255, 192, 128);
            ms04_admin_button.BackColor = Color.FromArgb(255, 255, 128);
            ms05_admin_button.BackColor = Color.FromArgb(128, 255, 128);
            ms07_admin_button.BackColor = Color.FromArgb(128, 128, 255);

            // Function for Button On Click
            ms03_admin_button.Click += ButtonClick_ReceiveMissaoMS03;
            ms04_admin_button.Click += ButtonClick_ReceiveMissaoMS04;
            ms05_admin_button.Click += ButtonClick_ReceiveMissaoMS05;
            ms07_admin_button.Click += ButtonClick_ReceiveMissaoMS07;

            panel_missoes.Controls.Add(ms03_admin_button);
            panel_missoes.Controls.Add(ms04_admin_button);
            panel_missoes.Controls.Add(ms05_admin_button);
            panel_missoes.Controls.Add(ms07_admin_button);
        }

        private void Missao_TextChange()
        {
            // Changes Misson Text and Color based on Entry misson ID of session
            switch (Login.MS_ID)
            {
                case ("MS03"):
                    missao_texto.Text = "MS03";
                    panel_missoes.BackColor = Color.FromArgb(255, 192, 128);
                    break;
                case ("MS04"):
                    missao_texto.Text = "MS04";
                    panel_missoes.BackColor = Color.FromArgb(255, 255, 128);
                    break;
                case ("MS05"):
                    missao_texto.Text = "MS05";
                    panel_missoes.BackColor = Color.FromArgb(128, 255, 128);
                    break;
                case ("MS07"):
                    missao_texto.Text = "MS07";
                    panel_missoes.BackColor = Color.FromArgb(128, 128, 255);
                    break;
            }
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (Login.MS_ID == "MS03")
                {
                    bool value = Convert.ToBoolean(DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                    if (value.ToString().Equals("True"))
                    { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow; }
                    else { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty; }
                    // Use ToString() to get bool value
                    string id = DataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS03_Concluido<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(value.ToString() + "<EOF>"));
                }
                else if (Login.MS_ID == "MS04")
                {
                    bool value = Convert.ToBoolean(DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                    if (value.ToString().Equals("True"))
                    { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow; }
                    else { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty; }
                    // Use ToString() to get bool value
                    string id = DataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS04_Concluido<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(value.ToString() + "<EOF>"));
                }
                else if (Login.MS_ID == "MS05")
                {
                    bool value = Convert.ToBoolean(DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                    if (value.ToString().Equals("True"))
                    { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow; }
                    else { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty; }
                    // Use ToString() to get bool value
                    string id = DataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS05_Concluido<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(value.ToString() + "<EOF>"));
                }
                else if (Login.MS_ID == "MS07")
                {
                    bool value = Convert.ToBoolean(DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                    if (value.ToString().Equals("True"))
                    { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow; }
                    else { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty; }
                    // Use ToString() to get bool value
                    string id = DataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS07_Concluido<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(value.ToString() + "<EOF>"));
                }

                else if (Login.MS_ID == "ADMIN")
                {
                    if (Admin_Missao == "Admin_MS03")
                    {
                        bool value = Convert.ToBoolean(DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                        if (value.ToString().Equals("True"))
                        { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow; }
                        else { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty; }
                        // Use ToString() to get bool value
                        string id = DataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        Login.sslstream.Write(Encoding.UTF8.GetBytes("MS03_Concluido<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(value.ToString() + "<EOF>"));
                    }
                    else if (Admin_Missao == "Admin_MS04")
                    {
                        bool value = Convert.ToBoolean(DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                        if (value.ToString().Equals("True"))
                        { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow; }
                        else { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty; }
                        // Use ToString() to get bool value
                        string id = DataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        Login.sslstream.Write(Encoding.UTF8.GetBytes("MS04_Concluido<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(value.ToString() + "<EOF>"));
                    }
                    else if (Admin_Missao == "Admin_MS05")
                    {
                        bool value = Convert.ToBoolean(DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                        if (value.ToString().Equals("True"))
                        { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow; }
                        else { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty; }
                        // Use ToString() to get bool value
                        string id = DataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        Login.sslstream.Write(Encoding.UTF8.GetBytes("MS05_Concluido<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(value.ToString() + "<EOF>"));
                    }
                    else if (Admin_Missao == "Admin_MS07")
                    {
                        bool value = Convert.ToBoolean(DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                        if (value.ToString().Equals("True"))
                        { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow; }
                        else { DataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty; }
                        // Use ToString() to get bool value
                        string id = DataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        Login.sslstream.Write(Encoding.UTF8.GetBytes("MS07_Concluido<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(value.ToString() + "<EOF>"));
                    }
                }
            }

            else
            {
                Read_Mission content_window = new Read_Mission();
                content_window.id_box.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
                content_window.remetente_box.Text = DataGrid.CurrentRow.Cells[1].Value.ToString();
                content_window.titulo_box.Text = DataGrid.CurrentRow.Cells[2].Value.ToString();
                content_window.corpo_box.Text = DataGrid.CurrentRow.Cells[3].Value.ToString();
                content_window.data_box.Text = DataGrid.CurrentRow.Cells[4].Value.ToString();
                try
                {
                    content_window.resposta_box.Text = DataGrid.CurrentRow.Cells[5].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    content_window.resposta_box.Text = "";
                }
                try
                {
                    content_window.comentarios_box.Text = DataGrid.CurrentRow.Cells[6].Value.ToString();
                }
                catch (NullReferenceException) { content_window.comentarios_box.Text = ""; }

                content_window.FormClosed += Read_Mission_FormClosed;
                content_window.ShowDialog();
            }
        }

        private string ReadMessage(SslStream sslStream)
        {
            StringBuilder messageData = new StringBuilder();
            try
            {
                byte[] buffer = new byte[2048];
                int bytes = -1;
                do
                {
                    bytes = sslStream.Read(buffer, 0, buffer.Length);
                    Decoder decoder = Encoding.UTF8.GetDecoder();
                    char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                    decoder.GetChars(buffer, 0, bytes, chars, 0);
                    messageData.Append(chars);
                    if (messageData.ToString().IndexOf("<EOF>") != -1)
                    {
                        break;
                    }
                } while (bytes != 0);

            } catch (NotSupportedException)
            {
                if (App_Window.isThreadON)
                {
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("THREAD_RESET" + "<EOF>"));
                    App_Window.isThreadON = false;
                }

                // Bring to front missoes tab
                App_Window.window.Controls.Clear();
                Missoes missoes = new Missoes();
                App_Window.window.Controls.Add(missoes);
            } catch (System.IO.IOException)
            {
                if (App_Window.isThreadON)
                {
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("THREAD_RESET" + "<EOF>"));
                    App_Window.isThreadON = false;
                }

                // Bring to front missoes tab
                App_Window.window.Controls.Clear();
                Missoes missoes = new Missoes();
                App_Window.window.Controls.Add(missoes);
            }

            return messageData.ToString();
        }
        
        private void Refresh_Click(object sender, EventArgs e)
        {
            App_Window.Disable_Buttons();
            Refresh.Enabled = false;

            DataGrid.Rows.Clear();
            DataGrid.Refresh();
            byte[] buffer = new byte[2048];
            switch (Login.MS_ID)
            {
                case ("MS03"):
                    Missao_ReceiveMails("MS03_XML<EOF>");
                    break;
                case ("MS04"):
                    Missao_ReceiveMails("MS04_XML<EOF>");
                    break;
                case ("MS05"):
                    Missao_ReceiveMails("MS05_XML<EOF>");
                    break;
                case ("MS07"):
                    Missao_ReceiveMails("MS07_XML<EOF>");
                    break;
            }

            Refresh.Enabled = true;
            App_Window.Enable_Buttons(); // Enable buttons again at the end...
        }

        private void Read_Mission_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (Login.MS_ID != "ADMIN")
            {
                DataGrid.Rows.Clear();
                DataGrid.Refresh();
                byte[] buffer = new byte[2048];
                switch (Login.MS_ID)
                {
                    case ("MS03"):
                        Missao_ReceiveMails("MS03_XML<EOF>");
                        break;
                    case ("MS04"):
                        Missao_ReceiveMails("MS04_XML<EOF>");
                        break;
                    case ("MS05"):
                        Missao_ReceiveMails("MS05_XML<EOF>");
                        break;
                    case ("MS07"):
                        Missao_ReceiveMails("MS07_XML<EOF>");
                        break;
                }
            }
            else
            {
                DataGrid.Rows.Clear();
                DataGrid.Refresh();
                byte[] buffer = new byte[2048];
                switch (Admin_Missao)
                {
                    case ("Admin_MS03"):
                        Missao_ReceiveMails("MS03_XML<EOF>");
                        break;
                    case ("Admin_MS04"):
                        Missao_ReceiveMails("MS04_XML<EOF>");
                        break;
                    case ("Admin_MS05"):
                        Missao_ReceiveMails("MS05_XML<EOF>");
                        break;
                    case ("Admin_MS07"):
                        Missao_ReceiveMails("MS07_XML<EOF>");
                        break;
                }
            }
        }

        // Admin Related Content on Misson
        private void ButtonClick_ReceiveMissaoMS03(object sender, EventArgs e)
        {
            Disable_Buttons();

            DataGrid.Rows.Clear();
            DataGrid.Refresh();

            missoes_panel.Controls.Remove(label);
            Controls.Remove(missoes_panel);

            missoes_panel = new Panel();
            missoes_panel.Location = new Point(3, 500);
            missoes_panel.Size = new Size(799, 50);
            missoes_panel.BackColor = Color.FromArgb(255, 192, 128);
            label = new Label();
            label.Text = "MS03";
            label.Font = new Font("Century Gothic", 14);
            label.Location = new Point(378, 12);
            missoes_panel.Controls.Add(label);
            Controls.Add(missoes_panel);
            missoes_panel.BringToFront();

            Missao_ReceiveMails("MS03_XML<EOF>");
            Admin_Missao = "Admin_MS03";

            Enable_Buttons(); // Enable Admin mission buttons...
            App_Window.Enable_Buttons(); // Enable buttons again at the end...
        }

        private void ButtonClick_ReceiveMissaoMS04(object sender, EventArgs e)
        {
            Disable_Buttons();

            DataGrid.Rows.Clear();
            DataGrid.Refresh();

            missoes_panel.Controls.Remove(label);
            Controls.Remove(missoes_panel);

            missoes_panel = new Panel();
            missoes_panel.Location = new Point(3, 500);
            missoes_panel.Size = new Size(799, 50);
            missoes_panel.BackColor = Color.FromArgb(255, 255, 128);
            label = new Label();
            label.Text = "MS04";
            label.Font = new Font("Century Gothic", 14);
            label.Location = new Point(378, 12);
            missoes_panel.Controls.Add(label);
            Controls.Add(missoes_panel);
            missoes_panel.BringToFront();

            Missao_ReceiveMails("MS04_XML<EOF>");
            Admin_Missao = "Admin_MS04";

            Enable_Buttons(); // Enable Admin mission buttons...
            App_Window.Enable_Buttons(); // Enable buttons again at the end...
        }

        private void ButtonClick_ReceiveMissaoMS05(object sender, EventArgs e)
        {
            Disable_Buttons();

            DataGrid.Rows.Clear();
            DataGrid.Refresh();

            missoes_panel.Controls.Remove(label);
            Controls.Remove(missoes_panel);

            missoes_panel = new Panel();
            missoes_panel.Location = new Point(3, 500);
            missoes_panel.Size = new Size(799, 50);
            missoes_panel.BackColor = Color.FromArgb(128, 255, 128);
            label = new Label();
            label.Text = "MS05";
            label.Font = new Font("Century Gothic", 14);
            label.Location = new Point(378, 12);
            missoes_panel.Controls.Add(label);
            Controls.Add(missoes_panel);
            missoes_panel.BringToFront();

            Missao_ReceiveMails("MS05_XML<EOF>");
            Admin_Missao = "Admin_MS05";

            Enable_Buttons(); // Enable Admin mission buttons...
            App_Window.Enable_Buttons(); // Enable buttons again at the end...
        }

        private void ButtonClick_ReceiveMissaoMS07(object sender, EventArgs e)
        {
            Disable_Buttons();

            DataGrid.Rows.Clear();
            DataGrid.Refresh();

            missoes_panel.Controls.Remove(label);
            Controls.Remove(missoes_panel);

            missoes_panel = new Panel();
            missoes_panel.Location = new Point(3, 500);
            missoes_panel.Size = new Size(799, 50);
            missoes_panel.BackColor = Color.FromArgb(128, 128, 255);
            label = new Label();
            label.Text = "MS07";
            label.Font = new Font("Century Gothic", 14);
            label.Location = new Point(378, 12);
            missoes_panel.Controls.Add(label);
            Controls.Add(missoes_panel);
            missoes_panel.BringToFront();

            Missao_ReceiveMails("MS07_XML<EOF>");
            Admin_Missao = "Admin_MS07";

            Enable_Buttons(); // Enable Admin mission buttons...
            App_Window.Enable_Buttons(); // Enable buttons again at the end...
        }

        private void Disable_Buttons()
        {
            ms03_admin_button.Enabled = false;
            ms04_admin_button.Enabled = false;
            ms05_admin_button.Enabled = false;
            ms07_admin_button.Enabled = false;
        }
        private void Enable_Buttons()
        {
            ms03_admin_button.Enabled = true;
            ms04_admin_button.Enabled = true;
            ms05_admin_button.Enabled = true;
            ms07_admin_button.Enabled = true;
        }
    }
}
