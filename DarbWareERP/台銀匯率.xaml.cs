using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using 邏輯;
using System.Data;
using 數據庫連線;
using System.Xml;
using System.Xml.Linq;
using DarbWareERP.繼承窗口;

namespace DarbWareERP
{
    /// <summary>
    /// 台銀匯率.xaml 的互動邏輯
    /// </summary>
    public partial class 台銀匯率 : 視窗繼承
    {
        public 台銀匯率()
        {
            InitializeComponent();
        }

        private void btn抓匯率_Click(object sender, RoutedEventArgs e)
        {
            抓台銀匯率 exchange = new 抓台銀匯率();
            dataGrid.ItemsSource = exchange.匯率().DefaultView;
        }

        private void btn插入資料庫_Click(object sender, RoutedEventArgs e)
        {
            string 訊息;
            資料庫抓幣別(out 訊息);
            MessageBox.Show(訊息);
        }

        private void 資料庫抓幣別(out string 訊息)
        {
            DataSet ds = Log.Log_Sys_Exec("BCURRENBrowse", "DARB_BROWSE", "BCURREN", "序號 <> 0", "2", "0");
            DataTable 資料庫的幣別 = ds.Tables[0];
            DataTable 台銀匯率 = ((DataView)dataGrid.ItemsSource).Table;
            DataTable 上傳明細 = 明細datatable();
            DataTable 主檔 = 主檔datatable();
            訊息 = 匯入明細資料(資料庫的幣別, 台銀匯率, 上傳明細);
            dataGrid1.ItemsSource = 上傳明細.DefaultView;
            XDocument 上傳明細表 = 寫成XML(上傳明細, "匯率明細");
            主檔資料設定(主檔);
            XDocument 上傳主檔 = 寫成XML(主檔, "匯率主檔");            
            string 傳回訊息 = 訊息 + Log.Log_Sys_Input("INPUT-BB", "BCURRENM", "Normal Add", "", "bcurrenm", "bcurrend", LP_DATA1: 上傳主檔.Document.ToString(), LP_DATA2: 上傳明細表.Document.ToString());
            MessageBox.Show(傳回訊息);
        }

        private void 主檔資料設定(DataTable 主檔)
        {
            string 目前時間 = DateTime.Now.ToShortDateString();
            string 明天 = DateTime.Now.AddDays(1).ToShortDateString();
            主檔.Rows.Add("+++", 目前時間, "", 明天, 2, "", "令狐沖", Environment.MachineName, "A", "", 0, 1, 0, 0, 0);
        }

        private XDocument 寫成XML(DataTable 上傳表, string 檔名)
        {
            DataSet VFPDATA = new DataSet("VFPData");
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.OmitXmlDeclaration = true;
            setting.Indent = true;
            setting.NewLineOnAttributes = true;
            VFPDATA.Tables.Add(上傳表);
            XmlWriter xw = XmlWriter.Create(@"f:\" + 檔名 + ".xml", setting);
            上傳表.TableName = "tmpdata";
            上傳表.WriteXml(xw);
            xw.Dispose();
            XDocument xd = XDocument.Load(@"f:\" + 檔名 + ".xml");
            return xd;
        }

        private string 匯入明細資料(DataTable 資料庫的幣別, DataTable 台銀匯率, DataTable 上傳明細)
        {
            string 訊息 = "";
            for (int i = 0; i < 資料庫的幣別.Rows.Count; i++)
            {
                string 條件 = "幣別 ='" + 資料庫的幣別.Rows[i]["幣別"].ToString() + "'";
                if (台銀匯率.Select(條件).Count() == 0)
                {
                    訊息 = 訊息 + "台銀匯率表沒有" + 資料庫的幣別.Rows[i]["幣別"].ToString() + "此匯率;";
                }
                else
                {
                    DataRow dr = 台銀匯率.Select(條件).First();
                    DataRow 上傳row = 上傳明細.NewRow();
                    上傳row["幣別"] = dr["幣別"];
                    decimal 買入 = Convert.ToDecimal(dr["即期買入"]);
                    decimal 賣出 = Convert.ToDecimal(dr["即期賣出"]);
                    decimal 中 = (Convert.ToDecimal(dr["即期買入"]) + Convert.ToDecimal(dr["即期賣出"])) / 2;
                    上傳row["買"] = 買入.ToString("#0.0000");
                    上傳row["賣"] = 賣出.ToString("#0.0000");
                    上傳row["中"] = 中.ToString("#0.0000");
                    上傳row["輸入日期"] = "";
                    上傳row["輸入人員"] = "令狐沖";
                    上傳row["輸入地點"] = Environment.MachineName;
                    上傳row["增刪修"] = "A";
                    上傳row["選擇"] = "";
                    上傳row["管制碼"] = 0;
                    上傳row["srvdbid"] = 1;
                    上傳row["pkid"] = 0;
                    上傳row["logid"] = 0;
                    上傳row["linkid"] = 0;
                    上傳明細.Rows.Add(上傳row);
                }
            }
            訊息 = "上傳成功，但是" + 訊息;
            return 訊息;
        }

        private DataTable 主檔datatable()
        {
            DataTable dt = new DataTable("tmpdata");
            dt.Columns.Add("單號");
            dt.Columns.Add("起始日期");
            dt.Columns.Add("截止日期");
            dt.Columns.Add("使用日期");
            dt.Columns.Add("類別");
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
            foreach (DataColumn dc in dt.Columns)
            {
                dc.ColumnMapping = MappingType.Attribute;
            }
            return dt;

        }
        private DataTable 明細datatable()
        {
            DataTable dt = new DataTable("tmpdata");
            dt.Columns.Add("幣別");
            dt.Columns.Add("買");
            dt.Columns.Add("賣");
            dt.Columns.Add("中");
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
            foreach (DataColumn dc in dt.Columns)
            {
                dc.ColumnMapping = MappingType.Attribute;
            }
            return dt;
        }
    }
}
