using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Add_Table : Form
    {
        public Add_Table()
        {
            InitializeComponent();
        }
        int mov;
        int movX;
        int movY;

        private void button1_Click(object sender, EventArgs e)
        {
            Constrain_T.instance.Visible = false;
            Create_T.instance.Visible = false;
               this.Hide();
        }

       
        private void Add_Table_Load(object sender, EventArgs e)
        {
            if (!panel_.Controls.Contains(Name_T.instance))
            {
                panel_.Controls.Add(Name_T.instance);
                Name_T.instance.Dock = DockStyle.Fill;
                Name_T.instance.BringToFront();
            }
            else
                Name_T.instance.BringToFront();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
