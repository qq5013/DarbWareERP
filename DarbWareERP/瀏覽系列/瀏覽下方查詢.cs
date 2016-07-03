using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DarbWareERP.瀏覽系列
{
    public class 瀏覽下方查詢        
    {
        public string 序號 { get; set; }
        public string 欄位編號 { get; set; }
        private string _欄位說明;
        public string 欄位說明 { get { return _欄位說明; } set { _欄位說明 = value; } }
        public string 運算子編號 { get; set; }
        private string _運算子說明;
        public string 運算子說明 { get { return _運算子說明; } set { _運算子說明 = value; } }
        private string _起始值;
        public string 起始值 { get { return _起始值; } set { _起始值 = value;} }
        public string 截止值 { get; set; }
         public ObservableCollection<欄位編號列表> 欄位編號列表 { get; set; }
        public ObservableCollection<運算子編號列表> 運算子編號列表 { get; set; }
    }
    public class 欄位編號列表
    {
        public int 欄位編號 { get; set; }
        public string 欄位說明 { get; set; }
    }
    public class 運算子編號列表
    {
        public string 運算子編號 { get; set; }
        public string 運算子說明 { get; set; }
    }
}
