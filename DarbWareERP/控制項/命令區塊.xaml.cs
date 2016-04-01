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

namespace DarbWareERP.控制項
{
    /// <summary>
    /// 命令區塊.xaml 的互動邏輯
    /// </summary>
    public partial class 命令區塊 : UserControl
    {
        private bool _是否可以離開頁面 = true;
        public  bool 是否可以離開頁面 { get { return _是否可以離開頁面; } set { _是否可以離開頁面 = value; } }
        
        public 命令區塊()
        {
            InitializeComponent();
        }
        private void btn返回上一層_Click(object sender, RoutedEventArgs e)
        {
            if (是否可以離開頁面)
            {
                Window window = Application.Current.MainWindow;
                Frame frame = (Frame)window.FindName("frame");
                頁面繼承 page = (頁面繼承)frame.Content;
                page.切換頁面("DarbWareERP.", 頁面枚舉.選單頁面);
                表單控制.Grid指令區.Visibility = Visibility.Hidden;       
            }
            else
            {
                MessageBox.Show(表單控制.目前編修資料表 + "正在編修中，不得離開。", "提醒", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private T FindParent<T>(DependencyObject i_dp) where T : DependencyObject
        {
            DependencyObject dobj = (DependencyObject)VisualTreeHelper.GetParent(i_dp);
            if (dobj != null)
            {
                if (dobj is T)
                {
                    return (T)dobj;
                }
                else
                {
                    dobj = FindParent<T>(dobj);
                    if (dobj != null && dobj is T)
                    {
                        return (T)dobj;
                    }
                }
            }
            return null;
        }
    }
}
