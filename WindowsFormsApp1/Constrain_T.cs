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
    public partial class Constrain_T : UserControl
    {
        private static Constrain_T _instance;
        public static Constrain_T instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Constrain_T();
                return _instance;
            }
        }
        public Constrain_T()
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


        private void Constrain_T_Load(object sender, EventArgs e)
        {
            //we should load the data structure from here to load the combo box of the columns name !
            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();

            FileStream fs = new FileStream("table_name.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string table_name = sr.ReadLine();
            sr.Close();
            fs.Close();

            List<Columns> ls_col = new List<Columns>();
            for (int i = 0; i < table_list.Count; i++)
            {
                if (table_list.ElementAt(i).table_name == table_name)
                {
                    ls_col = table_list.ElementAt(i).Table_colums;
                    break;
                }
            }
            for (int i = 0; i < ls_col.Count; i++)
            {
                if (ls_col[i].type.ToString() == "string")   // can not take constrains from string 
                    continue;       
                else
                    comboBox_col_Create.Items.Add(ls_col[i].name);
            }
        }

        private void Add_Const_Click(object sender, EventArgs e)
        {
            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();

            FileStream fs = new FileStream("Table_name.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string table_name = sr.ReadLine();
            sr.Close();
            fs.Close();

            List<Columns> ls_col = new List<Columns>();
            for (int i = 0; i < table_list.Count; i++)
            {
                if (table_list.ElementAt(i).table_name == table_name)
                {
                    ls_col = table_list.ElementAt(i).Table_colums;
                    break;
                }
            }

            string constran = Combo_const.Text + textBox_value.Text.ToString();
            //MessageBox.Show(constran);
            for (int i = 0; i < ls_col.Count; i++)
            {
                if (ls_col.ElementAt(i).name == comboBox_col_Create.Text)
                {
                    if (Combo_const.Text == "Auto" && (ls_col.ElementAt(i).type != "string" || ls_col.ElementAt(i).type != "char" || ls_col.ElementAt(i).type != "date"))
                    {
                        ls_col.ElementAt(i).constrains.Add(constran);
                        break;
                    }
                    else if (Combo_const.Text != "Auto")
                    {
                        bool cheak2 = true;
                        for (int f = 0; f < ls_col.ElementAt(i).constrains.Count; f++)
                        {
                            if (ls_col.ElementAt(i).constrains.ElementAt(f) == "Auto")
                            {
                                cheak2 = false;
                                break;
                            }
                        }
                        if (cheak2 == true)
                        {
                            ls_col.ElementAt(i).constrains.Add(constran);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Error must not add constrains with Auto constrain !!");
                        }
                    }
                }
            }
            for (int i = 0; i < table_list.Count; i++)
            {
                if (table_list.ElementAt(i).table_name == table_name)
                {
                    table_list.ElementAt(i).Table_colums = ls_col;
                    break;
                }
            }
            textBox_value.Text = "";
            Save(table_list);

            Combo_const.Text = "";
            textBox_value.Text = "";
        }

        private void comboBox_col_Create_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
