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
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Upda_Constrain : UserControl
    {
        private static Upda_Constrain _instance;
        public static Upda_Constrain instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Upda_Constrain();
                return _instance;
            }
        }
        int col=0;

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


        public Upda_Constrain()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (Update_T.instance.Visible==false)
            {
                Update_T.instance.Visible = true;
            }
            if (!panel1.Controls.Contains(Update_T.instance))
            {
                panel1.Controls.Add(Update_T.instance);
                Update_T.instance.Dock = DockStyle.Fill;
                Update_T.instance.BringToFront();
            }
            else
                Update_T.instance.BringToFront();

            //Cmbo_Add_Const.Items.Clear();
            Cmbo_Del_Const.Items.Clear();
            Cmbo_select_Col.Items.Clear();
        }

        private void Add_Const_Click(object sender, EventArgs e)
        {
            List<tables> table_list = new List<tables>();
            string table_name = Table_name();
            table_list = get_List_of_Tables();

            List<Columns> ls_col = new List<Columns>();
            int index = 0;
            for (int i = 0; i < table_list.Count; i++)
            {
                if (table_list.ElementAt(i).table_name == table_name)
                {
                    index = i;
                    break;
                }
            }
            ls_col = table_list[index].Table_colums;

            string constran = Cmbo_Add_Const.Text + textBox_value.Text.ToString();
           // MessageBox.Show(constran);

            for (int i = 0; i < ls_col.Count; i++)
            {
                if (ls_col.ElementAt(i).name == Cmbo_select_Col.Text)
                {
                    if (Cmbo_Add_Const.Text == "Auto" && (ls_col.ElementAt(i).type != "string" || ls_col.ElementAt(i).type != "char" || ls_col.ElementAt(i).type != "date"))
                    {
                        ls_col.ElementAt(i).constrains.Add(constran);
                        break;
                    }
                    else if (Cmbo_Add_Const.Text != "Auto")
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

            table_list[index].Table_colums = ls_col;
            textBox_value.Text = "";
            Cmbo_select_Col.Text = "";
            Cmbo_Add_Const.Text = "";
            Save(table_list);
        }

        private void Del_Cons_Click(object sender, EventArgs e)
        {
            if (Cmbo_Del_Const.Items.Count==0||Cmbo_Del_Const.SelectedItem.ToString()=="")
            {
                 MessageBox.Show("Empty Constrain !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string del_const = Cmbo_Del_Const.SelectedItem.ToString();
                string table_name = Table_name();

                List<tables> table_list = new List<tables>();
                table_list = get_List_of_Tables();
                int index = 0;
                for (int i = 0; i < table_list.Count; i++)
                {
                    if (table_list.ElementAt(i).table_name == table_name)
                    {
                        index = i;
                        break;
                    }
                }
                for(int i=0;i < table_list[index].Table_colums[col].constrains.Count;i++)
                {
                    if (table_list[index].Table_colums[col].constrains[i] == del_const)
                    {
                        table_list[index].Table_colums[col].constrains.RemoveAt(i);
                        break;
                    }
                }
                Cmbo_Del_Const.Items.Remove(del_const);
                Save(table_list);
                Cmbo_Del_Const.Items.Remove(del_const);
                Cmbo_Del_Const.Text = "";
            }
        }


        private void Cmbo_select_Col_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbo_Del_Const.Items.Clear();
            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();
            string selected_name = Cmbo_select_Col.SelectedItem.ToString();
            string table_name = Table_name();

            int index = 0;
            for (int i = 0; i < table_list.Count; i++)
            {
                if (table_list.ElementAt(i).table_name == table_name)
                {
                    index = i;
                    break;
                }
            }
            for (int i = 0; i < table_list[index].Table_colums.Count; i++)
            {
                if (table_list[index].Table_colums[i].name == selected_name)
                {
                    col = i;
                    for (int j = 0; j < table_list[index].Table_colums[i].constrains.Count; j++)
                    {
                        Cmbo_Del_Const.Items.Add(table_list[index].Table_colums[i].constrains[j]);
                    }
                }
            }
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            Cmbo_select_Col.Items.Clear();
            Cmbo_select_Col.Text = "";
           
            List<tables> table_list = new List<tables>();
            string table_name = Table_name();
            table_list = get_List_of_Tables();

            int index = 0;
            for (int i = 0; i < table_list.Count; i++)
            {
                if (table_list.ElementAt(i).table_name == table_name)
                {
                    index = i;
                    break;
                }
            }
            for (int i = 0; i < table_list[index].Table_colums.Count; i++)
            {
                Cmbo_select_Col.Items.Add(table_list[index].Table_colums[i].name);
            }
        }
    }
}
