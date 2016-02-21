using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace DarbWareERP.繼承窗口
{
    public class 視窗繼承 : Window
    {
        private bool canClose = false;
        public 視窗繼承()
        {

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = !canClose;
        }
        public void CloseWindow()
        {
            canClose = true;
            this.Close();
            canClose = false;
        }
        public string KeyFldValue { get; set; }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //在視窗中用左右鍵控制上一筆下一筆
            base.OnKeyDown(e);
            if (e.Key == Key.Left)
            {
                Button btn = FindChild<Button>(this, "btn上一筆");
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        private static T FindChild<T>(DependencyObject depObj, string childName) where T : DependencyObject
        {

            if (depObj == null) return null;

            if (depObj is T && ((FrameworkElement)depObj).Name == childName)
                return depObj as T;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                T obj = FindChild<T>(child, childName);

                if (obj != null)
                    return obj;
            }

            return null;
        }
    }
}



