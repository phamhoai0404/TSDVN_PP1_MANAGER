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

           return GetListDataTable(sql, ref listAfter);
            
        }
        public static string GetData(ref string totalRow, ref DataTable dataTable)
        {
            try
            {
                string sqlSumTotal = string.Format(@"Select COUNT(*) From History");
                string sql = string.Format("Select TOP 300  historyDate, departmentName, addressName, historyStatus, historyResistor, historyVoltage, historyNote " +
                                           "From (History " +
                                           "LEFT JOIN Address ON Address.addressID = History.historyAddress) " +
                                           "LEFT JOIN Department ON Address.addressDepartment = Department.departmentID " +
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
        public static string SearchData(Export input, ref DataTable listDataTable)
        {

            List<string> listSearch = new List<string>();
            if (input.deparmentID != -1)
            {
                listSearch.Add(string.Format("(addressDepartment = {0})", input.deparmentID));
            }
            if (input.exportDate == true)
            {
                string tempStart = input.dateFrom?.ToString("yyyy-MM-dd");
                string tempEnd = input.dateTo?.ToString("yyyy-MM-dd") + " 23:59:59";
                listSearch.Add(string.Format("(historyDate BETWEEN #{0}# AND #{1}#)", tempStart, tempEnd));
            }
            string stringWhere = " ";
            if(listSearch.Count() > 0)
            {
                stringWhere = "Where " + string.Join(" and ", listSearch);
            }

            string sqlSearch = string.Format("Select TOP 300  historyDate , addressName, historyStatus, historyResistor, historyVoltage, historyNote " +
                                           "From History " +
                                           "LEFT JOIN Address ON Address.addressID = History.historyAddress " +
                                           "{0}" +
                                           "ORDER BY historyDate DESC", stringWhere);



            return GetListDataTable(sqlSearch, ref listDataTable);
        }
    }
}
