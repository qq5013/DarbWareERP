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
using DarbWareERP.繼承窗口;
using System.ComponentModel;
using ViewModel;
using ViewModel.訊息相關;

namespace DarbWareERP
{
    /// <summary>
    /// 登入頁面.xaml 的互動邏輯
    /// </summary>
    public partial class 登入頁面 : 頁面繼承
    {
        登入ViewModel 登入viewmodel;
        BackgroundWorker backgroundWorker;
        public 登入頁面()
        {
            InitializeComponent();
            表單控制.目前頁面 = this;
            登入viewmodel = new 登入ViewModel();
            txt帳號.Focus();
            label4.Content = 登入viewmodel.資料庫;
            backgroundWorker = (BackgroundWorker)this.FindResource("backgroundWorker");            
        }

        private void btn離開_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn登入_Click(object sender, RoutedEventArgs e)
        {
            btn登入.IsEnabled = false;
            btn離開.IsEnabled = false;
            string[] argument = new string[2];
            argument[0] = txt帳號.Text;
            argument[1] = pwd密碼.Password;
            backgroundWorker.RunWorkerAsync(argument);
        }
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] argument = (string[])e.Argument;
            try
            {                
                e.Result = 登入viewmodel.登入(argument[0], argument[1]);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result == true)
            {
                表單控制.切換頁面("DarbWareERP.", "選單頁面");
            }
            else
            {
                錯誤訊息ViewModel.錯誤訊息顯示(0);
                pwd密碼.Password = "";
            }
            btn登入.IsEnabled = true;
            btn離開.IsEnabled = true;
        }
        
        private void txt帳號_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                UIElement element = Keyboard.FocusedElement as UIElement;
                element.MoveFocus(request);
            }
        }

        private void pwd密碼_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                UIElement element = Keyboard.FocusedElement as UIElement;
                element.MoveFocus(request);
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>()
            {
               "中文","English"
            };
            comboBox.DataContext = Enum.GetValues(typeof(語言.語言));
            comboBox.SelectedIndex = 0;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            語言.語言 language = (語言.語言)comboBox.SelectedIndex;
            語言.語言幫手.SwitchLanquage(language);           
        }
    }
}
