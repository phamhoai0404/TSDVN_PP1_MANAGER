using GUI_MAIN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_MAIN.DAL
{
    public class AddressAccess: BaseAccess
    {
        public static string CheckExistAddress(ref Address add)
        {
            string sql = string.Format("Select * from Address where addressName = '{0}'", add.addressName);
            DataTable tempData = new DataTable();
            string reusltTemp = GetListDataTable(sql, ref tempData);
            if (reusltTemp != RESULT.OK)
            {
                return reusltTemp;
            }

            if (tempData.Rows.Count == 1)
            {
                add.addressID = Convert.ToInt64(tempData.Rows[0]["addressID"].ToString());
                return RESULT.OK;
            }
            if (tempData.Rows.Count == 0)
            {
                return string.Format(RESULT.ERROR_NOT_ADDRESS, add.addressName);
            }
            return string.Format(RESULT.ERROR_MULTI_ADDRESS, add.addressName);


        }
    }
}
