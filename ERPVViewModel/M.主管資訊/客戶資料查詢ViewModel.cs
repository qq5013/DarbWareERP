using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ViewModel.M.主管資訊
{
    public class 客戶資料查詢ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public string 客戶代號
        {
            get
            {
                return _客戶代號;
            }
            set
            {
                _客戶代號 = value;
                OnPropertyChanged("客戶代號");
            }
        }
        public string 起始品號
        {
            get
            {
                return _起始品號;
            }
            set
            {
                _起始品號 = value;
                OnPropertyChanged("起始品號");
            }
        }
        public string 截止品號
        {
            get
            {
                return _截止品號;
            }
            set
            {
                _截止品號 = value;
                OnPropertyChanged("截止品號");
            }
        }
        public string 起始訂單
        {
            get
            {
                return _起始訂單;
            }
            set
            {
                _起始訂單 = value;
                OnPropertyChanged("起始訂單");
            }
        }
        public string 截止訂單
        {
            get
            {
                return _截止訂單;
            }
            set
            {
                _截止訂單 = value;
                OnPropertyChanged("截止訂單");
            }
        }
        public string 起始日期
        {
            get
            {
                return _起始日期;
            }
            set
            {
                _起始日期 = value;
                OnPropertyChanged("起始日期");
            }
        }
        public string 截止日期
        {
            get
            {
                return _截止日期;
            }
            set
            {
                _截止日期 = value;
                OnPropertyChanged("截止日期");
            }
        }
        private string _客戶代號;
        private string _起始品號;
        private string _截止品號;
        private string _起始訂單;
        private string _截止訂單;
        private string _起始日期;
        private string _截止日期;
        public void 查詢()
        {
            訂單查詢();
            出貨查詢();
        }
        private void 訂單查詢()
        {
            string 查詢欄位 = "a.客戶代號,a.客戶簡稱,a.訂單編號,b.客戶訂單號,a.受訂日期,b.序號,b.品號,b.品名,b.數量 as 訂單數量,b.單位, b.單價,b.原幣未稅,b.本幣未稅,a.幣別,a.匯率,b.預訂交期,b.已交數量,b.pkid";
            string 查詢條件= "a.客戶代號 = '"+客戶代號+"' AND b.品號 BETWEEN '"+起始品號+"' AND '"+截止品號+"' AND a.訂單編號 BETWEEN '"+起始訂單+"' AND '"+截止訂單+"' AND a.受訂日期 BETWEEN '"+起始日期+"' AND '"+截止日期+"'";
            邏輯Bll.M.主管資訊.主管資訊查詢.客戶資料訂單查詢(查詢欄位, 查詢條件);
        }
        private void 出貨查詢()
        {
            string 查詢欄位 = "x.倉單號,x.交易日期,y.數量,x.幣別,x.匯率,y.原幣未稅,y.本幣未稅,x.客戶代號,x.客戶簡稱,y.訂單pkid";
            string 查詢條件 = "EXISTS(SELECT * FROM ormast a inner join ordetl b on a.pkid = b.linkid WHERE b.pkid = y.訂單pkid AND    a.客戶代號 = '" + 客戶代號 + "' AND b.品號 BETWEEN '" + 起始品號 + "' AND '" + 截止品號 + "' AND a.訂單編號 BETWEEN '" + 起始訂單 + "' AND '" + 截止訂單 + "' AND a.受訂日期 BETWEEN '" + 起始日期 + "' AND '" + 截止日期 + "')";
            邏輯Bll.M.主管資訊.主管資訊查詢.客戶資料訂單查詢(查詢欄位, 查詢條件);
        }
    }
}
