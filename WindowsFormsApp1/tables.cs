using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class Columns
    {
        public string name;
        public string type;
        public List<string> data;
        public List<string> constrains;
        public bool isforgin;
        public List<string> data_forgin;
        public Columns()
        {
            name = "";
            type = "";
            data = new List<string>();
            constrains = new List<string>();
            isforgin = false;
            data_forgin = new List<string>();
        }
        public Columns(string na, string ty)
        {
            name = na;
            type = ty;

        }
        public void Enter_col_data(List<string> da, List<string> cons)
        {
            data = da;
            constrains = cons;
        }
        public void Enter_col_data(string na, string ty, List<string> da, List<string> cons)
        {
            name = na;
            type = ty;
            data = da;
            constrains = cons;
        }
    }
    [Serializable]
    public class tables
    {
        public List<string> Primary_keys;
        public List<Columns> Table_colums;
        public string table_name;
        public tables()
        {
            Primary_keys = new List<string>();
            Table_colums = new List<Columns>();
            table_name = "";
        }
    }
}
