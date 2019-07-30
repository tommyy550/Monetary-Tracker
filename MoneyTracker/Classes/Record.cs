using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Globalization.CultureInfo;
//using System.Globalization.DateTimeStyles;
//using System.IFormatProvider;

// For serialization
using System.Runtime.Serialization.Formatters.Binary;


namespace MoneyTracker.Classes
{
    [Serializable()]
    public class Record
    {
        int ID;
        string name;
        decimal cost;
        DateTime time;
        public Record(int id,string s,decimal c, DateTime t)
        {
            ID = id;
            name = s;
            cost = c;
            time = t;
        }
        public string show()
        {
            return ID.ToString() + "   " + name + "   " + cost.ToString() + "   " + time.ToString()+ "\n";
        }
        public decimal getCost()
        {
            return cost;
        }
        public int getID()
        {
            return ID;
        }
        public string getMonth()
        {
           return time.ToString("MMMM");
        }
        public string getYear()
        {
            return time.Year.ToString();
        }
    }
}
