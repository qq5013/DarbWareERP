using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DarbWareERP.繼承窗口;
using Model;
using 邏輯.視窗相關;
using 邏輯.視窗相關.B.基本資料;
using 報表;
using System.Data;
using System.Reflection;
using System.Printing;
using System.Drawing.Printing;

namespace DarbWareERP.B.基本資料
{
    /// <summary>
    /// 單位轉換表.xaml 的互動邏輯
    /// </summary>
    public partial class 單位轉換表 : 視窗繼承
    {
        private 單位轉換表Bll 單位轉換表Bll = new 單位轉換表Bll();
        public 單位轉換表()
        {
            InitializeComponent();
        }

        private void 視窗繼承_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("unitbaViewSource")));            
            SetControls();            
        }
        public override void SetControls()
        {
            base.SetControls();
            txt單位.IsReadOnly = Status == EnumStatus.一般;
            txt小數位數.IsReadOnly = Status == EnumStatus.一般;
            txt說明.IsReadOnly = Status == EnumStatus.一般;
        }
        public override void SetDefaultValue()
        {
            base.SetDefaultValue();
            txtpkid.Text = "";
            txt單位.Text = "+++";
            txt小數位數.Text = "0";
            txt說明.Text = "";
            txt單位.Focus();
        }

        public override bool UpdateData(CollectionViewSource cv)
        {
            return 單位轉換表Bll.UpdateData(cv, out this._增刪修訊息);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            CollectionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("unitbaViewSource")));
            DataTable dt = (DataTable)CollectionViewSource.Source;            
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = dt;
            f.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            f.reportViewer1.RefreshReport();

        }
    }
}
