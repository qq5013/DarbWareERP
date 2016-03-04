using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using 數據庫連線;

namespace 邏輯.資料驗證
{
    public class 主索引驗證:ValidationRule
    {
        public string ControlSource { get; set; }
        private string returnValue;
        string validData;
        string existTable;
        string chkField;
        string addedit;
        string srvbid;
        string pkid;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                Log.Log_Sys_Exec(ControlSource,"DARB_CHKDBL",out returnValue,validData,existTable,chkField,addedit,srvbid,pkid);
            }
            catch
            {
                return new ValidationResult(false, "不合法的輸入");
            }
            return new ValidationResult(true, null);
        }
    }
}
