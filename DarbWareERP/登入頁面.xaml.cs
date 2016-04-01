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
using 邏輯;
using DarbWareERP.繼承窗口;

namespace DarbWareERP
{
    /// <summary>
    /// 登入頁面.xaml 的互動邏輯
    /// </summary>
    public partial class 登入頁面 : 頁面繼承
    {
        登入Bll 登入Bll;
        public 登入頁面()
        {
            InitializeComponent();
            登入Bll = new 登入Bll();
            txt帳號.Focus();
            label4.Content = 登入Bll.資料庫;            
        }

        private void btn離開_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn登入_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (登入Bll.登入(txt帳號.Text, pwd密碼.Password))
                {
                    切換頁面("DarbWareERP.", 頁面枚舉.選單頁面);                               
                }
                else
                {
                    MessageBox.Show("帳號或密碼輸入錯誤");
                    pwd密碼.Password = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt帳號_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                UIElement element = Keyboard.FocusedElement as UIElement;
                element.MoveFocus(request);
            }
        }

        private void pwd密碼_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                UIElement element = Keyboard.FocusedElement as UIElement;
                element.MoveFocus(request);
            }
        }
    }
}
