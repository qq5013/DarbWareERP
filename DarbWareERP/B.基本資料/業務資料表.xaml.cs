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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DarbWareERP.繼承窗口;

namespace DarbWareERP.B.基本資料
{
    /// <summary>
    /// 業務資料表.xaml 的互動邏輯
    /// </summary>
    public partial class 業務資料表 : 頁面繼承
    {
        public 業務資料表()
        {
            InitializeComponent();
        }
        //private void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        //{                        
        //    CollectionViewSources[0] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("salesmenViewSource")));
        //    SetControls();
        //}
    }
}
