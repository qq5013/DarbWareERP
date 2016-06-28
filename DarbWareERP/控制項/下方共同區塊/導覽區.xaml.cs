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
using 邏輯.視窗相關;

namespace DarbWareERP.控制項.下方共同區塊
{
    /// <summary>
    /// 查詢區.xaml 的互動邏輯
    /// </summary>
    public partial class 導覽區 : UserControl
    {
        導覽區Bll 導覽區bll;
        控制項操作 控制項操作;
        頁面繼承 page;
        CollectionViewSource[] cv;
        TextBox txtkey;
        TextBox txtpkid;

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
            rbtn鑑值.IsChecked = true;
            rbtn瀏覽頁面.IsChecked = true;
            導覽區bll = new 導覽區Bll();
            控制項操作 = new 控制項操作();
            page = 控制項操作.尋找父代<頁面繼承>(this);
        }
        public void 導覽區指令(導覽區指令Delegate callback, 導覽區指令Enum 指令 = 導覽區指令Enum.預設)
        {
            if (txtkey == null)
            {
                txtkey = 控制項操作.用名稱尋找子代<TextBox>(page, "txt" + page.KeyFldValue);
            }
            if (txtpkid == null)
            {
                txtpkid = 控制項操作.用名稱尋找子代<TextBox>(page, "txtpkid");
            }
            if (cv == null)
            {
                cv = page.CollectionViewSources;
            }
            if (指令 == 導覽區指令Enum.查詢)
            {
                page.目前KeyFldValue = txt查詢.Text;
            }
            
            callback(page.Title.ToString(), cv, page.資料表名稱[0].ToUpper(), page.目前KeyFldValue);
            page.目前KeyFldValue = txtkey.Text;
            page.Pkid = txtpkid.Text;
        }
        private void btn檔首_Click(object sender, RoutedEventArgs e)
        {
            導覽區指令(導覽區bll.檔首);
        }

        private void btn上一筆_Click(object sender, RoutedEventArgs e)
        {
            導覽區指令(導覽區bll.上一筆);
        }

        private void btn重新整理_Click(object sender, RoutedEventArgs e)
        {
            導覽區指令(導覽區bll.重新整理);
        }

        private void btn下一筆_Click(object sender, RoutedEventArgs e)
        {
            導覽區指令(導覽區bll.下一筆);
        }

        private void btn檔尾_Click(object sender, RoutedEventArgs e)
        {
            導覽區指令(導覽區bll.檔尾);
        }

        private void txt查詢_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                導覽區指令(導覽區bll.查詢, 導覽區指令Enum.查詢);
                txt查詢.Text = "";
            }
        }
    }
}
