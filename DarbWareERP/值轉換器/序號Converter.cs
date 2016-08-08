using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Reflection;

namespace DarbWareERP.值轉換器
{
    public class 序號Converter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0].ToString() == "{DependencyProperty.UnsetValue}")
            {
                return null;
            }
            if (values[0].ToString()=="")
            {
                DataGrid datagrid = values[1] as DataGrid;
                int index= datagrid.Items.IndexOf(datagrid.CurrentItem);
                return (index+1).ToString("000");
                //PropertyInfo info = values[1].GetType().GetProperty("序號");
                //return info.GetValue(values[1]);
            }
            return values[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { value };
        }
    }
}
