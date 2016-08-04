using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class DeptViewModel
    {
        private DeptModel deptModel { get; set; }
        public DeptViewModel()
        {
            deptModel = new DeptModel();
        }
        public string 部門代號 { get { if (deptModel.部門代號 == null) { deptModel.部門代號 = ""; } return deptModel.部門代號; } set { deptModel.部門代號 = value; } }
        public string 部門簡稱 { get { if (deptModel.部門簡稱 == null) { deptModel.部門簡稱 = ""; } return deptModel.部門簡稱; } set { deptModel.部門簡稱 = value; } }
        public string 部門名稱 { get { if (deptModel.部門名稱 == null) { deptModel.部門名稱 = ""; } return deptModel.部門名稱; } set { deptModel.部門名稱 = value; } }
        public string 負責主管 { get { if (deptModel.負責主管 == null) { deptModel.負責主管 = ""; } return deptModel.負責主管; } set { deptModel.負責主管 = value; } }
        public string 職稱 { get { if (deptModel.職稱 == null) { deptModel.職稱 = ""; } return deptModel.職稱; } set { deptModel.職稱 = value; } }
        public int 要員人數 { get { return deptModel.要員人數; } set { deptModel.要員人數 = value; } }
        public string 生產順序 { get { if (deptModel.生產順序 == null) { deptModel.生產順序 = ""; } return deptModel.生產順序; } set { deptModel.生產順序 = value; } }
        public string 製程別 { get { if (deptModel.製程別 == null) { deptModel.製程別 = ""; } return deptModel.製程別; } set { deptModel.製程別 = value; } }
        public string 隸屬倉庫 { get { if (deptModel.隸屬倉庫 == null) { deptModel.隸屬倉庫 = ""; } return deptModel.隸屬倉庫; } set { deptModel.隸屬倉庫 = value; } }
        public string 可用倉庫 { get { if (deptModel.可用倉庫 == null) { deptModel.可用倉庫 = ""; } return deptModel.可用倉庫; } set { deptModel.可用倉庫 = value; } }
        public string 在製倉庫 { get { if (deptModel.在製倉庫 == null) { deptModel.在製倉庫 = ""; } return deptModel.在製倉庫; } set { deptModel.在製倉庫 = value; } }
        public string 出貨倉庫 { get { if (deptModel.出貨倉庫 == null) { deptModel.出貨倉庫 = ""; } return deptModel.出貨倉庫; } set { deptModel.出貨倉庫 = value; } }
        public string 外調倉庫 { get { if (deptModel.外調倉庫 == null) { deptModel.外調倉庫 = ""; } return deptModel.外調倉庫; } set { deptModel.外調倉庫 = value; } }
        public System.DateTime 輸入日期 { get { return deptModel.輸入日期; } set { deptModel.輸入日期 = value; } }
        public string 輸入人員 { get { if (deptModel.輸入人員 == null) { deptModel.輸入人員 = ""; } return deptModel.輸入人員; } set { deptModel.輸入人員 = value; } }
        public string 輸入地點 { get { if (deptModel.輸入地點 == null) { deptModel.輸入地點 = ""; } return deptModel.輸入地點; } set { deptModel.輸入地點 = value; } }
        public string 增刪修 { get { if (deptModel.增刪修 == null) { deptModel.增刪修 = ""; } return deptModel.增刪修; } set { deptModel.增刪修 = value; } }
        public string 選擇 { get { if (deptModel.選擇 == null) { deptModel.選擇 = ""; } return deptModel.選擇; } set { deptModel.選擇 = value; } }
        public int 管制碼 { get { return deptModel.管制碼; } set { deptModel.管制碼 = value; } }
        public short srvdbid { get { return deptModel.srvdbid; } set { deptModel.srvdbid = value; } }
        public int pkid { get { return deptModel.pkid; } set { deptModel.pkid = value; } }
        public int logid { get { return deptModel.logid; } set { deptModel.logid = value; } }
        public int linkid { get { return deptModel.linkid; } set { deptModel.linkid = value; } }
    }
}
