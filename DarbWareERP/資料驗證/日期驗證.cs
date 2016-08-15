using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DarbWareERP.資料驗證
{
    class 日期驗證 : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime result;
            if (value.ToString().Count() < 8)
            {
                return new ValidationResult(false, "請輸入正確的日期格式，例如20160101");
            }
            string convertvalue = value.ToString().Substring(0, 4) + "/" + value.ToString().Substring(4, 2) + "/" + value.ToString().Substring(6, 2);
           if ( DateTime.TryParse(convertvalue,out result))
            {
                return new ValidationResult(true, "null");
            }
            else
            {
                return new ValidationResult(false, "請輸入正確的日期格式，例如20160101");
            }
        }
    }
}
