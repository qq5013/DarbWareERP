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
        public string 上傳資料(string eventType,string 資料表名稱大寫,string dataFunc,string 資料表名稱小寫,string table2,
            string table3, string table4, string table5, string data1, string data2, string data3, string data4, string data5)
        {
            string result = Log.Log_Sys_Input(eventType, 資料表名稱大寫, dataFunc, "",
                     資料表名稱小寫, table2, table3, table4, table5, data1, data2, data3, data4, data5);
            return result;
        }
    }
}
