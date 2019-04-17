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
    public partial class Add_Col : UserControl
    {
        private static Add_Col _instance;
        public static Add_Col instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Add_Col();
                return _instance;
            }
        }
        public Add_Col()
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
            FileStream file1 = new FileStream("Tables.xml", FileMode.Truncate);
            file1.Close();
            FileStream file = new FileStream("Tables.xml", FileMode.Open);
            XmlSerializer ser = new XmlSerializer(t.GetType());
            ser.Serialize(file, t);
            file.Close();
        }

        /****************************************Functions**************************************************/

        private void button3_Click(object sender, EventArgs e)
        {
            if (combo_T_Names.Text == "")
            {
                MessageBox.Show("Please Select Table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<tables> table_list = new List<tables>();
                table_list = get_List_of_Tables();
                

                tables tab = new tables();
                tab.table_name = combo_T_Names.SelectedItem.ToString();
                List<Columns> col_list = new List<Columns>();
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    Columns temp_col = new Columns();
                    temp_col.name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    temp_col.type = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    if (dataGridView1.Rows[i].Cells[2].Value != null) 
                    {
                        tab.Primary_keys.Add(temp_col.name);
                    }
                    col_list.Add(temp_col);
                }
                tab.Table_colums = col_list;
                int index=0;
                for (int i = 0; i < table_list.Count; i++)
                {
                    if (table_list.ElementAt(i).table_name == combo_T_Names.SelectedItem.ToString())
                    {
                        index = i;
                        break;
                    }
                }
                // copy constrains and data to temp 
                for (int i = 0; i < table_list[index].Table_colums.Count; i++)
                {
                       tab.Table_colums[i].constrains= table_list[index].Table_colums[i].constrains;
                }
                for (int i = 0; i < table_list[index].Table_colums.Count; i++)
                {
                    tab.Table_colums[i].data = table_list[index].Table_colums[i].data;
                }
                table_list[index] = tab;

                Save(table_list);

                string T_name = combo_T_Names.Text;
                FileStream f = new FileStream("table_name.txt", FileMode.OpenOrCreate);
                StreamWriter wr = new StreamWriter(f);
                wr.WriteLine(T_name);
                wr.Close();
                f.Close();
                combo_T_Names.Text = "";
                combo_T_Names.Items.Clear();
                DataTable dd = new DataTable();
                dataGridView1.DataSource = dd;


                if (Upda_Constrain.instance.Visible == false)
                {
                    Upda_Constrain.instance.Visible = true;
                }
                if (!panel1.Controls.Contains(Upda_Constrain.instance))
                {
                    panel1.Controls.Add(Upda_Constrain.instance);
                    Upda_Constrain.instance.Dock = DockStyle.Fill;
                    Upda_Constrain.instance.BringToFront();
                }
                else
                    Upda_Constrain.instance.BringToFront();
            }
        }
       
        private void combo_T_Names_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();

            
            tables table = new tables();
            string table_name = combo_T_Names.SelectedItem.ToString();
            for (int i = 0; i < table_list.Count; i++)
            {
                if (table_list.ElementAt(i).table_name == table_name)
                {
                    table = table_list.ElementAt(i);
                    break;
                }
            }
            DataTable temp = new DataTable();

            for (int i = 0; i < table.Table_colums.Count; i++)
            {
                temp.Rows.Add();
            }
            dataGridView1.DataSource = temp;
            for (int i = 0; i < table.Table_colums.Count; i++)
            {
                if (table.Primary_keys.Contains(table.Table_colums[i].name.ToString()))
                {
                    dataGridView1.Rows[i].Cells[2].Value = true;
                }
            }

            for (int i = 0; i < table.Table_colums.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = table.Table_colums[i].name.ToString();
                dataGridView1.Rows[i].Cells[1].Value = table.Table_colums[i].type.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            combo_T_Names.Items.Clear();
            combo_T_Names.Text = "";
            DataTable tt = new DataTable();
            dataGridView1.DataSource = tt;
            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();
            

            for (int i = 0; i < table_list.Count; i++)
            {
                combo_T_Names.Items.Add(table_list.ElementAt(i).table_name);
            }
        }

        private void D_Col_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Delete this Col ?", "Warring", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowindex);
                List<tables> table_list = new List<tables>();
                table_list = get_List_of_Tables();

                string table_name = combo_T_Names.SelectedItem.ToString();

                int index = 0;
                for (int i = 0; i < table_list.Count; i++)
                {
                    if (table_list.ElementAt(i).table_name == table_name)
                    {
                        index = i;
                        break;
                    }
                }
                table_list[index].Table_colums.RemoveAt(rowindex);

                    Save(table_list);
                MessageBox.Show("Deleted (-_-)");
            }
        }
    }
}
