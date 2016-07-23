using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using 邏輯Bll.資料驗證;

namespace ViewModel.資料驗證
{
    public class 主索引驗證ViewModel : ValidationRule
    {
        主索引驗證Bll 主索引驗證bll = new 主索引驗證Bll();
        public CollectionViewSource Cvs { get; set; } //在XAML設定
        public string Table { get; set; } //在XAML設定
        public string DataEvent { get; set; }
        string chkField;
        string returnValue = "";
        string addedit;
        //int srvdbid;
        int pkid;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            ListCollectionView listCollectionView = (ListCollectionView)Cvs.View;
            
            DataTable dt = (DataTable)Cvs.Source;
            try
            {
                if (dt.Rows.Count == 0)
                {
                    addedit = "A";
                    //srvdbid = 主索引驗證bll.Srvdbid;
                    pkid = 0;
                }
                else
                {
                    addedit = "E";
                }
                主索引驗證bll.主索引檢查(DataEvent, ref returnValue, value.ToString(), Table, chkField, addedit, pkid.ToString());
                if (returnValue == "Y")
                {
                    //視窗ViewModel.是否可以儲存 = false;
                    MessageBox.Show("資料不得重複", "輸入錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new ValidationResult(false, "不合法的輸入");
                }
            }
            catch
            {
                return new ValidationResult(false, "不合法的輸入");
            }
            //視窗ViewModel.是否可以儲存 = true;
            return new ValidationResult(true, null);
        }
    }
}

