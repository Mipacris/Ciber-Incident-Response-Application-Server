using System;
using System.Drawing;
using System.Windows.Forms;

namespace Incident_Response_Ciberperseu
{
    public partial class Read_Content_Outlook : Form
    {
        Point lastPoint;

        public Read_Content_Outlook()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Read_Content_Outlook_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Read_Content_Outlook_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
