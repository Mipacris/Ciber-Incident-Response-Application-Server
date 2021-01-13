using Incident_Response_Ciber;
using System;
using System.Drawing;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Incident_Response_Ciber
{
    public partial class App_Window : Form
    {
        Point lastPoint;
        public static bool isThreadON;
        public static int counter;
        public static Label chat_counter;
        static string index_server;
        public static Panel window;
        public static TcpClient client;
        public static NetworkStream nwStream;
        public static bool isONChat;
        public static bool isUser;

        //Buttons static field
        public static Button Miss_bt;
        public static Button MissGeral_bt;
        public static Button chat_bt;
        public static Button outlook_bt;
        public static Button config_bt;
        public static Button about_bt;

        public App_Window()
        {
            InitializeComponent();

            // Giving the created buttons the respective public static variable created for
            // later to enable and disable buttons
            Miss_bt = Missoes_button;
            MissGeral_bt = missoes_geral_button;
            chat_bt = chat_button;
            outlook_bt = outlook_button;
            config_bt = configuraçoes_admin;
            about_bt = About_button;

            isONChat = false;
            isUser = false;
            string port_number = Read_Message(Login.sslstream);
            string port = port_number.Substring(0, (port_number.Length - 5));


            // TCP socket initialization
            try
            {
                client = new TcpClient(Login.IP_address, Convert.ToInt32(port));
                nwStream = client.GetStream();
                Thread thr = new Thread(upd_chat);
                thr.Start();
            } catch (Exception e1)
            {
                try
                {
                    if (Login.sslstream.IsAuthenticated == true)
                    {
                        Login.sslstream.Close();
                        Application.Exit();
                    }
                }
                catch (NullReferenceException)
                {
                    Application.Exit();
                }
            }

            window = Window_Panel;

            // Check with the server the number of messages to be read
            int diff = Chat_Update();
            chat_counter = chatCounter;
            if (diff == 0)
            {
                counter = 0;
                chat_counter.Visible = false;
            }
            else
            {
                if (diff < 0)
                {
                    counter = 0;
                    chat_counter.Visible = false;
                }
                else
                {
                    chat_counter.Text = diff.ToString();
                    chat_counter.Visible = true;
                    counter = diff;
                }
            }

            nickname.Text = Login.Username;

            Panel_Color();  // Getting Misson Color on Panel
            SidePanel.Height = Missoes_button.Height;

            // Button options
            Missoes_button.TabStop = false;
            outlook_button.TabStop = false;
            missoes_geral_button.TabStop = false;
            About_button.TabStop = false;
            configuraçoes_admin.TabStop = false;

            Disable_Buttons(); // Disable all buttons until application read

            // Bring to front missoes tab
            Missoes missoes = new Missoes();
            window.Controls.Add(missoes);
        }

        private void upd_chat()
        {
            while (true)
            {
                byte[] messagebytesToRead = new byte[client.ReceiveBufferSize];
                int message_bytesRead = nwStream.Read(messagebytesToRead, 0, client.ReceiveBufferSize);
                string message = Encoding.ASCII.GetString(messagebytesToRead, 0, message_bytesRead);

                if (!isONChat)
                {
                    if (counter == 0)
                    {
                        counter += 1;
                        chat_counter.Invoke((Action)delegate
                        {
                            chat_counter.Text = counter.ToString();
                            chat_counter.Visible = true;
                        });
                    }
                    else
                    {
                        counter += 1;
                        chat_counter.Invoke((Action)delegate
                        {
                            chat_counter.Text = counter.ToString();
                        });
                    }
                }
                else
                {
                    chat_counter.Invoke((Action)delegate
                    {
                        chat_counter.Visible = false;
                    });

                    if (!isUser)
                    {
                        chat.chatWindow.Invoke((Action)delegate
                        {
                            chat.chatWindow.Select(chat.chatWindow.TextLength, 0);
                            chat.chatWindow.SelectionColor = Color.Red;
                            chat.chatWindow.AppendText(message + "\n");
                            chat.chatWindow.SelectionStart = chat.chatWindow.Text.Length;
                            chat.chatWindow.ScrollToCaret();
                        });
                    } else
                    {
                        isUser = false;
                        chat.chatWindow.Invoke((Action)delegate
                        {
                            chat.chatWindow.Select(chat.chatWindow.TextLength, 0);
                            chat.chatWindow.SelectionColor = Color.Black;
                            chat.chatWindow.AppendText(message + "\n");
                            chat.chatWindow.SelectionStart = chat.chatWindow.Text.Length;
                            chat.chatWindow.ScrollToCaret();
                        });
                    }
                    // Updating the values
                    StreamReader index = new StreamReader("C:/Ciber_Save_Data/chat_index.txt");
                    string index_count_string = index.ReadLine();
                    Login.index_count = Convert.ToInt32(index_count_string);
                    index.Close();

                    StreamWriter index_file_writer = new StreamWriter("C:/Ciber_Save_Data/chat_index.txt");
                    index_file_writer.WriteLine((Login.index_count + 1));
                    index_file_writer.Close();
                }
            }
        }

        private static int Chat_Update()
        {
            StreamReader index = new StreamReader("C:/Ciber_Save_Data/chat_index.txt");
            string index_count_string = index.ReadLine();
            Login.index_count = Convert.ToInt32(index_count_string);
            index.Close();

            // Getting to index part
            Login.sslstream.Write(Encoding.UTF8.GetBytes("CHAT_INDEX" + "<EOF>"));
            index_server = Read_Message(Login.sslstream);
            index_server = index_server.Substring(0, (index_server.Length - 5));

            int index_diff = (Convert.ToInt32(index_server) - Login.index_count);

            return index_diff;
        }

        private void Missoes_button_Click(object sender, EventArgs e)
        {
            isONChat = false;
            // Side Panel
            SidePanel.Height = Missoes_button.Height;
            SidePanel.Top = Missoes_button.Top;

            Disable_Buttons(); // Disable all buttons until application read

            // Bring to front missoes tab
            window.Controls.Clear();
            Missoes missoes = new Missoes();
            window.Controls.Add(missoes);
        }

        private void Outlook_button_Click(object sender, EventArgs e)
        {
            isONChat = false;
            // Side Panel
            SidePanel.Height = outlook_button.Height;
            SidePanel.Top = outlook_button.Top;

            Disable_Buttons(); // Disable all buttons until application read

            // Bring to front outlook tab
            window.Controls.Clear();
            outlook outlook_window = new outlook();
            window.Controls.Add(outlook_window);
        }

        private void Missoes_geral_Click(object sender, EventArgs e)
        {
            isONChat = false;
            // Side Panel
            SidePanel.Height = missoes_geral_button.Height;
            SidePanel.Top = missoes_geral_button.Top;
            SidePanel.BringToFront();

            Disable_Buttons(); // Disable all buttons until application read

            // Bring to front Missoes Geral
            window.Controls.Clear();
            Geral geral_window = new Geral();
            window.Controls.Add(geral_window);
        }

        private void Panel_Color()
        {
            switch (Login.MS_ID)
            {
                case ("MS03"):
                    SidePanel.BackColor = Color.FromArgb(255, 192, 128);
                    break;
                case ("MS04"):
                    SidePanel.BackColor = Color.FromArgb(255, 255, 128);
                    break;
                case ("MS05"):
                    SidePanel.BackColor = Color.FromArgb(128, 255, 128);
                    break;
                case ("MS07"):
                    SidePanel.BackColor = Color.FromArgb(128, 128, 255);
                    break;
            }
        }

        private void Window_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Window_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void Minimize_button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void About_button_Click(object sender, EventArgs e)
        {
            isONChat = false;
            // Side Panel
            SidePanel.Height = About_button.Height;
            SidePanel.Top = About_button.Top;
            SidePanel.BringToFront();

            Disable_Buttons(); // Disable all buttons until application read

            // Bring to front Missoes Geral
            window.Controls.Clear();
            About_Sobre_InfoWindow about_window = new About_Sobre_InfoWindow();
            window.Controls.Add(about_window);
        }

        private void Minimize_close_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Minimize_close_panel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Configuraçoes_admin_Click(object sender, EventArgs e)
        {
            isONChat = false;
            // Side Panel
            SidePanel.Height = configuraçoes_admin.Height;
            SidePanel.Top = configuraçoes_admin.Top;
            SidePanel.BringToFront();

            Disable_Buttons(); // Disable all buttons until application read

            // Bring to front Config Admin
            window.Controls.Clear();
            Admin_Config_Tab config_tab = new Admin_Config_Tab();
            window.Controls.Add(config_tab);
        }

        private void Chat_button_Click(object sender, EventArgs e)
        {
            // Side Panel
            SidePanel.Height = chat_button.Height;
            SidePanel.Top = chat_button.Top;
            SidePanel.BringToFront();

            Disable_Buttons(); // Disable all buttons until application read

            // Bring to front Chat Form
            window.Controls.Clear();
            chat chat_form = new chat();
            window.Controls.Add(chat_form);
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

        public static void Disable_Buttons()
        {
            Miss_bt.Enabled = false;
            MissGeral_bt.Enabled = false;
            chat_bt.Enabled = false;
            outlook_bt.Enabled = false;
            config_bt.Enabled = false;
            about_bt.Enabled = false;
        }
        public static void Enable_Buttons()
        {
            Miss_bt.Enabled = true;
            MissGeral_bt.Enabled = true;
            chat_bt.Enabled = true;
            outlook_bt.Enabled = true;
            config_bt.Enabled = true;
            about_bt.Enabled = true;
        }
    }
}
