using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class BizContacts : Form
    {
        public BizContacts()
        {
            InitializeComponent();
        }

        private void BizContacts_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0; //first item in combobox is selected when the form loads
            dataGridView1.DataSource = bindingSource1; //sets the source of the data to be displayed in the grid view

            //Line below calls a method called GetData
            //The argument is a string that represents an sql query
            //select * from BizContacts means select all the data from the biz contacts table
            GetData("Select * from BizContacts");
        }

        private void GetData(string v)
        {
            throw new NotImplementedException();
        }
    }
}
