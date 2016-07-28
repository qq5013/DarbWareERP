using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線Dal;

namespace 邏輯Bll.登入
{
    public class 使用者Bll
    {
        private static 使用者Bll 使用者;
        private 使用者Bll()
        {

        }
        public static 使用者Bll GetInstance()
        {
            if (使用者 == null)
            {
                使用者 = new 使用者Bll();
            }
            return 使用者;
        }
        public DataTable 權限表 { get; set; }
        public DataSet 登入暫存表 { get; set; }
        public string 使用者名稱 { get; set; }
        public int Srvdbid { get { return Log.Srvdbid; } }
    }
}
