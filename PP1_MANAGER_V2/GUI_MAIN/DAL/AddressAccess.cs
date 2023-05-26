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
    public class AddressAccess : BaseAccess
    {
        public static string CheckExistAddress(ref Address add)
        {
            string sql = string.Format("Select * from Address where addressDepartment = {1} and addressName = '{0}' ", add.addressName, add.addressDepartment);
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
                return string.Format(RESULT.ERROR_NOT_ADDRESS, add.addressName, add.departmentName);
            }
            return string.Format(RESULT.ERROR_MULTI_ADDRESS, add.addressName, tempData.Rows.Count, add.departmentName);

        }
        public static string GetData(ref DataTable tempData)
        {
            string sql = "Select * from Address";
            return GetListDataTable(sql, ref tempData);
        }

        public static string AddAddress(string address)
        {
            try
            {
                string sql = string.Format("Select * from Address where addressName = '{0}'", address);
                DataTable tempData = new DataTable();
                OpenConnection();

                OleDbDataAdapter daSQL = new OleDbDataAdapter(sql, conn);//Kiem tra su ton tai
                daSQL.Fill(tempData);
                if (tempData.Rows.Count >= 1)
                {
                    CloseConnection();
                    return string.Format(RESULT.ERROR_FORMADDRESS_CHECKEXIST,address);
                }

                sql = string.Format("INSERT INTO Address(addressName) VALUES('{0}')", address);

                return ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {

                CloseConnection();
                return string.Format(RESULT.ERROR_015_CATCH, "AddAddress", ex.Message);
            }
        }
    }
}
