﻿using System;
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
    public partial class frmMoneyTracker : Form
    {
        
        
        public frmMoneyTracker()
        {
            InitializeComponent();
        }
        RecordList rList = new RecordList();
        
        string FileName = "PersistentObject1.bin";

       

        private void Form1_Load(object sender, EventArgs e)
        {
            POManager.readFromFile(ref rList, FileName);
            dateTimePicker1.Value = DateTime.Now;
            try
            {
                txtAverage.Text = rList.average().ToString();
                
            }
            catch
            {
                MessageBox.Show("No records exist. Cannot divide by 0.");
            }
            txtTotal.Text = rList.total().ToString();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            POManager.writeToFile(rList, FileName);//write to binary file
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Record r = new Record(rList.getRecordCount(), txtItem.Text, Convert.ToDecimal(txtPrice.Text), dateTimePicker1.Value);
                if (r.getCost() > 100)
                {
                    MessageBox.Show("That is quite a large amount of money. You should try to budget more.");
                }
                rList.add(r);
                
            }
            catch
            {
                MessageBox.Show("Enter a valid price.");
            }
            
            dateTimePicker1.Value = DateTime.Now;
            rList.incrementRecordCount();
            txtTotal.Text = rList.total().ToString();
            txtAverage.Text = rList.average().ToString();
            

        }

        private void btnShowRecords_Click(object sender, EventArgs e)
        {
            MessageBox.Show(rList.showContent());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                rList.deleteRecord(Convert.ToInt32(txtDelete.Text));
            }
            catch
            {
                MessageBox.Show("Done");
            }

        }
       
        //view stat
        private void button1_Click(object sender, EventArgs e)
        {
          
            String[] arr = new string[12];
            int counter = 0;
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                arr[counter] = itemChecked.ToString();
                counter++;
            }
            try
            {
                rList.viewRecords(arr, txtYear.Text);
            }
            catch
            {
                MessageBox.Show("Please check off at least one month and input a year in format XXXX.");
            }
        }
    }
}
