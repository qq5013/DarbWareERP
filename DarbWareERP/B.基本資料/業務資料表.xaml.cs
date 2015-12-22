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
using System.Data;
using 數據庫連線;

namespace DarbWareERP.B.基本資料
{
    /// <summary>
    /// 業務資料表.xaml 的互動邏輯
    /// </summary>
    public partial class 業務資料表 : Window
    {
        public 業務資料表()
        {
            InitializeComponent();
            //DataSet Q = Log.Log_Sys_Exec("業務資料表", "DARB_MOVEREC", "SALESMEN", "NEXT");
            //salesmenDataGrid.DataContext = Q.Tables[0];
        }

        private void 命令區塊_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
