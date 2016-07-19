using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Data;
using 數據庫連線Dal;
using System.Windows;

namespace 邏輯Bll.視窗相關.B.基本資料
{
    public class 業務資料表Bll 
    {
        //public bool UpdateData(CollectionViewSource cv, out string result)
        //{
        //    try
        //    {
        //        List<salesmen> salesmen = (List<salesmen>)DataTableToList<salesmen>.ConvertToModel((DataTable)cv.Source);
        //        salesmen新增值(salesmen);
        //        string 上傳資料 = XmlToSql<salesmen>.WriteXml(salesmen);
        //        result = Log.Log_Sys_Input("INPUT-BB", "SALESMEN", "Normal Add", "", "salesmen", LP_DATA1: 上傳資料);
        //        if (result.ToString().Contains("NG"))
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result = "儲存失敗";
        //        MessageBox.Show(ex.Message, result, MessageBoxButton.OK, MessageBoxImage.Error);
        //        return false;
        //    }
        //    return true;
        //}
        //private void salesmen新增值(List<salesmen> salesmen)
        //{
        //    foreach (var sales in salesmen)
        //    {
        //        sales.輸入人員 = Log.使用者名稱;
        //        sales.輸入日期 = DateTime.Now;
        //        sales.輸入地點 = Environment.MachineName;
        //        sales.增刪修 = "A";
        //        sales.選擇 = "";
        //    }
        //}
    }
}
