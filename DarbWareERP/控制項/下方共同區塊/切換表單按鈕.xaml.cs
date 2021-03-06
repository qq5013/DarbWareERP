﻿using DarbWareERP.繼承窗口;
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

namespace DarbWareERP.控制項.下方共同區塊
{
    /// <summary>
    /// 導覽區按鈕.xaml 的互動邏輯
    /// </summary>
    public partial class 切換表單按鈕 : Button
    {
        private string 系統別;        
        public 切換表單按鈕()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            系統別 = ((TextBlock)((WrapPanel)this.Parent).FindName("txbl系統名稱")).Text;
            表單控制.切換頁面("DarbWareERP." + 系統別 + ".", this.Content.ToString());            
        }       
    }
}
