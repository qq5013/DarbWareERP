using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線Dal;

namespace 邏輯Bll.視窗相關
{
    public class 搜尋TextBoxBll
    {
        public string 搜尋(string dataEvent,string seekField,string seekAlias,string delimiter,string pretext,string seekCode)
        {
            Log.Log_Sys_Exec(dataEvent, "DARB_SEEKGEN", ref seekField, seekAlias, delimiter, pretext, seekCode);
            return seekField;
        }
    }
}
