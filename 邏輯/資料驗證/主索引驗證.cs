using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using 數據庫連線;
using System.Data;
using System.Windows;

namespace 邏輯Bll.資料驗證
{
    public class 主索引驗證 : ValidationRule
    {
        public CollectionViewSource cvs { get; set; }
        public string ControlSource { get; set; }
        public string Table { get; set; }
        public string ChkField { get { return Model.視窗Model.KeyFldValue; } }
        private string returnValue = "";
        string addedit;
        int srvbid;
        int pkid;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ControlSource = ((BindingListCollectionView)cvs.View).ToString();
            DataTable dt = (DataTable)cvs.Source;
            try
            {
                if (dt.Rows.Count == 0)
                {
                    addedit = "A";
                    srvbid =Log.srvdbid;
                    pkid = 0;
                }
                else
                {
                    addedit = "E";
                }                
                Log.Log_Sys_Exec(ControlSource, "DARB_CHKDBL", ref returnValue, value.ToString(), Table, ChkField, addedit, srvbid.ToString(), pkid.ToString());
                if (returnValue == "Y")
                {
                    Model.視窗Model.是否可以儲存 = false;
                    MessageBox.Show("資料不得重複", "輸入錯誤", MessageBoxButton.OK, MessageBoxImage.Error);                    
                    return new ValidationResult(false, "不合法的輸入");
                }               
            }
            catch
            {
                return new ValidationResult(false, "不合法的輸入");
            }
            Model.視窗Model.是否可以儲存 = true;
            return new ValidationResult(true, null);
        }
    }
}
