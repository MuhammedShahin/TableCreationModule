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
    public partial class Edit_Form : Form
    {
        public Edit_Form()
        {
            InitializeComponent();
            if (!panel2.Controls.Contains(Add_Col.instance))
            {
                panel2.Controls.Add(Add_Col.instance);
                Add_Col.instance.Dock = DockStyle.Fill;
                Add_Col.instance.BringToFront();
            }
            else
                Add_Col.instance.BringToFront();
        }
        int mov;
        int movX;
        int movY;
        private void back_Click(object sender, EventArgs e)
        {
            Update_T.instance.Visible = false;
            Upda_Constrain.instance.Visible = false;
            this.Hide();
        }
       
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
    }
}
