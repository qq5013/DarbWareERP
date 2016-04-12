using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarbWareERP
{
    public class 運算子
    {
        public string 運算子編號 { get; set; }
        string 運算子說明 { get; set; }
        public 運算子(string 編號, string 說明)
        {
            運算子編號 = 編號;
            運算子說明 = 說明;
        }
    }
}
