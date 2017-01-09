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
            DataBarang frm = new DataBarang();

            frm.ShowDialog();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            DataPegawai frm = new DataPegawai();

            frm.ShowDialog();

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            DataKategoriBarang frm = new DataKategoriBarang();

            frm.ShowDialog();

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            DataBagianPegawai frm = new DataBagianPegawai();

            frm.ShowDialog();

        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            DataSupplier frm = new DataSupplier();

            frm.ShowDialog();

        }

        private void Beranda_Load(object sender, EventArgs e)
        {
            if(Login.level != "Admin")
            {
                metroTabControl1.TabPages.Remove(metroTabPage4);
            }
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            BarangMasuk frm = new BarangMasuk();

            frm.ShowDialog();

        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            BarangKeluar frm = new BarangKeluar();
            frm.ShowDialog();
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            ReportBarangForm frm = new ReportBarangForm();
            frm.ShowDialog();
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            ReportPegawaiForm frm = new ReportPegawaiForm();
            frm.ShowDialog();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            ReportSupplierForm frm = new ReportSupplierForm();
            frm.ShowDialog();
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            LaporanBarangMasuk1 frm = new LaporanBarangMasuk1();
            frm.ShowDialog();
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            LaporanBarangKeluar1 frm = new LaporanBarangKeluar1();
            frm.ShowDialog();
        }

        private void metroTile13_Click(object sender, EventArgs e)
        {
            DataUser frm = new DataUser();
            frm.ShowDialog();
        }
    }
}
