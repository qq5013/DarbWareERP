using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線;
using System.Data;

namespace 邏輯
{
    public class 電子賀卡Bll
    {
        public DataSet 客戶查詢()
        {
            DataSet ds;
            ds=Log.Log_Sys_Exec("CUDATABrowse", "DARB_BROWSE", "CUDATA", "客戶代號 NOT LIKE N'QWERT%'", "2", "0");
            return ds;
        }
    }
}
