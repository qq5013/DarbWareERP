using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線;
using System.Data;

namespace 邏輯.視窗相關
{
    public class 瀏覽
    {
        public DataSet 瀏覽查詢(string dataevent, string 查詢條件)
        {
            DataSet ds = Log.Log_Sys_Exec(dataevent + "Browse", "DARB_BROWSE", ref dataevent, 查詢條件, "2", "0");
            return ds;
        }
    }
}
