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
using System.Data;

namespace DarbWareERP
{
    /// <summary>
    /// 瀏覽頁面.xaml 的互動邏輯
    /// </summary>
    public partial class 瀏覽頁面1 : 頁面繼承
    {
        public 瀏覽頁面1(string title,string browsetype)
        {
            InitializeComponent();
            this.Title = title + Title;
            string 程式名稱 = 表單控制.目前頁面.Title.Replace("瀏覽頁面", "");
            txbl程式名稱.Text = 程式名稱;

            DataRow[] dr = Model.視窗Model.登入暫存表.Tables[0].Select("資料表別名 = '" + 程式名稱 + "'");
            int no = Model.視窗Model.登入暫存表.Tables[0].Rows.IndexOf(dr[0]);
            dg資料顯示.ItemsSource = Model.視窗Model.登入暫存表.Tables[1 + no].DefaultView;

            dr = Model.視窗Model.登入暫存表.Tables[0].Select("資料表別名 = '" + "LCL自訂條件別" + "'");
            no = Model.視窗Model.登入暫存表.Tables[0].Rows.IndexOf(dr[0]);
            DataTable 自訂條件別 = Model.視窗Model.登入暫存表.Tables[1 + no];            
            DataRow[] dr權限= Model.視窗Model.權限表.Select("程式名稱 = '" + 程式名稱 + "'");
            string 編號 = dr權限[0]["序號"].ToString();            
            編號 = 編號.Substring(0, 編號.IndexOf("-")) + 編號.Substring(編號.IndexOf("-")+1) + "B";            
            cbx預設條件.ItemsSource = 自訂條件別.Select("編號 = '" + 編號 + "'");


            dg查詢條件.ItemsSource = dg查詢條件表().DefaultView;
        }
        private DataTable dg查詢條件表()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No");
            dt.Columns.Add("欄位No");
            dt.Columns.Add("欄位說明");
            dt.Columns.Add("運算子編號");
            dt.Columns.Add("運算子說明");
            dt.Columns.Add("初始值(其他條件值)");
            dt.Columns.Add("截止值");
            dt.Columns.Add("欄位");
            dt.Columns.Add("欄位TYPE");
            return dt;
        }
        private void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        {
            

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
    }
}
