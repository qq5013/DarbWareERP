using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using 數據庫連線Dal;

namespace 邏輯Bll.M.主管資訊
{
    public class 主管資訊查詢
    {
        public static DataSet 客戶資料訂單查詢(string 查詢條件, string 查詢欄位)
        {
            string param1 = "vw_ormast a inner join vw_ordetl b on a.pkid=b.linkid";
            DataSet ds = Log.Log_Sys_Exec("客戶資料查詢---訂單", "DARB_GETDATA4", ref param1, 查詢條件, 查詢欄位);
            return ds;
        }
        public static DataSet 客戶資料出貨查詢(string 查詢條件, string 查詢欄位)
        {
            string param1 = "vw_trsama x inner join trsade y on x.pkid=y.linkid";
            DataSet ds = Log.Log_Sys_Exec("客戶資料查詢---出貨", "DARB_GETDATA4", ref param1, 查詢條件, 查詢欄位);
            return ds;
        }
    }
}
