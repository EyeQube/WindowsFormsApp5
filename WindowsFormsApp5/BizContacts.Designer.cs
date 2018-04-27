namespace WindowsFormsApp5
{
    partial class BizContacts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BizContacts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cboOrganisation = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgOpenImage = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExportOpen = new System.Windows.Forms.Button();
            this.btnSaveToText = new System.Windows.Forms.Button();
            this.btnOpenWord = new System.Windows.Forms.Button();
            this.cboInsatsK = new System.Windows.Forms.ComboBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.cboBeslutsfattare = new System.Windows.Forms.ComboBox();
            this.cboOrsak = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboBeslut = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtOrganisation = new System.Windows.Forms.TextBox();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtFörnamn = new System.Windows.Forms.TextBox();
            this.txtEfternamn = new System.Windows.Forms.TextBox();
            this.txtPersonnummer = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cboBeslutsdatum = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.show_Success);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDataGridView1_CellEndEdit);
            // 
            // cboOrganisation
            // 
            resources.ApplyResources(this.cboOrganisation, "cboOrganisation");
            this.cboOrganisation.FormattingEnabled = true;
            this.cboOrganisation.Name = "cboOrganisation";
            this.cboOrganisation.SelectedIndexChanged += new System.EventHandler(this.cboSearch_SelectedIndexChanged);
            this.cboOrganisation.MouseEnter += new System.EventHandler(this.txtSearch_TextChanged);
            this.cboOrganisation.MouseLeave += new System.EventHandler(this.txtSearch_TextChanged);
            this.cboOrganisation.MouseHover += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtNotes
            // 
            resources.ApplyResources(this.txtNotes, "txtNotes");
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Name = "label13";
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.MouseEnter += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.MouseLeave += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.MouseHover += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Name = "label10";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Name = "label5";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Name = "label7";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Name = "label1";
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // btnExportOpen
            // 
            resources.ApplyResources(this.btnExportOpen, "btnExportOpen");
            this.btnExportOpen.Name = "btnExportOpen";
            this.btnExportOpen.UseVisualStyleBackColor = true;
            // 
            // btnSaveToText
            // 
            resources.ApplyResources(this.btnSaveToText, "btnSaveToText");
            this.btnSaveToText.Name = "btnSaveToText";
            this.btnSaveToText.UseVisualStyleBackColor = true;
            this.btnSaveToText.Click += new System.EventHandler(this.btnSaveToText_Click);
            // 
            // btnOpenWord
            // 
            resources.ApplyResources(this.btnOpenWord, "btnOpenWord");
            this.btnOpenWord.Name = "btnOpenWord";
            this.btnOpenWord.UseVisualStyleBackColor = true;
            // 
            // cboInsatsK
            // 
            this.cboInsatsK.FormattingEnabled = true;
            resources.ApplyResources(this.cboInsatsK, "cboInsatsK");
            this.cboInsatsK.Name = "cboInsatsK";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dateTimePicker3, "dateTimePicker3");
            this.dateTimePicker3.Name = "dateTimePicker3";
            // 
            // cboBeslutsfattare
            // 
            this.cboBeslutsfattare.FormattingEnabled = true;
            this.cboBeslutsfattare.Items.AddRange(new object[] {
            resources.GetString("cboBeslutsfattare.Items")});
            resources.ApplyResources(this.cboBeslutsfattare, "cboBeslutsfattare");
            this.cboBeslutsfattare.Name = "cboBeslutsfattare";
            // 
            // cboOrsak
            // 
            this.cboOrsak.FormattingEnabled = true;
            resources.ApplyResources(this.cboOrsak, "cboOrsak");
            this.cboOrsak.Name = "cboOrsak";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Name = "label3";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // cboBeslut
            // 
            this.cboBeslut.FormattingEnabled = true;
            resources.ApplyResources(this.cboBeslut, "cboBeslut");
            this.cboBeslut.Name = "cboBeslut";
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox2.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox3.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox3, "comboBox3");
            this.comboBox3.Name = "comboBox3";
            // 
            // comboBox4
            // 
            this.comboBox4.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox4.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox4, "comboBox4");
            this.comboBox4.Name = "comboBox4";
            // 
            // comboBox5
            // 
            this.comboBox5.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox5.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox5, "comboBox5");
            this.comboBox5.Name = "comboBox5";
            // 
            // comboBox6
            // 
            this.comboBox6.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox6.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox6, "comboBox6");
            this.comboBox6.Name = "comboBox6";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label18.Name = "label18";
            // 
            // txtOrganisation
            // 
            resources.ApplyResources(this.txtOrganisation, "txtOrganisation");
            this.txtOrganisation.Name = "txtOrganisation";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label19.Name = "label19";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label20.Name = "label20";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label21.Name = "label21";
            // 
            // txtFörnamn
            // 
            resources.ApplyResources(this.txtFörnamn, "txtFörnamn");
            this.txtFörnamn.Name = "txtFörnamn";
            // 
            // txtEfternamn
            // 
            resources.ApplyResources(this.txtEfternamn, "txtEfternamn");
            this.txtEfternamn.Name = "txtEfternamn";
            // 
            // txtPersonnummer
            // 
            resources.ApplyResources(this.txtPersonnummer, "txtPersonnummer");
            this.txtPersonnummer.Name = "txtPersonnummer";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label22.Name = "label22";
            // 
            // cboBeslutsdatum
            // 
            this.cboBeslutsdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.cboBeslutsdatum, "cboBeslutsdatum");
            this.cboBeslutsdatum.Name = "cboBeslutsdatum";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label23.Name = "label23";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(WindowsFormsApp5.BizContacts);
            // 
            // BizContacts
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cboBeslutsdatum);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtPersonnummer);
            this.Controls.Add(this.txtEfternamn);
            this.Controls.Add(this.txtFörnamn);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtOrganisation);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cboBeslut);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboOrsak);
            this.Controls.Add(this.cboBeslutsfattare);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.cboInsatsK);
            this.Controls.Add(this.btnOpenWord);
            this.Controls.Add(this.btnSaveToText);
            this.Controls.Add(this.btnExportOpen);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cboOrganisation);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BizContacts";
            this.Load += new System.EventHandler(this.BizContacts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cboOrganisation;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.OpenFileDialog dlgOpenImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnExportOpen;
        private System.Windows.Forms.Button btnSaveToText;
        private System.Windows.Forms.Button btnOpenWord;
        private System.Windows.Forms.ComboBox cboInsatsK;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.ComboBox cboBeslutsfattare;
        private System.Windows.Forms.ComboBox cboOrsak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboBeslut;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtOrganisation;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtFörnamn;
        private System.Windows.Forms.TextBox txtEfternamn;
        private System.Windows.Forms.TextBox txtPersonnummer;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker cboBeslutsdatum;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}