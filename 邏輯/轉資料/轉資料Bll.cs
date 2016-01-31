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
using System.Reflection;

namespace 邏輯.轉資料
{
    public class 轉資料Bll
    {
        DbfOdbc dbfodbc = new DbfOdbc();
        public string 轉Accl()
        {
            string 上傳資料;

            string location = @"C:/temps/accl.dbf";
            string sqlrp_m = @"SELECT * FROM " + location;
            DataTable dbf = dbfodbc.GetOdbcDbfDataTable(location, sqlrp_m);
            List<accl> accl = (List<accl>)DataTableToList<accl>.ConvertToModel(dbf);
            foreach (accl ac in accl)
            {
                ac.控制方式9 = "";
                ac.控制方式a = "";
                ac.關帳日期 = "";
                ac.品號抓群組 = "";
                ac.原科目代號 = "";
                ac.原科目名稱 = "";
                ac.選擇 = "";
                ac.增刪修 = "A";
                ac.srvdbid = 1;
            }
            上傳資料 = XmlToSql<accl>.WriteXml(accl);
            轉資料Dal dal = new 轉資料Dal("ACCL");
            dal.sheetno調整();
            dal.tableseq歸零("accl");
            string result = Log.Log_Sys_Input("INPUT-BB", "ACCL", "Normal Add", "", "accl", "", LP_DATA1: 上傳資料);
            dal.sheetno還原();
            return result;
        }
        public string 轉SliyNew()
        {
            string locationm = @"C:/temps/sliym.dbf";
            string sqlm = @"SELECT * FROM " + locationm + " order by 傳票號碼";
            DataTable dbfm;
            dbfm = dbfodbc.GetOdbcDbfDataTable(locationm, sqlm);
            亂碼檢查(dbfm);
            dbfm.Columns.Add("pkid", typeof(int));
            string locationd = @"C:/temps/sliy.dbf";
            string sqld = @"SELECT * FROM " + locationd + " order by 傳票號碼";
            DataTable dbfd;
            dbfd = dbfodbc.GetOdbcDbfDataTable(locationd, sqld);
            亂碼檢查(dbfd);
            dbfd.Columns.Add("linkid", typeof(int));
            List<sliym> sliym = (List<sliym>)DataTableToList<sliym>.ConvertToModel(dbfm);
            for (int i = 0; i < sliym.Count; i++)
            {
                sliym[i].公司代碼 = 1;
                sliym[i].帳別 = "B";
                sliym[i].功能幣匯率 = 1;
                sliym[i].集團幣匯率 = 1;
                sliym[i].專案代號a = "";
                sliym[i].轉入類別 = "";
                sliym[i].關係人傳票 = "N";
                sliym[i].聯絡單id = 0;
                sliym[i].工作流程 = "";
                sliym[i].審核人員 = "舊系統轉資料";
                sliym[i].審核日期 = "";
                sliym[i].已審核 = "Y";
                sliym[i].選擇 = "";
                sliym[i].增刪修 = "A";
                sliym[i].srvdbid = 1;
                sliym[i].pkid = i;
            }
            List<sliy有傳票號碼> sliy有 = (List<sliy有傳票號碼>)DataTableToList<sliy有傳票號碼>.ConvertToModel(dbfd);
            foreach (sliy有傳票號碼 sl in sliy有)
            {
                sl.本借方金額 = sl.借方金額;
                sl.本貸方金額 = sl.貸方金額;
                sl.功能幣匯率 = 1;
                sl.集借方金額 = sl.借方金額;
                sl.集貸方金額 = sl.貸方金額;
                sl.集團幣匯率 = 1;
                sl.產品群組 = "";
                sl.單別1 = "";
                sl.單號1 = "";
                sl.單別2 = "";
                sl.單號2 = "";
                sl.財務單id = 0;
                sl.財務明細id = 0;
                sl.品號 = "";
                sl.數量 = 0;
                sl.單位 = "";
                sl.單價 = 0;
                sl.折扣 = 0;
                sl.金額 = 0;
                sl.收付款日 = "";
                sl.到期日 = "";
                sl.選擇 = "";
                sl.增刪修 = "A";
                sl.srvdbid = 1;
            }
            int over = sliy有.Count;
            int index = 0;
            int count = 0;
            foreach (sliym s in sliym)
            {
                count = count + 1;
                string 傳票號碼 = s.傳票號碼;
                for (int i = index; i < over; i++)
                {
                    if (sliy有[i].傳票號碼 == s.傳票號碼)
                    {
                        sliy有[i].linkid = s.pkid;
                    }
                    else
                    {
                        index = i;
                        break;
                    }
                }
            }
            List<sliy> sliy = new List<Model.sliy>();
            foreach (sliy有傳票號碼 xc in sliy有)
            {
                sliy qq = new sliy();
                qq.序號 = xc.序號;
                qq.科目代號 = xc.科目代號;
                qq.幣別 = xc.幣別;
                qq.原借方金額 = xc.原借方金額;
                qq.原貸方金額 = xc.原貸方金額;
                qq.匯率 = xc.匯率;
                qq.本借方金額 = xc.本借方金額;
                qq.本貸方金額 = xc.本貸方金額;
                qq.功能幣匯率 = xc.功能幣匯率;
                qq.借方金額 = xc.借方金額;
                qq.貸方金額 = xc.貸方金額;
                qq.集團幣匯率 = xc.集團幣匯率;
                qq.集借方金額 = xc.集借方金額;
                qq.集貸方金額 = xc.集貸方金額;
                qq.摘要 = xc.摘要;
                qq.分類索引1 = xc.分類索引1;
                qq.分類索引2 = xc.分類索引2;
                qq.分類索引3 = xc.分類索引3;
                qq.項目編號 = xc.項目編號;
                qq.部門代號 = xc.部門代號;
                qq.客廠代號 = xc.客廠代號;
                qq.員工編號 = xc.員工編號;
                qq.專案代號 = xc.專案代號;
                qq.產品群組 = xc.產品群組;
                qq.單別1 = xc.單別1;
                qq.單號1 = xc.單號1;
                qq.單別2 = xc.單別2;
                qq.單號2 = xc.單號2;
                qq.財務單id = xc.財務單id;
                qq.財務明細id = xc.財務明細id;
                qq.品號 = xc.品號;
                qq.數量 = xc.數量;
                qq.單位 = xc.單位;
                qq.單價 = xc.單價;
                qq.折扣 = xc.折扣;
                qq.金額 = xc.金額;
                qq.收付款日 = xc.收付款日;
                qq.到期日 = xc.到期日;
                qq.輸入日期 = xc.輸入日期;
                qq.輸入人員 = xc.輸入人員;
                qq.輸入地點 = xc.輸入地點;
                qq.增刪修 = xc.增刪修;
                qq.選擇 = xc.選擇;
                qq.管制碼 = xc.管制碼;
                qq.srvdbid = xc.srvdbid;
                qq.pkid = xc.pkid;
                qq.logid = xc.logid;
                qq.linkid = xc.linkid;
                sliy.Add(qq);
            }
            dbfd.Dispose();
            dbfm.Dispose();
            string 上傳主檔, 上傳明細;
            int 主檔筆數 = sliym.Count;
            int 上傳筆數 = 1000;
            int 循環 = 主檔筆數 / 上傳筆數;
            int 明細紀錄=0;
            string result="";
            轉資料Dal dal = new 轉資料Dal("SLIY");
            dal.sheetno調整();
            dal.tableseq歸零("sliy");
            dal.tableseq歸零("sliym");
            for (int i = 0; i <= 循環; i++)
            {
                List<sliym> sm;
                if (i == 循環)
                {
                    int 筆數 = sliym.Count - 1000 * i;
                    sm = sliym.GetRange(1000 * i, 筆數);
                }
                else
                {
                    sm = sliym.GetRange(1000 * i, 上傳筆數);
                }
                int pkid = sm.Last().pkid;
                int sindex = sliy.FindLastIndex(x => x.linkid == pkid)+1;
                List<sliy> sd;

                    sd = sliy.GetRange(明細紀錄, sindex - 明細紀錄);
                
                明細紀錄 = sindex;
                上傳主檔 = XmlToSql<sliym>.WriteXml(sm);
                上傳明細 = XmlToSql<sliy>.WriteXml(sd);
                result = Log.Log_Sys_Input("INPUT-BB", "SLIY", "Normal Add", "", "sliym", "sliy", LP_DATA1: 上傳主檔, LP_DATA2: 上傳明細);
            }
            dal.sheetno還原();
            return result;
        }      
        private void 亂碼檢查(DataTable dbf)
        {
            foreach (DataColumn dc in dbf.Columns)
            {
                if (dc.DataType == typeof(string))
                {
                    foreach (DataRow dr in dbf.Rows)
                    {
                        if (dr[dc] != null)
                        {
                            string text = dr[dc].ToString();
                            foreach (char c in text)
                            {
                                int asciiInt = Convert.ToInt32(c);
                                if (asciiInt <= 31)
                                {
                                    int i = text.IndexOf(c);
                                    dr[dc] = text.Remove(i);
                                }
                            }
                        }
                    }
                }
            }
        }

        class sliy有傳票號碼 : sliy
        {
            public string 傳票號碼 { get; set; }
        }

    }
}
