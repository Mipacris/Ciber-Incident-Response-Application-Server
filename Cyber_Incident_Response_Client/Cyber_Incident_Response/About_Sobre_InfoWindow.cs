using System;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cyber_Incident_Response
{
    public partial class About_Sobre_InfoWindow : UserControl
    {

        public About_Sobre_InfoWindow()
        {
            InitializeComponent();

            App_Window.Enable_Buttons(); // Enable buttons again at the end...
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
