using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;

namespace ViewModel
{
    public class DeptViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        private DeptModel deptModel { get; set; }
        public DeptViewModel()
        {
            deptModel = new DeptModel();
            部門代號 = "";
            部門簡稱 = "";
            部門名稱 = "";
            負責主管 = "";
            職稱 = "";
            生產順序 = "";
            製程別 = "";
            隸屬倉庫 = "";
            可用倉庫 = "";
            在製倉庫 = "";
            出貨倉庫 = "";
            外調倉庫 = "";
            輸入人員 = "";
            輸入地點 = "";
            增刪修 = "A";
            選擇 = "";
        }
        public string 部門代號 { get { if (deptModel.部門代號 == null) { deptModel.部門代號 = ""; } return deptModel.部門代號; } set { deptModel.部門代號 = value; OnPropertyChanged("部門代號"); } }
        public string 部門簡稱 { get { if (deptModel.部門簡稱 == null) { deptModel.部門簡稱 = ""; } return deptModel.部門簡稱; } set { deptModel.部門簡稱 = value; OnPropertyChanged("部門簡稱"); } }
        public string 部門名稱 { get { if (deptModel.部門名稱 == null) { deptModel.部門名稱 = ""; } return deptModel.部門名稱; } set { deptModel.部門名稱 = value; OnPropertyChanged("部門名稱"); } }
        public string 負責主管 { get { if (deptModel.負責主管 == null) { deptModel.負責主管 = ""; } return deptModel.負責主管; } set { deptModel.負責主管 = value; OnPropertyChanged("負責主管"); } }
        public string 職稱 { get { if (deptModel.職稱 == null) { deptModel.職稱 = ""; } return deptModel.職稱; } set { deptModel.職稱 = value; OnPropertyChanged("職稱"); } }
        public int 要員人數 { get { return deptModel.要員人數; } set { deptModel.要員人數 = value; OnPropertyChanged("要員人數"); } }
        public string 生產順序
        {
            get
            { if (deptModel.生產順序 == null) { deptModel.生產順序 = ""; } return deptModel.生產順序; }
            set
            { deptModel.生產順序 = value; OnPropertyChanged("生產順序"); }
        }
        public string 製程別 { get { if (deptModel.製程別 == null) { deptModel.製程別 = ""; } return deptModel.製程別; } set { deptModel.製程別 = value; OnPropertyChanged("製程別"); } }
        public string 隸屬倉庫 { get { if (deptModel.隸屬倉庫 == null) { deptModel.隸屬倉庫 = ""; } return deptModel.隸屬倉庫; } set { deptModel.隸屬倉庫 = value; OnPropertyChanged("隸屬倉庫"); } }
        public string 可用倉庫 { get { if (deptModel.可用倉庫 == null) { deptModel.可用倉庫 = ""; } return deptModel.可用倉庫; } set { deptModel.可用倉庫 = value; OnPropertyChanged("可用倉庫"); } }
        public string 在製倉庫 { get { if (deptModel.在製倉庫 == null) { deptModel.在製倉庫 = ""; } return deptModel.在製倉庫; } set { deptModel.在製倉庫 = value; OnPropertyChanged("在製倉庫"); } }
        public string 出貨倉庫 { get { if (deptModel.出貨倉庫 == null) { deptModel.出貨倉庫 = ""; } return deptModel.出貨倉庫; } set { deptModel.出貨倉庫 = value; OnPropertyChanged("出貨倉庫"); } }
        public string 外調倉庫 { get { if (deptModel.外調倉庫 == null) { deptModel.外調倉庫 = ""; } return deptModel.外調倉庫; } set { deptModel.外調倉庫 = value; OnPropertyChanged("外調倉庫"); } }
        public System.DateTime 輸入日期 { get { return deptModel.輸入日期; } set { deptModel.輸入日期 = value; OnPropertyChanged("輸入日期"); } }
        public string 輸入人員 { get { if (deptModel.輸入人員 == null) { deptModel.輸入人員 = ""; } return deptModel.輸入人員; } set { deptModel.輸入人員 = value; OnPropertyChanged("輸入人員"); } }
        public string 輸入地點 { get { if (deptModel.輸入地點 == null) { deptModel.輸入地點 = ""; } return deptModel.輸入地點; } set { deptModel.輸入地點 = value; OnPropertyChanged("輸入地點"); } }
        public string 增刪修 { get { if (deptModel.增刪修 == null) { deptModel.增刪修 = ""; } return deptModel.增刪修; } set { deptModel.增刪修 = value; OnPropertyChanged("增刪修"); } }
        public string 選擇 { get { if (deptModel.選擇 == null) { deptModel.選擇 = ""; } return deptModel.選擇; } set { deptModel.選擇 = value; OnPropertyChanged("選擇"); } }
        public int 管制碼 { get { return deptModel.管制碼; } set { deptModel.管制碼 = value; OnPropertyChanged("管制碼"); } }
        public short srvdbid { get { return deptModel.srvdbid; } set { deptModel.srvdbid = value; OnPropertyChanged("srvdbid"); } }
        public int pkid { get { return deptModel.pkid; } set { deptModel.pkid = value; OnPropertyChanged("pkid"); } }
        public int logid { get { return deptModel.logid; } set { deptModel.logid = value; OnPropertyChanged("logid"); } }
        public int linkid { get { return deptModel.linkid; } set { deptModel.linkid = value; OnPropertyChanged("linkid"); } }
    }
}
