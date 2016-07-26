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
        public 增刪修ViewModel 增刪修 { get; set; }//在XAML設定
        public string Table { get; set; } //在XAML設定
        public string CheckField { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string DataEvent;
            string returnValue = "";
            string addedit = "";
            string pkid = "";
            ListCollectionView listCollectionView = (ListCollectionView)Cvs.View;
            DataEvent = listCollectionView.SourceCollection.GetType().GenericTypeArguments[0].Name;
            try
            {
                if (listCollectionView.IsAddingNew)
                {
                    addedit = "A";
                    //srvdbid = 主索引驗證bll.Srvdbid;
                    pkid = "0";
                }
                else if (listCollectionView.IsEditingItem)
                {
                    addedit = "E";
                    pkid = 增刪修.Pkid;
                }

                主索引驗證bll.主索引檢查(DataEvent, ref returnValue, value.ToString(), Table, CheckField, addedit, pkid);
                if (returnValue == "Y")
                {
                    //視窗ViewModel.是否可以儲存 = false;                    
                    增刪修.可以儲存 = false;
                    return new ValidationResult(false, "資料重複");
                }
                else
                {
                    增刪修.可以儲存 = true;
                    return new ValidationResult(true, null);
                }
            }
            catch
            {
                return new ValidationResult(false, "不合法的輸入");
            }
            //視窗ViewModel.是否可以儲存 = true;
            
        }
    }
}

