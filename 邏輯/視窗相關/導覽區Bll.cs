using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線Dal;
using System.Data;
using System.Windows.Data;
using System.Windows;

namespace 邏輯Bll.視窗相關
{    
    public class 導覽區Bll
    {       
        public DataSet 導覽(string  程式名稱, string[] 資料表名稱, string keyfldvalue,string 查詢方式)
        {
            string LP_p1 = 資料表名稱[0].ToUpper();
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC", ref LP_p1, 查詢方式, keyfldvalue);
            return ds;
        }       
    }
}
