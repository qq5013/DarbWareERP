using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using 邏輯Bll;
using 邏輯Bll.視窗相關;
using System.Windows;
using System.Collections;
using 邏輯Bll.登入;

namespace ViewModel.增刪修
{
    public delegate bool 新增複製修改Delegate(CollectionViewSource[] cv, out string result);
    public class 增刪修ViewModel :DependencyObject
    {
        private bool _可以儲存 = true;
        public bool 可以儲存 { get { return _可以儲存; } set { _可以儲存 = value; } }
        public string Pkid { get; set; }
        public string[] 資料表名稱 { get; set; }
        public int 放行碼 { get; set; }

        增刪修Bll 增刪修bll = new 增刪修Bll();
        CollectionViewSource[] Cvs;
        public 增刪修ViewModel()
        {
            資料表名稱 = new string[5];
        }
        public bool UpdateData(CollectionViewSource[] cvs, out string result, 增刪修Status status, string[] 資料表名稱)
        {
            this.資料表名稱 = 資料表名稱;
            this.Cvs = cvs;
            新增複製修改Delegate dele;
            bool value = true;
            dele = (新增複製修改Delegate)Delegate.CreateDelegate(typeof(新增複製修改Delegate), this, status.ToString());
            value = dele(cvs, out result);
            return value;
        }
        private void 反射製作上傳資料(string[] stringList, 新增修改 新增修改)
        {
            for (int i = 0; i < Cvs.Count(); i++)
            {
                if (Cvs[i] != null)
                {
                    object 資料表 = Cvs[i].Source;
                    string model資料表 = "Model." + 資料表名稱[i].Substring(0, 1).ToUpper() + 資料表名稱[i].Substring(1).ToLower() + "Model";
                    Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
                    Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType(model資料表))
                        .Where(type => type != null)
                        .FirstOrDefault();
                    //string 上傳資料 = XmlToSql<T>.WriteXml(list);                    
                    Type writexml = typeof(XmlToSql<>).MakeGenericType(trgType);
                    MethodInfo xmltosql = writexml.GetMethod("WriteXml");
                    var list = 值設定(Cvs[i], trgType, 資料表名稱[i], 新增修改);                    
                    string 上傳用資料 = (string)xmltosql.Invoke(null, new object[] { list });
                    stringList[i] = 上傳用資料;
                }
                else
                {
                    break;
                }
            }
        }
        protected IList 值設定(CollectionViewSource cv, Type trgType, string 資料表名稱, 新增修改 新增修改)
        {
            object source = cv.Source;
            PropertyInfo count = source.GetType().GetProperty("Count");
            PropertyInfo items = source.GetType().GetProperty("Item");
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(trgType);
            IList instance = (IList)Activator.CreateInstance(constructedListType);
            for (int i = 0; i < Convert.ToInt32(count.GetValue(source)); i++)
            {
                object item = items.GetValue(source, new object[] { i });
                PropertyInfo 輸入人員 = item.GetType().GetProperty("輸入人員");
                輸入人員.SetValue(item, 使用者Bll.GetInstance().使用者名稱);
                PropertyInfo 輸入日期 = item.GetType().GetProperty("輸入日期");
                輸入日期.SetValue(item, DateTime.Now);
                PropertyInfo 輸入地點 = item.GetType().GetProperty("輸入地點");
                輸入地點.SetValue(item, Environment.MachineName);
                PropertyInfo 增刪修 = item.GetType().GetProperty("增刪修");
                增刪修.SetValue(item, 新增修改.ToString());
                PropertyInfo 選擇 = item.GetType().GetProperty("選擇");
                選擇.SetValue(item, "");
                instance.Add(item.GetType().GetProperty(資料表名稱 + "Model").GetValue(item));
            }
            return instance;
        }
        private bool 上傳資料庫(string eventType, string dataFunc, string[] stringList, out string result, string permitcode = "")
        {
            string 資料表名稱大寫 = 資料表名稱[0].ToUpper();
            string table1 = 資料表名稱[0].ToLower();
            string table2 = 資料表名稱[1] == null ? "" : 資料表名稱[1];
            string table3 = 資料表名稱[2] == null ? "" : 資料表名稱[2];
            string table4 = 資料表名稱[3] == null ? "" : 資料表名稱[3];
            string table5 = 資料表名稱[4] == null ? "" : 資料表名稱[4];
            string data1 = stringList[0] == null ? "" : stringList[0];
            string data2 = stringList[1] == null ? "" : stringList[1];
            string data3 = stringList[2] == null ? "" : stringList[2];
            string data4 = stringList[3] == null ? "" : stringList[3];
            string data5 = stringList[4] == null ? "" : stringList[4];
            try
            {
                result = 增刪修bll.上傳資料(eventType, 資料表名稱大寫, dataFunc, table1,
                    table2, table3, table4, table5, data1, data2, data3, data4, data5, permitcode);
                if (result.ToString().Contains("NG"))
                {
                    return false;
                }
                if (result.ToString().Contains("OK"))
                {
                    result = "儲存成功";
                }
                return true;
            }
            catch (Exception ex)
            {
                result = "儲存失敗";
                MessageBox.Show(ex.Message, result, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private bool 新增(CollectionViewSource[] cv, out string result)
        {
            string[] stringList = new string[5];
            反射製作上傳資料(stringList, 新增修改.A);
            bool 是否成功 = 上傳資料庫("INPUT-BB", "Normal Add", stringList, out result);
            return 是否成功;

        }
        private bool 複製(CollectionViewSource[] cv, out string result)
        {
            return 新增(cv, out result);
        }
        private bool 修改(CollectionViewSource[] cv, out string result)
        {
            string[] stringList = new string[5];
            反射製作上傳資料(stringList, 新增修改.E);
            bool 是否成功 = 上傳資料庫("INPUT-BE", "Normal Edit", stringList, out result, 放行碼.ToString());
            return 是否成功;
        }
        public void 刪除()
        {
            List<刪除表ViewModel> 刪除表 = new List<刪除表ViewModel>() { new 刪除表ViewModel(Pkid) };
            //string model資料表 = "Model." + 資料表名稱[0].Substring(0, 1).ToUpper() + 資料表名稱[0].Substring(1).ToLower() + "Model";
            //XmlToSql(model資料表, 刪除表);
            string 要刪除資料 = XmlToSql<刪除表ViewModel>.WriteXml(刪除表);
            string result = 增刪修bll.刪除(資料表名稱[0], 要刪除資料, 放行碼.ToString());
        }
        public bool 取得放行碼(string pkid)
        {
            bool 放行 = false;
            int 放行碼 = 0;
            string dataevent = 資料表名稱[0].ToUpper();
            List<刪修放行表ViewModel> 刪修放行表 = new List<刪修放行表ViewModel>() { new 刪修放行表ViewModel(pkid, dataevent) };
            //string model資料表 = "Model." + 資料表名稱[0].Substring(0, 1).ToUpper() + 資料表名稱[0].Substring(1).ToLower() + "Model";
            //XmlToSql(model資料表, 刪修放行表);
            string 上傳資料 = XmlToSql<刪修放行表ViewModel>.WriteXml(刪修放行表);
            string result = 增刪修bll.取得放行碼(資料表名稱[0], 上傳資料);
            string 回傳值 = result.Substring(result.IndexOf('(') + 1, result.IndexOf(')') - result.IndexOf('(') - 1);
            放行碼 = int.Parse(回傳值.Substring(0, 回傳值.IndexOf(',')));
            string 輸入人員 = 回傳值.Substring(回傳值.IndexOf(',') + 1);
            if (放行碼 > 0)
            {
                放行 = true;
                this.放行碼 = 放行碼;
            }
            else
            {
                放行 = false;
                MessageBox.Show(輸入人員 + "正在修改本筆資料或進行轉單中，不得修改或刪除", "注意", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            return 放行;
        }
        public void 刪除放行碼()
        {
            if (放行碼 != 0)
            {
                增刪修bll.刪除放行碼(資料表名稱[0], 放行碼);
                放行碼 = 0;
            }
        }
        private string XmlToSql(string 類別, object 資料)
        {
            //XmlToSql<T>.WriteXml
            Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
            Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType(類別))
                .Where(type => type != null)
                .FirstOrDefault();
            Type writexml = typeof(XmlToSql<>).MakeGenericType(trgType);
            MethodInfo xmltosql = writexml.GetMethod("WriteXml");
            string 上傳資料 = (string)xmltosql.Invoke(null, new object[] { 資料 });
            return 上傳資料;
        }
        protected enum 新增修改 { A, E }
    }
}

