using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Data;

namespace 邏輯
{
    public class 抓台銀匯率
    {
        public DataTable 匯率()
        {
            //要抓取的URL位址
            string Url = @"http://rate.bot.com.tw/Pages/Static/UIP003.zh-TW.htm";
            //得到指定Url的源碼
            string strWebContent = GetWebContent(Url);
            //抓上面的資料

            int iTableStart = strWebContent.IndexOf("<table title=\"牌告匯率\"");
            int iTableEnd = strWebContent.IndexOf("</table>", iTableStart);
            string strWeb = strWebContent.Substring(iTableStart, iTableEnd - iTableStart);
            WebBrowser web = new WebBrowser();
            web.Navigate("about:blank");
            HtmlDocument htmldoc = web.Document.OpenNew(true);
            htmldoc.Write(strWeb);
            HtmlElementCollection tr = htmldoc.GetElementsByTagName("tr");
            DataTable dt = new DataTable();                        
            dt.Columns.Add("幣別");
            dt.Columns.Add("幣別說明");
            dt.Columns.Add("現金買入");
            dt.Columns.Add("現金賣出");
            dt.Columns.Add("即期買入");
            dt.Columns.Add("即期賣出");
            for (int i = 2; i < tr.Count; i++)
            {                
                HtmlElementCollection td = tr[i].GetElementsByTagName("td");
                DataRow dr = dt.NewRow();
                int 左括號位置= td[0].InnerText.IndexOf("(");                
                int 右括號位置 = td[0].InnerText.IndexOf(")");
                int 字串長度 = 右括號位置-左括號位置-1;
                dr["幣別"] = td[0].InnerText.Substring(左括號位置+1, 字串長度);
                dr["幣別說明"]=  td[0].InnerText.Substring(0, 左括號位置);
                dr["現金買入"] = td[1].InnerText;
                dr["現金賣出"] = td[2].InnerText;
                dr["即期買入"] = td[3].InnerText;
                dr["即期賣出"] = td[4].InnerText;
                dt.Rows.Add(dr);
            }
            
            //foreach (HtmlElement qq in tr)
            //{
            //    HtmlElementCollection td = qq.GetElementsByTagName("td");
            //   DataRow dr= dt.NewRow();
            //    dr["幣別"] = qq.GetElementsByTagName("tr");
            //    dr["現金買入"] = td[0];
            //    dr["現金賣出"] = td[1];
            //    dr["即期買入"] = td[2];
            //    dr["即期賣出"] = td[3];
            //}
            return dt;
        }
        private string GetWebContent(string Url)
        {
            string strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //聲明一個HttpWebRequest請求
                request.Timeout = 6000;
                //設置連接逾時時間
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("GB2312");
                StreamReader streamReader = new StreamReader(streamReceive);
                strResult = streamReader.ReadToEnd();
            }
            catch
            {

            }
            return strResult;
        }
    }
}
