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
    public partial class Main_Form : Form
    {
        int mov;
        int movX;
        int movY;
        public Main_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void Add_Click(object sender, EventArgs e)
        {
            Add_Table s = new Add_Table();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit_Form f= new Edit_Form();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Form f = new Delete_Form();
            f.Show();
        }

        private void Relations_Click(object sender, EventArgs e)
        {
            Form_Relation r = new Form_Relation();
            r.Show();
        }
    }
}
