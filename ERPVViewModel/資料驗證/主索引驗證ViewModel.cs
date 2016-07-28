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
using System.Windows.Markup;
using ViewModel.增刪修;
using 邏輯Bll.資料驗證;

namespace ViewModel.資料驗證
{
    public class 主索引驗證ViewModel : ValidationRule
    {
        主索引驗證Bll 主索引驗證bll = new 主索引驗證Bll();
        public CollectionViewSource Cvs { get; set; } //在XAML設定        
        public string Table { get; set; } //在XAML設定        
        public string CheckField { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string returnValue = "";
            string addedit = "";
            string pkid = "";
            ListCollectionView listCollectionView = (ListCollectionView)Cvs.View;
            //dataEvent = listCollectionView.SourceCollection.GetType().GenericTypeArguments[0].Name;

            if (listCollectionView.IsAddingNew)
            {
                addedit = "A";
                pkid = "0";
            }
            else if (listCollectionView.IsEditingItem)
            {
                addedit = "E";
                var items = listCollectionView.SourceCollection.GetType().GetProperty("Item");
                var item = items.GetValue(listCollectionView.SourceCollection, new object[] { 0 });
                pkid = item.GetType().GetProperty("pkid").GetValue(item).ToString();
            }

            主索引驗證bll.主索引檢查(ref returnValue, value.ToString(), Table, CheckField, addedit, pkid);
            if (returnValue == "Y")
            {
                return new ValidationResult(false, "資料重複");
            }
            else
            {
                return new ValidationResult(true, null);
            }


        }
    }
}

