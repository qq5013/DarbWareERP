using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using 數據庫連線Dal;
using System.Data;
using System.Windows;
using 邏輯Bll.視窗相關;
using 邏輯Bll.登入;

namespace 邏輯Bll.資料驗證
{
    public class 主索引驗證Bll
    {        
        public void 主索引檢查( ref string returnValue, string value, string table, string chkField, string addedit, string pkid)
        {
            int Srvdbid = 使用者Bll.GetInstance().Srvdbid;
            var qry = from a in 使用者Bll.GetInstance().權限表.AsEnumerable()
                      where a.Field<string>("類別名稱") == table.ToUpper()
                      select a.Field<string>("程式名稱");
            string dataEvent = qry.FirstOrDefault();
            Log.Log_Sys_Exec(dataEvent+".單位", "DARB_CHKDBL", ref returnValue, value, table, chkField, addedit, Srvdbid.ToString(), pkid);
        }
    }
}
