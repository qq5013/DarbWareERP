using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class Dept_1ViewModel
    {
        private Dept_1Model dept_1Model { get; set; }
        public Dept_1ViewModel()
        {
            dept_1Model = new Dept_1Model();
        }
        public string 序號
        {
            get
            {
                if (dept_1Model.序號 == null)
                { dept_1Model.序號 = ""; }
                return dept_1Model.序號;
            }
            set { dept_1Model.序號 = value; }
        }
        public byte 人員別 { get { return dept_1Model.人員別; } set { dept_1Model.人員別 = value; } }
        public string 員工編號 { get { if (dept_1Model.員工編號 == null) { dept_1Model.員工編號 = ""; } return dept_1Model.員工編號; } set { dept_1Model.員工編號 = value; } }
        public string 姓名 { get { if (dept_1Model.姓名 == null) { dept_1Model.姓名 = ""; } return dept_1Model.姓名; } set { dept_1Model.姓名 = value; } }
        public string 備註 { get { if (dept_1Model.備註 == null) { dept_1Model.備註 = ""; } return dept_1Model.備註; } set { dept_1Model.備註 = value; } }
        public System.DateTime 輸入日期 { get { return dept_1Model.輸入日期; } set { dept_1Model.輸入日期 = value; } }
        public string 輸入人員 { get { if (dept_1Model.輸入人員 == null) { dept_1Model.輸入人員 = ""; } return dept_1Model.輸入人員; } set { dept_1Model.輸入人員 = value; } }
        public string 輸入地點 { get { if (dept_1Model.輸入地點 == null) { dept_1Model.輸入地點 = ""; } return dept_1Model.輸入地點; } set { dept_1Model.輸入地點 = value; } }
        public string 增刪修 { get { if (dept_1Model.增刪修 == null) { dept_1Model.增刪修 = ""; } return dept_1Model.增刪修; } set { dept_1Model.增刪修 = value; } }
        public string 選擇 { get { if (dept_1Model.選擇 == null) { dept_1Model.選擇 = ""; } return dept_1Model.選擇; } set { dept_1Model.選擇 = value; } }
        public int 管制碼 { get { return dept_1Model.管制碼; } set { dept_1Model.管制碼 = value; } }
        public short srvdbid { get { return dept_1Model.srvdbid; } set { dept_1Model.srvdbid = value; } }
        public int pkid { get { return dept_1Model.pkid; } set { dept_1Model.pkid = value; } }
        public int logid { get { return dept_1Model.logid; } set { dept_1Model.logid = value; } }
        public int linkid { get { return dept_1Model.linkid; } set { dept_1Model.linkid = value; } }
    }
}
