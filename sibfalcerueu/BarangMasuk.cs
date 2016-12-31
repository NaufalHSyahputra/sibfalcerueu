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
    public partial class BarangMasuk : MetroForm
    {
        public BarangMasuk()
        {
            InitializeComponent();
        }
        public MySqlConnection conn;
        public MySqlCommand cmd;
        private MySqlDataReader rd;
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
        private string kode()
        {
            long hitung;
            long hitung2;
            string urut;
            if (this.OpenConnection() == true)
            {
                string tanggal = DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year.ToString().Substring(2, 2);
                cmd = new MySqlCommand("select kode from barang where kode in(select max(kode) from barang) order by kode desc", conn);
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    hitung2 = Convert.ToInt64(rd[0].ToString().Substring(rd["kode"].ToString().Length - 9, 6));
                    if (tanggal == hitung2.ToString())
                    {
                        hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["kode"].ToString().Length - 3, 3)) + 1;
                        string joinstr = "000" + hitung;
                        urut = "MK" + tanggal + "" + joinstr.Substring(joinstr.Length - 3, 3);
                    }

                    else
                    {
                        urut = "MK" + tanggal + "001";
                    }
                }else
                {
                    urut = "MK" + tanggal + "001";
                }
                rd.Close();
                return urut;
            }
            this.CloseConnection();
            return "Gagal";
        }
    }
}
