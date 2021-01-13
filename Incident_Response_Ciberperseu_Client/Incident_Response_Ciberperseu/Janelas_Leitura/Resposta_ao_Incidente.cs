using System;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Incident_Response_Ciberperseu
{

    public partial class Resposta_ao_Incidente : Form
    {
        Point lastPoint;

        public Resposta_ao_Incidente()
        {
            InitializeComponent();

            Login.sslstream.Write(Encoding.UTF8.GetBytes("mail_read<EOF>"));
            int i = 0;
            while (true)
            {
                string check = ReadMessage(Login.sslstream);
                if (check == "DONE<EOF>")
                { break; }

                string mail = ReadMessage(Login.sslstream);

                mail_comboBox.Items.Add(mail.Substring(0, mail.Length - 5));

                i = i + 1;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Enviar_button_Click(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("OUTLOOK").Any() == true)
            {
                try
                {
                    var oApp = new Microsoft.Office.Interop.Outlook.Application();

                    Microsoft.Office.Interop.Outlook.NameSpace ns = oApp.GetNamespace("MAPI");
                    var f = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);

                    var mailItem = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.
                        OlItemType.olMailItem);
                    mailItem.Subject = titulo_mail_box.Text.ToString();
                    mailItem.HTMLBody = resposta_incidente_box.Text.ToString();
                    mailItem.To = mail_comboBox.SelectedItem.ToString();
                    mailItem.Send();
                    MessageBox.Show("Mail enviado com sucesso...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Atualizar os dados do Estado
                    string id = id_box.Text.ToString();
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("Estado<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(id + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("Enviado" + "<EOF>"));

                    Close();
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Mail não selecionado...", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("Mail inválido...", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show("Outlook não aberto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void Resposta_ao_Incidente_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Resposta_ao_Incidente_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
