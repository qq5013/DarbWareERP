using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using 數據庫連線;

namespace 邏輯.視窗相關
{
    public class WindowBll
    {
        private static WindowBll windowbll;
        private static DataTable 權限表 = Log.權限表;
        public  string 系統名稱 { get; private set; }
        private WindowBll()
        {

        }
        public static WindowBll GetInstance()
        {
            if (windowbll == null)
            {
                windowbll = new WindowBll();
            }
            權限表 = Log.權限表;
            return windowbll;
        }
        public List<string> 選單按鈕名稱列表()
        {
            List<string> 選單 = new List<string>();
            var qry = (from a in 權限表.AsEnumerable()
                       select a.Field<string>("按鈕名稱")).Distinct();
            foreach (var qq in qry)
            {
                if (!qq.Contains("EE")) //目前系統沒看到的按鈕
                {
                    選單.Add(qq);
                }
            }
            return 選單;
        }
        public List<string> 程式名稱列表(string 系統名) //導覽區的按鈕
        {
            this.系統名稱 = 系統名;
            List<string> 程式名稱列表 = new List<string>();
            var qry = from a in 權限表.AsEnumerable()
                      where a.Field<string>("按鈕名稱") == 系統名稱
                      select a.Field<string>("程式名稱");
            foreach (var qq in qry)
            {
                程式名稱列表.Add(qq);
            }
            return 程式名稱列表;
        }       
    }
}
