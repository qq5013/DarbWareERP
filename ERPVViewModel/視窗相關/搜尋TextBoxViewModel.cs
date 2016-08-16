using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 邏輯Bll.視窗相關;

namespace ViewModel.視窗相關
{
    public class 搜尋TextBoxViewModel
    {
        搜尋TextBoxBll textBoxBll = new 搜尋TextBoxBll();
        public string 搜尋(string dataEvent, string seekField, string seekAlias, string delimiter, string pretext, string seekCode)
        {
            string result = textBoxBll.搜尋(dataEvent, seekField, seekAlias, delimiter, pretext, seekCode);
            return result;
        }
    }
}
