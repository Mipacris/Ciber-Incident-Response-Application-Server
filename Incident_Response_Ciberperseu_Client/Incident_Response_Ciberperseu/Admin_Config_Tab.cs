using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciberperseu_Outlook
{
    public partial class Admin_Config_Tab : UserControl
    {
        public Admin_Config_Tab()
        {
            InitializeComponent();
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
        }

        private void Criar_perfil_button_Click(object sender, EventArgs e)
        {
            // Bring to front Config Admin
            config_window.Controls.Clear();
            criar_perfil perfil = new criar_perfil();
            config_window.Controls.Add(perfil);
        }
    }
}
