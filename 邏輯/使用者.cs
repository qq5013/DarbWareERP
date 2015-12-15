using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace 邏輯
{
    public static class 使用者
    {
        public static string 使用者代號 { get; set; }
        public static string 使用者名稱 { get; set; }
        public static int LogBookId { get; set; }
        public static DataTable 權限表 { get; set; }
    }
}
