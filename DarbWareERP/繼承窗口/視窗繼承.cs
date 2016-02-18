using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

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
    }
}



