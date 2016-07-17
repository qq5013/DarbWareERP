using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using 數據庫連線;
using Model;
using System.IO;
using System.Xml.Linq;
using System.Reflection;

namespace 邏輯.視窗相關
{
    public delegate bool 新增修改刪除Delegate(CollectionViewSource[] cv, out string result);
    public class 新增修改刪除Bll
    {
        public bool UpdateData(CollectionViewSource[] cv, out string result, EnumStatus status)
        {
            新增修改刪除Delegate dele;
            bool value = true;
            dele = (新增修改刪除Delegate)Delegate.CreateDelegate(typeof(新增修改刪除Delegate), this, status.ToString());
            value = dele(cv, out result);
            return value;
        }
        private void 反射製作上傳資料(CollectionViewSource[] cv, string[] stringList, 新增修改 新增修改)
        {
            for (int i = 0; i < cv.Count(); i++)
            {
                if (cv[i] != null)
                {
                    DataTable dt = (DataTable)cv[i].Source;
                    表設定((i + 1).ToString(), dt, 新增修改);
                    Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
                    Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType("Model." + 視窗Model.資料表名稱[i]))
                        .Where(type => type != null)
                        .FirstOrDefault();
                    //List<T> list = (List<T>)DataTableToList<T>.ConvertToModel(dt);
                    Type generic = typeof(List<>);
                    Type constructor = generic.MakeGenericType(trgType);
                    dynamic listq = Activator.CreateInstance(constructor);
                    Type datatabletolistType = typeof(DataTableToList<>).MakeGenericType(trgType);
                    MethodInfo minfo = datatabletolistType.GetMethod("ConvertToModel");
                    listq = minfo.Invoke(null, new object[] { dt });

                    //string 上傳資料 = XmlToSql<T>.WriteXml(list);
                    Type writexml = typeof(XmlToSql<>).MakeGenericType(trgType);
                    MethodInfo xmltosql = writexml.GetMethod("WriteXml");
                    string 上傳用資料 = (string)xmltosql.Invoke(null, new object[] { listq });
                    stringList[i] = 上傳用資料;
                }
                else
                {
                    break;
                }
            }
        }
        private bool 新增(CollectionViewSource[] cv, out string result)
        {
            string 資料表名稱大寫 = Model.視窗Model.資料表名稱[0].ToUpper();
            string 資料表名稱小寫 = Model.視窗Model.資料表名稱[0].ToLower();
            string eventType = "INPUT-BB";
            string dataFunc = "Normal Add";
            string[] stringList = new string[5];
            反射製作上傳資料(cv, stringList, 新增修改.A);

            string table2 = 視窗Model.資料表名稱[1] == null ? "" : 視窗Model.資料表名稱[1];
            string table3 = 視窗Model.資料表名稱[2] == null ? "" : 視窗Model.資料表名稱[2];
            string table4 = 視窗Model.資料表名稱[3] == null ? "" : 視窗Model.資料表名稱[3];
            string table5 = 視窗Model.資料表名稱[4] == null ? "" : 視窗Model.資料表名稱[4];
            string data1 = stringList[0] == null ? "" : stringList[0];
            string data2 = stringList[1] == null ? "" : stringList[1];
            string data3 = stringList[2] == null ? "" : stringList[2];
            string data4 = stringList[3] == null ? "" : stringList[3];
            string data5 = stringList[4] == null ? "" : stringList[4];
            try
            {
                result = Log.Log_Sys_Input(eventType, 資料表名稱大寫, dataFunc, "",
                    資料表名稱小寫, table2, table3, table4, table5, data1, data2, data3, data4, data5);
                if (result.ToString().Contains("NG"))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                result = "儲存失敗";
                MessageBox.Show(ex.Message, result, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private bool 複製(CollectionViewSource[] cv, out string result)
        {
            return 新增(cv, out result);
        }
        private bool 修改(CollectionViewSource[] cv, out string result)
        {
            string 資料表名稱大寫 = Model.視窗Model.資料表名稱[0].ToUpper();
            string 資料表名稱小寫 = Model.視窗Model.資料表名稱[0].ToLower();
            string eventType = "INPUT-BE";
            string dataFunc = "Normal Edit";
            string[] stringList = new string[5];

            反射製作上傳資料(cv, stringList, 新增修改.E);
            string table2 = 視窗Model.資料表名稱[1] == null ? "" : 視窗Model.資料表名稱[1];
            string table3 = 視窗Model.資料表名稱[2] == null ? "" : 視窗Model.資料表名稱[2];
            string table4 = 視窗Model.資料表名稱[3] == null ? "" : 視窗Model.資料表名稱[3];
            string table5 = 視窗Model.資料表名稱[4] == null ? "" : 視窗Model.資料表名稱[4];
            string data1 = stringList[0] == null ? "" : stringList[0];
            string data2 = stringList[1] == null ? "" : stringList[1];
            string data3 = stringList[2] == null ? "" : stringList[2];
            string data4 = stringList[3] == null ? "" : stringList[3];
            string data5 = stringList[4] == null ? "" : stringList[4];
            try
            {
                result = Log.Log_Sys_Input(eventType, 資料表名稱大寫, dataFunc, "",
                    資料表名稱小寫, table2, table3, table4, table5, data1, data2, data3, data4, data5,
                    視窗Model.放行碼.ToString());
                if (result.ToString().Contains("NG"))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                result = "儲存失敗";
                MessageBox.Show(ex.Message, result, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool 刪除(string pkid)
        {
            string 資料表名稱大寫 = Model.視窗Model.資料表名稱[0].ToUpper();
            string 資料表名稱小寫 = Model.視窗Model.資料表名稱[0].ToLower();
            DataTable dt = 刪除表製作(pkid);
            Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
            Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType("Model." + 視窗Model.資料表名稱[0]))
                .Where(type => type != null)
                .FirstOrDefault();
            Type writexml = typeof(XmlToSql<>).MakeGenericType(trgType);
            MethodInfo xmltosql = writexml.GetMethod("一般DataTable轉XML");
            string 上傳資料 = (string)xmltosql.Invoke(null, new object[] { 資料表名稱小寫 + "delete.xml", dt });
            //string 上傳資料 = XmlToSql<T>.一般DataTable轉XML(資料表名稱小寫 + "delete.xml", dt);
            string result = Log.Log_Sys_Input("INPUT-BD", 資料表名稱大寫, "Normal Delete", "", 資料表名稱小寫, LP_DATA1: 上傳資料, LP_PERMITCODE: Model.視窗Model.放行碼.ToString());
            視窗Model.放行碼 = 0;
            return true;
        }
        private DataTable 刪除表製作(string pkid)
        {
            DataTable 上傳表 = new DataTable();
            上傳表.Columns.Add("srvdbid");
            上傳表.Columns.Add("pkid");
            DataRow dr = 上傳表.NewRow();
            dr["srvdbid"] = Log.srvdbid;
            dr["pkid"] = pkid;
            上傳表.Rows.Add(dr);
            上傳表.TableName = "tmpdata";
            return 上傳表;
        }
        public bool 取得放行碼(string pkid)
        {
            bool 放行 = false;
            int 放行碼 = 0;
            string 資料表名稱大寫 = Model.視窗Model.資料表名稱[0].ToUpper();
            string 資料表名稱小寫 = Model.視窗Model.資料表名稱[0].ToLower();
            string param1 = "N"; //將來要加入檢查工作流程                
            DataTable dt = 刪修放行表(放行碼.ToString(), 資料表名稱小寫, pkid, 資料表名稱大寫);

            Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
            Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType("Model." + 視窗Model.資料表名稱[0]))
                .Where(type => type != null)
                .FirstOrDefault();
            Type writexml = typeof(XmlToSql<>).MakeGenericType(trgType);
            MethodInfo xmltosql = writexml.GetMethod("一般DataTable轉XML");
            string 上傳資料 = (string)xmltosql.Invoke(null, new object[] { 資料表名稱小寫 + "delete放行碼.xml", dt });
            //string 上傳資料 = XmlToSql<T>.一般DataTable轉XML(資料表名稱小寫 + "delete放行碼.xml", dt);
            string result = Log.Log_Sys_Input("PERMIT-1", 資料表名稱大寫, "Normal Permit", param1, 資料表名稱小寫, LP_DATA1: 上傳資料);
            string 回傳值 = result.Substring(result.IndexOf('(') + 1, result.IndexOf(')') - result.IndexOf('(') - 1);
            放行碼 = int.Parse(回傳值.Substring(0, 回傳值.IndexOf(',')));
            string 輸入人員 = 回傳值.Substring(回傳值.IndexOf(',') + 1);
            if (放行碼 > 0)
            {
                放行 = true;
                視窗Model.放行碼 = 放行碼;
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
            if (視窗Model.放行碼 != 0)
            {
                string 資料表名稱大寫 = Model.視窗Model.資料表名稱[0].ToUpper();
                string 資料表名稱小寫 = Model.視窗Model.資料表名稱[0].ToLower();
                string param1 = "";
                string result = Log.Log_Sys_Input("PERMIT-X", 資料表名稱大寫, "Cancel Permit", param1, 資料表名稱小寫, LP_PERMITCODE: 視窗Model.放行碼.ToString());
                視窗Model.放行碼 = 0;
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
            dr["輸入人員"] = Log.使用者名稱;
            dr["輸入地點"] = Environment.MachineName;
            dr["增刪修"] = "";
            dr["選擇"] = "";
            dr["管制碼"] = 0;
            dr["srvdbid"] = Log.srvdbid;
            dr["pkid"] = 0;
            dr["logid"] = 0;
            dr["linkid"] = 0;
            dt.Rows.Add(dr);
            return dt;
        }
        private delegate void 表設定Delegate(DataTable dt);
        protected void 表設定(string 表, DataTable dt, 新增修改 新增修改)
        {
            表設定Delegate dele= (表設定Delegate)Delegate.CreateDelegate(typeof(表設定Delegate), this, "表" + 表 + "設定");
            dele.Invoke(dt);
            值設定(dt, 新增修改);
        }
        protected virtual void 表1設定(DataTable dt)
        {

        }
        protected virtual void 表2設定(DataTable dt)
        {

        }
        protected virtual void 表3設定(DataTable dt)
        {

        }
        protected virtual void 表4設定(DataTable dt)
        {

        }
        protected virtual void 表5設定(DataTable dt)
        {

        }
        protected void 值設定(DataTable dt, 新增修改 新增修改)
        {
            int rowCount = dt.Rows.Count;
            if (rowCount != 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    dt.Rows[i]["輸入人員"] = Log.使用者名稱;
                    dt.Rows[i]["輸入日期"] = DateTime.Now;
                    dt.Rows[i]["輸入地點"] = Environment.MachineName;
                    dt.Rows[i]["增刪修"] = 新增修改;
                    dt.Rows[i]["選擇"] = "";
                }
            }
        }
        protected enum 新增修改 { A, E }
    }
}
