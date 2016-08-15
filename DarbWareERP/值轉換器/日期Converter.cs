using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DarbWareERP.值轉換器
{
    class 日期Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string convertvalue = value.ToString().Substring(0, 4) + "/" + value.ToString().Substring(4, 2) + "/" + value.ToString().Substring(6, 2);
            return convertvalue;            
        }
    }
}
