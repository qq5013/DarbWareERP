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

namespace DarbWareERP
{
    /// <summary>
    /// 主視窗.xaml 的互動邏輯
    /// </summary>
    public partial class 主視窗 : Window
    {
        public 主視窗()
        {
            InitializeComponent();            
        }
        protected override void OnClosed(EventArgs e)
        {
            
        }
    }
}
