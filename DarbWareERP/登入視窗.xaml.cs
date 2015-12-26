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
using 數據庫連線;
using 邏輯;
using System.Data;

namespace DarbWareERP
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class 登入視窗 : Window
    {
        public 登入視窗()
        {
            InitializeComponent();
            txt帳號.Focus();          
            
            
        }

        private void btn離開_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn登入_Click(object sender, RoutedEventArgs e)
        {

            int logbookid=0;
            try
            {
                使用者.權限表 = Log.Log_LogOn(txt帳號.Text, pwd密碼.Password, out logbookid);
            }
            catch { }
            
            使用者.LogBookId = logbookid;
            使用者.使用者代號 = txt帳號.Text;
            
            if (使用者.LogBookId > 0)
            {
                使用者.使用者名稱 = 使用者.權限表.Rows[0]["使用者姓名"].ToString().Trim();
                選單 q = new 選單();
                q.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("帳號或密碼輸入錯誤");
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
