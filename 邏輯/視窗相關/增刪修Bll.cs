using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線Dal;

namespace 邏輯Bll.視窗相關
{
    public class 增刪修Bll
    {
        public void 刪除放行碼(string 資料表名稱, int 放行碼)
        {
            string param1 = "";
            string 資料表名稱大寫 = 資料表名稱.ToUpper();
            string 資料表名稱小寫 = 資料表名稱.ToLower();
            Log.Log_Sys_Input("PERMIT-X", 資料表名稱大寫, "Cancel Permit", param1, 資料表名稱小寫, LP_PERMITCODE: 放行碼.ToString());
        }
    }
}
