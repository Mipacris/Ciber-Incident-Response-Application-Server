using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciberperseu_Outlook
{
    public partial class Read_Mission : Form
    {
        public Read_Mission()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Guardar_button_Click(object sender, EventArgs e)
        {
            string id = id_box.Text;
            string resposta_texto = resposta_box.Text;
            string comentario_texto = comentarios_box.Text;

            if (Login.MS_ID == "MS03")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("MS03_MissionChange<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
            }
            else if (Login.MS_ID == "MS04")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("MS04_MissionChange<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
            }

            else if (Login.MS_ID == "MS05")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("MS05_MissionChange<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
            }

            else if (Login.MS_ID == "MS07")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("MS07_MissionChange<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
            }

            else if (Login.MS_ID == "ADMIN")
            {
                if (Missoes.Admin_Missao == "Admin_MS03")
                {
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS03_MissionChange<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                }
                else if (Missoes.Admin_Missao == "Admin_MS04")
                {
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS04_MissionChange<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                }
                else if (Missoes.Admin_Missao == "Admin_MS05")
                {
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS05_MissionChange<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                }
                else if (Missoes.Admin_Missao == "Admin_MS07")
                {
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("MS07_MissionChange<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(resposta_texto + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(comentario_texto + "<EOF>"));
                }
            }

            MessageBox.Show("Guardado com sucesso...", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
