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

namespace WindowsFormsApp5
{
    public partial class Main : Form
    {
        private object tabControl;

        public Main()
        {
            InitializeComponent();
            PopulateTreeView();
            //this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
        }

        private void PopulateTreeView()
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



        private void tabBeslut_Click(object sender, EventArgs e)
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

            tabControl1.SelectedTab = tab;*/

        }



        /*   void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
           {
               TreeNode newSelected = e.Node;
               listView1.Items.Clear();
               DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
               ListViewItem.ListViewSubItem[] subItems;
               ListViewItem item = null;

               foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
               {
                   item = new ListViewItem(dir.Name, 0);
                   subItems = new ListViewItem.ListViewSubItem[] {new ListViewItem.ListViewSubItem(item, "Directory"), new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString())};
                   item.SubItems.AddRange(subItems);
                   listView1.Items.Add(item);
               }
               foreach (FileInfo file in nodeDirInfo.GetFiles())
               {
                   item = new ListViewItem(file.Name, 1);
                   subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "File"), new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString())};
                   item.SubItems.AddRange(subItems);
                   listView1.Items.Add(item);
               }

               listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
           }*/



    }
}
