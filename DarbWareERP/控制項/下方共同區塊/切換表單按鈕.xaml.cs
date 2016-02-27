using DarbWareERP.繼承窗口;
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
    /// 導覽區按鈕.xaml 的互動邏輯
    /// </summary>
    public partial class 切換表單按鈕 : Button
    {
        private string 系統別;
        private 控制項操作 控制項操作 = new 控制項操作();
        public 切換表單按鈕()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {                                   
            if (視窗控制.目前視窗 != this.Content.ToString())
            {
                系統別 = ((TextBlock)((WrapPanel)this.Parent).FindName("txbl系統名稱")).Text;
                if (視窗控制.視窗是否存在(this.Content.ToString()))
                {
                    視窗控制.開啟隱藏的視窗(this.Content.ToString());                    
                }
                else
                {
                    視窗控制.視窗加入(this.Content.ToString(), 打開表單(this.Content.ToString()));                    
                }
                視窗控制.目前視窗 = this.Content.ToString();
                控制項操作.尋找父代<視窗繼承>(this).Hide();
            }
        }
        private 視窗繼承 打開表單(string windowClass)
        {
            Type CAType = Type.GetType("DarbWareERP." + 系統別 + "." + windowClass);
            視窗繼承 window = (視窗繼承)Activator.CreateInstance(CAType);
            window.Show();
            return window;
        }       
    }
}
