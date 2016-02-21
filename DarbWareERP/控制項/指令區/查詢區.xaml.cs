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

namespace DarbWareERP.控制項.指令區
{
    /// <summary>
    /// 查詢區.xaml 的互動邏輯
    /// </summary>
    public partial class 查詢區 : UserControl
    {
        public 查詢區()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            rbtn鑑值.IsChecked = true;
            rbtn瀏覽頁面.IsChecked = true;
        }

        private void btn檔首_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("檔首");
        }

        private void btn上一筆_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("上一筆");
        }
        //btn上一筆.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        
    }
}
