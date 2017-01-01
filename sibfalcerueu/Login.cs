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
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }
        public MySqlConnection conn;
        public MySqlCommand cmd;
        private MySqlDataReader dr;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        public static string level;
        public static string kode;
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
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM user WHERE username='" + txtusername.Text + "' and password=MD5('" + txtpassword.Text + "')";
            if (this.OpenConnection() == true)
            {
                cmd = new MySqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MetroMessageBox.Show(this, "Selamat Datang!", "Success Login!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    while (dr.Read())
                    {
                        level = dr["level"].ToString();
                        kode = dr["kode_pegawai"].ToString();
                        Beranda beranda = new Beranda();
                        this.Hide();
                        beranda.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Username / Password Salah", "Gagal Login!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("ASA");
            }
        }
    }
}
