﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線Dal;
using System.Data;

namespace 邏輯Bll.視窗相關
{
    public class 瀏覽Bll
    {
        public DataSet 瀏覽查詢(string dataevent, string 查詢條件)
        {
            DataSet ds = Log.Log_Sys_Exec(dataevent + "Browse", "DARB_BROWSE", ref dataevent, 查詢條件, "2", "0");
            return ds;
        }
    }
}
