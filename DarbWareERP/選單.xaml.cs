using System.Windows;
using DarbWareERP.B.基本資料;
using DarbWareERP.繼承窗口;

namespace DarbWareERP
{
    /// <summary>
    /// 選單.xaml 的互動邏輯
    /// </summary>
    public partial class 選單 : 視窗繼承
    {
        public 選單()
        {
            InitializeComponent();
        }

        private void btn電子賀卡_Click(object sender, RoutedEventArgs e)
        {
            電子賀卡 window = new 電子賀卡();
            window.Show();
            this.CloseWindow();
        }

        private void btn台銀匯率_Click(object sender, RoutedEventArgs e)
        {
            台銀匯率 window = new 台銀匯率();
            window.Show();
            this.CloseWindow();
        }

        private void btn基本資料_Click(object sender, RoutedEventArgs e)
        {
            業務資料表 window = new 業務資料表();
            window.Show();
            this.CloseWindow();
        }

        private void btn返回登入視窗_Click(object sender, RoutedEventArgs e)
        {
            登入視窗 window = new 登入視窗();
            window.Show();
            this.CloseWindow();
        }

        private void btn轉ACCL_Click(object sender, RoutedEventArgs e)
        {
            DarbWareERP.轉資料.轉Accl window = new 轉資料.轉Accl();
            window.Show();
            this.CloseWindow();
        }

        private void btn轉sily_Click(object sender, RoutedEventArgs e)
        {
            DarbWareERP.轉資料.轉Sliy window = new 轉資料.轉Sliy();
            window.Show();
            this.CloseWindow();
        }
    }
}
