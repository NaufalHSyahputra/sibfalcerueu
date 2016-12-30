using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace sibfalcerueu
{
    public partial class DataBarang : MetroForm
    {
        public MySqlConnection conn;
        public MySqlCommand cmd;
        private MySqlDataReader rd;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        Timer t1 = new Timer();

        public DataBarang()
        {
            InitializeComponent();
        }
        //open connection to database
        private bool OpenConnection()
        {
            string connstring = "server=localhost;database=sbduas3;uid=root;pwd=;";
            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MetroMessageBox.Show(this, "Database Gagal Connect ! ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;

                    case 1045:
                        MetroMessageBox.Show(this, "Username / Password Salah", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    case 1042:
                        MetroMessageBox.Show(this, "Mysql Belum Nyala", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }
        private void kode()
        {
            long hitung;
            string urut;
            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand("select kode from barang where kode in(select max(kode) from barang) order by kode desc", conn);
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["kode"].ToString().Length - 3, 3)) + 1;
                    string joinstr = "000" + hitung;
                    urut = "BRG" + joinstr.Substring(joinstr.Length - 3, 3);
                }
                else
                {
                    urut = "BRG001";
                }
                rd.Close();
                txtkode.Text = urut;
            }
            this.CloseConnection();
        }
        private new void Select()
        {
            while (metroGrid1.Rows.Count > 0)
            {
                metroGrid1.Rows.RemoveAt(0);
            }
            string query = "SELECT * FROM barang";
            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            this.CloseConnection();
        }
        private void Select2()
        {
            string query = "SELECT * FROM supplier";

            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt1);
                metroGrid2.DataSource = dt1;
            }
            this.CloseConnection();
        }
        private void Select3()
        {
            string query = "SELECT * FROM kategori";

            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt2);
                metroGrid3.DataSource = dt2;
            }
            this.CloseConnection();
        }

        public void Insert()
        {
            string query = "INSERT INTO barang VALUES(@kode, @nama, @kategori, @stok, @supplier, @stokmin)";

            //open connection
            if (this.OpenConnection() == true)
            {
                //Start MysqlCommand
                cmd = new MySqlCommand(query, conn);

                //Binding Value
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                cmd.Parameters.AddWithValue("@nama", txtnama.Text);
                cmd.Parameters.AddWithValue("@kategori", txtkategori.Text);
                cmd.Parameters.AddWithValue("@stok", txtstok.Text);
                cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                cmd.Parameters.AddWithValue("@stokmin", txtstokmin.Text);

                //Execute command
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Input Data Barang Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Input Data Barang Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }
            //close connection
            this.CloseConnection();
            Select();
            btnbatal.PerformClick();
        }

        //Update statement
        public new void Update()
        {
            string query = "UPDATE barang SET nama = @nama, kategori = @kategori, stok = @stok, id_supplier = @supplier, stok_min = @stokmin WHERE kode = @kode";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                cmd = new MySqlCommand(query, conn);

                //Binding Value
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                cmd.Parameters.AddWithValue("@nama", txtnama.Text);
                cmd.Parameters.AddWithValue("@kategori", txtkategori.Text);
                cmd.Parameters.AddWithValue("@stok", txtstok.Text);
                cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                cmd.Parameters.AddWithValue("@stokmin", txtstokmin.Text);
                //Execute query
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Update Data Barang Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Update Data Barang Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            //close connection
            this.CloseConnection();
            Select();
            btnbatal.PerformClick();
        }

        public void Delete()
        {
            string query = "DELETE FROM barang WHERE kode = @kode";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Delete Data Barang Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Delete Data Barang Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            //close connection
            this.CloseConnection();
            Select();
            txtkode.Text = "";
            txtnama.Text = "";
            txtkategori.Text = "";
            txtstok.Text = "1";
            txtstokmin.Text = "1";
            txtsupplier.Text = "";
        }
        private void IsiCombobox()
        {
            // Bind combobox to dictionary
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("kode", "Kode Barang");
            test.Add("nama", "Nama Barang");
            test.Add("id_kategori", "Kode Kategori");
            test.Add("id_supplier", "Kode Supplier");
            metroComboBox1.DataSource = new BindingSource(test, null);
            metroComboBox1.DisplayMember = "Value";
            metroComboBox1.ValueMember = "Key";
        }
        private void Search()
        {
            string searchvalue = txtsearch.Text;
            string pilihan = ((KeyValuePair<string, string>)metroComboBox1.SelectedItem).Key;

            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format(pilihan + " like '%{0}%'", txtsearch.Text);
            metroGrid2.DataSource = dv.ToTable();
        }
        private void visiblepanel(string pil)
        {
            metroPanel2.Location = new Point(121, 263);
            metroPanel1.Location = new Point(121, 310);
            if (pil == "panel1")
            {
                if (metroPanel1.Visible)
                {
                    metroPanel1.Visible = false;
                }
                else
                {
                    metroPanel1.Visible = true;
                }
            }
            else
            {
                if (metroPanel2.Visible)
                {
                    metroPanel2.Visible = false;
                }
                else
                {
                    metroPanel2.Visible = true;
                }
            }
        }

        private void metroTextBox5_Click(object sender, EventArgs e)
        {
            visiblepanel("panel1");
        }

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.metroGrid2.Rows[e.RowIndex];
            txtsupplier.Text = row.Cells[0].Value.ToString();
            metroPanel1.Visible = false;
        }

        private void metroTextBox8_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt1.DefaultView;
            dv.RowFilter = string.Format("nama like '%{0}%'", metroTextBox8.Text);
            metroGrid2.DataSource = dv.ToTable();
        }

        private void metroPanel1_MouseLeave(object sender, EventArgs e)
        {
            metroPanel1.Visible = false;
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            txtnama.Enabled = true;
            txtkategori.Enabled = true;
            txtstok.Enabled = true;
            txtstokmin.Enabled = true;
            txtsupplier.Enabled = true;
            btnupdate.Visible = false;
            btnsdelete.Enabled = false;
            btnexit.Enabled = false;
            btnbatal.Visible = true;
            btninput.Visible = false;
            btnsupdate.Visible = true;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            kode();
            txtnama.Enabled = true;
            txtkategori.Enabled = true;
            txtstok.Enabled = true;
            txtstokmin.Enabled = true;
            txtsupplier.Enabled = true;
            btnbatal.Visible = true;
            btnsimpan.Enabled = true;
            btnupdate.Enabled = false;
            btnsdelete.Enabled = false;
            btnexit.Enabled = false;
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            txtkode.Text = "";
            txtnama.Text = "";
            txtkategori.Text = "";
            txtstok.Text = "1";
            txtstokmin.Text = "1";
            txtsupplier.Text = "";
            txtkode.Enabled = false;
            txtnama.Enabled = false;
            txtkategori.Enabled = false;
            txtstok.Enabled = false;
            txtstokmin.Enabled = false;
            txtsupplier.Enabled = false;
            btnsimpan.Enabled = false;
            btnupdate.Enabled = true;
            btnsdelete.Enabled = true;
            btnexit.Enabled = true;
            btnbatal.Visible = false;
            btnupdate.Visible = true;
            btnsupdate.Visible = false;
            btninput.Visible = true;
            metroPanel1.Visible = false;
            metroPanel2.Visible = false;
        }

        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.metroGrid3.Rows[e.RowIndex];
            txtkategori.Text = row.Cells[0].Value.ToString();
            metroPanel2.Visible = false;
        }

        private void metroPanel2_MouseLeave(object sender, EventArgs e)
        {
            metroPanel2.Visible = false;
        }

        private void txtkategori_Click(object sender, EventArgs e)
        {
            visiblepanel("panel2");
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt2.DefaultView;
            dv.RowFilter = string.Format("nama like '%{0}%'", metroTextBox1.Text);
            metroGrid3.DataSource = dv.ToTable();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if (txtkategori.Text == "" || txtnama.Text == "" || txtstok.Text == "" || txtstokmin.Text == "" || txtsupplier.Text == "")
            {
                MetroMessageBox.Show(this, "Masih Ada Data Yang Kosong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Insert();
            }
        }

        private void btnsupdate_Click(object sender, EventArgs e)
        {
            if (txtkategori.Text == "" || txtnama.Text == "" || txtstok.Text == "" || txtstokmin.Text == "" || txtsupplier.Text == "")
            {
                MetroMessageBox.Show(this, "Masih Ada Data Yang Kosong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Update();
            }
        }

        private void txtstok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtstokmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //gets a collection that contains all the rows
            DataGridViewRow row = this.metroGrid1.Rows[e.RowIndex];
            //populate the textbox from specific value of the coordinates of column and row.
            txtkode.Text = row.Cells[0].Value.ToString();
            txtnama.Text = row.Cells[1].Value.ToString();
            txtkategori.Text = row.Cells[2].Value.ToString();
            txtstok.Text = row.Cells[3].Value.ToString();
            txtstokmin.Text = row.Cells[4].Value.ToString();
            txtsupplier.Text = row.Cells[5].Value.ToString();
        }

        private void btnsdelete_Click(object sender, EventArgs e)
        {
            if (txtkode.Text == "")
            {
                MetroMessageBox.Show(this, "Masih Ada Data Yang Kosong!", "ERRROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MetroMessageBox.Show(this, "Apakah Anda Yakin Ingin Menghapus Data Tersebut?", "Konfirmasi Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Delete();
                }
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void DataBarang_Load(object sender, EventArgs e)
        {
            Opacity = 0;      //first the opacity is 0

            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start();
            Select();
            Select2();
            Select3();
            IsiCombobox();
            metroPanel1.Visible = false;
            btnbatal.Visible = false;
            btnsupdate.Visible = false;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
                t1.Stop();   //this stops the timer if the form is completely displayed
            else
                Opacity += 0.05;
        }

        private void DataBarang_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;    //cancel the event so the form won't be closed
            t1.Tick += new EventHandler(fadeOut);  //this calls the fade out function
            t1.Start();

            if (Opacity == 0)  //if the form is completly transparent
                e.Cancel = false;   //resume the event - the program can be closed
        }
        void fadeOut(object sender, EventArgs e)
        {
            if (Opacity <= 0)     //check if opacity is 0
            {
                t1.Stop();    //if it is, we stop the timer
                Close();   //and we try to close the form
            }
            else
            {
                Opacity -= 0.05;
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                Search();
            }
        }

        private void txtkategori_Enter(object sender, EventArgs e)
        {
            visiblepanel("panel2");
        }

        private void txtsupplier_Enter(object sender, EventArgs e)
        {
            visiblepanel("panel1");
        }
    }
}
