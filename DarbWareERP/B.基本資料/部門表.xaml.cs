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
using System.Data;
using ViewModel.增刪修;
using System.Reflection;

namespace DarbWareERP.B.基本資料
{
    /// <summary>
    /// 部門表.xaml 的互動邏輯
    /// </summary>
    public partial class 部門表 : 頁面繼承
    {
        
        public 部門表()
        {
            InitializeComponent();
            CommandBinding binding = new CommandBinding(ApplicationCommands.ContextMenu);
            binding.Executed += ContextMenu_Executed;
            this.CommandBindings.Add(binding);
        }

        private void ContextMenu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("qq");
        }
        protected override void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        {
            base.頁面繼承_Loaded(sender, e);
            CollectionViewSources[0] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("deptViewModelViewSource")));
            CollectionViewSources[1] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dept_1ViewModelViewSource")));         
            
        }
        public override void 初始值設定()
        {
            base.初始值設定();
            資料表名稱[0] = "dept";
            資料表名稱[1] = "dept_1";
            KeyFldValue = "部門代號";
            瀏覽代碼 = "DPT";
            瀏覽類型 = 瀏覽系列.瀏覽類型Enum.BForm;
        }

        public override void SetControls()
        {
            base.SetControls();
            foreach (Control c in grid1.Children)
            {
                if (c is TextBox)
                {
                    (c as TextBox).IsReadOnly = Status == 增刪修Status.一般;
                }
            }            
            txtpkid.IsReadOnly = true;
            dept_1DataGrid.IsReadOnly = Status == 增刪修Status.一般;
        }
        public override void SetTextBoxOrdetl()
        {
            base.SetTextBoxOrdetl();
            txt部門代號.Focus();
        }      

        private void dept_1DataGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (((DataGrid)sender).IsReadOnly)
            {
                e.Handled = true;
            }
        }

        private void dept_1DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }

        private void dept_1DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {           
        }

    }
}
