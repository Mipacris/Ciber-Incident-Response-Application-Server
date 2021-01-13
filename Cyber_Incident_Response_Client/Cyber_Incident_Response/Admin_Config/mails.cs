using System;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cyber_Incident_Response
{
    public partial class mails : UserControl
    {
        public mails()
        {
            InitializeComponent();

            App_Window.Disable_Buttons();
            Admin_Config_Tab.Disable_Config_Buttons();

            Login.sslstream.Write(Encoding.UTF8.GetBytes("mail_read<EOF>"));
            int i = 0;
            while (true)
            {
                string check = ReadMessage(Login.sslstream);
                if (check == "DONE<EOF>")
                { break; }

                string mail = ReadMessage(Login.sslstream);

                lista_mails.Items.Add(mail.Substring(0, mail.Length - 5));

                i = i + 1;
            }

            App_Window.Enable_Buttons();
            Admin_Config_Tab.Enable_Config_Buttons();
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

        private void Add_mail_Click(object sender, EventArgs e)
        {
            if ((mail_box.Text != null) || (mail_box.Text != ""))
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("mail_add<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(mail_box.Text + "<EOF>"));
                MessageBox.Show("Mail adicionado...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refreshing
                Controls.Clear();
                mails admin_mails = new mails();
                Controls.Add(admin_mails);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if ((lista_mails.SelectedItem.ToString() != null) || lista_mails.SelectedItem.ToString() != "")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("mail_remove<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(lista_mails.SelectedItem.ToString() + "<EOF>"));
                MessageBox.Show("Mail removido...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Refreshing
                Controls.Clear();
                mails admin_mails = new mails();
                Controls.Add(admin_mails);
            }
        }
    }
}
