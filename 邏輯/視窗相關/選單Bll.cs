using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using 數據庫連線Dal;

namespace 邏輯Bll.視窗相關
{
    public class 選單Bll
    {
        public static DataTable 權限表 { get { return Log.權限表; } }
    }
}
