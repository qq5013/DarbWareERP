using System;
using System.Data;
using System.Data.SqlClient;

namespace 數據庫連線
{

    public class 轉資料Dal
    {
        string DataSource = Properties.Settings.Default.DataSource,
                Database = "darbdcstcsa1",
                UserID = "foxcsa",
                Password = "plot138168";
        public string 單據別 { get; set; }
        string 日期欄位;
        public 轉資料Dal(string 單據別)
        {
            this.單據別 = 單據別;
        }
        public void sheetno調整()
        {
            日期欄位 = sheetno取得日期欄位();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn設定();
            cmd.CommandText = "UPDATE _sheetno SET 日期欄位='' WHERE 單據別='" + 單據別 + "'";
            cmd.Connection.Open();
            cmd.ExecuteScalar();
            cmd.Connection.Close();
            cmd.Dispose();
        }
        public void sheetno還原()
        {            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn設定();
            cmd.CommandText = "UPDATE _sheetno SET 日期欄位='" + 日期欄位 + "' WHERE 單據別='" + 單據別 + "'";
            cmd.Connection.Open();
            cmd.ExecuteScalar();
            cmd.Connection.Close();
            cmd.Dispose();
        }
        public void tableseq歸零(string 資料表名稱)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn設定();
            cmd.CommandText = "UPDATE _tableseq SET seqval=0 WHERE 資料表名稱='" + 資料表名稱 + "'";
            cmd.Connection.Open();
            cmd.ExecuteScalar();
            cmd.Connection.Close();
            cmd.Dispose();
        }
        private string sheetno取得日期欄位()
        {
            string result;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn設定();
            cmd.CommandText = "select 日期欄位 from _sheetno wheRE 單據別 = '" + 單據別 + "'";
            cmd.Connection.Open();
            result = cmd.ExecuteScalar().ToString();
            cmd.Connection.Close();
            cmd.Dispose();
            return result;
        }
        private SqlConnection conn設定()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=" + DataSource + ";" +
                          "Initial Catalog=" + Database + ";" + "User ID=" + UserID + ";" +
                          "Password=" + Password + ";";
            return conn;
        }
    }
}
