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
using DarbWareERP.繼承窗口;
using Model;
using 邏輯.視窗相關;
using 邏輯.視窗相關.B.基本資料;

namespace DarbWareERP.B.基本資料
{
    /// <summary>
    /// 單位轉換表.xaml 的互動邏輯
    /// </summary>
    public partial class 單位轉換表 : 視窗繼承
    {
        控制項操作 控制項操作 = new 控制項操作();
        單位轉換表Bll Bll = new 單位轉換表Bll();
        public 單位轉換表()
        {
            InitializeComponent();
        }

        private void 視窗繼承_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("unitbaViewSource")));
            // 透過設定 CollectionViewSource.Source 屬性載入資料: 
            // unitbaViewSource.Source = [泛用資料來源]
            控制項操作.設定TextboxReadonly(this, true);            
        }
        public override void SetControls()
        {
            base.SetControls();
            txt單位.IsReadOnly = Status == EnumStatus.一般;
            txt小數位數.IsReadOnly = Status == EnumStatus.一般;
            txt說明.IsReadOnly = Status == EnumStatus.一般;
        }
        public override void SetDefaultValue()
        {
            base.SetDefaultValue();
            txtpkid.Text = "";
            txt單位.Text = "+++";
            txt小數位數.Text = "0";
            txt說明.Text = "";
            txt單位.Focus();
        }

        public override bool UpdateData(CollectionViewSource cv)
        {
            return Bll.UpdateData(cv, out this._增刪修訊息);
        }        
    }
}
