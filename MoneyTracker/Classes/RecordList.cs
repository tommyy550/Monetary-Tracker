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
        int recordCount = 1;
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
        public int getRecordCount()
        {
            return recordCount;
        }
        public void incrementRecordCount()
        {
            recordCount++;
        }
        public decimal total()
        {
            decimal d = 0;
            foreach(Record r in rlist)
            {
                d += r.getCost();
            }
            return d;
        }
        public decimal average()
        {
            return total() / rlist.Count;
        }

    }
}
