using GUI_MAIN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_MAIN.DAL
{
    public class HistoryAccess : BaseAccess
    {

        public static string CheckAddress(Address add, ref DataTable listAfter)
        {
            string dateNow = DateTime.Now.ToString("MM/dd/yyyy");
            string sql = string.Format("Select historyDate, historyStatus, historyResistor, historyVoltage, historyNote " +
                                        "From History " +
                                        "WHERE historyAddress = {0} and DateValue(historyDate) = #{1}# " +
                                        "ORDER BY historyDate DESC", add.addressID, dateNow);

            string reusltTemp = GetListDataTable(sql, ref listAfter);
            if (reusltTemp != RESULT.OK)
            {
                return reusltTemp;
            }
            return RESULT.OK;
        }
        public static string GetData(ref string totalRow, ref DataTable dataTable)
        {
            try
            {
                string sqlSumTotal = string.Format(@"Select COUNT(*) From History");
                string sql = string.Format("Select TOP 300  historyDate, addressName, historyStatus, historyResistor, historyVoltage, historyNote " +
                                           "From History " +
                                           "LEFT JOIN Address ON Address.addressID = History.historyAddress " +
                                           "ORDER BY historyDate DESC"
                                           );

                OpenConnection();
                using (OleDbCommand command = new OleDbCommand(sqlSumTotal, conn))
                {
                    totalRow = command.ExecuteScalar().ToString();
                }
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn))
                {
                    adapter.Fill(dataTable);
                }
                CloseConnection();
                return RESULT.OK;
            }

            catch (Exception ex)
            {
                CloseConnection();
                return string.Format(RESULT.ERROR_015_CATCH, "GetData", ex.Message);
            }
        }


        public static string AddHistory(History history)
        {
            string sqlHistory = string.Format(@"INSERT INTO History(historyAddress, historyStatus, historyResistor ,historyVoltage, historyNote,  historyDate) 
                                                VALUES({0}, {1}, '{2}', '{3}', '{4}', NOW())",
                                                 history.historyAddressID, history.historyStatus, history.historyResistor, history.historyVoltage, history.historyNote);

            return ExecuteNonQuery(sqlHistory);
        }
    }
}
