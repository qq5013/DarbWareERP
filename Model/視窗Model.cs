using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    public class 視窗Model 
    {
        private static bool _是否可以儲存 = true;
        private static bool _是否可以離開頁面 = true;
        private static string _目前編修資料表 = "";
        public static string KeyFldValue { get; set; }
        public static bool 是否可以儲存 { get { return _是否可以儲存; } set { _是否可以儲存 = value; } }
        public static bool 是否可以離開頁面 { get { return _是否可以離開頁面; } set { _是否可以離開頁面 = value; } }
        public static string 目前編修資料表 { get { return _目前編修資料表; } set { _目前編修資料表 = value; } }          
    }
}
