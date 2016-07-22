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
using System.Collections.ObjectModel;
using System.Reflection;
using ViewModel;

namespace DarbWareERP.瀏覽系列
{
    /// <summary>
    /// 瀏覽頁面.xaml 的互動邏輯
    /// </summary>
    public partial class 瀏覽頁面 : 頁面繼承
    {
        //ObservableCollection<瀏覽Model> 下方查詢list;
        瀏覽ViewModel 瀏覽viewmodel = null;
        public 瀏覽頁面(string title, string 瀏覽代碼, string[] 資料表名稱)
        {
            InitializeComponent();
            瀏覽viewmodel = new 瀏覽ViewModel(資料表名稱);          
            
            this.Title = title + Title;
            for (int i = 0; i < 資料表名稱.Count(); i++)
            {
                if (資料表名稱[i] != null)
                {
                    this.資料表名稱[i] = 資料表名稱[i];
                }
            }
            瀏覽viewmodel.程式名稱 = 表單控制.目前頁面.Title.Replace("瀏覽頁面", "");
            txbl程式名稱.Text = 瀏覽viewmodel.程式名稱;
            base.瀏覽代碼 = 瀏覽代碼;
            瀏覽viewmodel.cbx預設條件賦值(瀏覽代碼, cbx預設條件);
            瀏覽viewmodel.查詢區域賦值(瀏覽代碼, 0, 欄位Column, 運算子Column);
            //dg查詢條件.DataContext = 瀏覽viewmodel.下方查詢list;
            CollectionViewSources[0] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("browseViewSource0")));
            CollectionViewSources[1] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("browseViewSource1")));
        }

        //private void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        //{

        //}
        private void btn返回_Click(object sender, RoutedEventArgs e)
        {
            表單控制.切換頁面("DarbwarERP.", txbl程式名稱.Text);
        }

        private void cbx預設條件_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int no = ((ComboBox)sender).SelectedIndex;
            txt預設條件說明.Text = 瀏覽viewmodel.條件說明[no];
            瀏覽viewmodel.查詢區域賦值(瀏覽代碼, no, 欄位Column, 運算子Column);
        }
        private void btn查詢_Click(object sender, RoutedEventArgs e)
        {
            //string 查詢條件 = 瀏覽viewmodel.查詢條件產生(下方查詢list);
            //瀏覽ViewModel 瀏覽viewmodel = new 瀏覽ViewModel();
            //DataSet ds = 瀏覽viewmodel.瀏覽查詢(資料表名稱, 查詢條件,CollectionViewSources);         
        }
        private void 運算子SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedItem != null)
            {
                //下方查詢list[dg查詢條件.SelectedIndex].運算子說明 = 瀏覽.運算子編號列表[comboBox.SelectedIndex].運算子說明;
            }
        }
        private void 欄位SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var comboBox = sender as ComboBox;
            //string 欄位type = "";
            //if (comboBox.SelectedItem != null)
            //{
            //    下方查詢list[dg查詢條件.SelectedIndex].欄位說明 = 瀏覽viewmodel.欄位編號列表[comboBox.SelectedIndex].欄位說明;
            //    欄位type = 瀏覽.尋找欄位type(下方查詢list[dg查詢條件.SelectedIndex].欄位說明);
            //    下方查詢list[dg查詢條件.SelectedIndex].欄位TYPE = 欄位type;
            //}
        }

        private void dg資料顯示1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSources[1].View.Filter = delegate (object item)
            {
                int pkid = 12;
                Type itemtype = item.GetType();
                int linkid = Convert.ToInt32(itemtype.GetProperty("linkid").GetValue(item));
                return pkid == linkid;
            };
        }
    }
}
