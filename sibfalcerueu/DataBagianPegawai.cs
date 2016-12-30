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
    public partial class DataBagianPegawai : MetroForm
    {
        public DataBagianPegawai()
        {
            InitializeComponent();
        }
        public MySqlConnection conn;
        public MySqlCommand cmd;
        private MySqlDataReader rd;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        Timer t1 = new Timer();
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
                cmd = new MySqlCommand("select kode from bagian where kode in(select max(kode) from bagian) order by kode desc", conn);
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["kode"].ToString().Length - 3, 3)) + 1;
                    string joinstr = "000" + hitung;
                    urut = "BAG" + joinstr.Substring(joinstr.Length - 3, 3);
                }
                else
                {
                    urut = "BAG001";
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
            string query = "SELECT * FROM bagian";

            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            this.CloseConnection();
        }

        public void Insert()
        {
            string query = "INSERT INTO bagian VALUES(@kode, @nama)";

            //open connection
            if (this.OpenConnection() == true)
            {
                //Start MysqlCommand
                cmd = new MySqlCommand(query, conn);

                //Binding Value
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                cmd.Parameters.AddWithValue("@nama", txtnama.Text);

                //Execute command
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Input Data Bagian Pegawai Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Input Data Bagian Pegawai Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
            string query = "UPDATE bagian SET nama = @nama WHERE kode = @kode";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                cmd = new MySqlCommand(query, conn);

                //Binding Value
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                cmd.Parameters.AddWithValue("@nama", txtnama.Text);
                //Execute query
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Update Data Bagian Pegawai Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Update Data Bagian Pegawai Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            //close connection
            this.CloseConnection();
            Select();
            btnbatal.PerformClick();
        }

        public void Delete()
        {
            string query = "DELETE FROM bagian WHERE kode = @kode";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kode", txtkode.Text);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MetroMessageBox.Show(this, "Delete Data Bagian Pegawai Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Delete Data Bagian Pegawai Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            //close connection
            this.CloseConnection();
            Select();
            txtkode.Text = "";
            txtnama.Text = "";
        }
        private void IsiCombobox()
        {
            // Bind combobox to dictionary
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("kode", "Kode Kategori");
            test.Add("nama", "Nama Kategori");
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
            txtnama.Text = row.Cells[1].Value.ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void DataBagianPegawai_Load(object sender, EventArgs e)
        {
            Opacity = 0;      //first the opacity is 0

            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start();
            Select();
            IsiCombobox();
            btnbatal.Visible = false;
            btnsupdate.Visible = false;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            txtkode.Text = "";
            txtnama.Text = "";
            txtkode.Enabled = false;
            txtnama.Enabled = false;
            btnsimpan.Enabled = false;
            btnupdate.Enabled = true;
            btnsdelete.Enabled = true;
            btnexit.Enabled = true;
            btninput.Visible = true;
            btnbatal.Visible = false;
            btnupdate.Visible = true;
            btnsupdate.Visible = false;
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            kode();
            txtnama.Enabled = true;
            btnbatal.Visible = true;
            btnsimpan.Enabled = true;
            btnupdate.Enabled = false;
            btnsdelete.Enabled = false;
            btnexit.Enabled = false;
        }

        private void btnsupdate_Click(object sender, EventArgs e)
        {
            if (txtnama.Text == "")
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
            txtnama.Enabled = true;
            btnupdate.Visible = false;
            btnsdelete.Enabled = false;
            btnexit.Enabled = false;
            btnbatal.Visible = true;
            btninput.Visible = false;
            btnsupdate.Visible = true;
        }

        private void btnsimpan_Click(object sender, EventArgs e)
        {
            if (txtnama.Text == "")
            {
                MetroMessageBox.Show(this, "Masih Ada Data Yang Kosong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Insert();
            }
        }
        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
                t1.Stop();   //this stops the timer if the form is completely displayed
            else
                Opacity += 0.05;
        }

        private void DataBagianPegawai_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
