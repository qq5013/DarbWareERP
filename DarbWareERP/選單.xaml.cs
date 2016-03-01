using System.Windows;
using DarbWareERP.B.基本資料;
using DarbWareERP.繼承窗口;
using 邏輯.視窗相關;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System;
using DarbWareERP.控制項;

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

        private void btn轉sliy_Click(object sender, RoutedEventArgs e)
        {
            DarbWareERP.轉資料.轉Sliy window = new 轉資料.轉Sliy();
            window.Show();
            this.CloseWindow();
        }

        private void 視窗繼承_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> 選單列表 = WindowBll.GetInstance().選單按鈕名稱列表();
            DependencyObject doj = VisualTreeHelper.GetChild(WrapPanel, 0);
            int 按鈕數 = VisualTreeHelper.GetChildrenCount(WrapPanel);
            for (int i = 0; i < 按鈕數; i++)
            {
                Button btn = (Button)VisualTreeHelper.GetChild(WrapPanel, i);
                if (i < 選單列表.Count)
                {
                    btn.Content = 選單列表[i];
                    btn.Click += 開啟視窗_Click;
                }
                else
                {
                    btn.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void 開啟視窗_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            List<string> 程式名稱列表 = WindowBll.GetInstance().程式名稱列表(btn.Content.ToString());
            Type CAType = Type.GetType("DarbWareERP." + btn.Content + "." + 程式名稱列表[0]);            
            視窗繼承 window = (視窗繼承)Activator.CreateInstance(CAType);            
            window.Show();
            表單控制.視窗加入(程式名稱列表[0],window);
            表單控制.目前視窗 = 程式名稱列表[0];
            this.CloseWindow();
        }
    }
}
