using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using 邏輯Bll.登入;

namespace ViewModel.增刪修
{
    public class 刪除表ViewModel
    {
        public 刪除表ViewModel(string pkid)
        {
            srvdbid = 使用者Bll.GetInstance().Srvdbid;
            this.pkid = int.Parse(pkid);
        }
        public 刪除表ViewModel()
        {

        }
        [XmlAttribute()]
        public int srvdbid { get; set; }
        [XmlAttribute()]
        public int pkid { get; set; }
    }
}
