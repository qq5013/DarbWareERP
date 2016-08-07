using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DarbWareERP.驗證
{
    class 控制項驗證
    {
        public static bool 子代驗證檢查(DependencyObject dobj)
        {
            bool result = true;
            foreach (DependencyObject obj in LogicalTreeHelper.GetChildren(dobj))
            {
                if (obj is ContentControl)
                {
                    result = 子代驗證檢查(obj);
                }
                if (obj is Panel)
                {
                    result = 子代驗證檢查(obj);
                }
                if (result == false)
                {
                    return result;
                }
                TextBox txt = obj as TextBox;
                if (txt == null) continue;
                if (Validation.GetHasError(txt))
                {
                    result = false; //只要有一個TEXTBOX錯就不能儲存
                    break;
                }
            }
            return result;
        }
        public static void 子代更新資料(DependencyObject dobj)
        {
            foreach (DependencyObject obj in LogicalTreeHelper.GetChildren(dobj))
            {
                if (obj is ContentControl)
                {
                    子代更新資料(obj);
                }
                if (obj is Panel)
                {
                    子代更新資料(obj);
                }
                else
                {
                    TextBox txt = obj as TextBox;
                    if (txt == null)
                    { continue; }
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
        }
    }
}
