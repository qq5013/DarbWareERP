using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using 邏輯Bll;
using 邏輯Bll.視窗相關;
using System.Globalization;

namespace ViewModel
{
    public delegate void 導覽區指令Delegate(string 程式名稱, CollectionViewSource[] cv, string[] 資料表名稱, string keyfldvalue);
    public class 導覽區ViewModel
    {
        private 導覽區Bll 導覽區Bll = new 導覽區Bll();
        public void 查詢(string 程式名稱, CollectionViewSource[] cv, string[] 資料表名稱, string keyfldvalue)
        {
            string LP_p1 = 資料表名稱[0].ToUpper();
            DataSet ds = 導覽區Bll.導覽(程式名稱, 資料表名稱, keyfldvalue, "SEEK");
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
                        cv[i].Source = 製作ObservableCollection(ds.Tables[i], 資料表名稱[i]);
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
            DataSet ds = 導覽區Bll.導覽(程式名稱, 資料表名稱, keyfldvalue, "TOP");
            for (int i = 0; i < cv.Count(); i++)
            {
                if (cv[i] != null)
                {
                    cv[i].Source = 製作ObservableCollection(ds.Tables[i], 資料表名稱[i]);
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
            DataSet ds = 導覽區Bll.導覽(程式名稱, 資料表名稱, keyfldvalue, "PRIOR");
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
                        cv[i].Source = 製作ObservableCollection(ds.Tables[i], 資料表名稱[i]);
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
            DataSet ds = 導覽區Bll.導覽(程式名稱, 資料表名稱, keyfldvalue, "RENEW");
            for (int i = 0; i < cv.Count(); i++)
            {
                if (cv[i] != null)
                {
                    cv[i].Source = 製作ObservableCollection(ds.Tables[i], 資料表名稱[i]);
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
            DataSet ds = 導覽區Bll.導覽(程式名稱, 資料表名稱, keyfldvalue, "NEXT");
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
                        cv[i].Source = 製作ObservableCollection(ds.Tables[i], 資料表名稱[i]);
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
            DataSet ds = 導覽區Bll.導覽(程式名稱, 資料表名稱, keyfldvalue, "TAIL");
            for (int i = 0; i < cv.Count(); i++)
            {
                if (cv[i] != null)
                {
                    cv[i].Source = 製作ObservableCollection(ds.Tables[i], 資料表名稱[i]); 
                }
                else
                {
                    break;
                }
            }
        }
        private dynamic 製作ObservableCollection(DataTable dt, string 資料表名稱)
        {
            資料表名稱 = 資料表名稱.Substring(0, 1).ToUpper() + 資料表名稱.Substring(1);
            Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
            Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType("ViewModel." + 資料表名稱 + "ViewModel"))
                .Where(type => type != null)
                .FirstOrDefault();
            //List<T> list = (List<T>)DataTableToList<T>.ConvertToModel(dt);
            Type generic = typeof(List<>);
            Type constructor = generic.MakeGenericType(trgType);
            dynamic listq = Activator.CreateInstance(constructor);
            Type datatabletolistType = typeof(DataTableToList<>).MakeGenericType(trgType);
            MethodInfo minfo = datatabletolistType.GetMethod("ConvertToModel");
            listq = minfo.Invoke(null, new object[] { dt });
            Type obser = typeof(ObservableCollection<>);
            Type obserconstructor = obser.MakeGenericType(trgType);
            var observableCollection = Activator.CreateInstance(constructor, listq);
            return observableCollection;
        }
    }
}
