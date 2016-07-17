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
using System.Reflection;
using 邏輯.訊息相關;

namespace DarbWareERP.瀏覽系列
{
    /// <summary>
    /// 瀏覽頁面.xaml 的互動邏輯
    /// </summary>
    public partial class 瀏覽頁面 : 頁面繼承
    {

        ObservableCollection<瀏覽下方查詢> 下方查詢list;
        瀏覽 瀏覽 = null;
        public 瀏覽頁面(string title, string 瀏覽代碼, string[] 資料表名稱)
        {
            InitializeComponent();
            瀏覽 = new 瀏覽(資料表名稱);
            下方查詢list = 瀏覽.下方查詢list;
            this.Title = title + Title;
            for (int i = 0; i < 資料表名稱.Count(); i++)
            {
                if (資料表名稱[i] != null)
                {
                    this.資料表名稱[i] = 資料表名稱[i];
                }
            }
            瀏覽.程式名稱 = 表單控制.目前頁面.Title.Replace("瀏覽頁面", "");
            txbl程式名稱.Text = 瀏覽.程式名稱;
            base.瀏覽代碼 = 瀏覽代碼;
            瀏覽.cbx預設條件賦值(瀏覽代碼, cbx預設條件);
            瀏覽.查詢區域賦值(瀏覽代碼, 0, 欄位Column, 運算子Column);
            dg查詢條件.DataContext = 下方查詢list;
            CollectionViewSources[0] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("browseViewSource0")));
            CollectionViewSources[1] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("browseViewSource1")));
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
            txt預設條件說明.Text = 瀏覽.條件說明[no];
            瀏覽.查詢區域賦值(瀏覽代碼, no, 欄位Column, 運算子Column);
        }
        private void btn查詢_Click(object sender, RoutedEventArgs e)
        {
            string 查詢條件 = 瀏覽.查詢條件產生(下方查詢list);
            瀏覽Bll 瀏覽Bll = new 瀏覽Bll();
            DataSet ds = 瀏覽Bll.瀏覽查詢(資料表名稱[0], 查詢條件);
            for (int i = 0; i < this.資料表名稱.Count(); i++)
            {
                Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
                Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType("Model." + this.資料表名稱[i]))
                    .Where(type => type != null)
                    .FirstOrDefault();
                //List<T> list = (List<T>)DataTableToList<T>.ConvertToModel(dt);
                if (trgType == null)
                {
                    break;
                }
                Type generic = typeof(List<>);
                Type constructor = generic.MakeGenericType(trgType);
                dynamic listq = Activator.CreateInstance(constructor);
                Type datatabletolistType = typeof(DataTableToList<>).MakeGenericType(trgType);
                MethodInfo minfo = datatabletolistType.GetMethod("ConvertToModel");
                listq = minfo.Invoke(null, new object[] { ds.Tables[i] });
                CollectionViewSources[i].Source = listq;
                if (i == 1)
                {
                    CollectionViewSources[1].Source = new ObservableCollection<Model.ordetl>(listq);
                }
            }
        }
        private void 運算子SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedItem != null)
            {
                下方查詢list[dg查詢條件.SelectedIndex].運算子說明 = 瀏覽.運算子編號列表[comboBox.SelectedIndex].運算子說明;
            }
        }
        private void 欄位SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string 欄位type = "";
            if (comboBox.SelectedItem != null)
            {
                下方查詢list[dg查詢條件.SelectedIndex].欄位說明 = 瀏覽.欄位編號列表[comboBox.SelectedIndex].欄位說明;
                欄位type = 瀏覽.尋找欄位type(下方查詢list[dg查詢條件.SelectedIndex].欄位說明);
                下方查詢list[dg查詢條件.SelectedIndex].欄位TYPE = 欄位type;
            }
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
