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
using ViewModel;
using System.Collections.ObjectModel;

namespace DarbWareERP.控制項.下方共同區塊
{    
    /// <summary>
    /// 查詢區.xaml 的互動邏輯
    /// </summary>
    public partial class 導覽區 : UserControl
    {
       
        導覽區ViewModel 導覽區ViewModel;
        頁面繼承 page;
        //CollectionViewSource[] cv;
        TextBox txtkey;
        TextBox txtpkid;
        CollectionViewSource[] 歷程cv=new CollectionViewSource[5] { new CollectionViewSource(), new CollectionViewSource(), new CollectionViewSource(), new CollectionViewSource(), new CollectionViewSource()};
        ObservableCollection<object>[] 歷程obs = new ObservableCollection<object>[5] { new ObservableCollection<object>(), new ObservableCollection<object>(), new ObservableCollection<object>(), new ObservableCollection<object>(), new ObservableCollection<object>()};
       
        public enum 導覽區指令Enum
        {
            預設, 查詢
        }
        public 導覽區()
        {
            InitializeComponent();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {            
            for (int i = 0; i < 歷程cv.Count(); i++)
            {
                歷程cv[i].Source = 歷程obs[i];
            }
            rbtn鑑值.IsChecked = true;
            rbtn資料歷程.IsChecked = true;
            導覽區ViewModel = new 導覽區ViewModel();
            page = 控制項操作.尋找父代<頁面繼承>(this);
        }
        private void 鍵值導覽區指令(導覽區指令Delegate callback, 導覽區指令Enum 指令 = 導覽區指令Enum.預設)
        {
            if (txtkey == null)
            {
                txtkey = 控制項操作.用名稱尋找子代<TextBox>(page, "txt" + page.KeyFldValue);
            }
            if (txtpkid == null)
            {
                txtpkid = 控制項操作.用名稱尋找子代<TextBox>(page, "txtpkid");
            }            
            if (指令 == 導覽區指令Enum.查詢)
            {
                page.目前KeyFldValue = txt查詢.Text;
            }
            callback(page.Title.ToString(), page.CollectionViewSources, page.資料表名稱, page.目前KeyFldValue);
            歷程obs[0].Add(page.CollectionViewSources[0].View.CurrentItem);            
            dataGrid.ScrollIntoView(page.CollectionViewSources[0].View.CurrentItem);
            
            page.目前KeyFldValue = txtkey.Text;
            page.Pkid = txtpkid.Text;            
        }
        private void 歷程導覽()
        {

        }
        private void btn檔首_Click(object sender, RoutedEventArgs e)
        {
            if (rbtn鑑值.IsChecked == true)
            {
                鍵值導覽區指令(導覽區ViewModel.檔首);
            }
            if (rbtn歷程.IsChecked == true)
            {

            }
            
            
        }

        private void btn上一筆_Click(object sender, RoutedEventArgs e)
        {
            鍵值導覽區指令(導覽區ViewModel.上一筆);

        }

        private void btn重新整理_Click(object sender, RoutedEventArgs e)
        {
            鍵值導覽區指令(導覽區ViewModel.重新整理);
        }

        private void btn下一筆_Click(object sender, RoutedEventArgs e)
        {
            鍵值導覽區指令(導覽區ViewModel.下一筆);
        }

        private void btn檔尾_Click(object sender, RoutedEventArgs e)
        {
            鍵值導覽區指令(導覽區ViewModel.檔尾);
        }

        private void txt查詢_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                鍵值導覽區指令(導覽區ViewModel.查詢, 導覽區指令Enum.查詢);
                txt查詢.Text = "";
            }
        }
        public void 查詢()
        {
            txt查詢.Text = txtkey.Text;
            鍵值導覽區指令(導覽區ViewModel.查詢, 導覽區指令Enum.查詢);
            txt查詢.Text = "";
        }
        public void 查詢(string text)
        {
            txt查詢.Text = text;
            鍵值導覽區指令(導覽區ViewModel.查詢, 導覽區指令Enum.查詢);
            txt查詢.Text = "";
        }

        private void rbtn資料歷程_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.DataContext = 歷程cv[0];
        }
    }
}
