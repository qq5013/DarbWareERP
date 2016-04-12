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
    public partial class 瀏覽頁面2 : 頁面繼承
    {
        string 程式名稱;
        List<string> 條件編號 = null;
        List<string> 條件說明 = null;
        public 瀏覽頁面2(string title, string browsetype)
        {
            InitializeComponent();
            this.Title = title + Title;
            程式名稱 = 表單控制.目前頁面.Title.Replace("瀏覽頁面", "");
            txbl程式名稱.Text = 程式名稱;
            dg資料顯示();

            DataRow[] dr = Model.視窗Model.登入暫存表.Tables[0].Select("資料表別名 = '" + "LCL自訂條件別" + "'");
            int no = Model.視窗Model.登入暫存表.Tables[0].Rows.IndexOf(dr[0]);
            DataTable 自訂條件別 = Model.視窗Model.登入暫存表.Tables[1 + no];
            DataRow[] dr權限 = Model.視窗Model.權限表.Select("程式名稱 = '" + 程式名稱 + "'");
            if (browsetype == "")
            {
                string 編號 = dr權限[0]["序號"].ToString();
                編號 = 編號.Substring(0, 編號.IndexOf("-")) + 編號.Substring(編號.IndexOf("-") + 1) + "B";
                cbx預設條件.ItemsSource = 自訂條件別.Select("編號 LIKE '%" + 編號 + "%'");
            }
            else
            {
                DataRow[] drs = 自訂條件別.Select("編號 LIKE '%" + browsetype + "%'");
                條件編號 = new List<string>();
                條件說明 = new List<string>();
                foreach (DataRow row in drs)
                {
                    條件編號.Add(row["編號"].ToString());
                    條件說明.Add(row["類別"].ToString());
                }
                cbx預設條件.ItemsSource = 條件編號;
                cbx預設條件.SelectedIndex = 0;
                txt預設條件說明.Text = 條件說明[0];
            }
            dr = Model.視窗Model.登入暫存表.Tables[0].Select("資料表別名 = '" + "LCL自訂條件欄位" + "'");
            no = Model.視窗Model.登入暫存表.Tables[0].Rows.IndexOf(dr[0]);
            DataTable 自訂條件欄位 = Model.視窗Model.登入暫存表.Tables[1 + no];
            dr = Model.視窗Model.登入暫存表.Tables[0].Select("資料表別名 = '" + "LCL原始自訂條件" + "'");
            no = Model.視窗Model.登入暫存表.Tables[0].Rows.IndexOf(dr[0]);
            DataTable 原始 = Model.視窗Model.登入暫存表.Tables[1 + no];
            dr = Model.視窗Model.登入暫存表.Tables[0].Select("資料表別名 = '" + "LCL運算子" + "'");
            no = Model.視窗Model.登入暫存表.Tables[0].Rows.IndexOf(dr[0]);
            DataTable 運算子 = Model.視窗Model.登入暫存表.Tables[1 + no];

            DataRow[] 原始編號 = 原始.Select("編號 = '" + 條件編號[0] + "'");
            DataRow[] rows自訂條件欄位 = 自訂條件欄位.Select("瀏覽類別 = '" + browsetype + "' and 欄位編號 = '" + 原始編號[0]["欄位編號"] + "'");
            DataRow[] rows運算子 = 運算子.Select("運算子編號 = '" + 原始編號[0]["運算子編號"] + "'");
            DataRow[] QQ = 運算子.Select("運算子編號 = '" + 原始編號[0]["運算子編號"] + "'");
            int mo = 運算子.Rows.IndexOf(QQ[0]);

            DataTable 查詢條件表 = dg查詢條件表();

            DataRow 條件 = 查詢條件表.NewRow();
            條件["No"] = 原始編號[0]["序號"];
            條件["欄位No"] = 原始編號[0]["欄位編號"];
            條件["欄位說明"] = rows自訂條件欄位[0]["欄位說明"];
            條件["運算子編號"] = 原始編號[0]["運算子編號"];
            //條件["運算子說明"] = rows運算子[0]["運算子說明"];
            條件["起始值"] = 原始編號[0]["值1"];
            條件["截止值"] = 原始編號[0]["值2"];
            條件["欄位"] = rows自訂條件欄位[0]["欄位"];
            條件["欄位TYPE"] = 原始編號[0]["序號"];
            查詢條件表.Rows.Add(條件);

            欄位Column.ItemsSource = rows自訂條件欄位;
            運算子Column.ItemsSource = 運算子.DefaultView;            
            dg查詢條件.ItemsSource = 查詢條件表.DefaultView;

        }
        
        private void dg資料顯示()
        {
            DataRow[] dr = Model.視窗Model.登入暫存表.Tables[0].Select("資料表別名 like '%" + 程式名稱 + "%'");
            int no = Model.視窗Model.登入暫存表.Tables[0].Rows.IndexOf(dr[0]);
            dg資料顯示1.ItemsSource = Model.視窗Model.登入暫存表.Tables[1 + no].DefaultView;
            int no2 = Model.視窗Model.登入暫存表.Tables[0].Rows.IndexOf(dr[1]);
            dg資料顯示2.ItemsSource = Model.視窗Model.登入暫存表.Tables[1 + no2].DefaultView;
        }
        private DataTable dg查詢條件表()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No");
            dt.Columns.Add("欄位No");
            dt.Columns.Add("欄位說明");
            dt.Columns.Add("運算子編號");
            dt.Columns.Add("運算子說明");
            dt.Columns.Add("起始值");
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

        private void cbx預設條件_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int no = ((ComboBox)sender).SelectedIndex;
            txt預設條件說明.Text = 條件說明[no];
        }
    }
}
