using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線Dal;
using 邏輯Bll.視窗相關;

namespace 邏輯Bll
{
    public class 登入Bll
    {
        public string 資料庫
        {
            get
            {
                return Log.資料庫;
            }
        }
        public bool 登入(string 帳號, string 密碼,ref DataSet 登入暫存表,ref DataTable 權限表)
        {
            int logbookid = 0;
            bool 可以登入 = false;
            try
            {
                Log.Log_LogOn(帳號, 密碼, out logbookid);
            }
            catch (Exception EX)
            {
                throw EX;
            }
            Log.LogBookId = logbookid;
            Log.使用者代號 = 帳號;
            if (Log.LogBookId > 0)
            {
                Log.使用者名稱 = Log.權限表.Rows[0]["使用者姓名"].ToString().Trim();
                可以登入 = true;
                string param1 = "VCLST";
                登入暫存表 = Log.Log_Sys_Exec("MENUSECR.SCX", "DARB_OPEN_DBF", ref param1, "0", "C");
                權限表 = Log.權限表;
            }
            return 可以登入;
        }
    }
}
