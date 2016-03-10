using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarbWareERP.繼承窗口;
using Model;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace DarbWareERP.控制項
{
    public enum 按鈕顏色
    {
        預設的顏色,增刪修的顏色
    }
    static class 表單控制
    {        
        private static 視窗繼承 _目前視窗實體;
        public static Brush 預設的顏色
        {
            get
            {
                Brush brush = (Brush)Application.Current.FindResource("ButtonFontColor");  
                return brush;
            }
        }
        public static Brush 增刪修的顏色 { get { return new SolidColorBrush(Colors.Red); } }
        public static string 目前視窗 { get; set; }
        public static 視窗繼承 目前視窗實體
        {
            get { return _目前視窗實體; }
            set
            {
                _目前視窗實體 = value;
                Model.視窗Model.KeyFldValue = _目前視窗實體.KeyFldValue;
            }
        }
        private static List<視窗繼承> 視窗列表 = new List<視窗繼承>(); // 存放實體
        private static List<string> 視窗名稱列表 = new List<string>();
        public static void 視窗新增儲存顏色修改(string 表單按鈕名稱,按鈕顏色 顏色)
        {
            控制項操作 控制項操作 = new 控制項操作();
            foreach (視窗繼承 w in 視窗列表)
            {
                Button btn = 控制項操作.用名稱尋找子代<Button>(w, 表單按鈕名稱);                                 
                switch (顏色)
                {
                    case 按鈕顏色.預設的顏色:
                        btn.Foreground = 預設的顏色;
                        break;
                    case 按鈕顏色.增刪修的顏色:
                        btn.Foreground = 增刪修的顏色;
                        break;
                }
            }
        }
        public  static void 視窗列表清空()
        {
            視窗列表.Clear();
            視窗名稱列表.Clear();
        }

        public static bool 視窗是否存在(string 視窗名稱)
        {
            bool 表單是否存在 = false;
            表單是否存在 = 視窗名稱列表.Contains(視窗名稱);
            return 表單是否存在;
        }
        public static void 視窗加入(string 開啟視窗, 視窗繼承 視窗)
        {
            視窗名稱列表.Add(開啟視窗);
            視窗列表.Add(視窗);
            目前視窗實體 = 視窗;
        }
        public static void 開啟隱藏的視窗(string 視窗名稱)
        {
            視窗繼承 window = 視窗列表.Find(x => x.Tag.ToString() == 視窗名稱);
            window.Show();
            目前視窗實體 = window;
        }
    }
}
