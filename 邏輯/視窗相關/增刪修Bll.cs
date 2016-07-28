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
        public string 取得放行碼(string 資料表名稱, string 上傳資料)
        {
            string 資料表名稱大寫 = 資料表名稱.ToUpper();
            string 資料表名稱小寫 = 資料表名稱.ToLower();
            string param1 = "N"; //將來要加入檢查工作流程     
            string result = Log.Log_Sys_Input("PERMIT-1", 資料表名稱大寫, "Normal Permit", param1, 資料表名稱小寫, LP_DATA1: 上傳資料);
            return result;
        }
        public string 上傳資料(string eventType, string 資料表名稱大寫, string dataFunc, string 資料表名稱小寫, string table2,
            string table3, string table4, string table5, string data1, string data2, string data3, string data4, string data5, string permitcode)
        {
            string result = Log.Log_Sys_Input(eventType, 資料表名稱大寫, dataFunc, "",
                     資料表名稱小寫, table2, table3, table4, table5, data1, data2, data3, data4, data5, permitcode);
            return result;
        }
        public string 刪除(string 資料表名稱,string 要刪除資料,string permitcode)
        {
            string dataevent = 資料表名稱.ToUpper();
            string 資料表名稱小寫 = 資料表名稱.ToLower();
            string result = Log.Log_Sys_Input("INPUT-BD", dataevent, "Normal Delete", "",　資料表名稱小寫, LP_DATA1: 要刪除資料, LP_PERMITCODE:permitcode);
            return result;
        }

    }
}
