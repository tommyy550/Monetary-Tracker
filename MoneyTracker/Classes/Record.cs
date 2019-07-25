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
        string name;
        decimal cost;
        public Record(string s,decimal c)
        {
            name = s;
            cost = c;
        }
    }
}
