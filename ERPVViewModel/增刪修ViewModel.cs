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

namespace ViewModel
{
    public delegate bool 新增複製修改Delegate(CollectionViewSource[] cv, out string result);
    public class 增刪修ViewModel
    {
        private bool _可以儲存 = true;
        public bool 可以儲存 { get { return _可以儲存; } set { _可以儲存 = value; } }
        public string Pkid { get; set; }
        string[] 資料表名稱;
        public int 放行碼 { get; set; }

        增刪修Bll 增刪修bll = new 增刪修Bll();
        public bool UpdateData(CollectionViewSource[] cv, out string result, 增刪修Status status, string[] 資料表名稱)
        {
            this.資料表名稱 = 資料表名稱;
            新增複製修改Delegate dele;
            bool value = true;
            dele = (新增複製修改Delegate)Delegate.CreateDelegate(typeof(新增複製修改Delegate), this, status.ToString());
            value = dele(cv, out result);
            return value;
        }
        private void 反射製作上傳資料(CollectionViewSource[] cv, string[] stringList, 新增修改 新增修改)
        {
            for (int i = 0; i < cv.Count(); i++)
            {
                if (cv[i] != null)
                {
                    object 資料表 = cv[i].Source;
                    string model資料表 = "Model." + 資料表名稱[i].Substring(0, 1).ToUpper() + 資料表名稱[i].Substring(1).ToLower() + "Model";
                    Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
                    Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType(model資料表))
                        .Where(type => type != null)
                        .FirstOrDefault();

                    //string 上傳資料 = XmlToSql<T>.WriteXml(list);                    
                    Type writexml = typeof(XmlToSql<>).MakeGenericType(trgType);
                    MethodInfo xmltosql = writexml.GetMethod("WriteXml");
                    PropertyInfo prop = 資料表.GetType().GetProperty("Item");
                    var list = 值設定(cv[i], trgType, 資料表名稱[i], 新增修改);
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
        private bool 新增(CollectionViewSource[] cv, out string result)
        {
            string 資料表名稱大寫 = 資料表名稱[0].ToUpper();
            string eventType = "INPUT-BB";
            string dataFunc = "Normal Add";
            string[] stringList = new string[5];
            反射製作上傳資料(cv, stringList, 新增修改.A);
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
                    table2, table3, table4, table5, data1, data2, data3, data4, data5);
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
        private bool 複製(CollectionViewSource[] cv, out string result)
        {
            return 新增(cv, out result);
        }
        private bool 修改(CollectionViewSource[] cv, out string result)
        {
            result = "";
            return true;

            //    string 資料表名稱大寫 = Model.視窗Model.資料表名稱[0].ToUpper();
            //    string 資料表名稱小寫 = Model.視窗Model.資料表名稱[0].ToLower();
            //    string eventType = "INPUT-BE";
            //    string dataFunc = "Normal Edit";
            //    string[] stringList = new string[5];

            //    反射製作上傳資料(cv, stringList, 新增修改.E);
            //    string table2 = 視窗Model.資料表名稱[1] == null ? "" : 視窗Model.資料表名稱[1];
            //    string table3 = 視窗Model.資料表名稱[2] == null ? "" : 視窗Model.資料表名稱[2];
            //    string table4 = 視窗Model.資料表名稱[3] == null ? "" : 視窗Model.資料表名稱[3];
            //    string table5 = 視窗Model.資料表名稱[4] == null ? "" : 視窗Model.資料表名稱[4];
            //    string data1 = stringList[0] == null ? "" : stringList[0];
            //    string data2 = stringList[1] == null ? "" : stringList[1];
            //    string data3 = stringList[2] == null ? "" : stringList[2];
            //    string data4 = stringList[3] == null ? "" : stringList[3];
            //    string data5 = stringList[4] == null ? "" : stringList[4];
            //    try
            //    {
            //        result = Log.Log_Sys_Input(eventType, 資料表名稱大寫, dataFunc, "",
            //            資料表名稱小寫, table2, table3, table4, table5, data1, data2, data3, data4, data5,
            //            視窗Model.放行碼.ToString());
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
        }
        public bool 刪除()
        {
            //string 資料表名稱大寫 = Model.視窗Model.資料表名稱[0].ToUpper();
            //string 資料表名稱小寫 = Model.視窗Model.資料表名稱[0].ToLower();
            //DataTable dt = 刪除表製作(pkid);
            //Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
            //Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType("Model." + 視窗Model.資料表名稱[0]))
            //    .Where(type => type != null)
            //    .FirstOrDefault();
            //Type writexml = typeof(XmlToSql<>).MakeGenericType(trgType);
            //MethodInfo xmltosql = writexml.GetMethod("一般DataTable轉XML");
            //string 上傳資料 = (string)xmltosql.Invoke(null, new object[] { 資料表名稱小寫 + "delete.xml", dt });
            //string 上傳資料 = XmlToSql<T>.一般DataTable轉XML(資料表名稱小寫 + "delete.xml", dt);
            //string result = Log.Log_Sys_Input("INPUT-BD", 資料表名稱大寫, "Normal Delete", "", 資料表名稱小寫, LP_DATA1: 上傳資料, LP_PERMITCODE: Model.視窗Model.放行碼.ToString());
            //視窗Model.放行碼 = 0;
            return true;
        }
        private DataTable 刪除表製作(string pkid)
        {
            DataTable 上傳表 = new DataTable();
            上傳表.Columns.Add("srvdbid");
            上傳表.Columns.Add("pkid");
            DataRow dr = 上傳表.NewRow();
            //dr["srvdbid"] = Log.srvdbid;
            dr["pkid"] = pkid;
            上傳表.Rows.Add(dr);
            上傳表.TableName = "tmpdata";
            return 上傳表;
        }
        public bool 取得放行碼(string pkid)
        {
            //bool 放行 = false;
            //int 放行碼 = 0;
            //string 資料表名稱大寫 = Model.視窗Model.資料表名稱[0].ToUpper();
            //string 資料表名稱小寫 = Model.視窗Model.資料表名稱[0].ToLower();
            //string param1 = "N"; //將來要加入檢查工作流程                
            //DataTable dt = 刪修放行表(放行碼.ToString(), 資料表名稱小寫, pkid, 資料表名稱大寫);

            //Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
            //Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType("Model." + 視窗Model.資料表名稱[0]))
            //    .Where(type => type != null)
            //    .FirstOrDefault();
            //Type writexml = typeof(XmlToSql<>).MakeGenericType(trgType);
            //MethodInfo xmltosql = writexml.GetMethod("一般DataTable轉XML");
            //string 上傳資料 = (string)xmltosql.Invoke(null, new object[] { 資料表名稱小寫 + "delete放行碼.xml", dt });
            ////string 上傳資料 = XmlToSql<T>.一般DataTable轉XML(資料表名稱小寫 + "delete放行碼.xml", dt);
            //string result = Log.Log_Sys_Input("PERMIT-1", 資料表名稱大寫, "Normal Permit", param1, 資料表名稱小寫, LP_DATA1: 上傳資料);
            //string 回傳值 = result.Substring(result.IndexOf('(') + 1, result.IndexOf(')') - result.IndexOf('(') - 1);
            //放行碼 = int.Parse(回傳值.Substring(0, 回傳值.IndexOf(',')));
            //string 輸入人員 = 回傳值.Substring(回傳值.IndexOf(',') + 1);
            //if (放行碼 > 0)
            //{
            //    放行 = true;
            //    視窗Model.放行碼 = 放行碼;
            //}
            //else
            //{
            //    放行 = false;
            //    MessageBox.Show(輸入人員 + "正在修改本筆資料或進行轉單中，不得修改或刪除", "注意", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //}
            //return 放行;
            return true;
        }
        public void 刪除放行碼()
        {
            if (放行碼 != 0)
            {

                增刪修bll.刪除放行碼(資料表名稱[0], 放行碼);
                放行碼 = 0;
            }
        }
        private DataTable 刪修放行表(string 放行碼, string 資料表名稱, string 放行pkid, string dataevent)
        {
            DataSet ds = new DataSet("VFPData");
            DataTable dt = new DataTable("tmpdata");
            ds.Tables.Add(dt);
            dt.Columns.Add("放行碼");
            dt.Columns.Add("資料表名稱");
            dt.Columns.Add("放行pkid");
            dt.Columns.Add("dataevent");
            dt.Columns.Add("輸入日期");
            dt.Columns.Add("輸入人員");
            dt.Columns.Add("輸入地點");
            dt.Columns.Add("增刪修");
            dt.Columns.Add("選擇");
            dt.Columns.Add("管制碼");
            dt.Columns.Add("srvdbid");
            dt.Columns.Add("pkid");
            dt.Columns.Add("logid");
            dt.Columns.Add("linkid");
            DataRow dr = dt.NewRow();
            dr["放行碼"] = 放行碼;
            dr["資料表名稱"] = 資料表名稱;
            dr["放行pkid"] = 放行pkid;
            dr["dataevent"] = dataevent;
            dr["輸入日期"] = "";
            //dr["輸入人員"] = Log.使用者名稱;
            dr["輸入地點"] = Environment.MachineName;
            dr["增刪修"] = "";
            dr["選擇"] = "";
            dr["管制碼"] = 0;
            //dr["srvdbid"] = Log.srvdbid;
            dr["pkid"] = 0;
            dr["logid"] = 0;
            dr["linkid"] = 0;
            dt.Rows.Add(dr);
            return dt;
        }
        //private delegate void 表設定Delegate(DataTable dt);
        //protected void 表設定(string 表, DataTable dt, 新增修改 新增修改)
        //{
        //    表設定Delegate dele = (表設定Delegate)Delegate.CreateDelegate(typeof(表設定Delegate), this, "表" + 表 + "設定");
        //    dele.Invoke(dt);
        //    值設定(dt, 新增修改);
        //}
        //protected virtual void 表1設定(DataTable dt)
        //{

        //}
        //protected virtual void 表2設定(DataTable dt)
        //{

        //}
        //protected virtual void 表3設定(DataTable dt)
        //{

        //}
        //protected virtual void 表4設定(DataTable dt)
        //{

        //}
        //protected virtual void 表5設定(DataTable dt)
        //{

        //}

        protected enum 新增修改 { A, E }
    }
}

