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

namespace DarbWareERP.轉資料
{
    /// <summary>
    /// 轉ACCL.xaml 的互動邏輯
    /// </summary>
    public partial class 轉Accl : 頁面繼承
    {
        public 轉Accl()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //轉傳票Bll 轉資料 = new 轉傳票Bll();
            //string result= 轉資料.轉Accl();
            //MessageBox.Show(result);
        }
    }
}
