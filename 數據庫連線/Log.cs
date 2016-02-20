using System;
using System.Data;
using System.Data.SqlClient;

namespace 數據庫連線
{
    public static class Log
    {

        public static string 使用者代號 { get; set; }
        public static string 使用者名稱 { get; set; }
        public static int LogBookId { get; set; }
        private static DataTable _權限表 = new DataTable(); //配合usercontrol，設計
        public static DataTable 權限表 { get { return _權限表; } set { _權限表 = value; } } //登入成功時賦值
        public static string 資料庫
        {
            get
            { return Properties.Settings.Default.資料庫名稱; }
        }

        static string DataSource = Properties.Settings.Default.DataSource,
                Database = Properties.Settings.Default.DataBase,
                UserID = Properties.Settings.Default.UserId,
                Password = Properties.Settings.Default.PassWord;
        public static SqlConnection conn = new SqlConnection
        {
            ConnectionString = "Data Source=" + DataSource + ";" +
                          "Initial Catalog=" + Database + ";" + "User ID=" + UserID + ";" +
                          "Password=" + Password + ";"
        };
        public static DataSet Log_Sys_Exec(string LP_DATAEVENT, string LP_DATAFUNC,
            string LP_P1, string LP_P2, string LP_P3 = "", string LP_P4 = "", string LP_P5 = "", string LP_P6 = "",
            string LP_P7 = "", string LP_P8 = "", string LP_P9 = "", string LP_P10 = "", string LP_P11 = "",
            string LP_P12 = "")
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "DARB_LOG_SYS_EXEC";
            cmd.Parameters.AddWithValue("@languagen", "");
            cmd.Parameters.AddWithValue("@eventtype", "Exec Proc");
            cmd.Parameters.AddWithValue("@dataevent", LP_DATAEVENT);
            cmd.Parameters.AddWithValue("@datafunc", LP_DATAFUNC);
            cmd.Parameters.Add(new SqlParameter("@param1", SqlDbType.NVarChar, 200)).Value = LP_P1;
            cmd.Parameters["@param1"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters.AddWithValue("@param2", LP_P2);
            cmd.Parameters.AddWithValue("@param3", LP_P3);
            cmd.Parameters.AddWithValue("@param4", LP_P4);
            cmd.Parameters.AddWithValue("@param5", LP_P5);
            cmd.Parameters.AddWithValue("@param6", LP_P6);
            cmd.Parameters.AddWithValue("@param7", LP_P7);
            cmd.Parameters.AddWithValue("@param8", LP_P8);
            cmd.Parameters.AddWithValue("@param9", LP_P9);
            cmd.Parameters.AddWithValue("@param10", LP_P10);
            cmd.Parameters.AddWithValue("@param11", LP_P11);
            cmd.Parameters.AddWithValue("@param12", LP_P12);
            cmd.Parameters.AddWithValue("@inputstaff", 使用者名稱);
            cmd.Parameters.AddWithValue("@localtime", DateTime.Now);
            cmd.Parameters.AddWithValue("@inputplace", Environment.MachineName);
            cmd.Parameters.AddWithValue("@srvdbid", 1);
            cmd.Parameters.Add(new SqlParameter("@log_sys_pkid", SqlDbType.Int)).Value = 0;
            cmd.Parameters["@log_sys_pkid"].Direction = ParameterDirection.Output;
            SqlParameter L_RESULT = cmd.Parameters.Add("@result", SqlDbType.NChar, 254);
            cmd.Parameters["@result"].Direction = ParameterDirection.Output;
            DataSet ds = 判斷表名(LP_DATAFUNC, cmd);
            return ds;
        }

        private static DataSet 判斷表名(string LP_DATAFUNC, SqlCommand cmd)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            //DataTable LN_EXEC_RESULT;
            switch (GetStringHeader(LP_DATAFUNC))
            {
                case StringHeader.DARB_EXIST:
                    adapter.Fill(ds, "TMPSQLSEEK");
                    //LN_EXEC_RESULT = ds.Tables["TMPSQLSEEK"];
                    break;
                case StringHeader.DARB_OPEN_DBF:
                    adapter.Fill(ds, "LCL伺服端資料表");
                    //LN_EXEC_RESULT = ds.Tables["LCL伺服端資料表"];
                    break;
                case StringHeader.DARB_PRGPAR1:
                    adapter.Fill(ds, "LCL系統參數表");
                    //LN_EXEC_RESULT = ds.Tables["LCL系統參數表"];
                    break;
                case StringHeader.DARB_MOVEREC:
                case StringHeader.DARB_BROWSE:
                case StringHeader.DARB_QRY:
                case StringHeader.DARB_BD_:
                case StringHeader.DARB_HISTORY:
                case StringHeader.DARB_RPT:
                case StringHeader.DARB_TUR:
                    adapter.Fill(ds, "TMPMOVEREC");
                    //LN_EXEC_RESULT = ds.Tables["TMPMOVEREC"];
                    break;
                //DARB_BD_:明細瀏覽  &&DARB_HISTORY:歷史查詢  &&DARB_RPT:報表列印 DARB_TR:轉單
                //*!*	LN_EXEC_RESULT >=1 代表完成(=2，表示返回 2 SETS),0表示尚在執行,-1表示失敗
                case StringHeader.DARB_SEEKGEN:
                    adapter.Fill(ds, "TSEEKMNO");
                    //LN_EXEC_RESULT = ds.Tables["TSEEKMNO"];
                    break;
                case StringHeader.DARB_WKFLOW_TODOQRY:
                    adapter.Fill(ds, "SQLWKFLOW_TODOQRY");
                    //LN_EXEC_RESULT = ds.Tables["SQLWKFLOW_TODOQRY"];
                    break;
                case StringHeader.DARB_WKFLOW_TODO:
                    adapter.Fill(ds, "SQLWKFLOW_TODO");
                    //LN_EXEC_RESULT = ds.Tables["SQLWKFLOW_TODO"];
                    break;
                default:
                    adapter.Fill(ds, "OTHER");
                    //LN_EXEC_RESULT = ds.Tables["OTHER"];
                    break;
            }
            return ds;
        }

        public static DataTable Log_LogOn(string user, string pwd, out int logbookid)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DARB_LOG_LOGON";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@srvdbid", 1);
            cmd.Parameters.AddWithValue("@inputstaff", user);
            cmd.Parameters.AddWithValue("@localtime", DateTime.Now);
            cmd.Parameters.AddWithValue("@inputplace", Environment.MachineName);
            cmd.Parameters.AddWithValue("@datafunc", "DARB_GETPASS");
            cmd.Parameters.AddWithValue("@usercode", user);
            cmd.Parameters.AddWithValue("@password", pwd);
            //LOGBOOKID有回傳值，放入pub_logbookid
            SqlParameter slogbookid = new SqlParameter("@logbookid", SqlDbType.Int);
            slogbookid.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(slogbookid);
            cmd.Parameters.AddWithValue("@computer", user);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            logbookid = (int)slogbookid.Value;
            權限表 = dt;
            return dt;
        }
        public static string Log_Sys_Input(string LP_EVENTTYPE, string LP_DATAEVENT, string LP_DATAFUNC,
            string LP_P1 = "", string LP_TABLE1 = "", string LP_TABLE2 = "", string LP_TABLE3 = "", string LP_TABLE4 = "", string LP_TABLE5 = "", string LP_DATA1 = "",
            string LP_DATA2 = "", string LP_DATA3 = "", string LP_DATA4 = "", string LP_DATA5 = "", string LP_PERMITCODE = "")
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DARB_LOG";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@languagen", "");
            cmd.Parameters.AddWithValue("@eventtype", LP_EVENTTYPE);
            cmd.Parameters.AddWithValue("@dataevent", LP_DATAEVENT);
            cmd.Parameters.AddWithValue("@datafunc", LP_DATAFUNC);
            cmd.Parameters.AddWithValue("@param1", LP_P1);
            cmd.Parameters.AddWithValue("@table1", LP_TABLE1);
            cmd.Parameters.AddWithValue("@table2", LP_TABLE2);
            cmd.Parameters.AddWithValue("@table3", LP_TABLE3);
            cmd.Parameters.AddWithValue("@table4", LP_TABLE4);
            cmd.Parameters.AddWithValue("@table5", LP_TABLE5);
            cmd.Parameters.AddWithValue("@data1", LP_DATA1);
            cmd.Parameters.AddWithValue("@data2", LP_DATA2);
            cmd.Parameters.AddWithValue("@data3", LP_DATA3);
            cmd.Parameters.AddWithValue("@data4", LP_DATA4);
            cmd.Parameters.AddWithValue("@data5", LP_DATA5);
            cmd.Parameters.AddWithValue("@inputstaff", 使用者名稱);
            cmd.Parameters.AddWithValue("@localtime", DateTime.Now);
            cmd.Parameters.AddWithValue("@inputplace", Environment.MachineName);
            cmd.Parameters.AddWithValue("@srvdbid", 1);
            cmd.Parameters.AddWithValue("@logbookid", LogBookId);
            cmd.Parameters.AddWithValue("@permitcode", LP_PERMITCODE);
            SqlParameter L_RESULT = cmd.Parameters.Add("@result", SqlDbType.NChar, 254);
            cmd.Parameters["@result"].Direction = ParameterDirection.Output;
            cmd.Connection.Open();
            cmd.ExecuteScalar();
            cmd.Connection.Close();
            return (string)cmd.Parameters["@result"].Value;
        }
        private enum StringHeader
        {
            DARB_EXIST, DARB_OPEN_DBF, DARB_PRGPAR1, DARB_MOVEREC, DARB_BROWSE, DARB_QRY, DARB_BD_,
            DARB_HISTORY, DARB_RPT, DARB_TUR, DARB_SEEKGEN, DARB_WKFLOW_TODOQRY, DARB_WKFLOW_TODO, OTHER
        }
        private static StringHeader GetStringHeader(string s)
        {
            if (s.StartsWith("DARB_EXIST")) return StringHeader.DARB_EXIST;
            if (s.StartsWith("DARB_OPEN_DBF")) return StringHeader.DARB_OPEN_DBF;
            if (s.StartsWith("DARB_PRGPAR1")) return StringHeader.DARB_PRGPAR1;
            if (s.StartsWith("DARB_MOVEREC")) return StringHeader.DARB_MOVEREC;
            if (s.StartsWith("DARB_BROWSE")) return StringHeader.DARB_BROWSE;
            if (s.StartsWith("DARB_QRY")) return StringHeader.DARB_QRY;
            if (s.StartsWith("DARB_BD_")) return StringHeader.DARB_BD_;
            if (s.StartsWith("DARB_HISTORY")) return StringHeader.DARB_HISTORY;
            if (s.StartsWith("DARB_RPT")) return StringHeader.DARB_RPT;
            if (s.StartsWith("DARB_WKFLOW_TODOQRY")) return StringHeader.DARB_WKFLOW_TODOQRY;
            if (s.StartsWith("DARB_WKFLOW_TODO")) return StringHeader.DARB_WKFLOW_TODO;
            return StringHeader.OTHER;
        }
    }
}
