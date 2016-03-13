using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using 邏輯;
using System.Data;
using DarbWareERP.繼承窗口;
using System.ComponentModel;

namespace DarbWareERP
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class 登入視窗 : 視窗繼承
    {
        登入Bll 登入Bll;
        public 登入視窗()
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
                    選單 q = new 選單();
                    q.Show();
                    this.CloseWindow();
                }
                else
                {
                    MessageBox.Show("帳號或密碼輸入錯誤");
                    pwd密碼.Password = "";
                }
            }
            catch(Exception ex)
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
