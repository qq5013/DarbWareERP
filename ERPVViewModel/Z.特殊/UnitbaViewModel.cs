using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    public class UnicodetbViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        private UnicodetbModel unicodetbModel { get; set; }
        public UnicodetbViewModel()
        {
            unicodetbModel = new UnicodetbModel();
            代號 = "";
            簡稱 = "";
            輸入人員 = "";
            輸入地點 = "";
            增刪修 = "";
            選擇 = "";
        }
        public byte 類別 { get { return unicodetbModel.類別; } set { unicodetbModel.類別 = value; OnPropertyChanged("類別"); } }
        public string 代號 { get { if (unicodetbModel.代號 == null) { unicodetbModel.代號 = ""; } return unicodetbModel.代號; } set { unicodetbModel.代號 = value; OnPropertyChanged("代號"); } }
        public string 簡稱 { get { if (unicodetbModel.簡稱 == null) { unicodetbModel.簡稱 = ""; } return unicodetbModel.簡稱; } set { unicodetbModel.簡稱 = value; OnPropertyChanged("簡稱"); } }
        public System.DateTime 輸入日期 { get { return unicodetbModel.輸入日期; } set { unicodetbModel.輸入日期 = value; OnPropertyChanged("輸入日期"); } }
        public string 輸入人員 { get { if (unicodetbModel.輸入人員 == null) { unicodetbModel.輸入人員 = ""; } return unicodetbModel.輸入人員; } set { unicodetbModel.輸入人員 = value; OnPropertyChanged("輸入人員"); } }
        public string 輸入地點 { get { if (unicodetbModel.輸入地點 == null) { unicodetbModel.輸入地點 = ""; } return unicodetbModel.輸入地點; } set { unicodetbModel.輸入地點 = value; OnPropertyChanged("輸入地點"); } }
        public string 增刪修 { get { if (unicodetbModel.增刪修 == null) { unicodetbModel.增刪修 = ""; } return unicodetbModel.增刪修; } set { unicodetbModel.增刪修 = value; OnPropertyChanged("增刪修"); } }
        public string 選擇 { get { if (unicodetbModel.選擇 == null) { unicodetbModel.選擇 = ""; } return unicodetbModel.選擇; } set { unicodetbModel.選擇 = value; OnPropertyChanged("選擇"); } }
        public int 管制碼 { get { return unicodetbModel.管制碼; } set { unicodetbModel.管制碼 = value; OnPropertyChanged("管制碼"); } }
        public short srvdbid { get { return unicodetbModel.srvdbid; } set { unicodetbModel.srvdbid = value; OnPropertyChanged("srvdbid"); } }
        public int pkid { get { return unicodetbModel.pkid; } set { unicodetbModel.pkid = value; OnPropertyChanged("pkid"); } }
        public int logid { get { return unicodetbModel.logid; } set { unicodetbModel.logid = value; OnPropertyChanged("logid"); } }
        public int linkid { get { return unicodetbModel.linkid; } set { unicodetbModel.linkid = value; OnPropertyChanged("linkid"); } }
    }
}
