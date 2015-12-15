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
using 邏輯;


namespace DarbWareERP
{
    /// <summary>
    /// 台銀匯率.xaml 的互動邏輯
    /// </summary>
    public partial class 台銀匯率 : Window
    {
        public 台銀匯率()
        {
            InitializeComponent();
        }

        private void btn抓匯率_Click(object sender, RoutedEventArgs e)
        {
            抓台銀匯率 exchange = new 抓台銀匯率();            
            dataGrid.ItemsSource = exchange.匯率().DefaultView;            
        }
    }
}
