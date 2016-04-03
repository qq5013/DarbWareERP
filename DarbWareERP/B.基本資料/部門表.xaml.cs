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
using Model;
using 邏輯.視窗相關;

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
        }
        protected override void 初始值設定()
        {
            KeyFldValue = "部門代號";
            資料表名稱 = "DEPT";
        }

        private void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("deptViewSource")));
            SetControls();
        }
        public override void SetControls()
        {
            base.SetControls();
            foreach (Control c in grid1.Children)
            {
                if (c is TextBox)
                {
                    (c as TextBox).IsReadOnly = Status == EnumStatus.一般;
                }
            }
        }
        public override void SetDefaultValue()
        {
            base.SetDefaultValue();
        }
        public override bool UpdateData(CollectionViewSource cv, EnumStatus status)
        {
            新增修改刪除<dept> dept = new 新增修改刪除<Model.dept>();
            return dept.UpdateData(cv, out this._增刪修訊息, status);
        }
    }
}
