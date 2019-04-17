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
    public partial class Update_T : UserControl
    {
        public List<string> col_name = new List<string>();
        private static Update_T _instance;
        public static Update_T instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Update_T();
                return _instance;
            }
        }
        public Update_T()
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

        private void D_Col_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Do You Want To Delete this Column ?", "Warring", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            //{
            //    int colindex = dataGridView1.CurrentCell.ColumnIndex;
            //    dataGridView1.Columns.RemoveAt(colindex);
            //    List<tables> table_list = new List<tables>();
            //    string table_name = Table_name();
            //    table_list = get_List_of_Tables();

            //    int index = 0;
            //    for (int i = 0; i < table_list.Count; i++)
            //    {
            //        if (table_list.ElementAt(i).table_name == table_name)
            //        {
            //            index = i;
            //            break;
            //        }
            //    }
            //    table_list[index].Table_colums.RemoveAt(colindex);
            //    Save(table_list);
            //    MessageBox.Show("Deleted (-_-)");
            //}
        }

        private void D_Row_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Delete this Row ?", "Warring", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowindex);
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
                for (int j = 0; j < table_list[index].Table_colums.Count; j++)
                {
                    if (table_list[index].Table_colums[j].data.Count <= rowindex)
                        continue;
                    table_list[index].Table_colums[j].data.RemoveAt(rowindex);
                }
                Save(table_list);
                MessageBox.Show("Deleted (-_-)");
            }
        }
        public DataColumn[] set_col(List<tables> table_list, int index, DataTable t)
        {
            int count = 0;
            for (int i = 0; i < table_list[index].Table_colums.Count; i++)
            {
                if (table_list[index].Table_colums.ElementAt(i).type == "int")
                {
                    bool z1 = true;
                    for (int j = 0; j < table_list[index].Table_colums.ElementAt(i).constrains.Count; j++)
                    {
                        if (table_list[index].Table_colums.ElementAt(i).constrains[j] == "Auto")
                        {
                            z1 = false;
                        }
                    }
                    if (z1 == true)
                    {
                        t.Columns.Add(table_list[index].Table_colums.ElementAt(i).name, typeof(int));
                        for (int j = 0; j < table_list[index].Primary_keys.Count; j++)
                        {
                            if (table_list[index].Primary_keys.ElementAt(j) == table_list[index].Table_colums.ElementAt(i).name)
                                count++;
                        }
                    }
                }

                else if ((table_list[index].Table_colums.ElementAt(i).type == "string") || (table_list[index].Table_colums.ElementAt(i).type == "date"))
                {
                    bool z2 = true;
                    for (int j = 0; j < table_list[index].Table_colums.ElementAt(i).constrains.Count; j++)
                    {
                        if (table_list[index].Table_colums.ElementAt(i).constrains[j] == "Auto")
                        {
                            z2 = false;
                        }
                    }
                    if (z2 == true)
                    {
                        t.Columns.Add(table_list[index].Table_colums.ElementAt(i).name, typeof(string));
                        for (int j = 0; j < table_list[index].Primary_keys.Count; j++)
                        {
                            if (table_list[index].Primary_keys.ElementAt(j) == table_list[index].Table_colums.ElementAt(i).name)
                                count++;
                        }
                    }
                }
                else if (table_list[index].Table_colums.ElementAt(i).type == "char")
                {
                    bool z3 = true;
                    for (int j = 0; j < table_list[index].Table_colums.ElementAt(i).constrains.Count; j++)
                    {
                        if (table_list[index].Table_colums.ElementAt(i).constrains[j] == "Auto")
                        {
                            z3 = false;
                        }
                    }
                    if (z3 == true)
                    {
                        t.Columns.Add(table_list[index].Table_colums.ElementAt(i).name, typeof(char));
                        for (int j = 0; j < table_list[index].Primary_keys.Count; j++)
                        {
                            if (table_list[index].Primary_keys.ElementAt(j) == table_list[index].Table_colums.ElementAt(i).name)
                                count++;
                        }
                    }
                }
                else if (table_list[index].Table_colums.ElementAt(i).type == "double")
                {
                    bool z4 = true;
                    for (int j = 0; j < table_list[index].Table_colums.ElementAt(i).constrains.Count; j++)
                    {
                        if (table_list[index].Table_colums.ElementAt(i).constrains[j] == "Auto")
                        {
                            z4 = false;
                        }
                    }
                    if (z4 == true)
                    {
                        t.Columns.Add(table_list[index].Table_colums.ElementAt(i).name, typeof(double));
                        for (int j = 0; j < table_list[index].Primary_keys.Count; j++)
                        {
                            if (table_list[index].Primary_keys.ElementAt(j) == table_list[index].Table_colums.ElementAt(i).name)
                                count++;
                        }
                    }
                }
                else if (table_list[index].Table_colums.ElementAt(i).type == "long")
                {
                    bool z5 = true;
                    for (int j = 0; j < table_list[index].Table_colums.ElementAt(i).constrains.Count; j++)
                    {
                        if (table_list[index].Table_colums.ElementAt(i).constrains[j] == "Auto")
                        {
                            z5 = false;
                        }
                    }
                    if (z5 == true)
                    {
                        t.Columns.Add(table_list[index].Table_colums.ElementAt(i).name, typeof(long));
                        for (int j = 0; j < table_list[index].Primary_keys.Count; j++)
                        {
                            if (table_list[index].Primary_keys.ElementAt(j) == table_list[index].Table_colums.ElementAt(i).name)
                                count++;
                        }
                    }
                }
                else if (table_list[index].Table_colums.ElementAt(i).type == "float")
                {
                    bool z6 = true;
                    for (int j = 0; j < table_list[index].Table_colums.ElementAt(i).constrains.Count; j++)
                    {
                        if (table_list[index].Table_colums.ElementAt(i).constrains[j] == "Auto")
                        {
                            z6 = false;
                        }
                    }
                    if (z6 == true)
                    {
                        t.Columns.Add(table_list[index].Table_colums.ElementAt(i).name, typeof(float));
                        for (int j = 0; j < table_list[index].Primary_keys.Count; j++)
                        {
                            if (table_list[index].Primary_keys.ElementAt(j) == table_list[index].Table_colums.ElementAt(i).name)
                                count++;
                        }
                    }
                }
            }

            DataColumn[] arr = new DataColumn[count];
            string s;
            int m = 0;
            for (int i = 0; i < t.Columns.Count; i++)
            {
                s = t.Columns[i].ColumnName;
                for (int j = 0; j < table_list[index].Primary_keys.Count; j++)
                {
                    if (table_list[index].Primary_keys.ElementAt(j) == s)
                    {
                        arr[m] = t.Columns[i];
                        m++;
                    }
                }
            }
            return arr;
        }
        public void enter_data(List<tables> table_list, int index, int[] arr, List<Columns> Un_auto)
        {
            int count = 0;
            for (int i = 0; i < table_list[index].Table_colums.Count; i++)
            {
                if (table_list[index].Table_colums[i].constrains.Count > 0)
                {
                    if (table_list[index].Table_colums[i].constrains[0] == "Auto")
                    {
                        arr[i]++;
                    }
                }
            }
            for (int i = 0; i < table_list[index].Table_colums.Count; i++)
            {
                if (arr[i] == 0)
                {
                    Un_auto.Add(table_list[index].Table_colums[i]);
                }
            }
            for (int i = 0; i < Un_auto.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    Un_auto[i].data.Add(dataGridView1.Rows[j].Cells[i].Value.ToString());
                }
            }


            for (int i = 0; i < table_list[index].Table_colums.Count; i++)
            {
                if (table_list[index].Table_colums[i].constrains.Count > 0)
                {
                    if (table_list[index].Table_colums[i].constrains[0] == "Auto")
                    {
                        Un_auto.Add(table_list[index].Table_colums[i]);
                    }
                }
            }
            for (int i = 0; i < Un_auto.Count; i++)
            {
                if (Un_auto[i].constrains.Count > 0)
                {
                    if (Un_auto[i].constrains[0] == "Auto")
                    {
                        for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                        {
                            count++;
                            Un_auto[i].data.Add(count.ToString());
                        }
                    }
                }
            }

            for (int i = 0; i < Un_auto.Count; i++)
            {
                for (int j = 0; j < table_list[index].Table_colums.Count; j++)
                {
                    if (Un_auto[i].name == table_list[index].Table_colums[j].name)
                    {
                        table_list[index].Table_colums[j].data = Un_auto[i].data;
                    }
                }
            }
        }
        public bool check_data(List<Columns> l1)
        {
            bool x1 = true;
            int pos = 0;
            for (int m = 0; m < l1.Count; m++)
            {
                for (int n = 0; n < l1[m].constrains.Count; n++)
                {
                    string x = l1[m].constrains[n].ToString();
                    if (x == "Auto")
                    {
                        break;
                    }

                    pos = m;
                    double y1 = 0;
                    string f = x[0].ToString();

                    string valueS = "";
                    string fraction = "0.";
                    double value_With_Fra = new double();
                    int valueN = new int();

                    /***************************/
                    if (f == "<")
                    {
                        if (x[1].ToString() == "=")
                        {
                            f = "<=";
                            for (int L = 2; L < x.Length; L++)
                            {
                                if (x[L].ToString() == ".")
                                {
                                    for (int Q = L + 1; Q < x.Length; Q++)
                                    {
                                        fraction += x[Q].ToString();
                                    }
                                    value_With_Fra = double.Parse(fraction);
                                    break;
                                }
                                else
                                    valueS += x[L].ToString();
                            }
                            valueN = int.Parse(valueS);
                            value_With_Fra += valueN;
                        }
                        else
                        {
                            f = "<";
                            for (int L = 1; L < x.Length; L++)
                            {
                                if (x[L].ToString() == ".")
                                {
                                    for (int Q = L + 1; Q < x.Length; Q++)
                                    {
                                        fraction += x[Q].ToString();
                                    }
                                    value_With_Fra = double.Parse(fraction);
                                    break;
                                }
                                valueS += x[L].ToString();
                            }
                            valueN = int.Parse(valueS);
                            value_With_Fra += valueN;
                        }
                    }
                    /*************************/
                    else if (f == ">")
                    {
                        if (x[1].ToString() == "=")
                        {
                            f = ">=";
                            for (int L = 2; L < x.Length; L++)
                            {
                                if (x[L].ToString() == ".")
                                {
                                    for (int Q = L + 1; Q < x.Length; Q++)
                                    {
                                        fraction += x[Q].ToString();
                                    }
                                    value_With_Fra = double.Parse(fraction);
                                    break;
                                }
                                valueS += x[L].ToString();
                            }
                            valueN = int.Parse(valueS);
                            value_With_Fra += valueN;
                        }
                        else
                        {
                            f = ">";
                            for (int L = 1; L < x.Length; L++)
                            {
                                if (x[L].ToString() == ".")
                                {
                                    for (int Q = L + 1; Q < x.Length; Q++)
                                    {
                                        fraction += x[Q].ToString();
                                    }
                                    value_With_Fra = double.Parse(fraction);
                                    break;
                                }
                                valueS += x[L].ToString();
                            }
                            valueN = int.Parse(valueS);
                            value_With_Fra += valueN;
                        }
                    }
                    /*************************/
                    else if (f == "!")
                    {
                        if (x[1].ToString() == "=")
                        {
                            f = "!=";
                            for (int L = 2; L < x.Length; L++)
                            {
                                if (x[L].ToString() == ".")
                                {
                                    for (int Q = L + 1; Q < x.Length; Q++)
                                    {
                                        fraction += x[Q].ToString();
                                    }
                                    value_With_Fra = double.Parse(fraction);
                                    break;
                                }
                                valueS += x[L].ToString();
                            }
                            valueN = int.Parse(valueS);
                            value_With_Fra += valueN;
                        }
                    }
                    /*************************/
                    else if (f == "=")
                    {
                        f = "=";
                        for (int L = 1; L < x.Length; L++)
                        {
                            if (x[L].ToString() == ".")
                            {
                                for (int Q = L + 1; Q < x.Length; Q++)
                                {
                                    fraction += x[Q].ToString();
                                }
                                value_With_Fra = double.Parse(fraction);
                                break;
                            }
                            valueS += x[L].ToString();
                        }
                        valueN = int.Parse(valueS);
                        value_With_Fra += valueN;

                    }
                    /*************************/
                    else if (f == "u")
                    {
                        f = "uni";
                        valueN = 0;
                    }

                    /************************************************************************/

                    y1 = value_With_Fra;
                    Dictionary<string, int> Check_temp = new Dictionary<string, int>();
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        double s;
                        bool Can_Be_String = double.TryParse(dataGridView1.Rows[i].Cells[pos].Value.ToString(), out s);

                        if (Can_Be_String == true)
                        {
                            if (f == "<")
                            {
                                if (s > y1)
                                {
                                    x1 = false;
                                    MessageBox.Show("the data you entered is conflicted with your constraints");
                                    break;
                                }
                            }
                            else if (f == ">")
                            {
                                if (s < y1)
                                {
                                    x1 = false;
                                    MessageBox.Show("the data you entered is conflicted with your constraints");
                                    break;
                                }
                            }
                            else if (f == "<=")
                            {
                                if (s > y1)
                                {
                                    x1 = false;
                                    MessageBox.Show("the data you entered is conflicted with your constraints");
                                    break;
                                }
                            }
                            else if (f == ">=")
                            {
                                if (s < y1)
                                {
                                    x1 = false;
                                    MessageBox.Show("the data you entered is conflicted with your constraints");
                                    break;
                                }
                            }
                            else if (f == "=")
                            {
                                if (s != y1)
                                {
                                    x1 = false;
                                    MessageBox.Show("the data you entered is conflicted with your constraints");
                                    break;
                                }
                            }
                            else if (f == "!=")
                            {
                                if (s == y1)
                                {
                                    x1 = false;
                                    MessageBox.Show("the data you entered is conflicted with your constraints");
                                    break;
                                }
                            }


                            else if (f == "u")
                            {
                                if (Check_temp.ContainsKey(dataGridView1.Rows[i].Cells[pos].Value.ToString()))
                                {
                                    MessageBox.Show("This value " + dataGridView1.Rows[i].Cells[pos].Value.ToString() + " is already Exist");
                                    x1 = false;
                                }
                                else
                                {
                                    Check_temp.Add(dataGridView1.Rows[i].Cells[pos].Value.ToString(), 0);
                                }
                            }
                        }
                    }
                }
            }
            return x1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
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
            bool x2;
            int u = table_list[index].Table_colums.Count;
            if (dataGridView1.Columns.Count == table_list[index].Table_colums.Count)
            {
                List<Columns> l1 = new List<Columns>();
                for (int i = 0; i < table_list[index].Table_colums.Count; i++)
                {
                    l1.Add(table_list[index].Table_colums[i]);
                }
                x2 = check_data(l1);

            }
            else
            {
                List<Columns> l2 = new List<Columns>();
                for (int i = 0; i < table_list[index].Table_colums.Count; i++)
                {
                    if (table_list[index].Table_colums[i].constrains.Count > 0)
                    {
                        if (table_list[index].Table_colums[i].constrains[0] != "Auto")
                        {
                            l2.Add(table_list[index].Table_colums[i]);
                        }
                    }
                    else
                    {
                        l2.Add(table_list[index].Table_colums[i]);
                    }

                }
                x2 = check_data(l2);
            }

            /***********************************************************************************************************************************************************/
            List<Columns> Un_auto = new List<Columns>();
            int[] arr = new int[table_list[index].Table_colums.Count];
            for (int i = 0; i < table_list[index].Table_colums.Count; i++)
            {
                arr[i] = 0;
            }
            DataTable t1 = new DataTable();
            if (x2 == true)
            {
                if (table_list[index].Table_colums[0].data.Count == 0)
                {
                    enter_data(table_list, index, arr, Un_auto);
                }
                else
                {
                    for (int i = 0; i < table_list[index].Table_colums.Count; i++)
                    {
                        table_list[index].Table_colums[i].data.Clear();
                    }
                    Un_auto.Clear();
                    enter_data(table_list, index, arr, Un_auto);
                }
                Save(table_list);
                DataTable tt = new DataTable();
                dataGridView1.DataSource = tt;
            }
        }

        private void Update_T_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            DataTable tt = new DataTable();
            dataGridView1.DataSource = tt;
            List<Columns> l1 = new List<Columns>();
            List<tables> table_list = new List<tables>();
            table_list = get_List_of_Tables();
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
            int max = table_list[index].Table_colums[0].data.Count; // get the maximum number of rows

            for (int i = 0; i < table_list[index].Table_colums.Count - 1; i++)
            {
                int count1 = table_list[index].Table_colums[i + 1].data.Count;
                if (count1 > max)
                {
                    max = count1;
                }
            }
            if (table_list[index].Table_colums[0].data.Count == 0) // if colums are empty user will enter data
            {
                DataTable t = new DataTable();
                t.PrimaryKey = set_col(table_list, index, t);
                dataGridView1.DataSource = t;
            }
            else // if colums aren't empty it will load old data and edit it
            {
                DataTable t = new DataTable();
                DataColumn[] arr1 = set_col(table_list, index, t);
                for (int i = 0; i < max; i++)
                {
                    t.Rows.Add();
                }
                dataGridView1.DataSource = t;
                for (int i = 0; i < table_list[index].Table_colums.Count; i++)
                {
                    if (table_list[index].Table_colums[i].constrains.Count > 0)
                    {
                        if (table_list[index].Table_colums[i].constrains[0] != "Auto")
                        {
                            l1.Add(table_list[index].Table_colums[i]);
                        }
                    }
                    else
                    {
                        l1.Add(table_list[index].Table_colums[i]);
                    }
                }
                for (int i = 0; i < l1.Count; i++)
                {
                    for (int j = 0; j < l1[i].data.Count; j++)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = l1[i].data[j].ToString();
                    }
                }
                t.PrimaryKey = arr1;
                dataGridView1.DataSource = t;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}

