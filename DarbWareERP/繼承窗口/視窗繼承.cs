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
        private 控制項操作 控制項操作 = new 控制項操作();
        private bool canClose = false;
        public string KeyFldValue { get; set; }        
        public string 資料表名稱 { get; set; }
        public CollectionViewSource CollectionViewSource { get; set; }

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
        
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //在視窗中用左右鍵控制上一筆下一筆
            base.OnKeyDown(e);
            if (e.Key == Key.Left)
            {
                Button btn = 控制項操作.用名稱尋找子代<Button>(this, "btn上一筆");
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }             
    }
}



