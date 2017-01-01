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
    public partial class BarangKeluar : MetroForm
    {
        public BarangKeluar()
        {
            InitializeComponent();
        }
        public MySqlConnection conn;
        public MySqlCommand cmd;
        private MySqlDataReader rd;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
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
        private void Select2()
        {
            string query = "SELECT * FROM barang";

            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt2);
                metroGrid3.DataSource = dt2;
            }
            this.CloseConnection();
        }
        private void visiblepanel(string pil)
        {
            metroPanel2.Location = new Point(155, 192);
            metroPanel1.Location = new Point(155, 152);
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
        private void kode()
        {
            long hitung;
            long hitung2;
            string urut;
            if (this.OpenConnection() == true)
            {
                string tanggal = DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year.ToString().Substring(2, 2);
                cmd = new MySqlCommand("select kode from barang_keluar where kode in(select max(kode) from barang_keluar) order by kode desc", conn);
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    hitung2 = Convert.ToInt64(rd[0].ToString().Substring(rd["kode"].ToString().Length - 9, 6));
                    if (tanggal == hitung2.ToString())
                    {
                        hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["kode"].ToString().Length - 3, 3)) + 1;
                        string joinstr = "000" + hitung;
                        urut = "KL" + tanggal + "" + joinstr.Substring(joinstr.Length - 3, 3);
                    }

                    else
                    {
                        urut = "KL" + tanggal + "001";
                    }
                }
                else
                {
                    urut = "KL" + tanggal + "001";
                }
                rd.Close();
                txtkodebm.Text = urut;
            }
            this.CloseConnection();
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            txtkodeuser.Text = "";
            txtkodebm.Text = "";
            txtkodebagian.Text = "";
            txtkodebarang.Text = "";
            txtjumlah.Text = "";
            txtjumlah.Enabled = false;
            txtkodebarang.Enabled = false;
            txtkodebagian.Enabled = false;
            btnsimpan.Enabled = false;
            btnbatal.Enabled = false;
            btnsimpan.Visible = false;
            btnsubmit.Enabled = false;
            btninput.Enabled = true;
            btnupdate.Visible = true;
            btndelete.Visible = true;
            btnsdelete.Visible = false;
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            kode();
            txtkodeuser.Text = Login.kode;
            if (string.IsNullOrWhiteSpace(txtkodebagian.Text))
            {
                txtkodebagian.Enabled = true;
            }
            else
            {
                txtkodebagian.Enabled = false;
            }
            txtjumlah.Enabled = true;
            txtkodebarang.Enabled = true;
            btnsimpan.Enabled = true;
            btninput.Enabled = false;
            btnsdelete.Enabled = false;
            btnupdate.Visible = false;
            btnsimpan.Visible = true;
            btnbatal.Enabled = true;
        }
        private string getNama(string kode)
        {
            string query = "SELECT nama FROM barang WHERE kode = @kode";
            string nama = "";
            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kode", txtkodebarang.Text);
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        nama = rd["nama"].ToString();
                    }
                }
                else
                {
                    nama = "ERROR NOW ROWS";
                }
            }
            else
            {
                nama = "ERROR CONNECTION";
            }
            return nama;
        }

        private void btnsimpan_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                if (txtkodebarang.Text == row.Cells[0].Value.ToString())
                {
                    // row exists
                    found = true;
                    MetroMessageBox.Show(this, "Data Sudah Ada Di List", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            if (!found)
            {
                string nama = getNama(txtkodebarang.Text);
                metroGrid1.Rows.Add(txtkodebarang.Text, nama, txtjumlah.Text);
                MetroMessageBox.Show(this, "Success Tambah Data", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            txtkodebarang.Text = "";
            txtjumlah.Text = "";
            txtkodebarang.Enabled = false;
            txtjumlah.Enabled = false;
            btnsimpan.Visible = false;
            btnupdate.Visible = true;
            btnbatal.Enabled = false;
            btninput.Enabled = true;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
            txtkodebagian.Enabled = false;
        }

        private void BarangKeluar_Load(object sender, EventArgs e)
        {
            Select();
            Select2();
            metroPanel1.Visible = false;
            metroPanel2.Visible = false;
            btnsimpan.Visible = false;
            btnsdelete.Visible = false;
            btnupdate.Visible = true;
            btnupdate.Enabled = false;
            btndelete.Enabled = false;
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (statecellclick.Text == "UPDATE")
            {
                btnupdate.Visible = false;
                btnsimpan.Enabled = true;
                btnsimpan.Visible = true;
                txtkodebarang.Enabled = true;
                txtjumlah.Enabled = true;
                //gets a collection that contains all the rows
                DataGridViewRow row = this.metroGrid1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtkodebarang.Text = row.Cells[0].Value.ToString();
                txtjumlah.Text = row.Cells[2].Value.ToString();
                metroGrid1.Rows.Remove(metroGrid1.CurrentRow);
            }
            else if (statecellclick.Text == "DELETE")
            {
                DialogResult result = MetroMessageBox.Show(this, "Apa Anda Yakin Ingin Menghapus Data Tersebut?", "Konfirmasi Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    metroGrid1.Rows.Remove(metroGrid1.CurrentRow);
                    MetroMessageBox.Show(this, "Data Berhasil Dihapus", "Sukses Hapus data", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
        }

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.metroGrid2.Rows[e.RowIndex];
                txtkodebagian.Text = row.Cells[0].Value.ToString();
                metroPanel1.Visible = false;
        }

        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.metroGrid3.Rows[e.RowIndex];
            if ((int)row.Cells[3].Value <= 0)
            {
                MetroMessageBox.Show(this, "Stok kosong", "Stok Kosong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtkodebarang.Text = row.Cells[0].Value.ToString();
                metroPanel2.Visible = false;
            }
        }

        private void metroTextBox8_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt1.DefaultView;
            dv.RowFilter = string.Format("nama like '%{0}%'", metroTextBox8.Text);
            metroGrid2.DataSource = dv.ToTable();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt2.DefaultView;
            dv.RowFilter = string.Format("nama like '%{0}%'", metroTextBox1.Text);
            metroGrid3.DataSource = dv.ToTable();
        }

        private void txtkodebagian_Click(object sender, EventArgs e)
        {
            visiblepanel("panel1");
        }

        private void metroPanel1_MouseLeave(object sender, EventArgs e)
        {
            visiblepanel("panel1");
        }

        private void txtkodebarang_Click(object sender, EventArgs e)
        {
            visiblepanel("panel2");
        }

        private void metroPanel2_MouseLeave(object sender, EventArgs e)
        {
            visiblepanel("panel2");
        }

        private void metroPanel2_VisibleChanged(object sender, EventArgs e)
        {
            if (metroPanel2.Visible == true)
            {
                txtkodebagian.Visible = false;
            }
            else
            {
                txtkodebagian.Visible = true;
            }
        }

        private void metroPanel1_VisibleChanged(object sender, EventArgs e)
        {
            if (metroPanel1.Visible == true)
            {
                txtkodebarang.Visible = false;
            }
            else
            {
                txtkodebarang.Visible = true;
            }
        }

        private void metroGrid1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnsubmit.Enabled = true;
        }

        private void metroGrid1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (metroGrid1.Rows.Count == 0)
            {
                btnsubmit.Enabled = false;
            }
        }
        private bool Insert1()
        {
            string query = "INSERT INTO barang_keluar VALUES (@kode, @tanggal, @kodeuser, @kodebagian)";
            if (this.OpenConnection() == true)
            {
                //Start MysqlCommand
                cmd = new MySqlCommand(query, conn);

                //Binding Value
                cmd.Parameters.AddWithValue("@kode", txtkodebm.Text);
                cmd.Parameters.AddWithValue("@tanggal", DateTime.Today);
                cmd.Parameters.AddWithValue("@kodeuser", txtkodeuser.Text);
                cmd.Parameters.AddWithValue("@kodebagian", txtkodebagian.Text);

                //Execute command
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    this.CloseConnection();
                    return false;
                }
            }
            return false;
        }
        private bool Insert2()
        {
            if (this.OpenConnection() == true)
            {
                foreach (DataGridViewRow row in metroGrid1.Rows)
                {
                    try
                    {
                        cmd = new MySqlCommand();
                        cmd = conn.CreateCommand();
                        if (row.IsNewRow) continue;
                        cmd.Parameters.AddWithValue("@kode", txtkodebm.Text);
                        cmd.Parameters.AddWithValue("@jumlah", row.Cells["jumlah"].Value);
                        cmd.Parameters.AddWithValue("@kode_barang", row.Cells["KodeBarang"].Value);
                        cmd.CommandText = "INSERT INTO detail_barang_keluar VALUES (@kode, @jumlah, @kode_barang)";
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        this.CloseConnection();
                        return false;
                    }
                }
                this.CloseConnection();
                return true;
            }
            return false;
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (this.Insert1() == true)
            {
                if (this.Insert2() == true)
                {
                    metroGrid1.Rows.Clear();
                    metroGrid1.Refresh();
                    txtkodebm.Text = "";
                    txtkodebagian.Text = "";
                    txtkodebarang.Text = "";
                    txtjumlah.Text = "";
                    MetroMessageBox.Show(this, "Submit Transaksi Barang Keluar Berhasil", "Transaksi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroMessageBox.Show(this, "Insert2 Gagal", "Transaksi Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Insert1 Gagal", "Transaksi Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsdelete_Click(object sender, EventArgs e)
        {
            metroGrid1.Rows.Remove(metroGrid1.CurrentRow);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Silahkan Pilih Data Yang Ingin Diedit", "Edit Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            statecellclick.Text = "UPDATE";
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Silahkan Pilih Data Yang Ingin Dihapus", "Edit Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            statecellclick.Text = "DELETE";
        }
    }
}
