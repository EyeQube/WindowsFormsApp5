using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace WindowsFormsApp5
{
    public partial class Main : Form
    {
        string connString = @"Data Source=DESKTOP-V4R7G9G\SQLEXPRESS;Initial Catalog=AdressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlDataAdapter dataAdapter; //this object here allows us to build the connection between the program and the database
        System.Data.DataTable table;//table to hold the information so we can fill the datagrid view
        //SqlCommandBuilder commandBuilder; //declare a new sql command builder object
        SqlConnection conn;//declares a variable to hold the sql connection
        string selectionStatement = "Select * from BizContacts";
        //string selectionOrg = "select * from BizContacts where lower(organisation)";

       

        public Main()
        {
            InitializeComponent();


            PopulateTreeView();
            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);

            refreshdata();
            refresh();

           // dataGridView1.Columns[0].Visible = false;
        }



        public void refreshdata()
        {

            DataRow dr;
            DataRow dInsatsK;
            DataRow Beslut;
            DataRow BeslutsFA;
            DataRow Orsak;


            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V4R7G9G\SQLEXPRESS;Initial Catalog=AdressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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


            // con.Close();
        }


        private void TabPage11(object sender, EventArgs e)
        {
            refreshdata();

            dataGridView1.DataSource = bindingSource1; //sets the source of the data to be displayed in the grid view

          //  dataGridView1.Columns[0].Visible = false;

            // cboOrganisation.SelectedIndex = 0; //first item in combobox is selected when the form loads

            //cboOrganisation.DisplayMember = "Organisation";
            //cboOrganisation.ValueMember = "Organisation";

            //Line below calls a method called GetData
            //The argument is a string that represents an sql query
            //select * from BizContacts means select all the data from the biz contacts table
            GetData(selectionStatement);

        }




        public void refresh()
        {
            dataGridView1.DataSource = bindingSource1; //sets the source of the data to be displayed in the grid view

           // dataGridView1.Columns[0].Visible = false;

            // cboOrganisation.SelectedIndex = 0; //first item in combobox is selected when the form loads

            //cboOrganisation.DisplayMember = "Organisation";
            //cboOrganisation.ValueMember = "Organisation";

            //Line below calls a method called GetData
            //The argument is a string that represents an sql query
            //select * from BizContacts means select all the data from the biz contacts table
            GetData(selectionStatement);
        }


        /*  private void Main_Load(object sender, EventArgs e)
          {
              refreshdata();
              dataGridView1.DataSource = bindingSource1; //sets the source of the data to be displayed in the grid view
              // cboOrganisation.SelectedIndex = 0; //first item in combobox is selected when the form loads
              //cboOrganisation.DisplayMember = "Organisation";
              //cboOrganisation.ValueMember = "Organisation";
              //Line below calls a method called GetData
              //The argument is a string that represents an sql query
              //select * from BizContacts means select all the data from the biz contacts table
              GetData(selectionStatement);
          }*/


        /*    private void tabPage11_Click(object sender, EventArgs e)
            {    
                refreshdata();
                dataGridView1.DataSource = bindingSource1; //sets the source of the data to be displayed in the grid view
                // cboOrganisation.SelectedIndex = 0; //first item in combobox is selected when the form loads
                //cboOrganisation.DisplayMember = "Organisation";
                //cboOrganisation.ValueMember = "Organisation";
                //Line below calls a method called GetData
                //The argument is a string that represents an sql query
                //select * from BizContacts means select all the data from the biz contacts table
                GetData(selectionStatement);
                //tabBeslut3.Update();
            } */

        private void GetData(string selectCommand)
        {
            try
            {
                dataAdapter = new SqlDataAdapter(selectCommand, connString);//pass in the select command and the connection string
                table = new System.Data.DataTable(); //make a new data table object
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table); //fill the data table
                bindingSource1.DataSource = table; //set the data source on the binding source to the table
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

            dataGridView1.Columns[0].Visible = false;
        }


        private void PopulateTreeView()
        {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(@"C:\Users\bitoreq_sattar\source\repos\WindowsFormsApp5\WindowsFormsApp5\Mina Brukare"); //../..");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }



        private void businessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BizContacts frm = new BizContacts(); //make a new business contacts form
                                                 //frm.MdiParent = this; //set the main form as the parent of each business form
            frm.Show(); //show the new form

            //frm.BringToFront();


            /*BizContacts frm = new BizContacts();
             frm.MdiParent = this;
            //frm.TopMost = true;
            //frm.BringToFront();
            SendToBack();
            //frm.Show(); 
            /* BizContacts frm = new BizContacts(); //make a new business contacts form
             
             Main p = new Main(); // Run time a panel is created
             p.Controls.Add(frm); // add child form in panel
             this.Controls.Add(p); // 'this' means MDI so, add panel inside MDI
             p.BringToFront(); // get panel in front or you can focus a control of child form
             p.Show(); // finally show form in MDI  */

        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);//cascade the child form inside the main form
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);//apply vertical layout to child forms inside parent form
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);//apply horizontal layout to child forms inside parent form
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //{

        //}

        //private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        // {
        /*    private void PopulateTreeView(object sender, TreeViewEventArgs e) //PopulateTreeView()
        {
                TreeNode rootNode;
                DirectoryInfo info = new DirectoryInfo(@"C:\Users\bitoreq_sattar\source\repos\WindowsFormsApp5\Mina Brukare"); //../..");
                if (info.Exists)
                {
                    rootNode = new TreeNode(info.Name);
                    rootNode.Tag = info;
                    GetDirectories(info.GetDirectories(), rootNode);
                    treeView1.Nodes.Add(rootNode);
                }
            } */




        /*  private void Form1_MdiChildActivate(object sender, EventArgs e)
          {
          }
          private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
          {
              ((sender as Form).Tag as TabPage).Dispose();
          }
          private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
          {
              if ((tabControl1.SelectedTab != null) &&
                  (tabControl1.SelectedTab.Tag != null))
                  (tabControl1.SelectedTab.Tag as Form).Select();
          } */



        /* private void tabBeslut_Click(object sender, EventArgs e)
         {
             BizContacts frm = new BizContacts();
             frm.TopLevel = false;
             tabBeslut.Controls.Add(frm);
             frm.Dock = DockStyle.Fill;
             frm.Show();
           //  BizContacts frmChild = new BizContacts();
             //AddNewTab(frmChild);
            //BizContacts frm = new BizContacts(); //make a new business contacts form
            // frmChild.MdiParent = this; //set the main form as the parent of each business form //
             //frmChild.ShowDialog(this); //show the new form
            // tabControl1.SelectedTab = BizContacts.ActiveForm.
         }
         private void AddNewTab(BizContacts frm)
         {
             BizContacts myTabPage = new BizContacts();
             tabBeslut = new TabPage();
             tabBeslut.Dock = DockStyle.Fill;
             tabBeslut.Controls.Add(tabBeslut);
            // tabControl1.TabPages.Add(myTabPage);
             /*TabPage tab = new TabPage(frm.Text);
             frm.TopLevel = false;
             frm.Parent = tab;
             frm.Visible = true;
             tabControl1.TabPages.Add(tab);
             frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);
             tabControl1.SelectedTab = tab;
    } */


        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }


        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "Directory"), new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString()) };
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "File"), new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString()) };
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }




        /* public BizContacts()
         {
             InitializeComponent();
             refreshdata();
         }*/






        /* private void btnAdd_Click(object sender, EventArgs e)
         {
             SqlCommand command;//declares a new sql command object
             //field names in the table
             string insert = @"insert into BizContacts(Beslut, Beslutsdatum, Insatskategori, Beslutsfattare, Organisation, Orsak, Anteckningar)

                               values(@Beslut, @Beslutsdatum, @Insatskategori, @Beslutsfattare, @Organisation, @Orsak, @Notes)"; //parameter names
             using (conn = new SqlConnection(connString)) //using allows disposing of low level resources
             {
                 try
                 {
                     conn.Open(); //open the connection
                     command = new SqlCommand(insert, conn);//create the new sql command object
                     command.Parameters.AddWithValue(@"Beslut", cboBeslut.Text);
                     command.Parameters.AddWithValue(@"Beslutsdatum", dateTimePicker2.Value.Date); //read value from form and save to table
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
             command.Parameters.Add("@Image", SqlDbType.VarBinary).Value = DBNull.Value;//Save null to database
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
} */


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



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            filtering(txtSearch.Text);

        }



        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
                GetData("select * from BizContacts");
            else
            {
                //GetData("select * from BizContacts where lower(organisation) like '%" + cboOrganisation.Text.ToString().ToLower() + "%'");
                GetData("select * from BizContacts where lower(organisation) like '%" + cboOrganisation.Text.ToString().ToLower() +
                        "%'and lower(efternamn) like '%" + txtSearch.Text.ToString().ToLower() + "%'"
                    );
            }
        }

       
        private void btnDelete_Click(object sender, MouseEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow; //grab a reference to the current row


            //DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            List<DataGridViewRow> lst = dataGridView1.SelectedRows.Cast<DataGridViewRow>().ToList();




            //rows.Clear();
            //rows[0].Cells


            /*   foreach(DataGridViewRow ro in lst)
               {
                   //DataRow myRow = (row.DataBoundItem as DataRowView).Row;
                   string values = ro.Cells["ID"].Value.ToString();  //Cells["ID"].Value.ToString();//grab the value from the id field of the selected record
                   string deleteStates = @"Delete from BizContacts where id = '" + values + "'";//this is the sql to delete the records from the sql table
               } */


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



        private void btnAdd_Click(object sender, MouseEventArgs e)
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
                    command.Parameters.AddWithValue(@"Beslutsdatum", dateTimePicker2.Value.Date); //read value from form and save to table
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
            //dataGridView1.ReadOnly = false;

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


         //   DataGridViewCellEventArgs r = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

         //     show_Success(this, e);

            // dataGridView1.Columns[0].ReadOnly = true;
            // dataGridView1.ReadOnly = true;
            // dataGridView1.RowTemplate.ReadOnly = true;
            // refreshdata();
            // dataGridView1.Update(); //Redraws the data grid view so the new record is visible on the bottom

        } 

        private void show_Success(object sender, DataGridViewCellEventArgs e)
        {
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


            if (dataGridView1.ReadOnly == false && String.IsNullOrWhiteSpace(dataGridView1.CurrentCell.ErrorText))
            {

                MessageBox.Show("Update Successfull");
            }
          

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.ReadOnly = true;
        }


        private void tabPage11_MouseHover(object sender, EventArgs e)
        {
            filtering(txtSearch.Text);

           // DataGridViewCellEventArgs r = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

           // show_Success(this, r);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            //dataGridView1.Update();

            string s = textBox2.Text;
            string a = textBox3.Text;

            if(a.Length >= 6 && a.Length <= 11)
            {
                txtSearch.Text = s + a;

                ////////////////////////////////////////////////////////////////////////



                DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;

                //string value = row.Cells["ID"].Value.ToString();//grab the value from the id field of the selected record
                string fname = row.Cells["Förnamn"].Value.ToString();//grab the value from the name field of the selected record

                txtPersonnummer.Text = row.Cells["Personnummer"].Value.ToString();
                txtFörnamn.Text = row.Cells["Förnamn"].Value.ToString();
                txtEfternamn.Text = row.Cells["Efternamn"].Value.ToString();
                txtOrganisation.Text = row.Cells["Organisation"].Value.ToString();
                cboBeslut.Text = row.Cells["Beslut"].Value.ToString();
                cboBeslutsfattare.Text = row.Cells["Beslutsfattare"].Value.ToString();
                cboInsatsK.Text = row.Cells["Insatskategori"].Value.ToString();
                cboOrsak.Text = row.Cells["Orsak"].Value.ToString();
                dateTimePicker2.Text = row.Cells["Beslutsdatum"].Value.ToString();

                // cboBeslut.ValueMember = row.Cells["Personnummer"].Value.ToString();
                // string lname = row.Cells["Efternamn"].Value.ToString();//grab the value from the last name field of the selected record

                // string org = row.Cells["Organisation"].Value.ToString();



                /////////////////////////////////////////////////////////////////////////

                tabControl1.SelectTab(1);
                tabBeslut.SelectTab(6);
                tabBeslut3.SelectTab(0);
            }
            else
            {
                txtSearch.Text = "";

                tabControl1.SelectTab(1);
                tabBeslut.SelectTab(6);
                tabBeslut3.SelectTab(0);
            }         
        }


        private void filtering(string textSearch)
        {
           // txtSearch.Text = "193901257246";

            string txtt = txtSearch.Text;
            string brex1 = "";
           // string re = "";
            string er = "";

          /*  if (txtSearch.Text.Length >= 7)
            {
                re = txtt.Substring(6, 1);

            }
            if (txtSearch.Text.Length >= 9)
            {
                er = txtt.Substring(8, 1);
            }*/


            /* int h;
             bool isNum = int.TryParse(re, out h);

             int year = 0;
             if(isNum == true)
             {
                 year = Convert.ToInt32(re);
             } */


            /////////////////////////////////////////////////////////
            int i = 0;
            int s = 0;
            foreach(var m in txtt)
            {
                if(m == '-' || m ==' ')
                {
                  if(m == '-' && ((txtSearch.Text.Length >= 8 && i==8) || (txtSearch.Text.Length >= 6 && i == 6)))
                    {
                        er = txtt.Substring(i, 1);                       
                    }

                    s = i;

                    txtt = txtt.Remove(i, 1);
                   
                   i--;
                }

                i++;
            }

            //s = txtSearch.Text.Length - (s + 1);

            brex1 = txtt;

            //////////////////////////////////////////////////////////

          /*  if (txtt.Length >= 9 && txtt.Length <= 13 && er == "-" && re != "-")
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
            } */

            long n;
            bool isNumeric = long.TryParse(brex1, out n);

            // string org = cboOrganisation.Text.ToString().ToLower().Trim();



            if (isNumeric == true && String.IsNullOrWhiteSpace(cboOrganisation.Text.ToString().ToLower()))
            {

                GetData("select * from BizContacts where replace(personnummer,'-','') like '%" + brex1 + "%'");


               /* if (String.IsNullOrWhiteSpace(ter) && ter.Length != 10 && ter.Length != 12)
                {
                    label9.ForeColor = Color.Red;
                    label9.Text = "OBS! Ofullständig personnummer i sökrutan";
                }
                else
                {
                    label9.ForeColor = Color.DarkBlue;
                    label9.Text = "Ex: Personnummer/namn";
                } */

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
            {
                GetData("select * from BizContacts where lower(organisation) like '%" + cboOrganisation.Text.ToString().ToLower() +
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


            if(txtSearch.Text.Length >= 10 && txtSearch.Text.Length <= 13 && isNumeric == true) //|| (er != "-" && (txtSearch.Text.Length == 10 || txtSearch.Text.Length == 12)))
            {
                if(er == "" && ((brex1.Length == 12) || (brex1.Length == 10)))
                {
                    label9.ForeColor = Color.Red;
                    label9.Text = "OBS! Bindestreck saknas.";
                }
                else if(er == "-" && ((s == 8 && txtSearch.Text.Length == 13) || (s == 6 && textSearch.Length == 11)))
                {
                    label9.ForeColor = Color.DarkBlue;
                    label9.Text = "Ex: Personnummer/namn";
                }
                else
                {
                    label9.ForeColor = Color.Red;
                    label9.Text = "OBS! Ofullständig personnummer i sökrutan";
                }

            }
           /* else if(((txtSearch.Text.Length >= 7 && s != 6 && s != 0) || (txtSearch.Text.Length >= 9 && s != 8)) && isNumeric == true)
            {
                label9.ForeColor = Color.Red;
                label9.Text = "OBS! Bindestreck saknas.";
            } */
             else if(!String.IsNullOrWhiteSpace(brex1) && isNumeric == true)
            {
                label9.ForeColor = Color.Red;
                label9.Text = "OBS! Ofullständig personnummer i sökrutan";
            }
            else
            {
                label9.ForeColor = Color.DarkBlue;
                label9.Text = "Ex: Personnummer/namn";
            } 

        }

         private void dataGridView1_CellEndEdit(object sender, EventArgs e)
        {
          /*  SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
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

            } */
        }

        private void btnDataGridView1_CellEndEdit(object sender, EventArgs e)
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridView1.ReadOnly = false;

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
        }

         private void dataGridView1_CellEndEdit(object sender, KeyPressEventArgs e)
        {
           // dataGridView1.ReadOnly = false;

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
        }

        private void dataGridView1_CellEndEdit(object sender, KeyEventArgs e)
        {
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
        }



        /* private void Main_Load(object sender, EventArgs e)
         {

         }*/




        /* private void showSuccess(object sender, DataGridViewCellEventArgs e)
         {
             if (dataGridView1.ReadOnly == false && String.IsNullOrWhiteSpace(dataGridView1.CurrentCell.ErrorText))
             {
                 MessageBox.Show("Update Successfull");
             }
         }*/



        /* private void label1_Click(object sender, EventArgs e)
        {
        }*/
    }



}
