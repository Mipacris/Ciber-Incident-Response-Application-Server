using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Incident_Response_Ciberperseu
{
    public partial class Admin_Config_Tab : UserControl
    {
        public static Button perfil_bt;
        public static Button mail_bt;
        public static Button logs_bt;
        public Admin_Config_Tab()
        {
            InitializeComponent();

            perfil_bt = criar_perfil_button;
            mail_bt = mails_button;
            logs_bt = logs_button;

            if (Login.MS_ID == "ADMIN")
            {
                // Bring to front Config Admin
                config_window.Controls.Clear();
                criar_perfil perfil = new criar_perfil();
                config_window.Controls.Add(perfil);
            }
            else
            {
                // Removing all things from screen
                Controls.Remove(config_panel);
                Controls.Remove(criar_perfil_button);
                Controls.Remove(config_window);
                // Creating a text to the user to know that separator is Admin acess only
                Label Admin_ACESS_text = new Label();
                Admin_ACESS_text.Text = "É necessário credenciais Admin para aceder a este conteúdo";
                Admin_ACESS_text.Font = new Font("Century Gothic", 20);
                Admin_ACESS_text.AutoSize = false;
                Admin_ACESS_text.TextAlign = ContentAlignment.MiddleCenter;
                Admin_ACESS_text.Dock = DockStyle.Fill;
                Controls.Add(Admin_ACESS_text);

            }

            App_Window.Enable_Buttons();
        }

        private void Criar_perfil_button_Click(object sender, EventArgs e)
        {
            // Bring to front Config Admin
            config_window.Controls.Clear();
            criar_perfil perfil = new criar_perfil();
            config_window.Controls.Add(perfil);
        }

        private void Logs_button_Click(object sender, EventArgs e)
        {
            // Bring to front Config Admin
            config_window.Controls.Clear();
            Logs_Viewer logs = new Logs_Viewer();
            config_window.Controls.Add(logs);
        }

        private void Mails_button_Click(object sender, EventArgs e)
        {
            config_window.Controls.Clear();
            mails admin_mails = new mails();
            config_window.Controls.Add(admin_mails);
        }

        public static void Disable_Config_Buttons()
        {
            perfil_bt.Enabled = false;
            mail_bt.Enabled = false;
            logs_bt.Enabled = false;
        }
        public static void Enable_Config_Buttons()
        {
            perfil_bt.Enabled = true;
            mail_bt.Enabled = true;
            logs_bt.Enabled = true;
        }
    }
}
