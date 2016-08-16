﻿using System;
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
    /// 搜尋TextBox.xaml 的互動邏輯
    /// </summary>
    public partial class 搜尋TextBox : TextBox
    {
        public 搜尋TextBox()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.ImeProcessedKey == Key.OemOpenBrackets || e.Key == Key.OemOpenBrackets)
            {
                搜尋頁面 window = new 搜尋頁面();
                window.ShowDialog();
                if (window.DialogResult == true)
                {
                    
                }
            }
        }
    }
}
