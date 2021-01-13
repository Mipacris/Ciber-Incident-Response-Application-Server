using System;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cyber_Incident_Response
{
    public partial class criar_perfil : UserControl
    {
        public criar_perfil()
        {
            InitializeComponent();

            App_Window.Disable_Buttons();
            Admin_Config_Tab.Disable_Config_Buttons();

            Login.sslstream.Write(Encoding.UTF8.GetBytes("username_read<EOF>"));
            int i = 0;
            while (true)
            {
                string check = ReadMessage(Login.sslstream);
                if (check == "DONE<EOF>")
                { break; }

                string usernames = ReadMessage(Login.sslstream);

                username_combobox.Items.Add(usernames.Substring(0, usernames.Length - 5));

                i = i + 1;
            }

            App_Window.Enable_Buttons();
            Admin_Config_Tab.Enable_Config_Buttons();
        }

        private void Criar_button_Click(object sender, EventArgs e)
        {
            if ((username_box.Text.Length == 0) || (password_box.Text.Length == 0) ||
                (nickname_box.Text.ToString().Length == 0))
            {
                MessageBox.Show("É necessário preencher todos os campos...", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string username = username_box.Text.ToString();
                    string password = password_box.Text.ToString();
                    string nickname = nickname_box.Text.ToString();
                    string missao = missao_comboBox.SelectedItem.ToString();

                    // Sending data to server
                    Login.sslstream.Write(Encoding.UTF8.GetBytes("Novo_Perfil<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(username + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(password + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(nickname + "<EOF>"));
                    Login.sslstream.Write(Encoding.UTF8.GetBytes(missao + "<EOF>"));

                    string username_message = ReadMessage(Login.sslstream);
                    if (username_message.Substring(0, username_message.Length - 5) == "username_error")
                    {
                        MessageBox.Show("Username já pertence á utilizado...Por favor tente outro...", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Perfil Criado com sucesso", "Perfil Criado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Refreshing
                    Controls.Clear();
                    criar_perfil perfil = new criar_perfil();
                    Controls.Add(perfil);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("É necessário atribuir uma missão ao perfil", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void Remover_button_Click(object sender, EventArgs e)
        {
            if ((username_combobox.SelectedItem.ToString() != null) || username_combobox.SelectedItem.ToString() != "")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("user_remove<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(username_combobox.SelectedItem.ToString() + "<EOF>"));
                MessageBox.Show("Utilizador removido...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refreshing
                Controls.Clear();
                criar_perfil perfil = new criar_perfil();
                Controls.Add(perfil);
            }
        }
    }
}
