﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarbWareERP.繼承窗口;
using Model;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using DarbWareERP.控制項.下方共同區塊;
using DarbWareERP.控制項;

namespace DarbWareERP
{
    public enum 按鈕顏色
    {
        預設的顏色, 增刪修的顏色
    }
    static class 表單控制
    {
        //private static 頁面繼承 _目前Page實體;
        public static Grid Grid指令區
        {
            get
            {
                Window window = Application.Current.MainWindow;
                Grid grid= (Grid)window.FindName("buttonGrid");
                return grid;
            }
        }
        public static 切換表單區 切換表單區實體
        {
            get
            {
                Window window = Application.Current.MainWindow;
                切換表單區 切換表單區 = (切換表單區)window.FindName("切換表單區");
                return 切換表單區;
            }
        }
        public static 命令區塊 命令區塊實體
        {
            get
            {
                Window window = Application.Current.MainWindow;
                命令區塊 命令區塊實體 = (命令區塊)window.FindName("命令區塊");
                return 命令區塊實體;
            }
        }
        public static Brush 預設的顏色
        {
            get
            {
                Brush brush = (Brush)Application.Current.FindResource("ButtonFontColor");
                return brush;
            }
        }
        public static Brush 增刪修的顏色 { get { return new SolidColorBrush(Colors.Red); } }
        public static 頁面繼承 目前頁面 { get; set; }        

        private static List<頁面繼承> _Page實體列表 = new List<頁面繼承>();       
        public static List<頁面繼承> Page實體列表 { get { return _Page實體列表; } set { _Page實體列表 = value; } }
        public static string 目前編修資料表 { get { return _目前編修資料表; } set { _目前編修資料表 = value; } }
        private static string _目前編修資料表 = "";
        
    }
}
