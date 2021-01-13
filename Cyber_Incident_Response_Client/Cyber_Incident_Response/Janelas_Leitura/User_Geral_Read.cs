using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyber_Incident_Response
{
    public partial class User_Geral_Read : Form
    {
        Point lastPoint;

        public User_Geral_Read()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void User_Geral_Read_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void User_Geral_Read_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
