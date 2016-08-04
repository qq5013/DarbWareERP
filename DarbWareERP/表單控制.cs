using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarbWareERP.繼承窗口;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using DarbWareERP.控制項.下方共同區塊;
using DarbWareERP.控制項;
using System.Windows.Navigation;
using System.Windows.Controls.Primitives;

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
                Grid grid = (Grid)window.FindName("buttonGrid");
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
        public static StatusBar 狀態欄
        {
            get
            {
                Window window = Application.Current.MainWindow;
                StatusBar 狀態欄 = (StatusBar)window.FindName("狀態欄");
                return 狀態欄;
            }
        }
        public static TextBlock 狀態欄文字敘述
        {
            get
            {
                Window window = Application.Current.MainWindow;
                TextBlock 狀態欄 = (TextBlock)window.FindName("狀態欄文字敘述");
                return 狀態欄;
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
        public static 頁面繼承 切換頁面(string nameSpace, string classinfo)
        {            
            NavigationService nav;
            頁面繼承 page;
            nav = NavigationService.GetNavigationService(目前頁面);
            if (表單控制.Page實體列表.Any(x => x.Title == classinfo))
            {
                page = 表單控制.Page實體列表.Find(x => x.Title == classinfo);
            }
            else
            {
                Type CAType = Type.GetType(nameSpace + classinfo);                
                page = (頁面繼承)Activator.CreateInstance(CAType);
                Page實體列表.Add(page);
            }
            表單控制.目前頁面 = page;
            nav.Navigate(page);            
            return page;
        }        
        public static void 切換瀏覽頁面( 瀏覽系列.瀏覽類型Enum 瀏覽類型,string title,string 瀏覽代碼,string[] 資料表名稱)
        {            
            NavigationService nav;
            頁面繼承 page=null;
            nav = NavigationService.GetNavigationService(目前頁面);            
            if (表單控制.Page實體列表.Any(x => x.Title == title+"瀏覽頁面"))
            {
                page = 表單控制.Page實體列表.Find(x => x.Title == title+ "瀏覽頁面");
            }
            else
            {
                if (瀏覽類型== 瀏覽系列.瀏覽類型Enum.AForm)
                {
                    page = new 瀏覽系列.AForm瀏覽頁面(title, 瀏覽代碼, 資料表名稱);
                }                                
                if(瀏覽類型 == 瀏覽系列.瀏覽類型Enum.BForm)
                {
                    page = new 瀏覽系列.BForm瀏覽頁面(title, 瀏覽代碼, 資料表名稱);
                }
                Page實體列表.Add(page);
            }                 
            表單控制.目前頁面 = page;
            nav.Navigate(page);
        }
    }
}
