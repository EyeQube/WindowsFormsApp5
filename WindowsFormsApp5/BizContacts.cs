using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class BizContacts : Form
    {
        string connString = @"Data Source=DESKTOP-V4R7G9G\SQLEXPRESS;Initial Catalog=AdressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlDataAdapter dataAdapter; //this object here allows us to build the connection between the program and the database
        DataTable table;//table to hold the information so we can fill the datagrid view


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

        private void GetData(string selectCommand)
        {
            try
            {
                dataAdapter = new SqlDataAdapter(selectCommand, connString);//pass in the select command and the connection string
                table = new DataTable(); //make a new data table object
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table); //fill the data table
                bindingSource1.DataSource = table; //set the data source on the binding source to the table
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);//show a useful message to the user of the program
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command;//declares a new sql command object
            //field names in the table
            string insert = @"insert into BizContacts(Date_Added, Company, Website, Title, First_Name, Last_Name, Address, City, State, Postal_Code, Mobile, Notes)
            
                              values(@Date_Added, @Company, @Website, @Title, @First_Name, @Last_Name, @Address, @City, @State, @Postal_Code, @Mobile, @Notes)"; //parameter names

            using(SqlConnection conn = new SqlConnection(connString)) //using allows disposing of low level resources
            {
                try
                {
                    conn.Open(); //open the connection
                    command = new SqlCommand(insert, conn);//create the new sql command object
                    command.Parameters.AddWithValue(@"Date_Added", dateTimePicker1.Value.Date); //read value from form and save to table
                    command.Parameters.AddWithValue(@"Company", txtCompany.Text);
                    command.Parameters.AddWithValue(@"Website", txtWebsite.Text);
                    command.Parameters.AddWithValue(@"Title", txtTitle.Text);
                    command.Parameters.AddWithValue(@"First_Name", txtFName.Text);
                    command.Parameters.AddWithValue(@"Last_Name", txtLName.Text);
                    command.Parameters.AddWithValue(@"Address", txtAddress.Text);
                    command.Parameters.AddWithValue(@"City", txtCity.Text);
                    command.Parameters.AddWithValue(@"State", txtState.Text);
                    command.Parameters.AddWithValue(@"Postal_Code", txtPostalCode.Text);
                    command.Parameters.AddWithValue(@"Mobile", txtMobile.Text);
                    command.Parameters.AddWithValue(@"Notes", txtNotes.Text);
                    command.ExecuteNonQuery();//push stuff into the table
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message); //If ther is something wrong, show the user a message
                }
                
            }

            GetData("Select * from BizContacts");
            dataGridView1.Update(); //Redraws the data grid view so the new record is visible on the bottom
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
