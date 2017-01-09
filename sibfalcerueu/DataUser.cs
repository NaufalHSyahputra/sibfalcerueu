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
    public partial class DataUser : MetroForm
    {
        public DataUser()
        {
            InitializeComponent();
        }
        public MySqlConnection conn;
        public MySqlCommand cmd;
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
        private new void Select()
        {
            while (metroGrid1.Rows.Count > 0)
            {
                metroGrid1.Rows.RemoveAt(0);
            }
            string query = "SELECT kode_pegawai,username,level FROM user";

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
            string query = "SELECT * FROM pegawai";

            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt1);
                metroGrid2.DataSource = dt1;
            }
            this.CloseConnection();
        }
        private void visiblepanel(string pil)
        {
            metroPanel1.Location = new Point(115, 97);
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

        private void txtkode_Click(object sender, EventArgs e)
        {
            visiblepanel("panel1");
        }
        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.metroGrid2.Rows[e.RowIndex];
            txtkode.Text = row.Cells[0].Value.ToString();
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
        public void Insert()
        {
            string query = "INSERT INTO user(kode_pegawai,username,password,level) VALUES(@kode, @username, MD5(@password), @level)";
            string value = "";
            bool isChecked = adminradio.Checked;
            if (isChecked)
                value = adminradio.Text;
            else
                value = userradio.Text;
            //open connection
            if (this.OpenConnection() == true)
            {
                //Start MysqlCommand
                cmd = new MySqlCommand(query, conn);

                //Binding Value
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@level", value);
                //Execute command
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Input Data User Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Input Data User Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
            string query = "UPDATE user SET username = @username, password = MD5(@password), level = @level WHERE kode_pegawai = @kode";
            string value = "";
            bool isChecked = adminradio.Checked;
            if (isChecked)
                value = adminradio.Text;
            else
                value = userradio.Text;
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                cmd = new MySqlCommand(query, conn);

                //Binding Value
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@level", value);
                //Execute query
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Update Data User Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Update Data User Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            //close connection
            this.CloseConnection();
            Select();
            btnbatal.PerformClick();
        }

        public void Delete()
        {
            string query = "DELETE FROM user WHERE kode_pegawai = @kode";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Delete Data User Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Delete Data User Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            //close connection
            this.CloseConnection();
            Select();
            txtkode.Text = "";
            txtusername.Text = "";
        }
        private void IsiCombobox()
        {
            // Bind combobox to dictionary
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("kode_pegawai", "Kode");
            test.Add("username", "Username");
            test.Add("level", "Level");
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
            metroGrid1.DataSource = dv.ToTable();
        }
        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //gets a collection that contains all the rows
            DataGridViewRow row = this.metroGrid1.Rows[e.RowIndex];
            //populate the textbox from specific value of the coordinates of column and row.
            txtkode.Text = row.Cells[0].Value.ToString();
            txtusername.Text = row.Cells[1].Value.ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void DataUser_Load(object sender, EventArgs e)
        {
            Select();
            Select2();
            IsiCombobox();
            btnbatal.Visible = false;
            btnsupdate.Visible = false;
            metroPanel1.Visible = false;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            txtkode.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
            adminradio.Checked = false;
            userradio.Checked = false;
            txtkode.Enabled = false;
            txtusername.Enabled = false;
            txtpassword.Enabled = false;
            adminradio.Enabled = false;
            userradio.Enabled = false;
            btnsimpan.Enabled = false;
            btnupdate.Enabled = true;
            btnsdelete.Enabled = true;
            btnexit.Enabled = true;
            btninput.Visible = true;
            btnbatal.Visible = false;
            btnupdate.Visible = true;
            btnsupdate.Visible = false;
            metroPanel1.Visible = false;
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            txtkode.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
            txtkode.Enabled = true;
            txtusername.Enabled = true;
            txtpassword.Enabled = true;
            adminradio.Enabled = true;
            userradio.Enabled = true;
            btnbatal.Visible = true;
            btnsimpan.Enabled = true;
            btnupdate.Enabled = false;
            btnsdelete.Enabled = false;
            btnexit.Enabled = false;
        }

        private void btnsupdate_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtpassword.Text == "" || ! (adminradio.Checked || userradio.Checked))
            {
                MetroMessageBox.Show(this, "Masih Ada Data Yang Kosong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Update();
            }
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            txtkode.Enabled = false;
            txtusername.Enabled = true;
            txtpassword.Enabled = true;
            adminradio.Enabled = true;
            userradio.Enabled = true;
            btnsdelete.Enabled = false;
            btnexit.Enabled = false;
            btnupdate.Visible = false;
            btnbatal.Visible = true;
            btninput.Visible = false;
            btnsupdate.Visible = true;
        }

        private void btnsimpan_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtkode.Text == "" || txtpassword.Text == "" || ! (adminradio.Checked || userradio.Checked))
            {
                MetroMessageBox.Show(this, "Masih Ada Data Yang Kosong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Insert();
            }
        }

        private void DataUser_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                Search();
            }
        }

        private void txtkode_Enter(object sender, EventArgs e)
        {
            visiblepanel("panel1");
        }

        private void metroPanel1_VisibleChanged(object sender, EventArgs e)
        {
            if(metroPanel1.Visible == true)
            {
                adminradio.Visible = false;
                userradio.Visible = false;
            }else
            {
                adminradio.Visible = true;
                userradio.Visible = true;
            }
        }
    }
}
