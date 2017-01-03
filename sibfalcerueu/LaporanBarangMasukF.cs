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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace sibfalcerueu
{
    public partial class LaporanBarangMasukF : MetroForm
    {
        public LaporanBarangMasukF()
        {
            InitializeComponent();
        }
        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        private void LaporanBarangMasukF_Load(object sender, EventArgs e)
        {
            crConnectionInfo.ServerName = SetDB.server;
            crConnectionInfo.DatabaseName = SetDB.nama;
            crConnectionInfo.UserID = SetDB.uid;
            crConnectionInfo.Password = SetDB.pass;
        }
    }
}
