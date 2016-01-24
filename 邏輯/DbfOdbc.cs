using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 邏輯
{
    public class DbfOdbc
    {
        public OdbcConnection OdbcDbfOpenConn(string Database)
        {
            string cnstr = "Driver={Microsoft Visual FoxPro Driver}; SourceType=DBF; SourceDB="
                + Database + "; Exclusive=No; Collate=Machine; NULL=Yes; DELETED=Yes; BACKGROUNDFETCH=Yes;";

            OdbcConnection icn = new OdbcConnection();
            icn.ConnectionString = cnstr;
            if (icn.State == ConnectionState.Open)
            {
                icn.Close();
            }
            icn.Open();
            return icn;
        }

        public DataTable GetOdbcDbfDataTable(string Database, string OdbcString)
        {
            DataTable myDataTable = new DataTable();
            OdbcConnection icn = OdbcDbfOpenConn(Database);
            OdbcDataAdapter da = new OdbcDataAdapter(OdbcString, icn);
            da.Fill(myDataTable);
            if (icn.State == ConnectionState.Open) icn.Close();
            return myDataTable;
        }
    }
}
