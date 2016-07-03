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
using System.Globalization;
using 邏輯.視窗相關;
using 邏輯;
using System.Collections.ObjectModel;

namespace DarbWareERP.瀏覽系列
{
    /// <summary>
    /// 瀏覽頁面.xaml 的互動邏輯
    /// </summary>
    public partial class 瀏覽頁面 : 頁面繼承
    {
        string 程式名稱;
        List<string> 條件編號 = null;
        List<string> 條件說明 = null;
        ObservableCollection<欄位編號列表> 欄位編號列表 = null;
        ObservableCollection<運算子編號列表> 運算子編號列表 = null;
        ObservableCollection<瀏覽下方查詢> 下方查詢list = new ObservableCollection<瀏覽下方查詢>();
        public 瀏覽頁面(string title, string browsetype, string[] 資料表名稱)
        {
            InitializeComponent();
            this.Title = title + Title;
            for (int i = 0; i < 資料表名稱.Count(); i++)
            {
                if (資料表名稱[i] != null)
                {
                    this.資料表名稱[i] = 資料表名稱[i];
                }
            }
            程式名稱 = 表單控制.目前頁面.Title.Replace("瀏覽頁面", "");
            txbl程式名稱.Text = 程式名稱;
            BrowseType = browsetype;
            cbx預設條件賦值(browsetype);
            cbx預設條件.SelectedIndex = 0;

        }

        private void 查詢區域賦值(string browsetype, int no)
        {
            下方查詢list.Clear();
            DataTable 自訂條件欄位 = 查詢LCL所在位置("LCL自訂條件欄位");
            DataTable 運算子 = 查詢LCL所在位置("LCL運算子");
            DataTable 原始 = 查詢LCL所在位置("LCL原始自訂條件");
            if (欄位編號列表 == null && 運算子編號列表 == null)
            {
                欄位編號列表 = new ObservableCollection<瀏覽系列.欄位編號列表>(DataTableToList<欄位編號列表>.ConvertToModel(自訂條件欄位.Select("瀏覽類別 = '" + browsetype + "'").CopyToDataTable()));
                運算子編號列表 = new ObservableCollection<瀏覽系列.運算子編號列表>(DataTableToList<運算子編號列表>.ConvertToModel(運算子));
                欄位Column.ItemsSource = 欄位編號列表;
                運算子Column.ItemsSource = 運算子編號列表;
                //ItemSource只能設定一次不然會前面的筆數會出錯
            }
            if (條件編號 != null)
            {
                DataRow[] 原始編號 = 原始.Select("編號 = '" + 條件編號[no] + "'");
                for (int i = 0; i < 原始編號.Count(); i++)
                {

                    DataRow[] rows自訂條件欄位 = 自訂條件欄位.Select("瀏覽類別 = '" + browsetype + "' and 欄位編號 = '" + 原始編號[i]["欄位編號"] + "'");
                    string 欄位說明 = rows自訂條件欄位.FirstOrDefault()["欄位說明"].ToString();
                    DataRow[] rows運算子 = 運算子.Select("運算子編號 = '" + 原始編號[i]["運算子編號"] + "'");
                    string 運算子說明 = rows運算子.FirstOrDefault()["運算子說明"].ToString();

                    瀏覽下方查詢 browse = new 瀏覽下方查詢();
                    browse.序號 = 原始編號[i]["序號"].ToString();
                    browse.欄位編號 = 原始編號[i]["欄位編號"].ToString();
                    browse.欄位說明 = 欄位說明;
                    browse.運算子編號 = 原始編號[i]["運算子編號"].ToString();
                    browse.運算子說明 = 運算子說明;
                    browse.起始值 = 原始編號[i]["值1"].ToString();
                    browse.截止值 = 原始編號[i]["值2"].ToString();
                    browse.欄位編號列表 = 欄位編號列表;
                    browse.運算子編號列表 = 運算子編號列表;
                    下方查詢list.Add(browse);                    
                }
            }        
            dg查詢條件.DataContext = 下方查詢list;
        }


        private void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        {


        }
        private void btn返回_Click(object sender, RoutedEventArgs e)
        {
            表單控制.切換頁面("DarbwarERP.", txbl程式名稱.Text);
        }

        private void cbx預設條件_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            int no = ((ComboBox)sender).SelectedIndex;
            txt預設條件說明.Text = 條件說明[no];
            查詢區域賦值(BrowseType, no);
        }

        private void btn查詢_Click(object sender, RoutedEventArgs e)
        {
            string 查詢條件 = 查詢條件產生(下方查詢list);
            瀏覽 瀏覽 = new 瀏覽();
            DataSet ds = 瀏覽.瀏覽查詢(資料表名稱[0], 查詢條件);
            ds.Relations.Add("relation", ds.Tables[0].Columns["pkid"], ds.Tables[1].Columns["linkid"]);
            //this.DataContext = ds;
            dg資料顯示1.ItemsSource = ds.Tables[0].DefaultView;
        }
        private string 查詢條件產生(ObservableCollection<瀏覽下方查詢> searchlist)
        {
            StringBuilder 查詢條件 = new StringBuilder();
            foreach (var search in searchlist)
            {
                switch (search.運算子編號)
                {
                    case "C":
                        查詢條件.Append(search.欄位說明 + " not like " + "'" + search.起始值 + "'");
                        break;
                }
            }

            return 查詢條件.ToString();
        }
        private DataTable 查詢LCL所在位置(string 查詢字串)
        {
            DataTable dt;
            DataRow[] dr = Model.視窗Model.登入暫存表.Tables[0].Select("資料表別名 = '" + 查詢字串 + "'");
            int no = Model.視窗Model.登入暫存表.Tables[0].Rows.IndexOf(dr[0]);
            dt = Model.視窗Model.登入暫存表.Tables[1 + no];
            return dt;

        }
        private void cbx預設條件賦值(string browsetype)
        {
            DataTable 自訂條件別 = 查詢LCL所在位置("LCL自訂條件別");
            if (browsetype == "")
            {
                DataRow[] dr權限 = Model.視窗Model.權限表.Select("程式名稱 = '" + 程式名稱 + "'");
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
                cbx預設條件.DataContext = 條件編號;               
            }
        }
        private void 運算子SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedItem != null)
            {
                //List<運算子編號列表> source = (List<運算子編號列表>)comboBox.ItemsSource;
                下方查詢list[dg查詢條件.SelectedIndex].運算子說明 = 運算子編號列表[comboBox.SelectedIndex].運算子說明;
            }
        }
        private void 欄位SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedItem != null)
            {
                下方查詢list[dg查詢條件.SelectedIndex].欄位說明 = 欄位編號列表[comboBox.SelectedIndex].欄位說明; 
                //List<欄位編號列表> source = (List<欄位編號列表>)comboBox.ItemsSource;
                //下方查詢list[dg查詢條件.SelectedIndex].欄位說明 = source[comboBox.SelectedIndex].欄位說明;
            }
        }  
    }
}
