using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 邏輯Bll;

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
            DataSet 登入暫存表 = null;
            DataTable 權限表 = null;
            bool result = 登入Bll.登入(帳號, 密碼, ref 登入暫存表,ref 權限表);
            使用者ViewModel.GetInstance().登入暫存表 = 登入暫存表;
            使用者ViewModel.GetInstance().權限表 = 權限表;
            return result;
        }
    }
}
