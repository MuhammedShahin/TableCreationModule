using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp1
{
    public partial class Name_T : UserControl
    {
        private static Name_T _instance;
        public static Name_T instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Name_T();
                return _instance;
            }
        }
        public Name_T()
        {
            InitializeComponent();
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
            FileStream file = new FileStream("Tables.xml", FileMode.Open);
            XmlSerializer ser = new XmlSerializer(t.GetType());
            ser.Serialize(file, t);
            file.Close();
        }

        /****************************************Functions**************************************************/

        private void Next_Click_1(object sender, EventArgs e)
        {
            //Take Table Name from text box .........................
            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();

            bool cheak1 = false;
            for (int i = 0; i < table_list.Count; i++)
            {
                if (table_list.ElementAt(i).table_name == table_name_text_box.Text.ToString())
                {
                    cheak1 = true;
                    break;
                }
            }
            if (cheak1 == true)
            {
                MessageBox.Show("This name is used try another one please ! ");
                table_name_text_box.Text = "";
            }
            else
            {
                FileStream fs = new FileStream("table_name.txt", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(table_name_text_box.Text.ToString());
                sw.Close();
                fs.Close();
                table_name_text_box.Text = "";

                if (Create_T.instance.Visible == false)
                {
                    Create_T.instance.Visible = true;
                }
                if (!panel1.Controls.Contains(Create_T.instance))
                {
                    panel1.Controls.Add(Create_T.instance);
                    Create_T.instance.Dock = DockStyle.Fill;
                    Create_T.instance.BringToFront();
                }
                else
                    Create_T.instance.BringToFront();
            }
        }
    }
}
