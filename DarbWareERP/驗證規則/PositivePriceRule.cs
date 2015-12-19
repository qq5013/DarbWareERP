using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DarbWareERP.驗證規則
{
    public class PositivePriceRule : ValidationRule
    {
        private decimal min = 0;
        private decimal max = decimal.MaxValue;
        public decimal Min
        {
            get { return min; }
            set { min = value; }
        }
        public decimal Max
        {
            get { return max; }
            set { max = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal price = 0;
            try
            {
                if (((string)value).Length > 0)
                    price = decimal.Parse((string)value, NumberStyles.Any, cultureInfo);
            }
            catch
            {
                return new ValidationResult(false, "Illegal characters");
            }
            if ((price < Min) || (price > Max))
            {
                return new ValidationResult(false, "Not in the range" + Min + "to" + Max + ".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
