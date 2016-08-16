using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 邏輯Bll;
using 邏輯Bll.登入;

namespace ViewModel
{
    public class 登入ViewModel
    {
        登入Bll 登入Bll;
        public 登入ViewModel()
        {
            登入Bll = new 登入Bll();
        }
        public string 資料庫
        {
            get { return 登入Bll.資料庫; }
        }
        public bool 登入(string 帳號, string 密碼)
        {
            bool result = 登入Bll.登入(帳號, 密碼);
            return result;
        }
    }
}
