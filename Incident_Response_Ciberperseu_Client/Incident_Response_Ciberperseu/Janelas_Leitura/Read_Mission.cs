using System;
using System.Drawing;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Incident_Response_Ciberperseu
{
    public partial class Read_Mission : Form
    {
        Point lastPoint;

        public Read_Mission()
        {
            InitializeComponent();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Guardar_button_Click(object sender, EventArgs e)
        {
            string id = id_box.Text;
            string resposta_texto = resposta_box.Text;
            string comentario_texto = comentarios_box.Text;
            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);

            if (Login.MS_ID == "MS03")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("MS03_MissionChange<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(Login.Username + " " + hm + "<EOF>"));

            }
            else if (Login.MS_ID == "MS04")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("MS04_MissionChange<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(Login.Username + " " + hm + "<EOF>"));
            }

            else if (Login.MS_ID == "MS05")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("MS05_MissionChange<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(Login.Username + " " + hm + "<EOF>"));
            }

            else if (Login.MS_ID == "MS07")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("MS07_MissionChange<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(Login.Username + " " + hm + "<EOF>"));
            }

            else if (Login.MS_ID == "ADMIN")
            {
                if (Missoes.Admin_Missao == "Admin_MS03")
                {
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS03_MissionChange<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(Login.Username + " " + hm + "<EOF>"));
                }
                else if (Missoes.Admin_Missao == "Admin_MS04")
                {
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS04_MissionChange<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(Login.Username + " " + hm + "<EOF>"));
                }
                else if (Missoes.Admin_Missao == "Admin_MS05")
                {
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS05_MissionChange<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(Login.Username + " " + hm + "<EOF>"));
                }
                else if (Missoes.Admin_Missao == "Admin_MS07")
                {
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS07_MissionChange<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(Login.Username + " " + hm + "<EOF>"));
                }
            }

            MessageBox.Show("Guardado com sucesso...", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Refreshing
            Dispose();

        }

        private void Read_Mission_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Read_Mission_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
