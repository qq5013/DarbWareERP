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
using ViewModel;

namespace DarbWareERP.B.基本資料
{
    /// <summary>
    /// 單位轉換表.xaml 的互動邏輯
    /// </summary>
    public partial class 單位轉換表 : 繼承窗口.頁面繼承
    {        
        public 單位轉換表()
        {
            InitializeComponent();            
        }
        public override void 初始值設定()
        {
            base.初始值設定();
            KeyFldValue = "單位";
            資料表名稱[0] = "unitba";            
        }
       
        protected override void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        {
            base.頁面繼承_Loaded(sender, e);
            CollectionViewSources[0] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("unitbaViewModelViewSource")));
        }
        public override void SetControls()
        {
            base.SetControls();
            txt單位.IsReadOnly = Status == 增刪修Status.一般;
            txt小數位數.IsReadOnly = Status == 增刪修Status.一般;
            txt說明.IsReadOnly = Status == 增刪修Status.一般;
        }
        public override void SetTextBoxOrdetl()
        {            
            txt單位.Focus();
        }
        
    }
}
