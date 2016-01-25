using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Model;
using 數據庫連線;

namespace 邏輯.轉資料
{
    public class 轉資料Bll
    {
        DbfOdbc dbfodbc = new DbfOdbc();
        DataTable dbf;
        public void 轉Accl()
        {
            string location = @"C:/temps/accl.dbf";
            string sqlrp_m = @"SELECT * FROM " + location;
            dbf = dbfodbc.GetOdbcDbfDataTable(location, sqlrp_m);
            List<accl> accl = (List<accl>)DataTableToList<accl>.ConvertToModel(dbf);
            string 上傳資料 =  XmlToSql<accl>.WriteXml(accl);

            //dbf.TableName = "dbf";
            //foreach (DataColumn dc in dbf.Columns)
            //{
            //    dc.ColumnMapping = MappingType.Attribute;
            //}
            //DataSet ds = new DataSet("dbf");
            //ds.Tables.Add(dbf);
            //XmlWriterSettings setting = new XmlWriterSettings();
            //setting.OmitXmlDeclaration = true;
            //setting.Indent = true;
            //setting.NewLineOnAttributes = true;
            //XmlWriter xw = XmlWriter.Create(@"C:/轉資料/accl.xml", setting);
            //dbf.WriteXml(xw);
            //xw.Dispose();
            //XDocument xd = XDocument.Load(@"C:/轉資料/accl.xml");
            //Log.Log_Sys_Input("INPUT-BB", "BCURRENM", "Normal Add", "", "bcurrenm", "bcurrend", LP_DATA1: xd.Document.ToString());           
        }        
        
    }
}
