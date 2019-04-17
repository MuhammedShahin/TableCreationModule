using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_Relation : Form
    {
        public Form_Relation()
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

        private void Form_Relation_Load(object sender, EventArgs e)
        {
            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();

            for (int i = 0; i < table_list.Count; i++)
            {
                combo_T1.Items.Add(table_list.ElementAt(i).table_name);
                combo_T2.Items.Add(table_list.ElementAt(i).table_name);
            }
        }

        private void Add_More_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || combo_T1.Text == "" || combo_T2.Text == "" || textBox_ColName.Text == "" || comboBox2_table2.Text == "")
                MessageBox.Show("Error Empty Inputs!!");

            else if (combo_T1.SelectedItem.ToString() == combo_T2.SelectedItem.ToString())
            {
                MessageBox.Show("Error must be diffrent tables to selcet !!");
                combo_T1.Text = "";
                combo_T2.Text = "";
                comboBox2_table2.Text = "";
                DataTable temp_to_Delete = new DataTable();
                dataGridView1.DataSource = temp_to_Delete;
                comboBox2_table2.Items.Clear();
            }
            else
            {
                List<tables> table_list = new List<tables>();
                table_list = get_List_of_Tables();

                int index = 0;
                for (int i = 0; i < table_list.Count; i++)
                {
                    if (table_list.ElementAt(i).table_name == combo_T1.SelectedItem.ToString())
                    {
                        index = i;
                        break;
                    }
                }
                DataTable tab = new DataTable();
                string c = comboBox1.SelectedItem.ToString();
                if (c == "int")
                {
                    tab.Columns.Add(textBox_ColName.Text, typeof(int));
                }
                else if (c == "string")
                {
                    tab.Columns.Add(textBox_ColName.Text, typeof(string));
                }
                else if (c == "double")
                {
                    tab.Columns.Add(textBox_ColName.Text, typeof(double));
                }
                else if (c == "long")
                {
                    tab.Columns.Add(textBox_ColName.Text, typeof(long));
                }
                else if (c == "float")
                {
                    tab.Columns.Add(textBox_ColName.Text, typeof(float));
                }
                else if (c == "char")
                {
                    tab.Columns.Add(textBox_ColName.Text, typeof(char));
                }

                int index1 = 0;
                for (int i = 0; i < table_list.Count; i++)
                {
                    if (table_list.ElementAt(i).table_name == combo_T2.SelectedItem.ToString())
                    {
                        index1 = i;
                        break;
                    }
                }
                bool cheak3 = false;
                string pr_ky_sec = comboBox2_table2.SelectedItem.ToString();
                for (int i = 0; i < table_list[index1].Primary_keys.Count; i++)
                {
                    if (table_list[index1].Primary_keys[i] == pr_ky_sec)
                    {
                        cheak3 = true;
                        break;
                    }
                }
                if (cheak3 == false)
                {
                    MessageBox.Show("it's not primary key for the sec table should select primary key !!");
                }
                else
                {
                    List<string> da_pr = new List<string>();
                    for (int i = 0; i < table_list[index1].Table_colums.Count; i++)
                    {
                        if (table_list[index1].Table_colums[i].name == pr_ky_sec)
                        {
                            for (int j = 0; j < table_list[index1].Table_colums[i].data.Count; j++)
                            {
                                da_pr.Add(table_list[index1].Table_colums[i].data[j]);
                            }
                            break;
                        }
                    }
                    string val;
                    Columns new_fk = new Columns();
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        bool cheak = false;
                        val = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        for (int j = 0; j < da_pr.Count; j++)
                        {
                            if (da_pr[j] == val)
                            {
                                cheak = true;
                                break;
                            }
                        }
                        if (cheak == false)
                        {
                            MessageBox.Show("invaled data please enter valid data that matches the primary key in the parent table !!");
                            dataGridView1.DataSource = tab;
                            return;
                        }
                        else
                        {
                            new_fk.data.Add(val);
                        }

                    }
                    new_fk.isforgin = true;
                    new_fk.name = textBox_ColName.Text.ToString();
                    new_fk.type = comboBox1.SelectedItem.ToString();
                    new_fk.data_forgin.Add(table_list[index1].table_name);
                    table_list[index].Table_colums.Add(new_fk);
                    dataGridView1.DataSource = tab;

                    Save(table_list);
                }
            }
        }

        private void combo_T2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2_table2.Items.Clear();
            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();

            int index = 0;
            string s = combo_T2.SelectedItem.ToString();
            for (int i = 0; i < table_list.Count; i++)
            {
                if (table_list.ElementAt(i).table_name == combo_T2.SelectedItem.ToString())
                {
                    index = i;
                    break;
                }
            }
            for (int i = 0; i < table_list[index].Table_colums.Count; i++)
            {
                comboBox2_table2.Items.Add(table_list[index].Table_colums[i].name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tab = new DataTable();
            string c = comboBox1.SelectedItem.ToString();
            if (c == "int")
            {
                tab.Columns.Add(textBox_ColName.Text, typeof(int));
            }
            else if (c == "string")
            {
                tab.Columns.Add(textBox_ColName.Text, typeof(string));
            }
            else if (c == "double")
            {
                tab.Columns.Add(textBox_ColName.Text, typeof(double));
            }
            else if (c == "long")
            {
                tab.Columns.Add(textBox_ColName.Text, typeof(long));
            }
            else if (c == "float")
            {
                tab.Columns.Add(textBox_ColName.Text, typeof(float));
            }
            else if (c == "char")
            {
                tab.Columns.Add(textBox_ColName.Text, typeof(char));
            }
            dataGridView1.DataSource = tab;
        }

        private void Done_Click(object sender, EventArgs e)
        {

        }
    }
}
