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
using ViewModel.M.主管資訊;

namespace DarbWareERP.M.主管資訊
{
    /// <summary>
    /// 客戶資料查詢.xaml 的互動邏輯
    /// </summary>
    public partial class 客戶資料查詢 : 頁面繼承
    {
        public 客戶資料查詢()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            客戶資料查詢ViewModel viewModel = this.DataContext as 客戶資料查詢ViewModel;
            viewModel.查詢();
        }
    }
}
