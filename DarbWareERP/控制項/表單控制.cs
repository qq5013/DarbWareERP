using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarbWareERP.繼承窗口;

namespace DarbWareERP.控制項
{
    static class 表單控制
    {
        public static string 目前視窗 { get; set; }
        private static List<視窗繼承> 視窗列表 = new List<視窗繼承>(); // 存放實體
        private static List<string> 視窗名稱列表 = new List<string>();
        public static bool 視窗是否存在(string 視窗名稱)
        {
            bool 表單是否存在 = false;
            表單是否存在 = 視窗名稱列表.Contains(視窗名稱);
            return 表單是否存在;
        }
        public static void 視窗加入(string 開啟視窗, 視窗繼承 視窗)
        {
            視窗名稱列表.Add(開啟視窗);
            視窗列表.Add(視窗);
        }
        public static void 開啟隱藏的視窗(string 視窗名稱)
        {
            視窗繼承 window = 視窗列表.Find(x => x.Tag.ToString() == 視窗名稱);
            window.Show();
        }
    }
}
