﻿using System;
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
using 邏輯.視窗相關.B.基本資料;
using System.Data;

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
            資料表名稱[0] = "dept";
            資料表名稱[1] = "dept_1";
        }

        private void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSources[0] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("deptViewSource")));
            CollectionViewSources[1] = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dept_1ViewSource")));
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
            txtpkid.IsReadOnly = true;
        }
        public override void SetDefaultValue()
        {
            base.SetDefaultValue();
            foreach (Control c in grid1.Children)
            {
                if (c is TextBox)
                {
                    c.Focus();
                    ((TextBox)c).Text = "";
                }
            }
            DataView dt = (DataView)this.CollectionViewSources[1].View.SourceCollection;
            dt[0].Row["序號"] = "001";            
            dt[0].Row["人員別"] = 0;
            dt[0].Row["員工編號"] = "";
            dt[0].Row["姓名"] = "";
            dt[0].Row["備註"] = "";
            txtpkid.Text = "";
            txtpkid.Focus();
            要員人數TextBox.Text = "0";
            要員人數TextBox.Focus();
            txt部門代號.Focus();

        }
        public override bool UpdateData(CollectionViewSource[] cv, EnumStatus status)
        {
            部門表Bll dept = new 部門表Bll();
            return dept.UpdateData(cv, out this._增刪修訊息, status);
        }
    }
}
