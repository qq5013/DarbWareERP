using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Model;
using System.Data;
using 數據庫連線;
using System.Windows;

namespace 邏輯.視窗相關.B.基本資料
{
    public class 業務資料表Bll : IWindow
    {
        public bool UpdateData(CollectionViewSource cv, out string result)
        {
            try
            {
                List<salesmen> listunitba = (List<salesmen>)DataTableToList<salesmen>.ConvertToModel((DataTable)cv.Source);
                unitba新增值(listunitba);
                string 上傳資料 = XmlToSql<unitba>.WriteXml(listunitba);
                result = Log.Log_Sys_Input("INPUT-BB", "UNITBA", "Normal Add", "", "unitba", LP_DATA1: 上傳資料);
            }
            catch (Exception ex)
            {
                result = "儲存失敗";
                MessageBox.Show(ex.Message, result, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void unitba新增值(List<salesmen> salesmen)
        {
            foreach (unitba unitba in listunitba)
            {
                unitba.輸入人員 = Log.使用者名稱;
                unitba.輸入日期 = DateTime.Now;
                unitba.輸入地點 = Environment.MachineName;
                unitba.增刪修 = "A";
                unitba.選擇 = "";
            }
        }
    }
}
