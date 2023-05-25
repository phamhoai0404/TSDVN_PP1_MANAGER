using GUI_MAIN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_MAIN.DAL
{
    public class HistoryAccess : BaseAccess
    {

        public static string CheckAddress(Address add, ref DataTable listAfter)
        {
            string dateNow = DateTime.Now.ToString("MM/dd/yyyy");
            string sql = string.Format("Select * " +
                                        "From History " +
                                        "WHERE historyAddress = {0} and DateValue(historyDate) = #{1}#", add.addressID, dateNow);

            string reusltTemp = GetListDataTable(sql, ref listAfter);
            if (reusltTemp != RESULT.OK)
            {
                return reusltTemp;
            }
            return RESULT.OK;
        }
    }
}
