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
    public partial class criar_perfil : UserControl
    {
        public criar_perfil()
        {
            InitializeComponent();
        }

        private void Criar_button_Click(object sender, EventArgs e)
        {
            try
            {
                string username = username_box.Text.ToString();
                string password = password_box.Text.ToString();
                string nickname = nickname_box.Text.ToString();
                string missao = missao_comboBox.GetItemText(missao_comboBox.SelectedItem);

                // Sending data to server
                Login.sslstream.Write(Encoding.UTF8.GetBytes("Novo_Perfil<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(username +"<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(password + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(nickname + "<EOF>"));
                Login.sslstream.Write(Encoding.UTF8.GetBytes(missao + "<EOF>"));

                MessageBox.Show("Perfil Criado com sucesso", "Perfil Criado",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("É necessário preencher todos os campos...", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
