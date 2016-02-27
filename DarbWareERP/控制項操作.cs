using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarbWareERP
{
    class 控制項操作
    {
        /// <summary>
        /// 設定資料區中的TEXTBOX的isreadonly值，在畫面初始、新增、儲存使用
        /// </summary>
        /// <param name="dobj"></param>
        /// <param name="是否可見"></param>
        public void 設定TextboxReadonly(DependencyObject dobj,bool 是否可見)
        {
            Grid grid = 用名稱尋找子代<Grid>(dobj, "資料區");
            if (grid == null) { return; }
            foreach (UIElement txt in grid.Children)
            {                
                if (txt is TextBox)
                {
                    ((TextBox)txt).IsReadOnly = 是否可見;
                }
            }
        }       
        public T 用名稱尋找子代<T>(DependencyObject depObj, string childName) where T : DependencyObject
        {

            if (depObj == null) return null;

            if (depObj is T && ((FrameworkElement)depObj).Name == childName)
                return depObj as T;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                T obj = 用名稱尋找子代<T>(child, childName);

                if (obj != null)
                    return obj;
            }
            return null;
        }
        public T 尋找父代<T>(DependencyObject i_dp) where T : DependencyObject
        {
            DependencyObject dobj = (DependencyObject)VisualTreeHelper.GetParent(i_dp);
            if (dobj != null)
            {
                if (dobj is T)
                {
                    return (T)dobj;
                }
                else
                {
                    dobj = 尋找父代<T>(dobj);
                    if (dobj != null && dobj is T)
                    {
                        return (T)dobj;
                    }
                }
            }
            return null;
        }
    }
}
