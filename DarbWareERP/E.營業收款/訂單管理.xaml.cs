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

namespace DarbWareERP.E.營業收款
{
    /// <summary>
    /// 訂單管理.xaml 的互動邏輯
    /// </summary>
    public partial class 訂單管理 : 頁面繼承
    {
        public 訂單管理()
        {
            InitializeComponent();
        }
        public override void 初始值設定()
        {
            base.初始值設定();
            KeyFldValue = "訂單編號";
            資料表名稱[0] = "ormast";
            資料表名稱[1] = "ordetl";
            瀏覽代碼 = "E05B";
        }
    }
}
