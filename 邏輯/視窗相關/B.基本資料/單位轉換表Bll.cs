using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 數據庫連線;
using System.Windows.Data;
using Model;
using System.Data;


namespace 邏輯.視窗相關.B.基本資料
{
    public class 單位轉換表Bll : IWindow
    {
        public bool UpdateData(CollectionViewSource cv)
        {             
            try
            {
                List<unitba> listunitba= (List<unitba>)DataTableToList<unitba>.ConvertToModel((DataTable)cv.Source);
                string 上傳資料= XmlToSql<unitba>.WriteXml(listunitba);
                string result = Log.Log_Sys_Input("INPUT-BB", "UNITBA", "Normal Add", "", "unitba", LP_DATA1: 上傳資料);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "儲存失敗", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;             
        }
    }
}
