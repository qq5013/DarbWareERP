using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using 邏輯Bll;
using 邏輯Bll.視窗相關;
using 邏輯Bll.訊息相關;

namespace DarbWareERP.瀏覽系列
{
    class 瀏覽
    {
        string[] 資料表名稱;
        public string 程式名稱 { get; set; }
        List<string> 條件編號 = null;
        public List<string> 條件說明
        {
            get; set;
        }
        public ObservableCollection<欄位編號列表> 欄位編號列表
        {
            get; set;
        }
        public ObservableCollection<運算子編號列表> 運算子編號列表
        {
            get; set;
        }
        private ObservableCollection<瀏覽下方查詢> _下方查詢list = new ObservableCollection<瀏覽下方查詢>();
        public ObservableCollection<瀏覽下方查詢> 下方查詢list
        {
            get
            {
                return _下方查詢list;
            }
            set
            {
                _下方查詢list = value;
            }
        }
        public 瀏覽(string[] 資料表名稱)
        {
            this.資料表名稱 = 資料表名稱;
        }
        public void 查詢區域賦值(string browsetype, int no, DataGridComboBoxColumn 欄位Column, DataGridComboBoxColumn 運算子Column)
        {
            下方查詢list.Clear();
            DataTable 自訂條件欄位 = 查詢LCL所在位置("LCL自訂條件欄位");
            DataTable 運算子 = 查詢LCL所在位置("LCL運算子");
            DataTable 原始 = 查詢LCL所在位置("LCL原始自訂條件");
            if (欄位編號列表 == null && 運算子編號列表 == null)
            {
                DataRow[] drs = 自訂條件欄位.Select("瀏覽類別 = '" + browsetype + "'");
                if (drs.Count() != 0)
                {
                    欄位編號列表 = new ObservableCollection<瀏覽系列.欄位編號列表>(DataTableToList<欄位編號列表>.ConvertToModel(drs.CopyToDataTable()));
                }
                else
                {
                    List<瀏覽系列.欄位編號列表> 欄位編號列表list = new List<瀏覽系列.欄位編號列表>();
                    Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
                    Type trgType = AssembliesLoaded.Select(assembly => assembly.GetType("Model." + this.資料表名稱[0]))
                        .Where(type => type != null)
                        .FirstOrDefault();
                    PropertyInfo[] pis= trgType.GetProperties();                    
                    for (int i = 0; i < pis.Count(); i++)
                    {
                        瀏覽系列.欄位編號列表 m = new 瀏覽系列.欄位編號列表();
                        m.欄位編號 = i + 1;
                        m.欄位說明 = pis[i].Name;
                        欄位編號列表list.Add(m);
                    }
                    欄位編號列表 = new ObservableCollection<瀏覽系列.欄位編號列表>(欄位編號列表list);
                }
                運算子編號列表 = new ObservableCollection<瀏覽系列.運算子編號列表>(DataTableToList<運算子編號列表>.ConvertToModel(運算子));
                欄位Column.ItemsSource = 欄位編號列表;
                運算子Column.ItemsSource = 運算子編號列表;
                //ItemSource只能設定一次不然會前面的筆數會出錯
            }
            if (條件編號 != null)
            {
                DataRow[] 原始編號 = 原始.Select("編號 = '" + 條件編號[no] + "'");
                for (int i = 0; i < 原始編號.Count(); i++)
                {
                    DataRow[] rows自訂條件欄位 = 自訂條件欄位.Select("瀏覽類別 = '" + browsetype + "' and 欄位編號 = '" + 原始編號[i]["欄位編號"] + "'");
                    string 欄位說明 = rows自訂條件欄位.FirstOrDefault()["欄位說明"].ToString();
                    DataRow[] rows運算子 = 運算子.Select("運算子編號 = '" + 原始編號[i]["運算子編號"] + "'");
                    string 運算子說明 = rows運算子.FirstOrDefault()["運算子說明"].ToString();
                    string 欄位type = 尋找欄位type(欄位說明);

                    瀏覽下方查詢 browse = new 瀏覽下方查詢();
                    browse.序號 = (i + 1).ToString();
                    browse.欄位編號 = 原始編號[i]["欄位編號"].ToString();
                    browse.欄位說明 = 欄位說明;
                    browse.運算子編號 = 原始編號[i]["運算子編號"].ToString();
                    browse.運算子說明 = 運算子說明;
                    browse.起始值 = 原始編號[i]["值1"].ToString();
                    browse.截止值 = 原始編號[i]["值2"].ToString();
                    browse.欄位TYPE = 欄位type;
                    browse.欄位編號列表 = 欄位編號列表;
                    browse.運算子編號列表 = 運算子編號列表;
                    下方查詢list.Add(browse);
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    瀏覽下方查詢 browse = new 瀏覽下方查詢();
                    browse.序號 = (i + 1).ToString();
                    browse.欄位編號 = 欄位編號列表[0].欄位編號.ToString();
                    browse.欄位說明 = 欄位編號列表[0].欄位說明;
                    browse.運算子編號 = 運算子編號列表[2].運算子編號;
                    browse.運算子說明 = 運算子編號列表[2].運算子說明;
                    browse.起始值 = "QWERT";
                    browse.截止值 = "";
                    browse.欄位TYPE = 尋找欄位type(欄位編號列表[0].欄位說明);
                    browse.欄位編號列表 = 欄位編號列表;
                    browse.運算子編號列表 = 運算子編號列表;
                    下方查詢list.Add(browse);
                }
            }
        }
        public DataTable 查詢LCL所在位置(string 查詢字串)
        {
            DataTable dt;
            DataRow[] dr = 視窗Bll.登入暫存表.Tables[0].Select("資料表別名 = '" + 查詢字串 + "'");
            int no = 視窗Bll.登入暫存表.Tables[0].Rows.IndexOf(dr[0]);
            dt = 視窗Bll.登入暫存表.Tables[1 + no];
            return dt;
        }
        public void cbx預設條件賦值(string browsetype, ComboBox cbx)
        {
            DataTable 自訂條件別 = 查詢LCL所在位置("LCL自訂條件別");
            if (browsetype == "" || browsetype==null)
            {
                DataRow[] dr權限 = 視窗Bll.權限表.Select("程式名稱 = '" + 程式名稱 + "'");
                string 編號 = dr權限[0]["序號"].ToString();
                編號 = 編號.Substring(0, 編號.IndexOf("-")) + 編號.Substring(編號.IndexOf("-") + 1) + "B";
                cbx.ItemsSource = 自訂條件別.Select("編號 LIKE '%" + 編號 + "%'");
            }
            else
            {
                DataRow[] drs = 自訂條件別.Select("編號 LIKE '%" + browsetype + "%'");
                條件編號 = new List<string>();
                條件說明 = new List<string>();
                foreach (DataRow row in drs)
                {
                    條件編號.Add(row["編號"].ToString());
                    條件說明.Add(row["類別"].ToString());
                }
                cbx.DataContext = 條件編號;
            }            
        }
        public string 尋找欄位type(string 要查詢欄位)
        {
            string result = "";
            try
            {
                Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "Model");
                for (int j = 0; j < 資料表名稱.Count(); j++)
                {
                    Type type = assembly.GetType(assembly.GetName().Name + "." + 資料表名稱[j]);
                    PropertyInfo[] f = type.GetProperties();
                    PropertyInfo ff = f.FirstOrDefault(x => x.Name == 要查詢欄位);
                    if (ff != null)
                    {
                        result = ff.PropertyType.Name;
                        break;
                    }
                }
            }
            catch
            {
                邏輯Bll.訊息相關.錯誤訊息Bll.錯誤訊息顯示(1);
            }
            return result;
        }
        public string 查詢條件產生(ObservableCollection<瀏覽下方查詢> searchlist)
        {
            StringBuilder 查詢條件 = new StringBuilder();
            foreach (var search in searchlist)
            {
                switch (search.運算子編號)
                {
                    case "A": //介於之間
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                查詢條件.Append(search.欄位說明 + " between " + "'" + search.起始值 + "' and '" + search.截止值 + "zzzzzz'");
                                break;
                            case "DateTime":
                                查詢條件.Append(search.欄位說明 + " between " + search.起始值 + " and " + search.截止值);
                                break;
                            default:
                                查詢條件.Append(search.欄位說明 + " between " + search.起始值 + " and " + search.截止值);
                                break;
                        }
                        break;
                    case "B": //等於
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                查詢條件.Append(search.欄位說明 + " like " + "'" + search.起始值 + "%'");
                                break;
                            case "DateTime":
                                查詢條件.Append(search.欄位說明 + " >= " + search.起始值 + " and " + search.欄位說明 + " < " + search.截止值);
                                break;
                            default:
                                查詢條件.Append(search.欄位說明 + " = " + "'" + search.起始值 + "'");
                                break;
                        }
                        break;
                    case "C": //不等於
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                查詢條件.Append(search.欄位說明 + " not like " + "'" + search.起始值 + "%'");
                                break;
                            case "DateTime":
                                查詢條件.Append(search.欄位說明 + " < " + search.起始值 + " OR " + search.欄位說明 + " >= " + search.截止值);
                                break;
                            default:
                                查詢條件.Append(search.欄位說明 + " <> " + search.起始值);
                                break;
                        }
                        break;
                    case "D": //大於
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                查詢條件.Append(search.欄位說明 + " > " + "'" + search.起始值 + "'");
                                break;
                            case "DateTime":
                                查詢條件.Append(search.欄位說明 + " > " + search.起始值);
                                break;
                            default:
                                查詢條件.Append(search.欄位說明 + " > " + search.起始值);
                                break;
                        }
                        break;
                    case "E": //大於等於
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                查詢條件.Append(search.欄位說明 + " >= " + "'" + search.起始值 + "'");
                                break;
                            case "DateTime":
                                查詢條件.Append(search.欄位說明 + " >= " + search.起始值);
                                break;
                            default:
                                查詢條件.Append(search.欄位說明 + " >= " + search.起始值);
                                break;
                        }
                        break;
                    case "F": //小於
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                查詢條件.Append(search.欄位說明 + " < " + "'" + search.起始值 + "'");
                                break;
                            case "DateTime":
                                查詢條件.Append(search.欄位說明 + " < " + search.起始值);
                                break;
                            default:
                                查詢條件.Append(search.欄位說明 + " < " + search.起始值);
                                break;
                        }
                        break;
                    case "G": //小於等於
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                查詢條件.Append(search.欄位說明 + " <= " + "'" + search.起始值 + "'");
                                break;
                            case "DateTime":
                                查詢條件.Append(search.欄位說明 + " <= " + search.起始值);
                                break;
                            default:
                                查詢條件.Append(search.欄位說明 + " <= " + search.起始值);
                                break;
                        }
                        break;
                    case "H": //包含
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                查詢條件.Append(search.欄位說明 + " like " + "'%" + search.起始值 + "%'");
                                break;
                            case "DateTime":
                                IFormatProvider culture = new CultureInfo("zh-TW", true);
                                DateTime time;
                                if (DateTime.TryParseExact(search.起始值, "yyyyMMdd", culture, DateTimeStyles.None, out time))
                                {
                                    time = time.AddDays(1);
                                    查詢條件.Append(search.欄位說明 + " >= " + search.起始值 + " and " + search.欄位說明 + " < " + time.ToShortDateString());
                                }
                                else
                                {
                                    錯誤訊息Bll.錯誤訊息顯示(2);
                                }
                                break;
                            default:
                                查詢條件.Append(search.欄位說明 + " = " + search.起始值);
                                break;
                        }
                        break;
                    case "I": //不含
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                查詢條件.Append("Not " + search.欄位說明 + " like " + "'%" + search.起始值 + "%'");
                                break;
                            case "DateTime":
                                IFormatProvider culture = new CultureInfo("zh-TW", true);
                                DateTime time;
                                if (DateTime.TryParseExact(search.起始值, "yyyyMMdd", culture, DateTimeStyles.None, out time))
                                {
                                    time = time.AddDays(1);
                                    查詢條件.Append(search.欄位說明 + " < " + search.起始值 + " and " + search.欄位說明 + " > " + time.ToShortDateString());
                                }
                                else
                                {
                                    錯誤訊息Bll.錯誤訊息顯示(2);
                                }
                                break;
                            default:
                                查詢條件.Append(search.欄位說明 + " <> " + search.起始值);
                                break;
                        }
                        break;
                    case "J": //位於其中
                        string[] 分割後字串 = search.起始值.Split(',');
                        int 總數 = 分割後字串.Count();
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                string 條件 = "";
                                for (int i = 0; i < 總數; i++)
                                {
                                    條件 = 條件 + search.欄位說明 + " like " + "'%" + 分割後字串[i] + "%'";
                                    if (i != 總數 - 1)
                                    {
                                        條件 = 條件 + " or ";
                                    }
                                }
                                查詢條件.Append(條件);
                                break;
                            case "DateTime":
                                string 日期欄位的條件 = "";
                                for (int i = 0; i < 總數; i++)
                                {
                                    日期欄位的條件 = 日期欄位的條件 + 分割後字串[i].Trim();
                                    if (i != 總數 - 1)
                                    {
                                        日期欄位的條件 = 日期欄位的條件 + ",";
                                    }
                                }
                                日期欄位的條件 = "convert(nchar(10)," + search.欄位說明 + ",111" + " In (" + 日期欄位的條件 + ")";
                                查詢條件.Append(日期欄位的條件);
                                break;
                            default:
                                string 數字欄位的條件 = "";
                                for (int i = 0; i < 總數; i++)
                                {
                                    數字欄位的條件 = 數字欄位的條件 + 分割後字串[i].Trim();
                                    if (i != 總數 - 1)
                                    {
                                        數字欄位的條件 = 數字欄位的條件 + ",";
                                    }
                                }
                                數字欄位的條件 = search.欄位說明 + " In (" + 數字欄位的條件 + ")";
                                查詢條件.Append(數字欄位的條件);
                                break;
                        }
                        break;
                    case "K": //等於空白
                        switch (search.欄位TYPE)
                        {
                            case "String":
                                查詢條件.Append("LEN(RTRIM(LTRIM(" + search.欄位說明 + ")))=0");
                                break;
                            case "DateTime":
                                break;
                            default:
                                查詢條件.Append(search.欄位說明 + " = 0");
                                break;
                        }
                        break;
                    case "L": //等於NULL               
                        查詢條件.Append(search.欄位說明 + " IS NULL");
                        break;
                    case "M": //考慮本條件                       
                        MessageBox.Show("還未新增");
                        break;
                    case "N": //不考慮本條件                       
                        MessageBox.Show("還未新增");
                        break;
                }
                查詢條件.Append(" AND ");
            }
            查詢條件.Remove(查詢條件.Length - 4, 4);
            return 查詢條件.ToString();
        }
    }
}
