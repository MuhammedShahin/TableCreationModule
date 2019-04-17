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
    public partial class Create_T : UserControl
    {
        private static Create_T _instance;
        public static Create_T instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Create_T();
                return _instance;
            }
        }
        public Create_T()
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


        private void C_Click(object sender, EventArgs e)
        {
            // our code .............
            FileStream fs = new FileStream("table_name.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string table_name = sr.ReadLine();
            sr.Close();
            fs.Close();

            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();

            tables tab = new tables();
            tab.table_name = table_name;
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
            table_list.Add(tab);
            Save(table_list);

            DataTable t = new DataTable();
            dataGridView1.DataSource = t;

            if (Constrain_T.instance.Visible == false)
            {
                Constrain_T.instance.Visible = true;
            }
            if (!panel.Controls.Contains(Constrain_T.instance))
            {
                panel.Controls.Add(Constrain_T.instance);
                Constrain_T.instance.Dock = DockStyle.Fill;
                Constrain_T.instance.BringToFront();
            }
            else
                Constrain_T.instance.BringToFront();
        }
    }
}
