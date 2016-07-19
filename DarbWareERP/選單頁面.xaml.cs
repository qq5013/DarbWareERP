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
using DarbWareERP.控制項;
using 邏輯Bll.視窗相關;
using DarbWareERP.B.基本資料;

namespace DarbWareERP
{
    /// <summary>
    /// 選單頁面.xaml 的互動邏輯
    /// </summary>
    public partial class 選單頁面 : 頁面繼承
    {
        public 選單頁面()
        {
            InitializeComponent();
            List<string> 選單列表 = WindowBll.GetInstance().選單按鈕名稱列表();
            DependencyObject doj = VisualTreeHelper.GetChild(WrapPanel, 0);
            int 按鈕數 = VisualTreeHelper.GetChildrenCount(WrapPanel);

            for (int i = 0; i < 按鈕數; i++)
            {
                Button btn = (Button)VisualTreeHelper.GetChild(WrapPanel, i);
                if (選單列表.Contains(btn.Content.ToString()))
                {
                    btn.Click += 開啟視窗_Click;
                }
                else
                {
                    btn.Click += 沒有權限_Click;
                }
            }
        }
        private void btn電子賀卡_Click(object sender, RoutedEventArgs e)
        {
            //電子賀卡 window = new 電子賀卡();
            //window.Show();
            //this.CloseWindow();
        }

        private void btn台銀匯率_Click(object sender, RoutedEventArgs e)
        {
            //台銀匯率 window = new 台銀匯率();
            //window.Show();
            //this.CloseWindow();
        }

        private void btn返回登入視窗_Click(object sender, RoutedEventArgs e)
        {
            表單控制.切換頁面("DarbWareERP.", "登入頁面");


        }
        private void btn轉ACCL_Click(object sender, RoutedEventArgs e)
        {
            //DarbWareERP.轉資料.轉Accl window = new 轉資料.轉Accl();
            //window.Show();
            //this.CloseWindow();
        }

        private void btn轉sliy_Click(object sender, RoutedEventArgs e)
        {
            //DarbWareERP.轉資料.轉Sliy window = new 轉資料.轉Sliy();
            //window.Show();
            //this.CloseWindow();
        }

        private void 開啟視窗_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            List<string> 程式名稱列表 = WindowBll.GetInstance().程式名稱列表(btn.Content.ToString());
            if (表單控制.切換頁面("DarbWareERP." + btn.Content + ".", 程式名稱列表[0]))
            {
                表單控制.Grid指令區.Visibility = Visibility.Visible;
                表單控制.切換表單區實體.按鈕賦值();
            }
        }
        private void 沒有權限_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("沒有權限，不行進入程式", "訊息", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn設定_Click(object sender, RoutedEventArgs e)
        {
            設定畫面 W = new 設定畫面();
            W.ShowDialog();
        }
    }
}
