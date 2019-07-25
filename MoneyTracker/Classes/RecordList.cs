//Tommy Huynh
//4/18/19
//Stores Person objects
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace MoneyTracker.Classes
{
    [Serializable()]
    public class RecordList
    {
        List<Record> rlist = new List<Record>();
        public void add(Record r) //add a person to list 
        {
            rlist.Add(r);
        }
        public int Count()//return count of list
        {
            return rlist.Count;
        }
        public string showContent()
        {
            string s = "";
            foreach(Record r in rlist)
            {
                s += r.show();
            }
            return s;
        }
    }
}
