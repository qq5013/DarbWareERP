using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 報表
{
    public partial class 預覽報表 : Form
    {
        object obj;
        public 預覽報表(object obj)
        {
            InitializeComponent();
            this.obj = obj;
        }

        private void 預覽報表_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "報表.單位轉換表.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Unitba", obj));
            this.reportViewer1.RefreshReport();
        }
    }
}
