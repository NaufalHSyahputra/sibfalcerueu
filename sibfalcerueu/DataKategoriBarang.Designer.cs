namespace sibfalcerueu
{
    partial class DataKategoriBarang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnexit = new MetroFramework.Controls.MetroTile();
            this.btnsdelete = new MetroFramework.Controls.MetroTile();
            this.btnupdate = new MetroFramework.Controls.MetroTile();
            this.btnsimpan = new MetroFramework.Controls.MetroTile();
            this.btninput = new MetroFramework.Controls.MetroTile();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.txtnama = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtkode = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtsearch = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnbatal = new MetroFramework.Controls.MetroTile();
            this.btnsupdate = new MetroFramework.Controls.MetroTile();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnexit);
            this.groupBox3.Controls.Add(this.btnsdelete);
            this.groupBox3.Controls.Add(this.btnupdate);
            this.groupBox3.Controls.Add(this.btnsimpan);
            this.groupBox3.Controls.Add(this.btninput);
            this.groupBox3.Location = new System.Drawing.Point(390, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 200);
            this.groupBox3.TabIndex = 78;
            this.groupBox3.TabStop = false;
            // 
            // btnexit
            // 
            this.btnexit.ActiveControl = null;
            this.btnexit.Location = new System.Drawing.Point(15, 146);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(403, 42);
            this.btnexit.TabIndex = 9;
            this.btnexit.Text = "Keluar";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnexit.UseSelectable = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnsdelete
            // 
            this.btnsdelete.ActiveControl = null;
            this.btnsdelete.Location = new System.Drawing.Point(253, 81);
            this.btnsdelete.Name = "btnsdelete";
            this.btnsdelete.Size = new System.Drawing.Size(163, 51);
            this.btnsdelete.TabIndex = 8;
            this.btnsdelete.Text = "Delete Data";
            this.btnsdelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnsdelete.TileImage = global::sibfalcerueu.Properties.Resources.images;
            this.btnsdelete.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsdelete.UseSelectable = true;
            this.btnsdelete.Click += new System.EventHandler(this.btnsdelete_Click_1);
            // 
            // btnupdate
            // 
            this.btnupdate.ActiveControl = null;
            this.btnupdate.Location = new System.Drawing.Point(253, 12);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(163, 51);
            this.btnupdate.TabIndex = 7;
            this.btnupdate.Text = "Edit Data";
            this.btnupdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnupdate.TileImage = global::sibfalcerueu.Properties.Resources.images;
            this.btnupdate.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdate.UseSelectable = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnsimpan
            // 
            this.btnsimpan.ActiveControl = null;
            this.btnsimpan.Enabled = false;
            this.btnsimpan.Location = new System.Drawing.Point(15, 81);
            this.btnsimpan.Name = "btnsimpan";
            this.btnsimpan.Size = new System.Drawing.Size(163, 51);
            this.btnsimpan.TabIndex = 6;
            this.btnsimpan.Text = "Simpan Data";
            this.btnsimpan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnsimpan.TileImage = global::sibfalcerueu.Properties.Resources.images;
            this.btnsimpan.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsimpan.UseSelectable = true;
            this.btnsimpan.Click += new System.EventHandler(this.btnsimpan_Click);
            // 
            // btninput
            // 
            this.btninput.ActiveControl = null;
            this.btninput.Location = new System.Drawing.Point(15, 12);
            this.btninput.Name = "btninput";
            this.btninput.Size = new System.Drawing.Size(163, 51);
            this.btninput.TabIndex = 5;
            this.btninput.Text = "Input Data Baru";
            this.btninput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btninput.TileImage = global::sibfalcerueu.Properties.Resources.images;
            this.btninput.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btninput.UseSelectable = true;
            this.btninput.Click += new System.EventHandler(this.btninput_Click);
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Items.AddRange(new object[] {
            "Kode",
            "Nama"});
            this.metroComboBox1.Location = new System.Drawing.Point(253, 15);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(148, 29);
            this.metroComboBox1.TabIndex = 1;
            this.metroComboBox1.UseSelectable = true;
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(166, 21);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(81, 19);
            this.metroLabel7.TabIndex = 0;
            this.metroLabel7.Text = "Berdasarkan";
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToDeleteRows = false;
            this.metroGrid1.AllowUserToOrderColumns = true;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(16, 371);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(806, 173);
            this.metroGrid1.TabIndex = 74;
            this.metroGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellClick_1);
            // 
            // txtnama
            // 
            this.txtnama.Enabled = false;
            this.txtnama.Lines = new string[0];
            this.txtnama.Location = new System.Drawing.Point(114, 135);
            this.txtnama.MaxLength = 32767;
            this.txtnama.Name = "txtnama";
            this.txtnama.PasswordChar = '\0';
            this.txtnama.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtnama.SelectedText = "";
            this.txtnama.Size = new System.Drawing.Size(207, 23);
            this.txtnama.TabIndex = 73;
            this.txtnama.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(16, 135);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(45, 19);
            this.metroLabel2.TabIndex = 72;
            this.metroLabel2.Text = "Nama";
            // 
            // txtkode
            // 
            this.txtkode.Enabled = false;
            this.txtkode.Lines = new string[0];
            this.txtkode.Location = new System.Drawing.Point(114, 89);
            this.txtkode.MaxLength = 32767;
            this.txtkode.Name = "txtkode";
            this.txtkode.PasswordChar = '\0';
            this.txtkode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtkode.SelectedText = "";
            this.txtkode.Size = new System.Drawing.Size(207, 23);
            this.txtkode.TabIndex = 70;
            this.txtkode.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(16, 89);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(72, 19);
            this.metroLabel1.TabIndex = 69;
            this.metroLabel1.Text = "Kode Level";
            // 
            // txtsearch
            // 
            this.txtsearch.Lines = new string[0];
            this.txtsearch.Location = new System.Drawing.Point(407, 15);
            this.txtsearch.MaxLength = 32767;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtsearch.SelectedText = "";
            this.txtsearch.Size = new System.Drawing.Size(199, 27);
            this.txtsearch.TabIndex = 2;
            this.txtsearch.UseSelectable = true;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtsearch);
            this.groupBox1.Controls.Add(this.metroComboBox1);
            this.groupBox1.Controls.Add(this.metroLabel7);
            this.groupBox1.Location = new System.Drawing.Point(16, 311);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 53);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pencarian";
            // 
            // btnbatal
            // 
            this.btnbatal.ActiveControl = null;
            this.btnbatal.Location = new System.Drawing.Point(405, 100);
            this.btnbatal.Name = "btnbatal";
            this.btnbatal.Size = new System.Drawing.Size(163, 51);
            this.btnbatal.TabIndex = 79;
            this.btnbatal.Text = "Batal";
            this.btnbatal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnbatal.TileImage = global::sibfalcerueu.Properties.Resources.images;
            this.btnbatal.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbatal.UseSelectable = true;
            this.btnbatal.Click += new System.EventHandler(this.btnbatal_Click);
            // 
            // btnsupdate
            // 
            this.btnsupdate.ActiveControl = null;
            this.btnsupdate.Location = new System.Drawing.Point(643, 100);
            this.btnsupdate.Name = "btnsupdate";
            this.btnsupdate.Size = new System.Drawing.Size(163, 51);
            this.btnsupdate.TabIndex = 80;
            this.btnsupdate.Text = "Update";
            this.btnsupdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnsupdate.TileImage = global::sibfalcerueu.Properties.Resources.images;
            this.btnsupdate.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsupdate.UseSelectable = true;
            this.btnsupdate.Click += new System.EventHandler(this.btnsupdate_Click_1);
            // 
            // DataKategoriBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 575);
            this.Controls.Add(this.btnsupdate);
            this.Controls.Add(this.btnbatal);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.txtnama);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtkode);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "DataKategoriBarang";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Data Kategori Barang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataKategoriBarang_FormClosing);
            this.Load += new System.EventHandler(this.DataKategoriBarang_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroTextBox txtnama;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtkode;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtsearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTile btnexit;
        private MetroFramework.Controls.MetroTile btnsdelete;
        private MetroFramework.Controls.MetroTile btnupdate;
        private MetroFramework.Controls.MetroTile btnsimpan;
        private MetroFramework.Controls.MetroTile btninput;
        private MetroFramework.Controls.MetroTile btnbatal;
        private MetroFramework.Controls.MetroTile btnsupdate;
    }
}