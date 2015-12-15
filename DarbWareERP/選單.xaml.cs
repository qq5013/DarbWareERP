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

namespace DarbWareERP
{
    /// <summary>
    /// 選單.xaml 的互動邏輯
    /// </summary>
    public partial class 選單 : Window
    {
        public 選單()
        {
            InitializeComponent();
        }

        private void btn電子賀卡_Click(object sender, RoutedEventArgs e)
        {
            電子賀卡 f = new 電子賀卡();
            f.Show();
            this.Close();
        }

        private void btn台銀匯率_Click(object sender, RoutedEventArgs e)
        {
            台銀匯率 f = new 台銀匯率();
            f.Show();
            this.Close();
        }
    }
}
