using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarbWareERP.瀏覽系列
{
    public class 瀏覽下方查詢
    {
        public string 序號 { get; set; }
        public string 欄位編號 { get; set; }
        public string 欄位說明 { get; set; }
        public string T運算子編號 { get; set; }
        public string 運算子說明 { get; set; }
        public string 起始值 { get; set; }
        public string 截止值 { get; set; }        

        public List<欄位編號列表> 欄位編號列表 { get; set; }
        public List<運算子編號列表> 運算子編號列表 { get; set; }
    }
    public class 欄位編號列表
    {
        public string 欄位編號 { get; set; }
        public string 欄位說明 { get; set; }
    }
    public class 運算子編號列表
    {
        public string 運算子編號 { get; set; }
        public string 運算子說明 { get; set; }
    }
}
