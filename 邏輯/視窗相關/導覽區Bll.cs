using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線;
using System.Data;
using System.Windows.Data;
using Model;
using System.Windows;

namespace 邏輯.視窗相關
{
    public class 導覽區Bll
    {        
        public void 檔首(string 程式名稱, CollectionViewSource cv, string 資料表名稱, string keyfldvalue)
        {
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC", 資料表名稱, "TOP", keyfldvalue);
            cv.Source = ds.Tables[0];
        }
        public void 上一筆(string 程式名稱, CollectionViewSource cv, string 資料表名稱, string keyfldvalue)
        {
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC", 資料表名稱, "PRIOR", keyfldvalue);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("無上一筆紀錄可移動","訊息視窗",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            else
            {
                cv.Source = ds.Tables[0];
            }
        }
        public void 重新整理(string 程式名稱, CollectionViewSource cv, string 資料表名稱, string keyfldvalue)
        {
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC", 資料表名稱, "RENEW", keyfldvalue);
            cv.Source = ds.Tables[0];
        }
        public void 下一筆(string 程式名稱, CollectionViewSource cv, string 資料表名稱, string keyfldvalue)
        {
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC", 資料表名稱, "NEXT", keyfldvalue);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("無下一筆紀錄可移動", "訊息視窗", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                cv.Source = ds.Tables[0];
            }
        }
        public void 檔尾(string 程式名稱, CollectionViewSource cv, string 資料表名稱, string keyfldvalue)
        {
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC", 資料表名稱, "TAIL", keyfldvalue);
            cv.Source = ds.Tables[0];
        }
    }
}
