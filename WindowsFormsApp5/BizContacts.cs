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
using System.IO;//needed for file use
using System.Diagnostics;//needed to open up excel from our code using Process.Start
using Microsoft.Office.Interop.Excel;//needed to make an excel object in our code
using Microsoft.Office.Interop.Word;
using System.Collections;

namespace WindowsFormsApp5
{
    public partial class BizContacts : Form
    {
        string connString = @"Data Source=SAK\SQLEXPRESS;Initial Catalog=AdressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlDataAdapter dataAdapter; //this object here allows us to build the connection between the program and the database
        System.Data.DataTable table;//table to hold the information so we can fill the datagrid view
        //SqlCommandBuilder commandBuilder; //declare a new sql command builder object
        SqlConnection conn;//declares a variable to hold the sql connection
        string selectionStatement = "Select * from BizContacts";
        //string selectionOrg = "select * from BizContacts where lower(organisation)";

        public BizContacts()
        {
            InitializeComponent();
            refreshdata();
        }

        public void refreshdata()
        {
            DataRow dr;
            DataRow dInsatsK;
            DataRow Beslut;
            DataRow BeslutsFA;
            DataRow Orsak;
          

            SqlConnection con = new SqlConnection(@"Data Source=SAK\SQLEXPRESS;Initial Catalog=AdressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM BizContacts WHERE ID IN(SELECT MIN(ID) FROM BizContacts GROUP BY Organisation)", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);

            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "Organisation" };
            dt.Rows.InsertAt(dr, 0);

            
            cboOrganisation.ValueMember = "ID";
            cboOrganisation.DisplayMember = "Organisation";
            cboOrganisation.DataSource = dt;

                
            SqlCommand Ins = new SqlCommand("SELECT * FROM BizContacts WHERE ID IN(SELECT MIN(ID) FROM BizContacts GROUP BY Insatskategori)", con);
            SqlDataAdapter In = new SqlDataAdapter(Ins);
            System.Data.DataTable di = new System.Data.DataTable();
            In.Fill(di);

            dInsatsK = di.NewRow();
            dInsatsK.ItemArray = new object[] { 0, "Insatskategori" };
            di.Rows.InsertAt(dInsatsK, 0);

            cboInsatsK.ValueMember = "ID";
            cboInsatsK.DisplayMember = "Insatskategori";
            cboInsatsK.DataSource = di;



            SqlCommand Bes = new SqlCommand("SELECT * FROM BizContacts WHERE ID IN(SELECT MIN(ID) FROM BizContacts GROUP BY Beslut)", con);
            SqlDataAdapter Be = new SqlDataAdapter(Bes);
            System.Data.DataTable db = new System.Data.DataTable();
            Be.Fill(db);

            Beslut = db.NewRow();
            Beslut.ItemArray = new object[] { 0, "Beslut" };
            db.Rows.InsertAt(Beslut, 0);

            cboBeslut.ValueMember = "ID";
            cboBeslut.DisplayMember = "Beslut";
            cboBeslut.DataSource = db;


            /*System.Data.DataTable dbe = new System.Data.DataTable();
              sda.Fill(dbe);

              dr = dbe.NewRow();
              dr.ItemArray = new object[] { 0, "Beslutsdatum" };
              dbe.Rows.InsertAt(dr, 0);

              cboBeslutsdatum.ValueChanged = "ID";
              cboBeslutsdatum.DisplayMember = "Beslutsdatum";
              cboBeslutsdatum.DataSource = dbe; */

            SqlCommand Besfat = new SqlCommand("SELECT * FROM BizContacts WHERE ID IN(SELECT MIN(ID) FROM BizContacts GROUP BY Beslutsfattare)", con);
            SqlDataAdapter Besfa = new SqlDataAdapter(Besfat);
            System.Data.DataTable dbf = new System.Data.DataTable();
            Besfa.Fill(dbf);

            BeslutsFA = dbf.NewRow();
            BeslutsFA.ItemArray = new object[] { 0, "Beslutsfattare" };
            dbf.Rows.InsertAt(BeslutsFA, 0);

            cboBeslutsfattare.ValueMember = "ID";
            cboBeslutsfattare.DisplayMember = "Beslutsfattare";
            cboBeslutsfattare.DataSource = dbf;



            SqlCommand Orsaka = new SqlCommand("SELECT * FROM BizContacts WHERE ID IN(SELECT MIN(ID) FROM BizContacts GROUP BY Orsak)", con);
            SqlDataAdapter Orsa = new SqlDataAdapter(Orsaka);
            System.Data.DataTable ors = new System.Data.DataTable();
            Orsa.Fill(ors);

            Orsak = ors.NewRow();
            Orsak.ItemArray = new object[] { 0, "Orsak" };
            ors.Rows.InsertAt(Orsak, 0);

            cboOrsak.ValueMember = "ID";
            cboOrsak.DisplayMember = "Orsak";
            cboOrsak.DataSource = ors;

                                                               

            con.Close();
        }


        private void BizContacts_Load(object sender, EventArgs e)
        {
            refreshdata();

            dataGridView1.DataSource = bindingSource1; //sets the source of the data to be displayed in the grid view

            // cboOrganisation.SelectedIndex = 0; //first item in combobox is selected when the form loads

            //cboOrganisation.DisplayMember = "Organisation";
            //cboOrganisation.ValueMember = "Organisation";

            //Line below calls a method called GetData
            //The argument is a string that represents an sql query
            //select * from BizContacts means select all the data from the biz contacts table

            dataGridView1.Columns[0].Visible = false;

            GetData(selectionStatement);
        }

        private void GetData(string selectCommand)
        {
            try
            {
                dataAdapter = new SqlDataAdapter(selectCommand, connString);//pass in the select command and the connection string
                table = new System.Data.DataTable(); //make a new data table object
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table); //fill the data table
                bindingSource1.DataSource = table; //set the data source on the binding source to the table

                

                //dataGridView1.RowTemplate.ReadOnly = false;

                //dataGridView1.Columns[0].ReadOnly = true; //this helps prevent the idfield from being changed
                // dataGridView1.Columns[0].Visible = false;
                // dataGridView1.Columns[1].Visible = false;
                //dataGridView1.Columns[10].Visible = false;
                //dataGridView1.Columns[11].Visible = false;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);//show a useful message to the user of the program
            }

            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command;//declares a new sql command object
            //field names in the table
            string insert = @"insert into BizContacts(Personnummer, Förnamn, Efternamn, Beslut, Beslutsdatum, Insatskategori, Beslutsfattare, Organisation, Orsak, Anteckningar)
            
                              values(@Personnummer, @Förnamn, @Efternamn, @Beslut, @Beslutsdatum, @Insatskategori, @Beslutsfattare, @Organisation, @Orsak, @Notes)"; //parameter names

            using (conn = new SqlConnection(connString)) //using allows disposing of low level resources
            {
                try
                {
                    conn.Open(); //open the connection
                    command = new SqlCommand(insert, conn);//create the new sql command object
                    command.Parameters.AddWithValue(@"Personnummer", txtPersonnummer.Text);
                    command.Parameters.AddWithValue(@"Förnamn", txtFörnamn.Text);
                    command.Parameters.AddWithValue(@"Efternamn", txtEfternamn.Text);
                    command.Parameters.AddWithValue(@"Beslut", cboBeslut.Text);
                    command.Parameters.AddWithValue(@"Beslutsdatum", dtpBeslutsdatum.Value.Date); //read value from form and save to table
                    command.Parameters.AddWithValue(@"Insatskategori", cboInsatsK.Text);
                    command.Parameters.AddWithValue(@"Beslutsfattare", cboBeslutsfattare.Text);
                    command.Parameters.AddWithValue(@"Organisation", txtOrganisation.Text);
                    command.Parameters.AddWithValue(@"Orsak", cboOrsak.Text);
                    command.Parameters.AddWithValue(@"Notes", txtNotes.Text);

                    /*  if(!(String.IsNullOrWhiteSpace(txtOrganisation.Text)) && !(cboOrganisation.Items.Contains(txtOrganisation.Text.ToString())))
                      cboOrganisation.Items.Add(txtOrganisation.Text.ToString()); */


                    /*System.Object[] ItemObject = new System.Object[50];
                    for (int i = 0; i < ItemObject.Count(); i++)
                    {
                        ItemObject[i] = txtOrganisation.Text.ToString();
                    }
                    cboOrganisation.Items.AddRange(ItemObject);*/



                    /* if (dlgOpenImage.FileName != "") //check whether file name is not empty
                         command.Parameters.AddWithValue(@"Image", File.ReadAllBytes(dlgOpenImage.FileName));//convert images to bytes for saving
                     else
                         command.Parameters.Add("@Image", SqlDbType.VarBinary).Value = DBNull.Value;//Save null to database*/
                    command.ExecuteNonQuery();//push stuff into the table
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); //If ther is something wrong, show the user a message
                }

            }

            GetData(selectionStatement);
            refreshdata();
            dataGridView1.Update(); //Redraws the data grid view so the new record is visible on the bottom
        }


        /* private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
         {
             SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
             dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();//get the update command
             try
             {
                 bindingSource1.EndEdit();//updates the table that is in memory in our program
                 dataAdapter.Update(table);//actually updates the data base
                 MessageBox.Show("Update Successfull");//confirms to user update is saved 
             }
             catch (Exception ex)
             {
                 dataGridView1.CurrentCell.ErrorText = "Personnummer och beslutsdatum måste vara ifyllda";
                 //MessageBox.Show(ex.Message); //show message to the user

             }
             //refreshdata();
             //dataGridView1.Update(); //Redraws the data grid view so the new record is visible on the bottom
         }  */

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow; //grab a reference to the current row


            //DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            List<DataGridViewRow> lst = dataGridView1.SelectedRows.Cast<DataGridViewRow>().ToList();




            //rows.Clear();
            //rows[0].Cells


            foreach (DataGridViewRow ro in lst)
            {

                //DataRow myRow = (row.DataBoundItem as DataRowView).Row;

                string values = ro.Cells["ID"].Value.ToString();  //Cells["ID"].Value.ToString();//grab the value from the id field of the selected record
                string deleteStates = @"Delete from BizContacts where id = '" + values + "'";//this is the sql to delete the records from the sql table

            }


            if (lst.Count > 1)
            {


                DataGridViewSelectedRowCollection SelectRowsSet = dataGridView1.SelectedRows;

                DataGridViewRow rowz;

                IEnumerator Enumerator = SelectRowsSet.GetEnumerator();

                Enumerator.Reset();

                DialogResult res = MessageBox.Show("Do you really want to delete selected rows?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes) //check whether user really wants to delete records
                {


                    while (Enumerator.MoveNext())
                    {

                        rowz = (DataGridViewRow)Enumerator.Current;

                        string values = rowz.Cells["ID"].Value.ToString();
                        string deleteStates = @"Delete from BizContacts where id = '" + values + "'";

                        if (res == DialogResult.Yes)
                        {
                            using (conn = new SqlConnection(connString))
                            {
                                try
                                {
                                    conn.Open();//try to open connection
                                    SqlCommand comm = new SqlCommand(deleteStates, conn);
                                    comm.ExecuteNonQuery();//this line actually causes the deletion to run                                 
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);//runs when something is wrong with the connection
                                }
                            }
                        }
                    }

                    GetData(selectionStatement);//get the data again;
                    dataGridView1.Update();//redraw the data grid view with updated information
                }
            }
            else
            {
                string value = row.Cells["ID"].Value.ToString();//grab the value from the id field of the selected record
                string fname = row.Cells["Förnamn"].Value.ToString();//grab the value from the name field of the selected record
                string lname = row.Cells["Efternamn"].Value.ToString();//grab the value from the last name field of the selected record
                string pname = row.Cells["Personnummer"].Value.ToString();
                string org = row.Cells["Organisation"].Value.ToString();
                DialogResult result = MessageBox.Show("Do you really want to delete " + fname + " " + lname + ", Personnummer: " + pname + ", record " + value, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                string deleteState = @"Delete from BizContacts where id = '" + value + "'";//this is the sql to delete the records from the sql table

                if (result == DialogResult.Yes) //check whether user really wants to delete records
                {
                    using (conn = new SqlConnection(connString))
                    {
                        try
                        {
                            conn.Open();//try to open connection
                            SqlCommand comm = new SqlCommand(deleteState, conn);
                            comm.ExecuteNonQuery();//this line actually causes the deletion to run
                            GetData(selectionStatement);//get the data again;
                            dataGridView1.Update();//redraw the data grid view with updated information
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);//runs when something is wrong with the connection
                        }
                    }
                }
            }


            refreshdata();
            //cboOrganisation.Items.Remove(org);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (txtSearch.Text)  //(cboSearch.SelectedItem.ToString())//present because we have a combo box
            {
                case "Personnummer":
                    GetData("select * from BizContacts where lower(personnummer) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;

                case "Förnamn":
                    GetData("select * from BizContacts where lower(förnamn) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;

                case "Efternamn":
                    GetData("select * from BizContacts where lower(efternamn) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
            }
        }

        /* private void btnGetImage_Click(object sender, EventArgs e)
         {
             if (dlgOpenImage.ShowDialog() == DialogResult.OK) //use if in case user cancels getting image and FileName is blank
                // dlgOpenImage.ShowDialog(); //show box for selecting image from drive
             pictureBox1.Load(dlgOpenImage.FileName); //loads image from drive using the file name property of the dialog box

         }*/

        /*private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new Form(); //make a new form
            frm.BackgroundImage = pictureBox1.Image;//set background image of new, preview form of image
            frm.Size = pictureBox1.Image.Size;//sets the size of the form to the size of the image so the image is wholly visible
            frm.Show();//show form with image
        }*/

        private void btnExportOpen_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application(); //make a new excel object
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);//make a work book
            _Worksheet worksheet = null;//make a work sheet and for now set it to null


            try
            {

                worksheet = workbook.ActiveSheet;//set active sheet
                worksheet.Name = "Business Contacts";

                //because both data grids and excel sheets are tabular, use nested loops to write from one to the other
                for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count - 1; rowIndex++) //this loop controls the row number
                {
                    for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++) //this is needed to go over the columns of each row
                    {
                        if (rowIndex == 0) //because the first row at index 0 is the header row
                        {
                            //in Excel, row and column indexes begin at 1,1 not 0,0
                            //write out the header texts from the grid view to excel sheet
                            worksheet.Cells[rowIndex + 1, colIndex + 1] = dataGridView1.Columns[colIndex].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[rowIndex + 1, colIndex + 1] = dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString();
                        }
                    }

                }

                if (saveFileDialog1.ShowDialog() == DialogResult.OK) //user clicks ok
                {
                    workbook.SaveAs(saveFileDialog1.FileName); // save file to drive
                    Process.Start("excel.exe", saveFileDialog1.FileName); //load excel with the exported file
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//show message in case of errors
            }
            finally //this code always runs
            {
                excel.Quit();
                workbook = null;//make workbook object null
                excel = null;
            }

        } 

        private void btnSaveToText_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) //check whether somebody has clicked the ok button
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells) //once you have a row grabbed, go through the cells of that row one at a time using foreach
                            sw.Write(cell.Value); //this line actually write the value to a text file
                        sw.WriteLine(); //this pushes the cursor to the next line
                    }
                }
                Process.Start("notepad.exe", saveFileDialog1.FileName); //open file in notepad after the file is written to the drive

            }
        }

         private void btnOpenWord_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word._Application word = new Microsoft.Office.Interop.Word.Application();//make a new word object
            Document doc = word.Documents.Add();//make a new document 
            Microsoft.Office.Interop.Word.Range rng = doc.Range(0, 0);
            Table wdTable = doc.Tables.Add(rng, dataGridView1.Rows.Count, dataGridView1.Columns.Count);//make new table based on our data grid view
            wdTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleDouble;//make a thick outer border
            wdTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;//make the cell lines thin
            try
            {

                doc = word.ActiveDocument; //make an active document in word
                //i is the row index from the data grid view
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++) //this loop is needed to step through the columns of each row
                    {
                        //line below runs several times, each time writing the cell value from the grid to word
                        wdTable.Cell(i + 1, j + 1).Range.InsertAfter(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }

                }

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    doc.SaveAs(saveFileDialog1.FileName); //save file to drive
                    Process.Start("winword.exe", saveFileDialog1.FileName);//open the document in word after the table is made
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // show a box with a message if there is an error
            }
            finally
            {
                word.Quit(); // quit word
                word = null;
                doc = null; //clean up the word object and document object
            }

        } 

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }


        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            //txtSearch.Text = "19301116-3842";

            string txtt = txtSearch.Text;
            string brex1 = "";
            string re = "";
            string er = "";

            if (txtSearch.Text.Length >= 7)
            {
                re = txtt.Substring(6, 1);

            }
            if (txtSearch.Text.Length >= 9)
            {
                er = txtt.Substring(8, 1);
            }


            /* int h;
             bool isNum = int.TryParse(re, out h);

             int year = 0;
             if(isNum == true)
             {
                 year = Convert.ToInt32(re);
             } */


            if (txtt.Length >= 9 && txtt.Length <= 13 && er == "-" && re != "-")
            {
                brex1 = txtt.Remove(8, 1);

            }
            else if (re == "-")//(txtt.Length >= 7 && txtt.Length <= 11 && re == "-")
            {
                brex1 = txtt.Remove(6, 1);
            }
            else
            {
                brex1 = txtSearch.Text;
            }

            long n;
            bool isNumeric = long.TryParse(brex1, out n);

            // string org = cboOrganisation.Text.ToString().ToLower().Trim();


            if (isNumeric == true && String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
            {

                GetData("select * from BizContacts where replace(personnummer,'-','') like '%" + brex1 + "%'");

            }
            else if (isNumeric == true && !String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
            {
                GetData("select * from BizContacts where replace(personnummer,'-','') like '%" + brex1 +
                         "%'and lower(organisation) like '%" + cboOrganisation.Text.ToString().ToLower() + "%'");
            }

            else if (String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()) && String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()))
            {
                GetData("select * from BizContacts");
            }

            else if (String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()) && !String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()))
            {
                GetData("select * from BizContacts where lower(efternamn) like '%" + txtSearch.Text.ToLower() + "%'");
            }

            /* else if (!String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()) && String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
             {
                 GetData("select * from BizContacts where lower(efternamn) like '%" + txtSearch.Text.ToString().ToLower() + "%'");
             } */

            else if (String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()) && !String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
                GetData("select * from BizContacts where lower(organisation) like '%" + cboOrganisation.Text.ToString().ToLower() +
                "%'and len(organisation) like '%" + cboOrganisation.Text.ToString().Length + "%'");

            else if (!String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()) && !String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
            {
                GetData("select * from BizContacts where lower(efternamn) like '%" + txtSearch.Text.ToLower() +
                "%'and lower(organisation) like '%" + cboOrganisation.Text.ToString() +
                "%'and len(organisation) like '%" + cboOrganisation.Text.ToString().Length + "%'");

            }
            else if (!String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()) && !String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
            {
                GetData("select * from BizContacts where lower(efternamn) like '%" + txtSearch.Text.ToLower() +
                "%'and lower(organisation) like '%" + cboOrganisation.Text.ToString().ToLower() +
                "%'and len(organisation) like '%" + cboOrganisation.Text.ToString().ToLower().Length + "%'");

            }
            //dataGridView1.Update();
            /* else 
                 GetData("select * from BizContacts where lower(förnamn) like '%" + txtSearch.Text.ToLower() + "%'"); */

            //  GetData("select * from BizContacts where lower(efternamn) like '%" + txtSearch.Text.ToLower() + "%'");




        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            //txtSearch.Text = "19301116-3842";

            string txtt = txtSearch.Text;
            string brex1 = "";
            string re = "";
            string er = "";

            if (txtSearch.Text.Length >= 7)
            {
                re = txtt.Substring(6, 1);

            }
            if (txtSearch.Text.Length >= 9)
            {
                er = txtt.Substring(8, 1);
            }


            /* int h;
             bool isNum = int.TryParse(re, out h);

             int year = 0;
             if(isNum == true)
             {
                 year = Convert.ToInt32(re);
             } */


            if (txtt.Length >= 9 && txtt.Length <= 13 && er == "-" && re != "-")
            {
                brex1 = txtt.Remove(8, 1);

            }
            else if (re == "-")//(txtt.Length >= 7 && txtt.Length <= 11 && re == "-")
            {
                brex1 = txtt.Remove(6, 1);
            }
            else
            {
                brex1 = txtSearch.Text;
            }

            long n;
            bool isNumeric = long.TryParse(brex1, out n);

            // string org = cboOrganisation.Text.ToString().ToLower().Trim();


            if (isNumeric == true && String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
            {

                GetData("select * from BizContacts where replace(personnummer,'-','') like '%" + brex1 + "%'");

            }
            else if (isNumeric == true && !String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
            {
                GetData("select * from BizContacts where replace(personnummer,'-','') like '%" + brex1 +
                         "%'and lower(organisation) like '%" + cboOrganisation.Text.ToString().ToLower() + "%'");
            }

            else if (String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()) && String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()))
            {
                GetData("select * from BizContacts");
            }

            else if (String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()) && !String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()))
            {
                GetData("select * from BizContacts where lower(efternamn) like '%" + txtSearch.Text.ToLower() + "%'");
            }

            /* else if (!String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()) && String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
             {
                 GetData("select * from BizContacts where lower(efternamn) like '%" + txtSearch.Text.ToString().ToLower() + "%'");
             } */

            else if (String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()) && !String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
                GetData("select * from BizContacts where lower(organisation) like '%" + cboOrganisation.Text.ToString().ToLower() +
                "%'and len(organisation) like '%" + cboOrganisation.Text.ToString().Length + "%'");

            else if (!String.IsNullOrWhiteSpace(txtSearch.Text.ToString().ToLower()) && !String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
            {
                GetData("select * from BizContacts where lower(efternamn) like '%" + txtSearch.Text.ToLower() +
                "%'and lower(organisation) like '%" + cboOrganisation.Text.ToString().ToLower() +
                "%'and len(organisation) like '%" + cboOrganisation.Text.ToString().ToLower().Length + "%'");

            }
            //dataGridView1.Update();
            /* else 
                 GetData("select * from BizContacts where lower(förnamn) like '%" + txtSearch.Text.ToLower() + "%'"); */

            //  GetData("select * from BizContacts where lower(efternamn) like '%" + txtSearch.Text.ToLower() + "%'");



        }


        private void btnDataGridView1_CellEndEdit(object sender, MouseEventArgs e)
        {
             try
            {
                dataGridView1.ReadOnly = false;
                dataGridView1.RowTemplate.ReadOnly = false;

            dataGridView1.Columns[0].ReadOnly = true;
               
                  // dataGridView1.CurrentCell.ReadOnly = true;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("ID kan ej redigeras");
            } 

        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = false;

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();//get the update command
            try
            {
                bindingSource1.EndEdit();//updates the table that is in memory in our program
                dataAdapter.Update(table);//actually updates the data base
                //MessageBox.Show("Update Successfull");//confirms to user update is saved 
            }
            catch (Exception ex)
            {
                dataGridView1.CurrentCell.ErrorText = "Personnummer och beslutsdatum måste vara ifyllda";
                //MessageBox.Show(ex.Message); //show message to the user

            }

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.ReadOnly = true;
            refreshdata();
            dataGridView1.Update(); //Redraws the data grid view so the new record is visible on the bottom

        }

        private void show_Success(object sender, DataGridViewCellEventArgs e)
        {
           if(dataGridView1.ReadOnly == false && String.IsNullOrWhiteSpace(dataGridView1.CurrentCell.ErrorText))
            {
               MessageBox.Show("Update Successfull");
            }
        }     
    }

    /* private void label1_Click(object sender, EventArgs e)
    {

    }*/

}
