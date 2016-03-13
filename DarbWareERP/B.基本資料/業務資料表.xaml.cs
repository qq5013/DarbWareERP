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
using System.Windows.Shapes;
using System.Data;
using DarbWareERP.繼承窗口;
using Model;
using 邏輯.視窗相關.B.基本資料;

namespace DarbWareERP.B.基本資料
{
    /// <summary>
    /// 業務資料表.xaml 的互動邏輯
    /// </summary>
    public partial class 業務資料表 : 視窗繼承
    {
        private 業務資料表Bll 業務資料表Bll = new 業務資料表Bll();
        public 業務資料表()
        {
            InitializeComponent();                       
        }

        private void 視窗繼承_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource  = ((System.Windows.Data.CollectionViewSource)(this.FindResource("salesmenViewSource")));           
            SetControls();
        }
        public override void SetControls()
        {
            base.SetControls();            
            txt到職日期.IsReadOnly = Status == EnumStatus.一般;
            txt姓名.IsReadOnly = Status == EnumStatus.一般;
            txt業務員編號.IsReadOnly = Status == EnumStatus.一般;
            txt部門代號.IsReadOnly = Status == EnumStatus.一般;
            txt離職日期.IsReadOnly = Status == EnumStatus.一般;
        }
        public override void SetDefaultValue()
        {
            base.SetDefaultValue();
            txtpkid.Text = "";
            txt到職日期.Text = "";
            txt姓名.Text = "";
            txt業務員編號.Text = "+++";
            txt部門代號.Text = "";
            txt離職日期.Text = "";
            txt業務員編號.Focus();
        }

        public override bool UpdateData(CollectionViewSource cv)
        {
            return 業務資料表Bll.UpdateData(cv, out this._增刪修訊息);
        }
    }
}
