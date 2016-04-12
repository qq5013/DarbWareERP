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
    public partial class Form1 : Form
    {
        DataTable datatable;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(DataTable dt)
        {
            InitializeComponent();
            datatable = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "報表.Report2.rdlc";
            unitbaBindingSource.DataSource = datatable;
            this.reportViewer1.RefreshReport();
        }
    }
}
