using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Cyber_Incident_Response
{
    public partial class outlook : UserControl
    {
        public outlook()
        {
            InitializeComponent();

            if (Login.MS_ID == "ADMIN")
            {
                var mails = OutlookEmails.ReadMailsItems();
                int i = 0;
                foreach (var mail in mails)
                {
                    DataGrid.Rows.Add();
                    DataGrid.Rows[i].Cells["id"].Value = mail.EmailID;
                    DataGrid.Rows[i].Cells["Remetente"].Value = mail.FromEmail;
                    DataGrid.Rows[i].Cells["Titulo"].Value = mail.EmailSubject;
                    DataGrid.Rows[i].Cells["Corpo"].Value = mail.EmailBody;
                    DataGrid.Rows[i].Cells["Data"].Value = mail.EmailDate;

                    if (mail.flag == OlImportance.olImportanceHigh)
                    {
                        DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                    else if (mail.flag == OlImportance.olImportanceLow)
                    {
                        DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                    }

                    i = i + 1;
                }
            }
            else
            {
                // Removing all things from screen
                Controls.Remove(DataGrid);
                Controls.Remove(ms03_button);
                Controls.Remove(ms04_button);
                Controls.Remove(ms05_button);
                Controls.Remove(ms07_button);
                Controls.Remove(descartar_button);
                // Creating a text to the user to know that separator is Admin acess only
                Label Admin_ACESS_text = new Label();
                Admin_ACESS_text.Text = "É necessário credenciais Admin para aceder a este conteúdo";
                Admin_ACESS_text.Font = new Font("Century Gothic", 20);
                Admin_ACESS_text.AutoSize = false;
                Admin_ACESS_text.TextAlign = ContentAlignment.MiddleCenter;
                Admin_ACESS_text.Dock = DockStyle.Fill;
                Controls.Add(Admin_ACESS_text);
            }

            App_Window.Enable_Buttons(); // Enable buttons again at the end...
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 5)
            {
                Read_Content_Outlook content_window = new Read_Content_Outlook();
                content_window.id_outlook_box.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
                content_window.remetente_box.Text = DataGrid.CurrentRow.Cells[1].Value.ToString();
                content_window.titulo_box.Text = DataGrid.CurrentRow.Cells[2].Value.ToString();
                content_window.corpo_box.Text = DataGrid.CurrentRow.Cells[3].Value.ToString();
                content_window.data_box.Text = DataGrid.CurrentRow.Cells[4].Value.ToString();
                content_window.ShowDialog();
            }
        }

        private void Ms03_button_Click(object sender, EventArgs e)
        {

            byte[] buffer = new byte[2048];
            Login.sslstream.Write(Encoding.UTF8.GetBytes("MS03" + "<EOF>"));

            for (int i = 0; i <= DataGrid.Rows.Count - 1; i++)
            {
                bool check_value = Convert.ToBoolean(DataGrid.Rows[i].Cells["Inject"].Value);
                if (check_value == true)
                {

                    // Sending data to the server to store as a mission
                    try
                    {

                        // Sending contents from mail to inject
                        string id_message = DataGrid.Rows[i].Cells["id"].Value.ToString();
                        string remetente_message = DataGrid.Rows[i].Cells["Remetente"].Value.ToString();
                        string titulo_message = DataGrid.Rows[i].Cells["Titulo"].Value.ToString();
                        string corpo_message = DataGrid.Rows[i].Cells["Corpo"].Value.ToString();
                        string data_message = DataGrid.Rows[i].Cells["Data"].Value.ToString();

                        Login.sslstream.Write(Encoding.UTF8.GetBytes("GOING<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(id_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(remetente_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(titulo_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(corpo_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(data_message + "<EOF>"));

                        OutlookEmails.Mail_Inject(id_message);
                        DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;

                        DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)DataGrid.Rows[i].Cells["Inject"];
                        check.Value = check.FalseValue;
                    }
                    catch (System.Exception e1)
                    {
                        Console.Write(e1);
                        MessageBox.Show("Possible Errors: \n" +
                            "Server is Down\n" +
                            "Internet is Off\n" +
                            "Program is not running in administrator\n" +
                            "If possible try again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Login.sslstream.Write(Encoding.UTF8.GetBytes("END_INJECT" + "<EOF>"));
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain,
          SslPolicyErrors sslPolicyErrors)
        {
            return true; // Allow untrusted certificates
        }

        private void Ms04_button_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[2048];
            Login.sslstream.Write(Encoding.UTF8.GetBytes("MS04" + "<EOF>"));

            for (int i = 0; i <= DataGrid.Rows.Count - 1; i++)
            {
                bool check_value = Convert.ToBoolean(DataGrid.Rows[i].Cells["Inject"].Value);
                if (check_value == true)
                {

                    // Sending data to the server to store as a mission
                    try
                    {

                        // Sending contents from mail to inject
                        string id_message = DataGrid.Rows[i].Cells["id"].Value.ToString();
                        string remetente_message = DataGrid.Rows[i].Cells["Remetente"].Value.ToString();
                        string titulo_message = DataGrid.Rows[i].Cells["Titulo"].Value.ToString();
                        string corpo_message = DataGrid.Rows[i].Cells["Corpo"].Value.ToString();
                        string data_message = DataGrid.Rows[i].Cells["Data"].Value.ToString();

                        Login.sslstream.Write(Encoding.UTF8.GetBytes("GOING<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(id_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(remetente_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(titulo_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(corpo_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(data_message + "<EOF>"));

                        OutlookEmails.Mail_Inject(id_message);
                        DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;

                        DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)DataGrid.Rows[i].Cells["Inject"];
                        check.Value = check.FalseValue;
                    }
                    catch (System.Exception e1)
                    {
                        Console.Write(e1);
                        MessageBox.Show("Possible Errors: \n" +
                            "Server is Down\n" +
                            "Internet is Off\n" +
                            "Program is not running in administrator\n" +
                            "If possible try again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Login.sslstream.Write(Encoding.UTF8.GetBytes("END_INJECT" + "<EOF>"));
        }

        private void Ms05_button_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[2048];
            Login.sslstream.Write(Encoding.UTF8.GetBytes("MS05" + "<EOF>"));

            for (int i = 0; i <= DataGrid.Rows.Count - 1; i++)
            {
                bool check_value = Convert.ToBoolean(DataGrid.Rows[i].Cells["Inject"].Value);
                if (check_value == true)
                {

                    // Sending data to the server to store as a mission
                    try
                    {

                        // Sending contents from mail to inject
                        string id_message = DataGrid.Rows[i].Cells["id"].Value.ToString();
                        string remetente_message = DataGrid.Rows[i].Cells["Remetente"].Value.ToString();
                        string titulo_message = DataGrid.Rows[i].Cells["Titulo"].Value.ToString();
                        string corpo_message = DataGrid.Rows[i].Cells["Corpo"].Value.ToString();
                        string data_message = DataGrid.Rows[i].Cells["Data"].Value.ToString();

                        Login.sslstream.Write(Encoding.UTF8.GetBytes("GOING<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(id_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(remetente_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(titulo_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(corpo_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(data_message + "<EOF>"));

                        OutlookEmails.Mail_Inject(id_message);
                        DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;

                        DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)DataGrid.Rows[i].Cells["Inject"];
                        check.Value = check.FalseValue;
                    }
                    catch (System.Exception e1)
                    {
                        Console.Write(e1);
                        MessageBox.Show("Possible Errors: \n" +
                            "Server is Down\n" +
                            "Internet is Off\n" +
                            "Program is not running in administrator\n" +
                            "If possible try again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Login.sslstream.Write(Encoding.UTF8.GetBytes("END_INJECT" + "<EOF>"));
        }

        private void Ms07_button_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[2048];
            Login.sslstream.Write(Encoding.UTF8.GetBytes("MS07" + "<EOF>"));

            for (int i = 0; i <= DataGrid.Rows.Count - 1; i++)
            {
                bool check_value = Convert.ToBoolean(DataGrid.Rows[i].Cells["Inject"].Value);
                if (check_value == true)
                {

                    // Sending data to the server to store as a mission
                    try
                    {

                        // Sending contents from mail to inject
                        string id_message = DataGrid.Rows[i].Cells["id"].Value.ToString();
                        string remetente_message = DataGrid.Rows[i].Cells["Remetente"].Value.ToString();
                        string titulo_message = DataGrid.Rows[i].Cells["Titulo"].Value.ToString();
                        string corpo_message = DataGrid.Rows[i].Cells["Corpo"].Value.ToString();
                        string data_message = DataGrid.Rows[i].Cells["Data"].Value.ToString();

                        Login.sslstream.Write(Encoding.UTF8.GetBytes("GOING<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(id_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(remetente_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(titulo_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(corpo_message + "<EOF>"));
                        Login.sslstream.Write(Encoding.UTF8.GetBytes(data_message + "<EOF>"));

                        OutlookEmails.Mail_Inject(id_message);
                        DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;

                        DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)DataGrid.Rows[i].Cells["Inject"];
                        check.Value = check.FalseValue;
                    }
                    catch (System.Exception e1)
                    {
                        Console.Write(e1);
                        MessageBox.Show("Possible Errors: \n" +
                            "Server is Down\n" +
                            "Internet is Off\n" +
                            "Program is not running in administrator\n" +
                            "If possible try again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Login.sslstream.Write(Encoding.UTF8.GetBytes("END_INJECT" + "<EOF>"));
        }

        private void Descartar_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= DataGrid.Rows.Count - 1; i++)
            {
                bool check_value = Convert.ToBoolean(DataGrid.Rows[i].Cells["Inject"].Value);
                if (check_value == true)
                {

                    try
                    {

                        // Sending contents from mail to inject
                        string id_message = DataGrid.Rows[i].Cells["id"].Value.ToString();

                        OutlookEmails.Mail_Inject_LowImportance(id_message);
                        DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;

                        DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)DataGrid.Rows[i].Cells["Inject"];
                        check.Value = check.FalseValue;
                    }
                    catch (System.Exception e1)
                    {
                        Console.Write(e1);
                        MessageBox.Show("Possible Errors: \n" +
                            "Server is Down\n" +
                            "Internet is Off\n" +
                            "Program is not running in administrator\n" +
                            "If possible try again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }


    public class OutlookEmails
    {
        public static Microsoft.Office.Interop.Outlook.Application outlook_app = null;
        public static NameSpace outlooknamespace = null;
        public static MAPIFolder inboxFolder = null;
        public static Items mailItems = null;

        public string FromEmail { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }

        public DateTime EmailDate { get; set; }

        public string EmailID { get; set; }

        public OlImportance flag { get; set; }

        public static List<OutlookEmails> ReadMailsItems()
        {
            List<OutlookEmails> listEmailsDetails = new List<OutlookEmails>();
            OutlookEmails emailDetails;

            try
            {
                outlook_app = new Microsoft.Office.Interop.Outlook.Application();
                outlooknamespace = outlook_app.GetNamespace("MAPI");
                inboxFolder = outlooknamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                mailItems = inboxFolder.Items;

                foreach (MailItem item in mailItems)
                {
                    emailDetails = new OutlookEmails();
                    emailDetails.FromEmail = item.SenderName;
                    emailDetails.EmailSubject = item.Subject;
                    emailDetails.EmailBody = item.Body;
                    emailDetails.EmailDate = item.ReceivedTime;
                    emailDetails.EmailID = item.EntryID;
                    emailDetails.flag = item.Importance;
                    listEmailsDetails.Add(emailDetails);
                    ReleaseComObjetc(item);
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error initiating the outlook...\n" +
                    "Try again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                ReleaseComObjetc(mailItems);
                ReleaseComObjetc(inboxFolder);
                ReleaseComObjetc(outlooknamespace);
                ReleaseComObjetc(outlook_app);
            }
            return listEmailsDetails;
        }

        public static void Mail_Inject(string id)
        {

            try
            {
                outlook_app = new Microsoft.Office.Interop.Outlook.Application();
                outlooknamespace = outlook_app.GetNamespace("MAPI");
                inboxFolder = outlooknamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                mailItems = inboxFolder.Items;

                foreach (MailItem item in mailItems)
                {
                    if (item.EntryID == id)
                    {
                        item.Importance = OlImportance.olImportanceHigh;
                        item.Save();

                    }

                    ReleaseComObjetc(item);

                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                ReleaseComObjetc(mailItems);
                ReleaseComObjetc(inboxFolder);
                ReleaseComObjetc(outlooknamespace);
                ReleaseComObjetc(outlook_app);
            }
        }

        public static void Mail_Inject_LowImportance(string id)
        {
            try
            {
                outlook_app = new Microsoft.Office.Interop.Outlook.Application();
                outlooknamespace = outlook_app.GetNamespace("MAPI");
                inboxFolder = outlooknamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                mailItems = inboxFolder.Items;

                foreach (MailItem item in mailItems)
                {
                    if (item.EntryID == id)
                    {
                        item.Importance = OlImportance.olImportanceLow;
                        item.Save();

                    }

                    ReleaseComObjetc(item);

                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                ReleaseComObjetc(mailItems);
                ReleaseComObjetc(inboxFolder);
                ReleaseComObjetc(outlooknamespace);
                ReleaseComObjetc(outlook_app);
            }
        }
        private static void ReleaseComObjetc(object obj)
        {
            if (obj != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
        }
    }
}
