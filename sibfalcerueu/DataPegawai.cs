﻿using System;
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
    public partial class DataPegawai : MetroForm
    {
        public DataPegawai()
        {
            InitializeComponent();
        }

        public MySqlConnection conn;
        public MySqlCommand cmd;
        private MySqlDataReader rd;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        //open connection to database
        private bool OpenConnection()
        {
                        string connstring = "server=" + SetDB.server + ";database=" + SetDB.nama + ";uid=" + SetDB.uid + ";pwd=" + SetDB.pass + ";";
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
                cmd = new MySqlCommand("select kode from pegawai where kode in(select max(kode) from pegawai) order by kode desc", conn);
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["kode"].ToString().Length - 3, 3)) + 1;
                    string joinstr = "000" + hitung;
                    urut = "PGW" + joinstr.Substring(joinstr.Length - 3, 3);
                }
                else
                {
                    urut = "PGW001";
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
            string query = "SELECT * FROM pegawai";
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
            string query = "SELECT * FROM bagian";

            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt1);
                metroGrid2.DataSource = dt1;
            }
            this.CloseConnection();
        }

        public void Insert()
        {
            string query = "INSERT INTO pegawai VALUES(@kode, @nama, @alamat, @nohp, @email, @bagian)";

            //open connection
            if (this.OpenConnection() == true)
            {
                //Start MysqlCommand
                cmd = new MySqlCommand(query, conn);

                //Binding Value
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                cmd.Parameters.AddWithValue("@nama", txtnama.Text);
                cmd.Parameters.AddWithValue("@alamat", txtalamat.Text);
                cmd.Parameters.AddWithValue("@nohp", txtnohp.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@bagian", txtbagian.Text);

                //Execute command
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Input Data Pegawai Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Input Data Pegawai Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
            string query = "UPDATE pegawai SET nama = @nama, alamat = @alamat, nohp = @nohp, email = @email, bagian = @bagian WHERE kode = @kode";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                cmd = new MySqlCommand(query, conn);

                //Binding Value
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                cmd.Parameters.AddWithValue("@nama", txtnama.Text);
                cmd.Parameters.AddWithValue("@alamat", txtalamat.Text);
                cmd.Parameters.AddWithValue("@nohp", txtnohp.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@bagian", txtbagian.Text);
                //Execute query
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Update Data Pegawai Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Update Data Pegawai Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            //close connection
            this.CloseConnection();
            Select();
            btnbatal.PerformClick();
        }

        public void Delete()
        {
            string query = "DELETE FROM pegawai WHERE kode = @kode";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Delete Data Pegawai Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Delete Data Pegawai Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            //close connection
            this.CloseConnection();
            Select();
            txtkode.Text = "";
            txtnama.Text = "";
            txtalamat.Text = "";
            txtemail.Text = "";
            txtnohp.Text = "";
            txtbagian.Text = "";
        }
        private void IsiCombobox()
        {
            // Bind combobox to dictionary
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("kode", "Kode");
            test.Add("nama", "Nama");
            test.Add("alamat", "Alamat");
            test.Add("email", "Email");
            test.Add("nohp", "Nomor HP");
            test.Add("bagian", "Bagian");
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
            metroPanel1.Location = new Point(64, 340);
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
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            txtkode.Text = "";
            txtnama.Text = "";
            txtalamat.Text = "";
            txtemail.Text = "";
            txtnohp.Text = "";
            txtbagian.Text = "";
            txtkode.Enabled = false;
            txtnama.Enabled = false;
            txtalamat.Enabled = false;
            txtemail.Enabled = false;
            txtnohp.Enabled = false;
            txtbagian.Enabled = false;
            btnsimpan.Enabled = false;
            btnupdate.Enabled = true;
            btnsdelete.Enabled = true;
            btnexit.Enabled = true;
            btnbatal.Visible = false;
            btnupdate.Visible = true;
            btnsupdate.Visible = false;
            btninput.Visible = true;
            metroPanel1.Visible = false;
        }

        private void btnsupdate_Click(object sender, EventArgs e)
        {
            if (txtalamat.Text == "" || txtnama.Text == "" || txtnohp.Text == "" || txtbagian.Text == "" || txtemail.Text == "")
            {
                MetroMessageBox.Show(this, "Masih Ada Data Yang Kosong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Update();
            }
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //gets a collection that contains all the rows
            DataGridViewRow row = this.metroGrid1.Rows[e.RowIndex];
            //populate the textbox from specific value of the coordinates of column and row.
            txtkode.Text = row.Cells[0].Value.ToString();
            txtnama.Text = row.Cells[1].Value.ToString();
            txtalamat.Text = row.Cells[2].Value.ToString();
            txtnohp.Text = row.Cells[3].Value.ToString();
            txtemail.Text = row.Cells[4].Value.ToString();
            txtbagian.Text = row.Cells[5].Value.ToString();
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
        private void DataPegawai_Load(object sender, EventArgs e)
        {
            Select();
            Select2();
            IsiCombobox();
            metroPanel1.Visible = false;
            btnbatal.Visible = false;
            btnsupdate.Visible = false;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataPegawai_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            txtnama.Enabled = true;
            txtalamat.Enabled = true;
            txtemail.Enabled = true;
            txtnohp.Enabled = true;
            txtbagian.Enabled = true;
            btnupdate.Visible = false;
            btnbatal.Visible = true;
            btninput.Visible = false;
            btnsupdate.Visible = true;
            btnsdelete.Enabled = false;
            btnexit.Enabled = false;
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            
            txtkode.Text = "";
            txtnama.Text = "";
            txtalamat.Text = "";
            txtemail.Text = "";
            txtnohp.Text = "";
            txtbagian.Text = "";
            txtnama.Enabled = true;
            txtalamat.Enabled = true;
            txtemail.Enabled = true;
            txtnohp.Enabled = true;
            txtbagian.Enabled = true;
            btnbatal.Visible = true;
            btnsimpan.Enabled = true;
            btnupdate.Enabled = false;
            btnsdelete.Enabled = false;
            btnexit.Enabled = false;
            kode();
        }

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.metroGrid2.Rows[e.RowIndex];
            txtbagian.Text = row.Cells[0].Value.ToString();
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

        private void txtbagian_Click(object sender, EventArgs e)
        {
            visiblepanel("panel1");
        }

        private void btnsimpan_Click(object sender, EventArgs e)
        {
            if (txtalamat.Text == "" || txtnama.Text == "" || txtnohp.Text == "" || txtbagian.Text == "" || txtemail.Text == "")
            {
                MetroMessageBox.Show(this, "Masih Ada Data Yang Kosong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Insert();
            }
        }

        private void txtbagian_Enter(object sender, EventArgs e)
        {
            visiblepanel("panel1");
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                Search();
            }
        }
    }
}
