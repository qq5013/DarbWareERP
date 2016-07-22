using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class 使用者ViewModel
    {
        private static 使用者ViewModel 使用者;
        private 使用者ViewModel()
        {

        }
        public static 使用者ViewModel GetInstance()
        {
            if (使用者 == null)
            {
                使用者 = new 使用者ViewModel();
            }
            return 使用者;
        }
        public DataTable 權限表 { get; set; }
        public DataSet 登入暫存表 { get; set; }
    }
}
