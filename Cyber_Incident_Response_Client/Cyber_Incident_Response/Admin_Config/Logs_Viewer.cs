using System;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cyber_Incident_Response
{
    public partial class Logs_Viewer : UserControl
    {
        public Logs_Viewer()
        {
            InitializeComponent();

            App_Window.Disable_Buttons();
            Admin_Config_Tab.Disable_Config_Buttons();

            Login.sslstream.Write(Encoding.UTF8.GetBytes("Logs<EOF>"));
            int i = 0;
            while (true)
            {
                string check = ReadMessage(Login.sslstream);
                if (check == "DONE<EOF>")
                { break; }
                string ip = ReadMessage(Login.sslstream);
                string data = ReadMessage(Login.sslstream);
                string username = ReadMessage(Login.sslstream);
                string missao = ReadMessage(Login.sslstream);

                Logs_DataGrid.Rows.Add();
                Logs_DataGrid.Rows[i].Cells["IP"].Value = ip.Substring(0, (ip.Length - 5));
                Logs_DataGrid.Rows[i].Cells["Data"].Value = data.Substring(0, (data.Length - 5));
                Logs_DataGrid.Rows[i].Cells["Username"].Value = username.Substring(0, (username.Length - 5));
                Logs_DataGrid.Rows[i].Cells["Missao"].Value = missao.Substring(0, (missao.Length - 5));

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
    }
}
