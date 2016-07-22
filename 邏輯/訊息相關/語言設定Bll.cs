using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 邏輯Bll.訊息相關
{
    public static class 語言設定Bll
    {
        public static 語言版本enum 語言 = 語言版本enum.中文;
        public enum 語言版本enum
        {
            中文=1,
            英文=2
        }
    }
}
