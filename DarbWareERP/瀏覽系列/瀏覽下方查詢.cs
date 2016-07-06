using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DarbWareERP.瀏覽系列
{
    public class 瀏覽下方查詢 : INotifyPropertyChanged
    {
        public string 序號 { get; set; }
        private string _欄位編號;
        public string 欄位編號 { get { return _欄位編號; } set {_欄位編號 = value; OnPropertyChanged("欄位編號"); } }
        private string _欄位說明;
        public string 欄位說明 { get { return _欄位說明; } set { _欄位說明 = value;OnPropertyChanged("欄位說明"); } }
        private string _運算子編號;
        public string 運算子編號 { get { return _運算子編號; } set { _運算子編號 = value;OnPropertyChanged("運算子編號"); } }
        private string _運算子說明;
        public string 運算子說明 { get { return _運算子說明; } set { _運算子說明 = value;OnPropertyChanged("運算子說明"); } }
        private string _起始值;
        public string 起始值 { get { return _起始值; } set { _起始值 = value;OnPropertyChanged("起始值"); } }
        private string _截止值;
        public string 截止值 { get { return _截止值; } set { _截止值 = value;OnPropertyChanged("截止值"); } }
        private string _欄位TYPE;
        public string 欄位TYPE { get { return _欄位TYPE; } set { _欄位TYPE = value;OnPropertyChanged("欄位TYPE"); } }
        public ObservableCollection<欄位編號列表> 欄位編號列表 { get; set; }
        public ObservableCollection<運算子編號列表> 運算子編號列表 { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
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
