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
        public 命令區塊()
        {
            InitializeComponent();
        }
        private void btn返回上一層_Click(object sender, RoutedEventArgs e)
        {
            if (Model.視窗Model.是否可以離開頁面)
            {
                選單 window = new 選單();
                window.Show();
                視窗繼承 w = null;
                w = FindParent<視窗繼承>(this);
                w.CloseWindow();
                表單控制.視窗列表清空();
            }
            else
            {
                MessageBox.Show(Model.視窗Model.目前編修資料表 + "正在編修中，不得離開。","提醒",MessageBoxButton.OK,MessageBoxImage.Exclamation);
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
