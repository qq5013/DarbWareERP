using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    public class UnitbaViewModel
    {
        public UnitbaModel unitbaModel { get; set; }
        public UnitbaViewModel()
        {
            unitbaModel = new UnitbaModel();
        }
        public string 單位 { get { return unitbaModel.單位; } set { unitbaModel.單位 = value; } }
        public string 說明 { get { return unitbaModel.說明; } set { unitbaModel.說明 = value; } }
        public byte 小數位數 { get { return unitbaModel.小數位數; } set { unitbaModel.小數位數 = value; } }
        public System.DateTime 輸入日期 { get { return unitbaModel.輸入日期; } set { unitbaModel.輸入日期 = value; } }
        public string 輸入人員 { get { return unitbaModel.輸入人員; } set { unitbaModel.輸入人員 = value; } }
        public string 輸入地點 { get { return unitbaModel.輸入地點; } set { unitbaModel.輸入地點 = value; } }
        public string 增刪修 { get { return unitbaModel.增刪修; } set { unitbaModel.增刪修 = value; } }
        public string 選擇 { get { return unitbaModel.選擇; } set { unitbaModel.選擇 = value; } }
        public int 管制碼 { get { return unitbaModel.管制碼; } set { unitbaModel.管制碼 = value; } }
        public short srvdbid { get { return unitbaModel.srvdbid; } set { unitbaModel.srvdbid = value; } }
        public int pkid { get { return unitbaModel.pkid; } set { unitbaModel.pkid = value; } }
        public int logid { get { return unitbaModel.logid; } set { unitbaModel.logid = value; } }
        public int linkid { get { return unitbaModel.linkid; } set { unitbaModel.linkid = value; } }
    }
}


