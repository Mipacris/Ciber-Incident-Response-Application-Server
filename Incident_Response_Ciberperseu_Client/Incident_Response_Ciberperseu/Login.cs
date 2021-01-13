using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Incident_Response_Ciberperseu
{
    public partial class Login : Form
    {
        Thread thread;
        public static SslStream sslstream;
        public static string MS_ID;
        Point lastPoint;
        public static string Username;
        public static Int32 index_count;
        public static string IP_address;

        public Login()
        {
            InitializeComponent();
            string ip;
            string port;

            if (Directory.Exists("C:/Ciberperseu_Save_Data"))
            {
                StreamReader ip_port_file = new StreamReader("C:/Ciberperseu_Save_Data/login_ip_port_registry.txt");
                int count = 0;
                string line;
                while ((line = ip_port_file.ReadLine()) != null)
                {
                    if (count == 0)
                    {
                        ip_box.Text = line;
                        IP_address = ip_box.Text;
                    }
                    else if (count == 1)
                    {
                        port_box.Text = line;
                    }
                    count++;
                }
                ip_port_file.Close();

                StreamReader index = new StreamReader("C:/Ciberperseu_Save_Data/chat_index.txt");
                string index_count_string = index.ReadLine();
                index_count = Convert.ToInt32(index_count_string);
                index.Close();
            }
        }

        // Login Button Click
        private void Button1_Click(object sender, EventArgs e)
        {
            int bytes = -1;
            StreamWriter file;

            if (!Directory.Exists("C:/Ciberperseu_Save_Data"))
            {
                Directory.CreateDirectory("C:/Ciberperseu_Save_Data");
                var file_create = File.Create("C:/Ciberperseu_Save_Data/login_ip_port_registry.txt");
                file_create.Close();

                File.CreateText("C:/Ciberperseu_Save_Data/chat_index.txt").Close();
                StreamWriter chat_index = new StreamWriter("C:/Ciberperseu_Save_Data/chat_index.txt");
                chat_index.WriteLine("0");
                chat_index.Close();
                index_count = 0;
            }

            if (ip_memorizar.Checked == true)
            {
                File.WriteAllText("C:/Ciberperseu_Save_Data/login_ip_port_registry.txt", String.Empty);
                file = new StreamWriter("C:/Ciberperseu_Save_Data/login_ip_port_registry.txt");
                file.WriteLine(ip_box.Text);
                file.WriteLine(port_box.Text);
                file.Close();
            }

            try
            {
                // Create a TCP/IP  socket.    
                TcpClient client = new TcpClient(ip_box.Text, Convert.ToInt32(port_box.Text));

                NetworkStream netStream = client.GetStream();
                // SSL Stream
                sslstream = new SslStream(netStream, false,
                    new RemoteCertificateValidationCallback(ValidateServerCertificate));

                sslstream.AuthenticateAsClient("ciberperseu_cert");

                byte[] buffer = new byte[2048];

                // Sending a Login Credentials
                sslstream.Write(Encoding.UTF8.GetBytes(username_box.Text + "<EOF>"));
                sslstream.Write(Encoding.UTF8.GetBytes(password_box.Text + "<EOF>"));

                string username_message = ReadMessage(sslstream); // Getting username from server
                Username = username_message.Substring(0, (username_message.Length - 5));

                string message = ReadMessage(sslstream);
                // See what was the server message
                if (message == "Logged in admin<EOF>")
                {
                    Login_Log_Data(Username, "ADMIN");
                    MessageBox.Show("Login successful...", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MS_ID = "ADMIN";
                    this.Hide();
                    this.Parent = null;
                    App_Window app_window_form = new App_Window();
                    app_window_form.Show();

                }
                else if (message == "Logged in ms03<EOF>")
                {
                    Login_Log_Data(Username, "MS03");
                    MessageBox.Show("Login successful...", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MS_ID = "MS03";
                    this.Hide();
                    this.Parent = null;
                    App_Window app_window_form = new App_Window();
                    app_window_form.Show();
                }
                else if (message == "Logged in ms04<EOF>")
                {
                    Login_Log_Data(Username, "MS04");
                    MessageBox.Show("Login successful...", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MS_ID = "MS04";
                    this.Hide();
                    this.Parent = null;
                    App_Window app_window_form = new App_Window();
                    app_window_form.Show();
                }
                else if (message == "Logged in ms05<EOF>")
                {
                    Login_Log_Data(Username, "MS05");
                    MessageBox.Show("Login successful...", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MS_ID = "MS05";
                    this.Hide();
                    this.Parent = null;
                    App_Window app_window_form = new App_Window();
                    app_window_form.Show();
                }
                else if (message == "Logged in ms07<EOF>")
                {
                    Login_Log_Data(Username, "MS07");
                    MessageBox.Show("Login successful...", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MS_ID = "MS07";
                    this.Hide();
                    this.Parent = null;
                    App_Window app_window_form = new App_Window();
                    app_window_form.Show();
                }
                else if (message == "Error2<EOF>")
                {
                    MessageBox.Show("This account is already logged in...", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);                  
                }
                else
                {
                    MessageBox.Show("Login Invalid...", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }

            }
            catch (Exception e1)
            {
                try
                {
                    if (sslstream.IsAuthenticated == true)
                    {
                        sslstream.Close();
                        MessageBox.Show("Possible Errors: \n" +
                        "Server is Down\n" +
                        "Internet is Off\n" +
                        "Program is not running in administrator\n" +
                        "If possible try again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                } catch (NullReferenceException)
                {
                    MessageBox.Show("Possible Errors: \n" +
                    "Server is Down\n" +
                    "Internet is Off\n" +
                    "Program is not running in administrator\n" +
                    "If possible try again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain,
          SslPolicyErrors sslPolicyErrors)
        {
            return true; // Allow untrusted certificates
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

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Close_login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_login_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Login_Log_Data(string username, string missao)
        {
            // Sending Login Log Register Data to Server
            string pubIP = new WebClient().DownloadString("https://api.ipify.org");
            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);

            sslstream.Write(Encoding.UTF8.GetBytes(pubIP + "<EOF>"));
            sslstream.Write(Encoding.UTF8.GetBytes(hm + "<EOF>"));
            sslstream.Write(Encoding.UTF8.GetBytes(username + "<EOF>"));
            sslstream.Write(Encoding.UTF8.GetBytes(missao + "<EOF>"));
        }
    }

}
