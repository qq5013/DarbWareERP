using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 邏輯Bll.訊息相關
{
    public static class 參數設定Bll
    {
        public static _語言版本 語言 = _語言版本.中文;
        public enum _語言版本
        {
            中文=1,
            英文=2
        }
    }
}
