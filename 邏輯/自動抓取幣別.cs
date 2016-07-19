using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線Dal;

namespace 邏輯Bll
{
    public class 自動抓取幣別
    {
        public DataSet Sql幣別表()
        {
            string lp_p1 = "BCURREN";
            DataSet ds = Log.Log_Sys_Exec("BCURRENBrowse", "DARB_BROWSE", ref lp_p1, "序號 <> 0", "2", "0");
            return ds;
        }
        public string 上傳幣別表(string 幣別主檔,string 幣別明細)
        {
           string result =  Log.Log_Sys_Input("INPUT-BB", "BCURRENM", "Normal Add", "", "bcurrenm", "bcurrend", LP_DATA1: 幣別主檔, LP_DATA2: 幣別明細);
            return result;
        }
    }
}
