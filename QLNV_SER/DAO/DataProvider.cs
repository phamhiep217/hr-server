using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace QLNV_SER.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        private static string strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            @"Data source= D:\Program Files\ChamCong\Data- May Cham Cong\" +
            @"MITACOACCESS.mdb";
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (OleDbConnection con = new OleDbConnection(strcon))
            {
                con.Open();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, con))
                {
                    adapter.Fill(data);
                }
                con.Close();
            }
            return data;
        }
    }
}