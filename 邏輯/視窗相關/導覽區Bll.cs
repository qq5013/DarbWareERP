using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 數據庫連線Dal;
using System.Data;
using System.Windows.Data;
using System.Windows;

namespace 邏輯Bll.視窗相關
{
    public delegate void 導覽區指令Delegate(string 程式名稱, CollectionViewSource[] cv, string[] 資料表名稱, string keyfldvalue);
    public class 導覽區Bll
    {       
        public void 查詢(string 程式名稱, CollectionViewSource[] cv, string[] 資料表名稱, string keyfldvalue)
        {
            string LP_p1 = 資料表名稱[0].ToUpper();
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC",ref LP_p1, "SEEK", keyfldvalue);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("查無資料", "訊息視窗", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {                
                for (int i = 0; i < cv.Count(); i++)
                {
                    if (cv[i] != null)
                    {
                        cv[i].Source = ds.Tables[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public void 檔首(string 程式名稱, CollectionViewSource[] cv, string[] 資料表名稱, string keyfldvalue)
        {
            string LP_p1 = 資料表名稱[0].ToUpper();
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC", ref LP_p1, "TOP", keyfldvalue);            
            for (int i = 0; i < cv.Count(); i++)
            {
                if (cv[i] != null)
                {
                    cv[i].Source = ds.Tables[i];
                }
                else
                {
                    break;
                }
            }
        }
        public void 上一筆(string 程式名稱, CollectionViewSource[] cv, string[] 資料表名稱, string keyfldvalue)
        {
            string LP_p1 = 資料表名稱[0].ToUpper();
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC",ref LP_p1, "PRIOR", keyfldvalue);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("無上一筆紀錄可移動", "訊息視窗", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                for (int i = 0; i < cv.Count(); i++)
                {
                    if (cv[i] != null)
                    {
                        cv[i].Source = ds.Tables[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public void 重新整理(string 程式名稱, CollectionViewSource[] cv, string[] 資料表名稱, string keyfldvalue)
        {
            string LP_p1 = 資料表名稱[0].ToUpper();
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC",ref LP_p1, "RENEW", keyfldvalue);
            for (int i = 0; i < cv.Count(); i++)
            {
                if (cv[i] != null)
                {
                    cv[i].Source = ds.Tables[i];
                }
                else
                {
                    break;
                }
            }
        }
        public void 下一筆(string 程式名稱, CollectionViewSource[] cv, string[] 資料表名稱, string keyfldvalue)
        {
            string LP_p1 = 資料表名稱[0].ToUpper();
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC",ref LP_p1, "NEXT", keyfldvalue);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("無下一筆紀錄可移動", "訊息視窗", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                for (int i = 0; i < cv.Count(); i++)
                {
                    if (cv[i] != null)
                    {
                        cv[i].Source = ds.Tables[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public void 檔尾(string 程式名稱, CollectionViewSource[] cv, string[] 資料表名稱, string keyfldvalue)
        {
            string LP_p1 = 資料表名稱[0].ToUpper();
            DataSet ds = Log.Log_Sys_Exec("SQLEDIT-" + 程式名稱, "DARB_MOVEREC",ref LP_p1, "TAIL", keyfldvalue);
            for (int i = 0; i < cv.Count(); i++)
            {
                if (cv[i] != null)
                {
                    cv[i].Source = ds.Tables[i];
                }
                else
                {
                    break;
                }
            }
        }
    }
}
