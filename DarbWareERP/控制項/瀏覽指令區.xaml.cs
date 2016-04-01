using DarbWareERP.繼承窗口;
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

namespace DarbWareERP.控制項
{
    /// <summary>
    /// 瀏覽指令區.xaml 的互動邏輯
    /// </summary>
    public partial class 瀏覽指令區 : UserControl
    {
        public 瀏覽指令區()
        {
            InitializeComponent();
        }

        private void btn返回_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            頁面繼承 page;
            nav = NavigationService.GetNavigationService(this);
            if (表單控制.Page實體列表.Any(x => x.Title == txbl程式名稱.Text))
            {
                page = 表單控制.Page實體列表.Find(x => x.Title == txbl程式名稱.Text);
            }
            else
            {
                throw new Exception();
            }
            表單控制.目前頁面 = page;
            nav.Navigate(page);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {            
            string 程式名稱 = 表單控制.目前頁面.Title;
            txbl程式名稱.Text = 程式名稱.Replace("瀏覽頁面", "");

        }
       
    }
}
