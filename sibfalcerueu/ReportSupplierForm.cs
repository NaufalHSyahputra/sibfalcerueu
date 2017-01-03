using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MetroFramework.Forms;
using MetroFramework;

namespace sibfalcerueu
{
    public partial class ReportSupplierForm : MetroForm
    {
        public ReportSupplierForm()
        {
            InitializeComponent();
        }
        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        private void ReportSupplierForm_Load(object sender, EventArgs e)
        {
            crConnectionInfo.ServerName = SetDB.server;
            crConnectionInfo.DatabaseName = SetDB.nama;
            crConnectionInfo.UserID = SetDB.uid;
            crConnectionInfo.Password = SetDB.pass;
        }
    }
}
