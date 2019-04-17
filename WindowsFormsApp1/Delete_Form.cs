using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Delete_Form : Form
    {
        public Delete_Form()
        {
            InitializeComponent();
        }

        int mov;
        int movX;
        int movY;

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        /****************************************Functions**************************************************/
        string Table_name()
        {
            FileStream fs = new FileStream("table_name.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string table_name = sr.ReadLine();
            sr.Close();
            fs.Close();
            return table_name;
        }

        List<tables> get_List_of_Tables()
        {
            List<tables> table_list = new List<tables>();
            XmlSerializer xs = new XmlSerializer(table_list.GetType());
            FileStream file = new FileStream("Tables.xml", FileMode.OpenOrCreate);
            if (file.Length != 0)
                table_list = (List<tables>)xs.Deserialize(file);
            file.Close();

            return table_list;
        }

        void Save(List<tables> t)
        {
            FileStream file1 = new FileStream("Tables.xml", FileMode.Truncate);
            file1.Close();
            FileStream file = new FileStream("Tables.xml", FileMode.Open);
            XmlSerializer ser = new XmlSerializer(t.GetType());
            ser.Serialize(file, t);
            file.Close();
        }

        /****************************************Functions**************************************************/

        private void D_Table_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Delete this Table ?", "Warring", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                List<tables> table_list = new List<tables>();
                table_list = get_List_of_Tables();

                for(int i=0;i< table_list.Count;i++)
                {
                    if (table_list.ElementAt(i).table_name==Tab_name_comb.SelectedItem.ToString())
                    {
                        table_list.RemoveAt(i);
                        break;
                    }
                }
                Save(table_list);

                Tab_name_comb.Text = "";
                Tab_name_comb.Items.Remove(Tab_name_comb.SelectedItem.ToString());
                MessageBox.Show("Deleted (-_-)");
            }
        }

        private void Delete_Form_Load(object sender, EventArgs e)
        {
            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();

            for (int i = 0; i < table_list.Count; i++)
            {
                Tab_name_comb.Items.Add(table_list.ElementAt(i).table_name);
            }
        }
    }
}
