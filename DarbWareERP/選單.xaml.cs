using System.Windows;
using DarbWareERP.B.基本資料;

namespace DarbWareERP
{
    /// <summary>
    /// 選單.xaml 的互動邏輯
    /// </summary>
    public partial class 選單 : Window
    {
        public 選單()
        {
            InitializeComponent();
        }

        private void btn電子賀卡_Click(object sender, RoutedEventArgs e)
        {
            電子賀卡 window = new 電子賀卡();
            window.Show();
            this.Close();
        }

        private void btn台銀匯率_Click(object sender, RoutedEventArgs e)
        {
            台銀匯率 window = new 台銀匯率();
            window.Show();
            this.Close();
        }

        private void btn基本資料_Click(object sender, RoutedEventArgs e)
        {
            業務資料表 window = new 業務資料表();
            window.Show();
            this.Close();
        }

        private void btn返回登入視窗_Click(object sender, RoutedEventArgs e)
        {
            登入視窗 window = new 登入視窗();
            window.Show();
            this.Close();
        }
    }
}
