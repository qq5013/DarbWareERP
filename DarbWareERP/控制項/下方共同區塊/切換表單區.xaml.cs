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
using 邏輯.視窗相關;

namespace DarbWareERP.控制項.下方共同區塊
{
    /// <summary>
    /// B_基本資料.xaml 的互動邏輯
    /// </summary>
    public partial class 切換表單區 : UserControl
    {
        public 切換表單區()
        {
            InitializeComponent();
        }
        public void 按鈕賦值()
        {
            txbl系統名稱.Text = WindowBll.GetInstance().系統名稱;
            List<string> 按鈕列表 = WindowBll.GetInstance().程式名稱列表(txbl系統名稱.Text);
            int 按鈕數 = VisualTreeHelper.GetChildrenCount(WrapPanel);
            for (int i = 0; i < 按鈕數; i++)
            {
                Button btn = (Button)VisualTreeHelper.GetChild(WrapPanel, i);
                if (i < 按鈕列表.Count)
                {
                    btn.Content = 按鈕列表[i];      
                    btn.Name = "btn"+ 按鈕列表[i];
                }
                else
                {
                    btn.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
