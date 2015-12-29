using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
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
using 數據庫連線;
using 邏輯;
using System.Data;
using System.Net;
using System.Net.Mail;
using DarbWareERP.繼承窗口;

namespace DarbWareERP
{
    /// <summary>
    /// 電子賀卡.xaml 的互動邏輯
    /// </summary>
    public partial class 電子賀卡 : 視窗繼承
    {
        public 電子賀卡()
        {
            InitializeComponent();
        }

        private void btn查詢_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = Log.Log_Sys_Exec("CUDATABrowse", "DARB_BROWSE", "CUDATA", "客戶代號 NOT LIKE N'QWERT%'", "2", "0");
            ds.Tables[0].Columns.Add("是否寄信", typeof(bool)).SetOrdinal(0);
            dataGrid.ItemsSource = ds.Tables[0].DefaultView;

        }

        private void btn寄信_Click(object sender, RoutedEventArgs e)
        {
            信件 mail = new 信件("momo16542@gmail.com");
            if (mail.寄信("ry.xware@msa.hinet.net", "s", "ad"))
            {
                MessageBox.Show("信件已寄出");
            }
            else
            {
                MessageBox.Show("失敗");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView q in dataGrid.ItemsSource)
            {

            }

        }
    }
}
