using GUI_MAIN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_MAIN.DAL
{
    public class BaseAccess
    {
        private static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DATABASE\Database_DT.accdb;Persist Security Info=False";
        protected static OleDbConnection conn = null;

        //Thực hiện khởi tạo kết nối
        //CreatedBy: HoaiPT(20/10/2022)
        protected static void OpenConnection()
        {
            if (conn == null)
                conn = new OleDbConnection(connectString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        //Thực hiện đóng kết nối
        //CreatedBy: HoaiPT(20/10/2022)
        protected static void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
        protected static string GetListDataTable(string strSQL, ref DataTable dsSQL)
        {
            try
            {
                OpenConnection();
                OleDbDataAdapter daSQL = new OleDbDataAdapter(strSQL, conn);
                daSQL.Fill(dsSQL);
                CloseConnection();
                return RESULT.OK;
            }
            catch (Exception ex)
            {
                return string.Format(RESULT.ERROR_015_CATCH, "GetListDataTable", ex.Message);
            }
        }
        protected static string ExecuteNonQuery(string sql)
        {
            OleDbCommand cmdSQL = new OleDbCommand();
            try
            {
                OpenConnection();
                cmdSQL.Connection = conn;

                cmdSQL.Transaction = conn.BeginTransaction();
                cmdSQL.CommandText = sql;
                cmdSQL.ExecuteNonQuery();

                cmdSQL.Transaction.Commit();

                CloseConnection();
                cmdSQL.Dispose();
                cmdSQL = null;

                return RESULT.OK;
            }
            catch (Exception ex)
            {
                cmdSQL.Transaction.Rollback();
                CloseConnection();
                return string.Format(RESULT.ERROR_015_CATCH, "ExecuteNonQuery", ex.Message); ;
            }
        }

    }
}
