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
        public static string GetData(ref string totalRow, ref DataTable tempData)
        {
            try
            {
                string sqlSumTotal = "Select Count(*) from Address";
                string sql = string.Format("Select TOP 300  addressID, departmentName, addressName " +
                                          "From Address " +
                                          "LEFT JOIN Department ON Address.addressDepartment = Department.departmentID " +
                                          "ORDER BY addressID DESC");

                OpenConnection();
                using (OleDbCommand command = new OleDbCommand(sqlSumTotal, conn))
                {
                    totalRow = command.ExecuteScalar().ToString();
                }
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn))
                {
                    adapter.Fill(tempData);
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

        public static string AddAddress(Address address)
        {
            try
            {
                string sql = string.Format("Select * from Address where addressName = '{0}'", address.addressName);
                DataTable tempData = new DataTable();
                OpenConnection();

                OleDbDataAdapter daSQL = new OleDbDataAdapter(sql, conn);//Kiem tra su ton tai
                daSQL.Fill(tempData);
                if (tempData.Rows.Count >= 1)
                {
                    CloseConnection();
                    return string.Format(RESULT.ERROR_FORMADDRESS_CHECKEXIST, address.addressName);
                }

                sql = string.Format("INSERT INTO Address(addressName, addressDepartment) VALUES('{0}', {1})", address.addressName, address.addressDepartment);

                return ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {

                CloseConnection();
                return string.Format(RESULT.ERROR_015_CATCH, "AddAddress", ex.Message);
            }
        }

        public static string CheckExistAddressMulti(string multiAddress)
        {
            string sql = string.Format("Select departmentName, addressName " +
                                        "from Address " +
                                        "LEFT JOIN Department ON Address.addressDepartment = Department.departmentID " +
                                        "where addressName IN ({0}) ", multiAddress);

            DataTable tempData = new DataTable();
            string reusltTemp = GetListDataTable(sql, ref tempData);
            if (reusltTemp != RESULT.OK)
            {
                return reusltTemp;
            }
            if (tempData.Rows.Count == 0)
            {
                return RESULT.OK;
            }

            return "Đã tồn tại dữ liệu: " + tempData.Rows.Count + " row \n" + GetDataTable(tempData);
        }
        public static string AddAddressMulti(List<ImportAddress> listAddress)
        {
            OleDbCommand cmdSQL = new OleDbCommand();
            string tempFirst = @"INSERT INTO Address( addressName, addressDepartment ) VALUES ('{0}', {1})";

            try
            {
                OpenConnection();
                cmdSQL.Connection = conn;
                cmdSQL.Transaction = conn.BeginTransaction();
                string sqlAdd = "";
                foreach (var item in listAddress)
                {
                    sqlAdd = string.Format(tempFirst, item.addressName, item.departmentID);
                    cmdSQL.CommandText = sqlAdd;
                    cmdSQL.ExecuteNonQuery();
                }

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
                return string.Format(RESULT.ERROR_015_CATCH, "AddAddressMulti", ex.Message);
            }

        }

        /// <summary>
        /// Thuc hien lay du lieu cua GetDataTable de hien thi
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private static string GetDataTable(DataTable dataTable)
        {

            StringBuilder stringBuilder = new StringBuilder();

            int columnCount = dataTable.Columns.Count;

            // Lấy danh sách tên cột
            List<string> columnNames = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList();

            // Xây dựng chuỗi tiêu đề cột
            stringBuilder.AppendLine(string.Join("\t", columnNames));

            // Duyệt qua từng dòng trong DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                // Lấy giá trị của từng ô dữ liệu trong dòng
                List<string> rowValues = new List<string>();
                foreach (var item in row.ItemArray)
                {
                    rowValues.Add(item.ToString());
                }

                // Xây dựng chuỗi dữ liệu của dòng hiện tại
                stringBuilder.AppendLine(string.Join("\t", rowValues));
            }

            return stringBuilder.ToString();
        }

    }
}

