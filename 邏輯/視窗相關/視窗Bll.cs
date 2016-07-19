using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace 邏輯Bll.視窗相關
{
    public class 視窗Bll
    {                             
        public static bool 是否可以儲存 { get { return _是否可以儲存; } set { _是否可以儲存 = value; } }
        private static bool _是否可以儲存 = true;
        public static string KeyFldValue { get; set; }
        public static string 目前KeyFldValue { get; set; }
        public static string[] 資料表名稱 { get; set; }
        public static int 放行碼 { get; set; }
        public static DataSet 登入暫存表 { get; set; }
        public static DataTable 權限表 { get; set; }
    }
}
