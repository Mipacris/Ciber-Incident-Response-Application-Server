using System;
using System.Drawing;
using System.IO;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cyber_Incident_Response
{
    public partial class chat : UserControl
    {
        public static RichTextBox chatWindow;

        public chat()
        {
            InitializeComponent();
            chatWindow = chat_window;

            if (Login.MS_ID != "ADMIN") { Controls.Remove(delete); }

            StreamReader index = new StreamReader("C:/Cyber_Save_Data/chat_index.txt");
            string index_count_string = index.ReadLine();
            Login.index_count = Convert.ToInt32(index_count_string);
            index.Close();

            // Getting to index part
            Login.sslstream.Write(Encoding.UTF8.GetBytes("CHAT_INDEX" + "<EOF>"));
            string index_server = Read_Message(Login.sslstream);
            index_server = index_server.Substring(0, (index_server.Length - 5));

            Login.sslstream.Write(Encoding.UTF8.GetBytes("CHAT" + "<EOF>"));
            int count_line = 1;
            while (true)
            {
                string message = Read_Message(Login.sslstream);
                if (message == "OK<EOF>") { break; }
                else
                {
                    if (count_line > Login.index_count)
                    {
                        chat_window.Select(chat_window.TextLength, 0);
                        chat_window.SelectionColor = Color.Red;
                        chat_window.AppendText(message.Substring(0, (message.Length - 5)) + "\n");
                    }
                    else
                    {
                        chat_window.Select(chat_window.TextLength, 0);
                        chat_window.SelectionColor = Color.Black;
                        chat_window.AppendText(message.Substring(0, (message.Length - 5)) + "\n");
                    }

                    count_line += 1;
                }
            }

            // Put the recent messages to red for the client to read
            App_Window.chat_counter.Visible = false;
            App_Window.counter = 0;

            // Updating the values
            if ((index_server != "0") && (Login.index_count < Convert.ToInt32(index_server)))
            {
                StreamWriter index_file_writer = new StreamWriter("C:/Cyber_Save_Data/chat_index.txt");
                index_file_writer.WriteLine(index_server);
                index_file_writer.Close();
            }
            else if (index_server == "0")
            {
                StreamWriter index_file_writer = new StreamWriter("C:/Cyber_Save_Data/chat_index.txt");
                index_file_writer.WriteLine("0");
                index_file_writer.Close();
            }
            else if (Login.index_count < Convert.ToInt32(index_server))
            {
                StreamWriter index_file_writer = new StreamWriter("C:/Cyber_Save_Data/chat_index.txt");
                index_file_writer.WriteLine(index_server);
                index_file_writer.Close();
            }

            chat_window.SelectionStart = chat_window.Text.Length;
            chat_window.ScrollToCaret();

            App_Window.Enable_Buttons(); // Enable buttons again at the end...
            //Put ONChat bool ON for Chat TCP thread
            App_Window.isONChat = true;
        }

        private void Enviar_button_Click(object sender, EventArgs e)
        {
            if (enviar_window.Text != "")
            {
                Login.sslstream.Write(Encoding.UTF8.GetBytes("CHAT_SEND" + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(Login.Username + "<EOF>"));

                var src = DateTime.Now;
                var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);
                Login.sslstream.Write(Encoding.UTF8.GetBytes(hm + "<EOF>"));

                Login.sslstream.Write(Encoding.UTF8.GetBytes(enviar_window.Text + "<EOF>"));
                enviar_window.Text = "";

                App_Window.isUser = true;
            }
            else
            {
                MessageBox.Show("Sem texto para enviar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Get_Update()
        {
            // Getting to index part
            Login.sslstream.Write(Encoding.UTF8.GetBytes("CHAT_INDEX" + "<EOF>"));
            string index_server = Read_Message(Login.sslstream);
            index_server = index_server.Substring(0, (index_server.Length - 5));

            // Updating the values
            StreamWriter index_file_writer = new StreamWriter("C:/Cyber_Save_Data/chat_index.txt");
            index_file_writer.WriteLine(index_server);
            index_file_writer.Close();
        }

        static string Read_Message(SslStream sslStream)
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

        private void Delete_Click(object sender, EventArgs e)
        {
            Login.sslstream.Write(Encoding.UTF8.GetBytes("DELETE_CHAT<EOF>"));
            chat_window.Clear();
        }
    }
}
