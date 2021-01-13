using System;
using System.Data;
using System.Drawing;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Incident_Response_Ciberperseu
{
    public partial class Geral : UserControl
    {
        public Geral()
        {
            InitializeComponent();

            byte[] buffer = new byte[2048];

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("id");
            dt.Columns.Add("Missão");
            dt.Columns.Add("Titulo");
            dt.Columns.Add("Data");
            dt.Columns.Add("Resposta");
            dt.Columns.Add("Utilizador");
            dt.Columns.Add("Comentários");
            dt.Columns.Add("Concluido");
            dt.Columns.Add("Estado");

            Login.sslstream.Write(Encoding.UTF8.GetBytes("MS_GERAL<EOF>"));
            int i = 0;
            while (true)
            {
                string check = ReadMessage(Login.sslstream);
                if (check == "DONE<EOF>")
                { break; }
                string id = ReadMessage(Login.sslstream);
                string missao = ReadMessage(Login.sslstream);
                string titulo = ReadMessage(Login.sslstream);
                string data = ReadMessage(Login.sslstream);
                string resposta = ReadMessage(Login.sslstream);
                string utilizador_data = ReadMessage(Login.sslstream);
                string comentarios = ReadMessage(Login.sslstream);
                string concluido = ReadMessage(Login.sslstream);
                string estado = ReadMessage(Login.sslstream);

                DataRow row = dt.NewRow();

                row["id"] = id.Substring(0, (id.Length - 5));
                row["Missão"] = missao.Substring(0, (missao.Length - 5));
                row["Titulo"] = titulo.Substring(0, (titulo.Length - 5));
                row["Data"] = data.Substring(0, (data.Length - 5));
                row["Resposta"] = resposta.Substring(0, (resposta.Length - 5));
                row["Utilizador"] = utilizador_data.Substring(0, (utilizador_data.Length - 5));
                row["Comentários"] = comentarios.Substring(0, (comentarios.Length - 5));
                if (concluido.Substring(0, (concluido.Length - 5)).Equals("nao"))
                {
                    row["Concluido"] = "Não";
                }
                else
                {
                    row["Concluido"] = "Sim";

                }
                row["Estado"] = estado.Substring(0, (estado.Length - 5));

                dt.Rows.Add(row);
                i = i + 1;
            }

            DataGrid_Geral.DataSource = dt;

            App_Window.Enable_Buttons(); // Enable buttons again at the end...
        }

        static string ReadMessage(SslStream sslStream)
        {
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
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

            return messageData.ToString();
        }

        private void DataGrid_Geral_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grid_row in DataGrid_Geral.Rows)
            {
                if (grid_row.Cells["Concluido"].Value.ToString().Equals("Sim"))
                {
                    grid_row.DefaultCellStyle.BackColor = Color.Yellow;
                }

                if (grid_row.Cells["Estado"].Value.ToString().Equals("Enviado"))
                {
                    grid_row.DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
        }

        private void Search_box_TextChanged(object sender, EventArgs e)
        {
            (DataGrid_Geral.DataSource as DataTable).DefaultView.RowFilter = string.Format("Titulo LIKE '%{0}%'" +
                "OR Missão LIKE '%{0}%' OR Data LIKE '%{0}%' OR Resposta LIKE '%{0}%' " +
                "OR Utilizador LIKE '%{0}%' OR Comentários LIKE '%{0}%'",
                search_box.Text);
        }

        private void DataGrid_Geral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Login.MS_ID == "ADMIN")
            {

                Resposta_ao_Incidente content_window = new Resposta_ao_Incidente();
                content_window.id_box.Text = DataGrid_Geral.CurrentRow.Cells[0].Value.ToString();
                content_window.missao_resposta_box.Text = DataGrid_Geral.CurrentRow.Cells[1].Value.ToString();
                content_window.titulo_resposta_box.Text = DataGrid_Geral.CurrentRow.Cells[2].Value.ToString();
                content_window.resposta_incidente_box.Text = DataGrid_Geral.CurrentRow.Cells[4].Value.ToString();
                content_window.utilizador_resposta_box.Text = DataGrid_Geral.CurrentRow.Cells[5].Value.ToString();
                content_window.coment_resposta_box.Text = DataGrid_Geral.CurrentRow.Cells[6].Value.ToString();
                content_window.titulo_mail_box.Text = DataGrid_Geral.CurrentRow.Cells[2].Value.ToString();

                content_window.FormClosed += Resposta_Incident_FormClosed;
                content_window.ShowDialog();
            }
            else
            {
                User_Geral_Read content_window = new User_Geral_Read();
                content_window.missao_resposta_box.Text = DataGrid_Geral.CurrentRow.Cells[1].Value.ToString();
                content_window.titulo_resposta_box.Text = DataGrid_Geral.CurrentRow.Cells[2].Value.ToString();
                content_window.resposta_incidente_box.Text = DataGrid_Geral.CurrentRow.Cells[4].Value.ToString();
                content_window.utilizador_resposta_box.Text = DataGrid_Geral.CurrentRow.Cells[5].Value.ToString();
                content_window.coment_resposta_box.Text = DataGrid_Geral.CurrentRow.Cells[6].Value.ToString();
                content_window.ShowDialog();
            }
        }

        private void Resposta_Incident_FormClosed(object sender, FormClosedEventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("id");
            dt.Columns.Add("Missão");
            dt.Columns.Add("Titulo");
            dt.Columns.Add("Data");
            dt.Columns.Add("Resposta");
            dt.Columns.Add("Utilizador");
            dt.Columns.Add("Comentários");
            dt.Columns.Add("Concluido");
            dt.Columns.Add("Estado");

            Login.sslstream.Write(Encoding.UTF8.GetBytes("MS_GERAL<EOF>"));
            int i = 0;
            while (true)
            {
                string check = ReadMessage(Login.sslstream);
                if (check == "DONE<EOF>")
                { break; }
                string id = ReadMessage(Login.sslstream);
                string missao = ReadMessage(Login.sslstream);
                string titulo = ReadMessage(Login.sslstream);
                string data = ReadMessage(Login.sslstream);
                string resposta = ReadMessage(Login.sslstream);
                string utilizador_data = ReadMessage(Login.sslstream);
                string comentarios = ReadMessage(Login.sslstream);
                string concluido = ReadMessage(Login.sslstream);
                string estado = ReadMessage(Login.sslstream);

                DataRow row = dt.NewRow();

                row["id"] = id.Substring(0, (id.Length - 5));
                row["Missão"] = missao.Substring(0, (missao.Length - 5));
                row["Titulo"] = titulo.Substring(0, (titulo.Length - 5));
                row["Data"] = data.Substring(0, (data.Length - 5));
                row["Resposta"] = resposta.Substring(0, (resposta.Length - 5));
                row["Utilizador"] = utilizador_data.Substring(0, (utilizador_data.Length - 5));
                row["Comentários"] = comentarios.Substring(0, (comentarios.Length - 5));
                if (concluido.Substring(0, (concluido.Length - 5)).Equals("nao"))
                {
                    row["Concluido"] = "Não";
                }
                else
                {
                    row["Concluido"] = "Sim";

                }
                row["Estado"] = estado.Substring(0, (estado.Length - 5));

                dt.Rows.Add(row);
                i = i + 1;
            }

            DataGrid_Geral.DataSource = dt;
        }
    }
}
