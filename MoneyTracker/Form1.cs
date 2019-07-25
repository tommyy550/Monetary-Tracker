using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyTracker.Classes;

namespace MoneyTracker
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        RecordList rList = new RecordList();
        string FileName = "PersistentObject1.bin";

       

        private void Form1_Load(object sender, EventArgs e)
        {
            POManager.readFromFile(ref rList, FileName);
            dateTimePicker1.Value = DateTime.Now;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            POManager.writeToFile(rList, FileName);//write to binary file
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Record r = new Record(txtItem.Text, Convert.ToDecimal(txtPrice.Text),dateTimePicker1.Value);
            rList.add(r);
            dateTimePicker1.Value = DateTime.Now;
            
        }

       
    }
}
