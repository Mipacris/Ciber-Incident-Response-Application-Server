using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Security.Authentication;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Net.NetworkInformation;
using System.Collections;

namespace ciber_server_console
{

    class Program
    {

        public static ArrayList client_list = new ArrayList();
        public static ArrayList client_chat_list = new ArrayList();
        public static ArrayList user_list = new ArrayList();
        public static Int32 port = 10000;
        static void Main(string[] args)
        {
            TcpClient client;

            // Ciber Server Folder
            if (!Directory.Exists("C:/Ciber_Server_Data"))
            {
                Directory.CreateDirectory("C:/Ciber_Server_Data");
                XML_FileCreation("C:/Ciber_Server_Data/MS03.xml");
                XML_FileCreation("C:/Ciber_Server_Data/MS04.xml");
                XML_FileCreation("C:/Ciber_Server_Data/MS05.xml");
                XML_FileCreation("C:/Ciber_Server_Data/MS07.xml");
                XML_FileCreation("C:/Ciber_Server_Data/MS_Geral.xml");
                XML_FileCreation("C:/Ciber_Server_Data/Accounts.xml");
                XML_FileCreation("C:/Ciber_Server_Data/Logs.xml");
                XML_FileCreation("C:/Ciber_Server_Data/Mails.xml");
                File.CreateText("C:/Ciber_Server_Data/chat.txt").Close();
                File.CreateText("C:/Ciber_Server_Data/chat_index.txt").Close();

                FileStream chat_index = File.OpenWrite("C:/Ciber_Server_Data/chat_index.txt");
                StreamWriter chat_index_new = new StreamWriter(chat_index);
                chat_index_new.WriteLine("0");
                chat_index_new.Close();

                

                XDocument xml_doc = new XDocument();
                xml_doc = XDocument.Load("C:/Ciber_Server_Data/Accounts.xml");
                xml_doc.Element("root").Add(new XElement("Account", "admin",
                    new XElement("password","admin"),
                    new XElement("nickname","Admin"),
                    new XElement("missao","ADMIN")));
                xml_doc.Save("C:/Ciber_Server_Data/Accounts.xml");
            }

            // Creating TCP/IP (IPV4) socket and listen for incoming connections

            Int32 Port = 9000; // Port

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, Port);
            Console.WriteLine("Local IP Address - Wireless: " + GetLocalIPv4(NetworkInterfaceType.Wireless80211));
            Console.WriteLine("Local IP Address - Ethernet: " + GetLocalIPv4(NetworkInterfaceType.Ethernet));
            Console.WriteLine("Port: " + Port);
            Console.WriteLine("Public IP: " + GetPublicIP());
            TcpListener listener = new TcpListener(endpoint);
            listener.Start();
            while (true)
            {
                Console.WriteLine("Waiting for Client connection...");
                client = listener.AcceptTcpClient();

                handleClient handler = new handleClient();
                handler.startClient(client);

            }

        }

        private static void XML_FileCreation(string path)
        {
            var xml = File.Create(path);
            xml.Close();
            new XDocument(
                new XElement("root")).Save(path);
        }

        public static string GetLocalIPv4(NetworkInterfaceType _type) 
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                    
                }
            }
            return output;
        }

        public static string GetPublicIP()
        {
            string pubIP = "";
            try
            {
                pubIP = new WebClient().DownloadString("https://api.ipify.org");
            }
            catch (WebException)
            {
                pubIP = "No Internet Connection";
            }
            return pubIP;
        }
    }

    public class handleClient
    {
        TcpClient client;
        static X509Certificate2 servercertificate = null;
        string id;
        string comentario;
        string concluido;
        string resposta;
        Socket serverSocket;
        byte[] byteData = new byte[1024];

        public void startClient(TcpClient inClientSocket)
        {
            client = inClientSocket;
            Thread thread = new Thread(delegate() { connection(); });
            thread.Start();

        }

        private void connection()
        {
            string username = null;
            NetworkStream nwStream = null;

            servercertificate = new X509Certificate2("C:/ciber_cert.pfx", "ciber");
            NetworkStream netstream = client.GetStream();
            // A client has connected. Create the SSL Stream using client network stream
            SslStream sslStream = new SslStream(netstream, false);

            Program.client_list.Add(sslStream);
            // Authenticate the server but dont require client to authenticate
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                sslStream.AuthenticateAsServer(servercertificate, false, SslProtocols.Tls12, true);
                string MessageData;
                byte[] message_missao;
                byte[] nickname;
                string ip = "";
                string date = "";
                string user = "";
                string mission = "";

                // Handling a possible forced closed

                username = ReadMessage(sslStream);
                string password = ReadMessage(sslStream);

                // Check on XML account list
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("C:/Ciber_Server_Data/Accounts.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList node_list = root.SelectNodes("Account");

                bool isUserRepetead = false;
                foreach (string row in Program.user_list)
                {
                    if (row.Contains(username.Substring(0, (username.Length - 5))))
                    {
                        isUserRepetead = true;
                    } 
                }
                if (!isUserRepetead) { Program.user_list.Add(username); }

                int i = 0;
                foreach (XmlNode node in node_list)
                {
                    if (username.Substring(0, (username.Length - 5)) == node_list.Item(i).ChildNodes[0].Value.ToString())
                    {
                        if (password.Substring(0, (password.Length - 5)) == node["password"].InnerText)
                        {
                            if (isUserRepetead)
                            {
                                sslStream.Write(Encoding.UTF8.GetBytes("Random_Message<EOF>"));
                                sslStream.Write(Encoding.UTF8.GetBytes("Error2<EOF>"));
                                isUserRepetead = false;
                                break;
                            }

                            string missao = node["missao"].InnerText.ToString();
                            string nick = node["nickname"].InnerText.ToString();
                            if (missao == "MS03")
                            {
                                nickname = Encoding.UTF8.GetBytes(nick + "<EOF>");
                                sslStream.Write(nickname);

                                message_missao = Encoding.UTF8.GetBytes("Logged in ms03<EOF>");
                                sslStream.Write(message_missao);

                                ip = ReadMessage(sslStream);
                                date = ReadMessage(sslStream);
                                user = ReadMessage(sslStream);
                                mission = ReadMessage(sslStream);
                            }
                            else if (missao == "MS04")
                            {
                                nickname = Encoding.UTF8.GetBytes(nick + "<EOF>");
                                sslStream.Write(nickname);

                                message_missao = Encoding.UTF8.GetBytes("Logged in ms04<EOF>");
                                sslStream.Write(message_missao);

                                ip = ReadMessage(sslStream);
                                date = ReadMessage(sslStream);
                                user = ReadMessage(sslStream);
                                mission = ReadMessage(sslStream);
                            }
                            else if (missao == "MS05")
                            {
                                nickname = Encoding.UTF8.GetBytes(nick + "<EOF>");
                                sslStream.Write(nickname);

                                message_missao = Encoding.UTF8.GetBytes("Logged in ms05<EOF>");
                                sslStream.Write(message_missao);

                                ip = ReadMessage(sslStream);
                                date = ReadMessage(sslStream);
                                user = ReadMessage(sslStream);
                                mission = ReadMessage(sslStream);
                            }
                            else if (missao == "MS07")
                            {
                                nickname = Encoding.UTF8.GetBytes(nick + "<EOF>");
                                sslStream.Write(nickname);

                                message_missao = Encoding.UTF8.GetBytes("Logged in ms07<EOF>");
                                sslStream.Write(message_missao);

                                ip = ReadMessage(sslStream);
                                date = ReadMessage(sslStream);
                                user = ReadMessage(sslStream);
                                mission = ReadMessage(sslStream);
                            }
                            else if (missao == "ADMIN")
                            {
                                nickname = Encoding.UTF8.GetBytes(nick + "<EOF>");
                                sslStream.Write(nickname);

                                message_missao = Encoding.UTF8.GetBytes("Logged in admin<EOF>");
                                sslStream.Write(message_missao);

                                ip = ReadMessage(sslStream);
                                date = ReadMessage(sslStream);
                                user = ReadMessage(sslStream);
                                mission = ReadMessage(sslStream);
                            }
                            break;
                        }
                    }
                    i = i + 1;
                }

                XDocument log_xml = new XDocument();
                log_xml = XDocument.Load("C:/Ciber_Server_Data/Logs.xml");
                log_xml.Element("root").Add(new XElement("Log", "",
                    new XElement("ip", ip.Substring(0, (ip.Length - 5))),
                    new XElement("date", date.Substring(0, (date.Length - 5))),
                    new XElement("user", user.Substring(0, (user.Length - 5))),
                    new XElement("mission", mission.Substring(0, (mission.Length - 5)))));
                log_xml.Save("C:/Ciber_Server_Data/Logs.xml");

                /*                      TCP chat server
                 */
                //////////////////////////////////////////////////////////
                sslStream.Write(Encoding.UTF8.GetBytes(Program.port + "<EOF>"));
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, Program.port);
                Program.port += 1;
                TcpListener listener = new TcpListener(endpoint);
                //---incoming client connected---
                listener.Start();
                TcpClient client = listener.AcceptTcpClient();
                //---get the incoming data through a network stream---
                nwStream = client.GetStream();
                Program.client_chat_list.Add(nwStream);

                //////////////////////////////////////////////////////////////////

                while (true)
                {
                    try
                    {
                        MessageData = ReadMessage(sslStream);
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Client closed connection...");
                        sslStream.Close();
                        Program.client_list.Remove(sslStream);
                        Program.user_list.Remove(username);
                        Program.client_chat_list.Remove(nwStream);
                        break;
                    }


                    byte[] message;
                    string my_username;

                    // Write message to client
                    switch (MessageData)
                    {
                        // Chat
                        case ("CHAT<EOF>"):
                            Chat_request(sslStream);
                            break;

                        case ("CHAT_SEND<EOF>"):
                            Chat_Send(sslStream, nwStream);
                            break;

                        case ("CHAT_INDEX<EOF>"):
                            Chat_Index(sslStream);
                            break;

                        case ("DELETE_CHAT<EOF>"):
                            Chat_Delete(sslStream);
                            break;
                        
                        // Perfil Creation
                        case ("Novo_Perfil<EOF>"):
                            Perfil(sslStream);
                            break;

                        case ("username_read<EOF>"):
                            Usernames_Read(sslStream);
                            break;

                        case ("user_remove<EOF>"):
                            Usernames_Remove(sslStream);
                            break;

                        // Logs Reader
                        case ("Logs<EOF>"):
                            Logs(sslStream);
                            break;

                        // Mail Admin Read
                        case ("mail_read<EOF>"):
                            Mail_Read(sslStream);
                            break;
                        // Mail Admin Add
                        case ("mail_add<EOF>"):
                            Mail_Add(sslStream);
                            break;

                        // Main Admin Remove
                        case ("mail_remove<EOF>"):
                            Mail_Remove(sslStream);
                            break;

                        // Mails Injection
                        case ("MS03<EOF>"):
                            Inject("MS03.xml", sslStream, "MS03");
                            break;
                        case ("MS04<EOF>"):
                            Inject("MS04.xml", sslStream, "MS04");
                            break;
                        case ("MS05<EOF>"):
                            Inject("MS05.xml", sslStream, "MS05");
                            break;
                        case ("MS07<EOF>"):
                            Inject("MS07.xml", sslStream, "MS07");
                            break;

                        // Missons Mails Send
                        case ("MS03_XML<EOF>"):
                            XML_SEND("C:/Ciber_Server_Data/MS03.xml", sslStream);
                            break;
                        case ("MS04_XML<EOF>"):
                            XML_SEND("C:/Ciber_Server_Data/MS04.xml", sslStream);
                            break;
                        case ("MS05_XML<EOF>"):
                            XML_SEND("C:/Ciber_Server_Data/MS05.xml", sslStream);
                            break;
                        case ("MS07_XML<EOF>"):
                            XML_SEND("C:/Ciber_Server_Data/MS07.xml", sslStream);
                            break;

                        // Mission Resposta and Comentario Changed
                        case ("MS03_MissionChange<EOF>"):
                            id = ReadMessage(sslStream);
                            resposta = ReadMessage(sslStream);
                            comentario = ReadMessage(sslStream);
                            my_username = ReadMessage(sslStream);
                            XML_MissionChange("MS03.xml", id, resposta, comentario);
                            XML_Geral_MissionChange("MS_Geral.xml", id, resposta, comentario, my_username);
                            break;
                        case ("MS04_MissionChange<EOF>"):
                            id = ReadMessage(sslStream);
                            resposta = ReadMessage(sslStream);
                            comentario = ReadMessage(sslStream);
                            my_username = ReadMessage(sslStream);
                            XML_MissionChange("MS04.xml", id, resposta, comentario);
                            XML_Geral_MissionChange("MS_Geral.xml", id, resposta, comentario, my_username);
                            break;
                        case ("MS05_MissionChange<EOF>"):
                            id = ReadMessage(sslStream);
                            resposta = ReadMessage(sslStream);
                            comentario = ReadMessage(sslStream);
                            my_username = ReadMessage(sslStream);
                            XML_MissionChange("MS05.xml", id, resposta, comentario);
                            XML_Geral_MissionChange("MS_Geral.xml", id, resposta, comentario, my_username);
                            break;
                        case ("MS07_MissionChange<EOF>"):
                            id = ReadMessage(sslStream);
                            resposta = ReadMessage(sslStream);
                            comentario = ReadMessage(sslStream);
                            my_username = ReadMessage(sslStream);
                            XML_MissionChange("MS07.xml", id, resposta, comentario);
                            XML_Geral_MissionChange("MS_Geral.xml", id, resposta, comentario, my_username);
                            break;

                        // Mission Concluido Changed
                        case ("MS03_Concluido<EOF>"):
                            id = ReadMessage(sslStream);
                            concluido = ReadMessage(sslStream);
                            XML_Concluido("MS03.xml", id, concluido);
                            XML_Geral_Concluido("MS_Geral.xml", id, concluido);
                            break;
                        case ("MS04_Concluido<EOF>"):
                            id = ReadMessage(sslStream);
                            concluido = ReadMessage(sslStream);
                            XML_Concluido("MS04.xml", id, concluido);
                            XML_Geral_Concluido("MS_Geral.xml", id, concluido);
                            break;
                        case ("MS05_Concluido<EOF>"):
                            id = ReadMessage(sslStream);
                            concluido = ReadMessage(sslStream);
                            XML_Concluido("MS05.xml", id, concluido);
                            XML_Geral_Concluido("MS_Geral.xml", id, concluido);
                            break;
                        case ("MS07_Concluido<EOF>"):
                            id = ReadMessage(sslStream);
                            concluido = ReadMessage(sslStream);
                            XML_Concluido("MS07.xml", id, concluido);
                            XML_Geral_Concluido("MS_Geral.xml", id, concluido);
                            break;

                        // Mission Geral Details
                        case ("MS_GERAL<EOF>"):
                            XML_Geral_SEND("C:/Ciber_Server_Data/MS_Geral.xml", sslStream);
                            break;

                        case ("Estado<EOF>"):
                            Estado_Change(sslStream);
                            break;

                        //THREAD
                        case ("THREAD_RESET<EOF>"):
                            byte[] thread_reset = Encoding.UTF8.GetBytes("RESET<EOF>");
                            sslStream.Write(thread_reset);
                            break;

                        case null:
                            byte[] error_message = Encoding.UTF8.GetBytes("Error<EOF>");
                            sslStream.Write(error_message);
                            break;
                    }
                }
            }
            catch (NullReferenceException)
            {
                byte[] random_message = Encoding.UTF8.GetBytes("Random_Message<EOF>");
                sslStream.Write(random_message);
                byte[] error_message = Encoding.UTF8.GetBytes("Error<EOF>");
                sslStream.Write(error_message);
            }
            catch (ArgumentOutOfRangeException)
            {
                byte[] random_message = Encoding.UTF8.GetBytes("Random_Message<EOF>");
                sslStream.Write(random_message);
                byte[] error_message = Encoding.UTF8.GetBytes("Error<EOF>");
                sslStream.Write(error_message);
                Console.WriteLine("Closed connection...");
                sslStream.Close();
                sslStream.Close();
                Program.client_list.Remove(sslStream);
                Program.user_list.Remove(username);
                Program.client_chat_list.Remove(nwStream);
            }

            catch (IOException)
            {
                Console.WriteLine("Error due to certificate or connection...");
            }
        }
        
        static String ReadMessage(SslStream sslstream)
        {
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;

                do
                {
                    // Read the client's test message
                    bytes = sslstream.Read(buffer, 0, buffer.Length);
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

        private void Inject(string missaoXML, SslStream sslStream, string missao_geral)
        {
            while (true)
            {
                string check_msg = ReadMessage(sslStream);
                if (check_msg == "END_INJECT<EOF>")
                {
                    Console.WriteLine("inject Mission received...");
                    break;
                }

                id = ReadMessage(sslStream);
                string remetente = ReadMessage(sslStream);
                string titulo = ReadMessage(sslStream);
                string corpo = ReadMessage(sslStream);
                string data = ReadMessage(sslStream);

                XML_Append(missaoXML, id, remetente, titulo, corpo, data);
                XML_Geral_Append("MS_Geral.xml", id, missao_geral, titulo, data);
            }
        }

        private void XML_Append(string missaoXML, string ID, string remetente, string titulo, string corpo, string data)
        {
            XDocument xml_doc = new XDocument();
            xml_doc = XDocument.Load("C:/Ciber_Server_Data/" + missaoXML);
            xml_doc.Element("root").Add(new XElement("ID", ID.Substring(0, (ID.Length - 5)),
                new XElement("remetente", remetente.Substring(0, (remetente.Length - 5))),
                new XElement("titulo", titulo.Substring(0, (titulo.Length - 5))),
                new XElement("corpo", corpo.Substring(0, (corpo.Length - 5))),
                new XElement("data", data.Substring(0, (data.Length - 5))),
                new XElement("resposta", ""),
                new XElement("comentarios", ""),
                new XElement("concluido", "nao")));
            xml_doc.Save("C:/Ciber_Server_Data/" + missaoXML);
        }

        private void XML_SEND(string path, SslStream sslStream)
        {
            byte[] message;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("ID");

                int i = 0;
                foreach (XmlNode node in node_list)
                {

                    string id_node = Convert.ToString(node_list.Item(i).ChildNodes[0].Value);
                    string remetente_node = Convert.ToString(node["remetente"].InnerText);
                    string titulo_node = Convert.ToString(node["titulo"].InnerText);
                    string corpo_node = Convert.ToString(node["corpo"].InnerText);
                    string data_node = Convert.ToString(node["data"].InnerText);
                    string resposta_node = Convert.ToString(node["resposta"].InnerText);
                    string comentarios_node = Convert.ToString(node["comentarios"].InnerText);
                    string concluido_node = Convert.ToString(node["concluido"].InnerText);

                    message = Encoding.UTF8.GetBytes("OK<EOF>"); // Sending OK message
                    sslStream.Write(message);
                    message = Encoding.UTF8.GetBytes(id_node + "<EOF>"); // Sending ID 
                    sslStream.Write(message);
                    message = Encoding.UTF8.GetBytes(remetente_node + "<EOF>"); // Sending remetente 
                    sslStream.Write(message);
                    message = Encoding.UTF8.GetBytes(titulo_node + "<EOF>"); // Sending Titulo
                    sslStream.Write(message);
                    message = Encoding.UTF8.GetBytes(corpo_node + "<EOF>"); // Sending corpo
                    sslStream.Write(message);
                    message = Encoding.UTF8.GetBytes(data_node + "<EOF>"); // Sending data
                    sslStream.Write(message);
                    message = Encoding.UTF8.GetBytes(resposta_node + "<EOF>"); // Sending data
                    sslStream.Write(message);
                    message = Encoding.UTF8.GetBytes(comentarios_node + "<EOF>"); // Sending comentarios
                    sslStream.Write(message);
                    message = Encoding.UTF8.GetBytes(concluido_node + "<EOF>"); // Sending comentarios
                    sslStream.Write(message);

                    i = i + 1;
                }
                message = Encoding.UTF8.GetBytes("DONE<EOF>");
                sslStream.Write(message);
        }

        private void XML_MissionChange(string missaoXML, string id, string resposta,string comentario)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/" + missaoXML);
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("ID");

            int i = 0;
            foreach (XmlNode node in node_list)
            {
                if (id.Substring(0, (id.Length - 5)) == node_list.Item(i).ChildNodes[0].Value.ToString())
                {
                    node["resposta"].InnerText = "";
                    node["resposta"].InnerText = resposta.Substring(0, (resposta.Length - 5));
                    node["comentarios"].InnerText = "";
                    node["comentarios"].InnerText = comentario.Substring(0, (comentario.Length - 5));
                    break;
                }
                i = i + 1;
            }

            xmlDoc.Save("C:/Ciber_Server_Data/" + missaoXML);
        }

        private void XML_Concluido(string missaoXML, string id, string concluido)
        {

            if (concluido.Equals("True<EOF>"))
            { concluido = "sim"; }
            else
            { concluido = "nao"; }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/" + missaoXML);
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("ID");

            int i = 0;
            foreach (XmlNode node in node_list)
            {
                if (id.Substring(0, (id.Length - 5)) == node_list.Item(i).ChildNodes[0].Value.ToString())
                {
                    node["concluido"].InnerText = "";
                    node["concluido"].InnerText = concluido;
                    break;
                }
                i = i + 1;
            }

            xmlDoc.Save("C:/Ciber_Server_Data/" + missaoXML);
        }

        private void XML_Geral_Append(string xmlGeral, string ID, string missao, string titulo, string data)
        {
            XDocument xml_doc = new XDocument();
            xml_doc = XDocument.Load("C:/Ciber_Server_Data/" + xmlGeral);
            xml_doc.Element("root").Add(new XElement("ID", ID.Substring(0, (ID.Length - 5)),
                new XElement("missao", missao),
                new XElement("titulo", titulo.Substring(0, (titulo.Length - 5))),
                new XElement("data", data.Substring(0, (data.Length - 5))),
                new XElement("resposta", ""),
                new XElement("utilizador_data", ""),
                new XElement("comentarios", ""),
                new XElement("concluido", "nao"),
                new XElement("estado","Não Enviado")));
            xml_doc.Save("C:/Ciber_Server_Data/" + xmlGeral);
        }

        private void XML_Geral_SEND(string path, SslStream sslStream)
        {
            byte[] message;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("ID");

            int i = 0;
            foreach (XmlNode node in node_list)
            {

                string id_node = Convert.ToString(node_list.Item(i).ChildNodes[0].Value);
                string missao_node = Convert.ToString(node["missao"].InnerText); 
                string titulo_node = Convert.ToString(node["titulo"].InnerText); 
                string data_node = Convert.ToString(node["data"].InnerText);
                string resposta_node = Convert.ToString(node["resposta"].InnerText);
                string utilizador_data_node = Convert.ToString(node["utilizador_data"].InnerText);
                string comentarios_node = Convert.ToString(node["comentarios"].InnerText);
                string concluido_node = Convert.ToString(node["concluido"].InnerText);
                string estado_node = Convert.ToString(node["estado"].InnerText);

                message = Encoding.UTF8.GetBytes("OK<EOF>"); // Sending OK message
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(id_node + "<EOF>"); // Sending ID 
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(missao_node + "<EOF>"); // Sending remetente 
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(titulo_node + "<EOF>"); // Sending Titulo
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(data_node + "<EOF>"); // Sending data
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(resposta_node + "<EOF>"); // Sending data
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(utilizador_data_node + "<EOF>"); // Sending data
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(comentarios_node + "<EOF>"); // Sending comentarios
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(concluido_node + "<EOF>"); // Sending concluido
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(estado_node + "<EOF>"); // Sending estado
                sslStream.Write(message);

                i = i + 1;
            }
            message = Encoding.UTF8.GetBytes("DONE<EOF>");
            sslStream.Write(message);
        }

        private void XML_Geral_MissionChange(string xmlGeral, string id, string resposta, string comentario, string user_data)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/" + xmlGeral);
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("ID");

            int i = 0;
            foreach (XmlNode node in node_list)
            {
                if (id.Substring(0, (id.Length - 5)) == node_list.Item(i).ChildNodes[0].Value.ToString())
                {
                    node["resposta"].InnerText = "";
                    node["resposta"].InnerText = resposta.Substring(0, (resposta.Length - 5));
                    node["utilizador_data"].InnerText = "";
                    node["utilizador_data"].InnerText = user_data.Substring(0, (user_data.Length - 5));
                    node["comentarios"].InnerText = "";
                    node["comentarios"].InnerText = comentario.Substring(0, (comentario.Length - 5));
                    break;
                }
                i = i + 1;
            }

            xmlDoc.Save("C:/Ciber_Server_Data/" + xmlGeral);
        }

        private void XML_Geral_Concluido(string xmlGeral, string id, string concluido)
        {

            if (concluido.Equals("True<EOF>"))
            { concluido = "sim"; }
            else
            { concluido = "nao"; }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/" + xmlGeral);
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("ID");

            int i = 0;
            foreach (XmlNode node in node_list)
            {
                if (id.Substring(0, (id.Length - 5)) == node_list.Item(i).ChildNodes[0].Value.ToString())
                {
                    node["concluido"].InnerText = "";
                    node["concluido"].InnerText = concluido;
                    break;
                }
                i = i + 1;
            }

            xmlDoc.Save("C:/Ciber_Server_Data/" + xmlGeral);
        }

        private void Perfil(SslStream sslStream)
        {
            bool isPresent = false;
            string username = ReadMessage(sslStream);
            string password = ReadMessage(sslStream);
            string nickname = ReadMessage(sslStream);
            string missao = ReadMessage(sslStream);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/Accounts.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("Account");

            int i = 0;
            foreach (XmlNode node in node_list)
            {
                if (username.Substring(0, (username.Length - 5)) == node_list.Item(i).ChildNodes[0].Value.ToString())
                {
                    isPresent = true;
                }
                i = i + 1;
            }
            xmlDoc.Save("C:/Ciber_Server_Data/Accounts.xml");

            if (!isPresent)
            {
                XDocument xml_doc = new XDocument();
                xml_doc = XDocument.Load("C:/Ciber_Server_Data/Accounts.xml");
                xml_doc.Element("root").Add(new XElement("Account", username.Substring(0, (username.Length - 5)),
                    new XElement("password", password.Substring(0, (password.Length - 5))),
                    new XElement("nickname", nickname.Substring(0, (nickname.Length - 5))),
                    new XElement("missao", missao.Substring(0, (missao.Length - 5)))));
                xml_doc.Save("C:/Ciber_Server_Data/Accounts.xml");

                byte[] username_message = Encoding.UTF8.GetBytes("username_sucess<EOF>");
                sslStream.Write(username_message);

            }
            else
            {
                byte[] user_error_message = Encoding.UTF8.GetBytes("username_error<EOF>");
                sslStream.Write(user_error_message);
            }
        }

        private void Usernames_Read(SslStream sslStream)
        {
            byte[] message;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/Accounts.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("Account");

            int i = 0;
            foreach (XmlNode node in node_list)
            {

                string user_node = Convert.ToString(node["nickname"].InnerText);

                message = Encoding.UTF8.GetBytes("OK<EOF>"); // Sending OK message
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(user_node + "<EOF>"); // Sending mail
                sslStream.Write(message);

                i = i + 1;
            }
            message = Encoding.UTF8.GetBytes("DONE<EOF>");
            sslStream.Write(message);
        }

        private void Usernames_Remove(SslStream sslStream)
        {
            byte[] message;

            string user_to_delete = ReadMessage(sslStream);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/Accounts.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("Account");

            int i = 0;
            foreach (XmlNode node in node_list)
            {
                if (user_to_delete.Substring(0, user_to_delete.Length - 5) == node["nickname"].InnerText.ToString())
                {
                    root.RemoveChild(node_list.Item(i));
                    xmlDoc.Save("C:/Ciber_Server_Data/Accounts.xml");
                    break;
                }

                i = i + 1;
            }
        }

        private void Logs(SslStream sslStream)
        {
            byte[] message;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/Logs.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("Log");

            int i = 0;
            foreach (XmlNode node in node_list)
            {

                string ip_node = Convert.ToString(node["ip"].InnerText);
                string data_node = Convert.ToString(node["date"].InnerText);
                string user_node = Convert.ToString(node["user"].InnerText);
                string mission_node = Convert.ToString(node["mission"].InnerText);

                message = Encoding.UTF8.GetBytes("OK<EOF>"); // Sending OK message
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(ip_node + "<EOF>");
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(data_node + "<EOF>"); 
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(user_node + "<EOF>"); 
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(mission_node + "<EOF>");
                sslStream.Write(message);

                i = i + 1;
            }

            message = Encoding.UTF8.GetBytes("DONE<EOF>");
            sslStream.Write(message);
        }

        private void Mail_Add(SslStream sslStream)
        {
            string mail = ReadMessage(sslStream);

            XDocument xml_doc = new XDocument();
            xml_doc = XDocument.Load("C:/Ciber_Server_Data/Mails.xml");
            xml_doc.Element("root").Add(new XElement("Mails", "",
                new XElement("mail", mail.Substring(0, (mail.Length - 5)))));
            xml_doc.Save("C:/Ciber_Server_Data/Mails.xml");
        }

        private void Mail_Read(SslStream sslStream)
        {
            byte[] message;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/Mails.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("Mails");

            int i = 0;
            foreach (XmlNode node in node_list)
            {

                string mail_node = Convert.ToString(node["mail"].InnerText);

                message = Encoding.UTF8.GetBytes("OK<EOF>"); // Sending OK message
                sslStream.Write(message);
                message = Encoding.UTF8.GetBytes(mail_node + "<EOF>"); // Sending mail
                sslStream.Write(message);

                i = i + 1;
            }
            message = Encoding.UTF8.GetBytes("DONE<EOF>");
            sslStream.Write(message);
        }

        private void Mail_Remove(SslStream sslStream)
        {

            string mail_to_delete = ReadMessage(sslStream);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/Mails.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("Mails");

            int i = 0;
            foreach (XmlNode node in node_list)
            {
                if (mail_to_delete.Substring(0,mail_to_delete.Length - 5) == node["mail"].InnerText.ToString())
                {
                    root.RemoveChild(node_list.Item(i));
                    xmlDoc.Save("C:/Ciber_Server_Data/Mails.xml");
                    break;
                }

                i = i + 1;
            }
        }

        private void Estado_Change(SslStream sslStream)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:/Ciber_Server_Data/MS_Geral.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList node_list = root.SelectNodes("ID");

            string ID_geral = ReadMessage(sslStream);
            string estado = ReadMessage(sslStream);

            int i = 0;
            foreach (XmlNode node in node_list)
            {
                if (ID_geral.Substring(0, (ID_geral.Length - 5)) == node_list.Item(i).ChildNodes[0].Value.ToString())
                {
                    node["estado"].InnerText = "";
                    node["estado"].InnerText = estado.Substring(0, (estado.Length - 5));

                    break;
                }
                i = i + 1;
            }

            xmlDoc.Save("C:/Ciber_Server_Data/MS_Geral.xml");
        }

        private void Chat_request(SslStream sslStream)
        {
            byte[] message;
            using (StreamReader sr = File.OpenText("C:/Ciber_Server_Data/chat.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    message = Encoding.UTF8.GetBytes(s +"<EOF>"); // Sending Line
                    sslStream.Write(message);
                }
                message = Encoding.UTF8.GetBytes("OK<EOF>"); // Sending Line
                sslStream.Write(message);
                sr.Close();
            }
        }

        private void Chat_Send(SslStream sslStream, NetworkStream nwStream)
        {
            StreamReader sr = File.OpenText("C:/Ciber_Server_Data/chat_index.txt");
            string chat_message;
            
            string count_string = sr.ReadLine();
            sr.Close();

            int count = Convert.ToInt32(count_string);
            count += 1;
            FileStream index_file = File.OpenWrite("C:/Ciber_Server_Data/chat_index.txt");
            StreamWriter sw = new StreamWriter(index_file);
            sw.WriteLine(count.ToString());
            sw.Close();
            
            string username = ReadMessage(sslStream);
            string date = ReadMessage(sslStream);
            string message = ReadMessage(sslStream);

            username = username.Substring(0, (username.Length - 5));
            date = date.Substring(0, (date.Length - 5));
            message = message.Substring(0, (message.Length - 5));

            using (StreamWriter chat_writer = File.AppendText("C:/Ciber_Server_Data/chat.txt"))
            {
                chat_message = (username + " [" + date + "] - " + message);
                chat_writer.WriteLine(chat_message);
                chat_writer.Close();
            }

            foreach (NetworkStream stream in Program.client_chat_list)
            {
                stream.Write(Encoding.ASCII.GetBytes(chat_message), 0, Encoding.ASCII.GetBytes(chat_message).Length);
            }
        }

        private void Chat_Index(SslStream sslStream)
        {
            FileStream chat_index = File.OpenRead("C:/Ciber_Server_Data/chat_index.txt");
            StreamReader chat_index_new = new StreamReader(chat_index);
            string index = chat_index_new.ReadLine();
            chat_index_new.Close();

            sslStream.Write(Encoding.UTF8.GetBytes(index + "<EOF>"));
        }

        private void Chat_Delete(SslStream sslStream)
        {
            StreamWriter chat_text = new StreamWriter("C:/Ciber_Server_Data/chat.txt");
            chat_text.Write("");
            chat_text.Close();

            StreamWriter chat_index_new = new StreamWriter("C:/Ciber_Server_Data/chat_index.txt");
            chat_index_new.Write("0");
            chat_index_new.Close();
        }
    }
    
}
    

