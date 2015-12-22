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

namespace DarbWareERP.控制項
{
    /// <summary>
    /// 命令區塊.xaml 的互動邏輯
    /// </summary>
    public partial class 命令區塊 : UserControl
    {
        public 命令區塊()
        {
            InitializeComponent();
        }
        private void btn返回上一層_Click(object sender, RoutedEventArgs e)
        {
            ((Window)((Grid)(this.Parent)).Parent).Close();
            選單 window = new 選單();
            window.Show();
        }
    }
}
