using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace 邏輯.視窗相關
{
    interface IWindow
    {
        //所有視窗的邏輯處理都要用這個介面
        bool UpdateData(CollectionViewSource cv);        
    }
}
