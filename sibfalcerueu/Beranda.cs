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
    public partial class Beranda : MetroForm
    {
        public Beranda()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            DataBarang DaBa = new DataBarang();
            DaBa.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            DataPegawai DaPe = new DataPegawai();
            DaPe.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            DataKategoriBarang DaKaBa = new DataKategoriBarang();
            DaKaBa.Show();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            DataBagianPegawai DaBaPe = new DataBagianPegawai();
            DaBaPe.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            DataSupplier DaSu = new DataSupplier();
            DaSu.Show();
        }
    }
}
