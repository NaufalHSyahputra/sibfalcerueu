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
    public partial class LaporanBarangKeluar1 : MetroForm
    {
        public LaporanBarangKeluar1()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            LaporanBarangKeluarF lbm = new LaporanBarangKeluarF();
            lbm.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            LaporanBarangKeluarPerPeriodeF lbm = new LaporanBarangKeluarPerPeriodeF();
            lbm.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            LaporanBarangKeluarPerTanggalF lbm = new LaporanBarangKeluarPerTanggalF();
            lbm.Show();
        }
    }
}
