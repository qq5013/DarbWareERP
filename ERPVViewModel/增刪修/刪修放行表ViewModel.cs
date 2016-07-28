using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using 邏輯Bll.登入;

namespace ViewModel.增刪修
{
    public class 刪修放行表ViewModel
    {
        public 刪修放行表ViewModel()
        {
        }
        public 刪修放行表ViewModel(string 放行pkid, string dataevent)
        {
            string 資料表名稱 = dataevent.ToLower();
            this.放行碼 = "0";
            this.資料表名稱 = 資料表名稱;
            this.放行pkid = 放行pkid;
            this.dataevent = dataevent;
            this.輸入日期 = DateTime.Now;
            this.輸入人員 = 使用者Bll.GetInstance().使用者名稱;
            this.輸入地點 = Environment.MachineName;
            this.增刪修 = "";
            this.選擇 = "";
            this.srvdbid = 使用者Bll.GetInstance().Srvdbid;
        }
        [XmlAttribute()]
        public string 放行碼 { get; set; }
        [XmlAttribute()]
        public string 資料表名稱 { get; set; }
        [XmlAttribute()]
        public string 放行pkid { get; set; }
        [XmlAttribute()]
        public string dataevent { get; set; }
        [XmlAttribute()]
        public DateTime 輸入日期 { get; set; }
        [XmlAttribute()]
        public string 輸入人員 { get; set; }
        [XmlAttribute()]
        public string 輸入地點 { get; set; }
        [XmlAttribute()]
        public string 增刪修 { get; set; }
        [XmlAttribute()]
        public string 選擇 { get; set; }
        [XmlAttribute()]
        public int 管制碼 { get; set; }
        [XmlAttribute()]
        public int srvdbid { get; set; }
        [XmlAttribute()]
        public int pkid { get; set; }
        [XmlAttribute()]
        public int logid { get; set; }
        [XmlAttribute()]
        public int linkid { get; set; }
    }
}
