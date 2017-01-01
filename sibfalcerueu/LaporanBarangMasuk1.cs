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

namespace sibfalcerueu
{
    public partial class LaporanBarangMasuk1 : MetroForm
    {
        public LaporanBarangMasuk1()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            LaporanBarangMasukF lbm = new LaporanBarangMasukF();
            lbm.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            LaporanBarangMasukPerPeriodeF lbm = new LaporanBarangMasukPerPeriodeF();
            lbm.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            LaporanBarangMasukPerTanggalF lbm = new LaporanBarangMasukPerTanggalF();
            lbm.Show();
        }
    }
}
