using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace sibfalcerueu
{
    public partial class SetDB : MetroForm
    {
        public SetDB()
        {
            InitializeComponent();
        }
        //Variabel Yang Mau Di Passing 
        public static string server;
        public static string nama;
        public static string uid;
        public static string pass;

        MySqlConnection conn;
        private void metroButton1_Click(object sender, EventArgs e)
        {
            server = txtserver.Text;
            nama = txtnama.Text;
            uid = txtuid.Text;
            pass = txtpass.Text;
            string connstring = "server=" + server + ";database=" + nama + ";uid=" + uid + ";pwd=" + pass + ";";
            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();
                MetroMessageBox.Show(this, "Database Berhasil Connect ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroButton2.Enabled = true;
                metroButton1.Enabled = false;
                conn.Close();
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
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Login lf = new Login();
            lf.Show();
            this.Hide();
        }
        private void SetDB_Load(object sender, EventArgs e)
        {

        }
    }
}
