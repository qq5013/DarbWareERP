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
using ViewModel.增刪修;

namespace DarbWareERP.Z.特殊
{
    /// <summary>
    /// unicodetb.xaml 的互動邏輯
    /// </summary>
    public partial class unicodetb : 頁面繼承
    {
        public unicodetb()
        {
            InitializeComponent();
        }
        protected override void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        {
            base.頁面繼承_Loaded(sender, e);
            CollectionViewSources[0] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("unitcodetbViewModelViewSource")));
        }
        public override void 初始值設定()
        {
            base.初始值設定();
            資料表名稱[0] = "unicodetb";
            KeyFldValue = "代號";
        }
        public override void SetControls()
        {
            base.SetControls();
            txt代號.IsReadOnly = Status == 增刪修Status.一般;
            txt簡稱.IsReadOnly = Status == 增刪修Status.一般;
            cbo類別.IsEnabled = Status != 增刪修Status.一般;
        }
        public override void SetTextBoxOrdetl()
        {
            base.SetTextBoxOrdetl();
            txt代號.Focus();
        }
    }
}
