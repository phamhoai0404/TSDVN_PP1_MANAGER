using GUI_MAIN.DAL;
using GUI_MAIN.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyExcel = Microsoft.Office.Interop.Excel;

namespace GUI_MAIN.BLL
{
    public class ManagerAddress
    {
        public static string GetDataAddress(ref string totalRow, ref DataGridView dgv)
        {
            DataTable table = new DataTable();

            string resultValue = AddressAccess.GetData(ref totalRow, ref table);
            if (resultValue != RESULT.OK)
            {
                return resultValue;
            }

            dgv.Rows.Clear();
            foreach (DataRow item in table.Rows)
            {
                dgv.Rows.Add(item.ItemArray);
            }
            return RESULT.OK;
        }
        public static string GetDataList(ref DataTable table)
        {
            //table.Clear();
            ////string resultValue = AddressAccess.GetData(ref table);
            //if (resultValue != RESULT.OK)
            //{
            //    return resultValue;
            //}

            ////Clear Data
            //listAddress.Clear();

            //var tempTable = table.AsEnumerable().Select(s => new Address {
            //    addressID = Convert.ToInt64(s["addressID"]),
            //    addressName = s.Field<string>("addressName"),
            //});
            //listAddress = tempTable.ToList();
            return RESULT.OK;

        }
        public static string AddAddress(Address tempAddress)
        {
            if (tempAddress.addressDepartment == -1)
            {
                return RESULT.ERROR_MUST_SELECT_DEPARTMENT;
            }
            if (string.IsNullOrWhiteSpace(tempAddress.addressName))
            {
                return RESULT.ERROR_VALIDATE_FORMADDRESS;
            }

            tempAddress.addressName = tempAddress.addressName.Trim();//Loai bo ki tu thua
            return AddressAccess.AddAddress(tempAddress);
        }
        /// <summary>
        /// Check su ton tai cua sheetName trong excel
        /// </summary>
        /// <param name="wbTemp"></param>
        /// <param name="tempSheet"></param>
        /// <returns>
        /// True: Ton tai
        /// False: Khong ton tai 
        /// </returns>
        private static bool CheckExistSheetName(MyExcel.Workbook wbTemp, string tempSheet)
        {
            foreach (object sheetObj in wbTemp.Sheets)
            {
                if (sheetObj is MyExcel.Worksheet sheet && sheet.Name == tempSheet)
                {
                    return true;
                }
            }
            return false;
        }

        public static string CheckFileImport(string fileName, ref List<ImportAddress> listAdd, ComboBox dataDepartment)
        {
            try
            {
                MyExcel.Application app = null;
                MyExcel.Workbook wb = null;
                MyExcel.Worksheet ws = null;

                app = new MyExcel.Application();
                app.AskToUpdateLinks = false;
                app.DisplayAlerts = false;


                wb = app.Workbooks.Open(fileName, false);
                string sheetName = "DATA";
                if (CheckExistSheetName(wb, sheetName) == false)
                {
                    wb.Close();
                    return string.Format(RESULT.ERROR_IMPORT_SHEETNAME, sheetName);
                }
                ws = wb.Sheets[sheetName];//Thuc hien gan gia tri ws

                long lastRow = ws.Cells[ws.Rows.Count, "A"].End[MyExcel.XlDirection.xlUp].Row; ;
                object[,] values = (object[,])ws.Range["A" + 2, "B" + lastRow].Value2;
                wb.Close();

                DataTable temp = new DataTable();
                GetDataTable(ref temp, dataDepartment);

                ImportAddress tempAddress = new ImportAddress();
                for (long row = 1; row <= values.GetLength(0); row++)
                {
                    //Check ten muon chen
                    tempAddress.addressName = values[row, 2]?.ToString()?.Trim();
                    if (string.IsNullOrEmpty(tempAddress.addressName))
                    {
                        return string.Format(RESULT.ERROR_IMPORT_NOTNULL_DEPARTMENT, row + 1);
                    }

                    //Check id
                    tempAddress.departmentID = CheckDepartment(temp, values[row, 1]?.ToString()?.Trim());
                    if (tempAddress.departmentID == MdlCommon.NOT_DEPARTMENT)
                    {
                        return string.Format(RESULT.ERROR_IMPORT_NOT_DEPARTMENT, row + 1, tempAddress.addressName);
                    }
                    listAdd.Add(new ImportAddress(tempAddress));
                }
                if (listAdd.Count() == 0)
                {
                    return string.Format(RESULT.ERROR_IMPORT_NOT_DATA, fileName);
                }

                string check = "";
                bool tempCheckDupliate = CheckDuplicateAddress(listAdd, ref check);
                if (tempCheckDupliate == true)
                {
                    return string.Format(RESULT.ERROR_IMPORT_ADDRESS_DUPPLICATE, check);
                }

                string multiAddress = string.Join(" OR ", listAdd.Select(item => $"addressName = '{item.addressName}'"));
                return AddressAccess.CheckExistAddressMulti(multiAddress);
            }
            catch (Exception ex )
            {
                return string.Format(RESULT.ERROR_015_CATCH, "CheckFileImport", ex.Message);
            }
        }

        public static string AddAddressMulti(List<ImportAddress> listAdd)
        {
            return AddressAccess.AddAddressMulti(listAdd);
        }

        private static int CheckDepartment(DataTable temp, string valueDepartment)
        {

            DataRow[] result = temp.Select($"departmentName = '{valueDepartment}'");
            if (result.Length > 0)
            {
                return Convert.ToInt32(result[0]["departmentID"]);
            }

            return MdlCommon.NOT_DEPARTMENT;
        }

        /// <summary>
        /// Check su lap lai cua gia tri
        /// </summary>
        /// <param name="listInput"></param>
        /// <param name="addressDuplicate"></param>
        /// <returns></returns>
        private static bool CheckDuplicateAddress(List<ImportAddress> listInput, ref string addressDuplicate)
        {

            HashSet<string> idSet = new HashSet<string>();

            foreach (var row in listInput)
            {
                if (!idSet.Add(row.addressName.ToUpper()))
                {
                    addressDuplicate = row.addressName;
                    return true;
                }
            }

            return false;
        }

        private static void GetDataTable(ref DataTable temp, ComboBox combobox)
        {
            temp.Columns.Add("departmentName");
            temp.Columns.Add("departmentID");

            foreach (var item in combobox.Items)
            {
                if (item is DataRowView rowView)
                {
                    DataRow row = temp.NewRow();
                    row["departmentName"] = rowView["departmentName"];
                    row["departmentID"] = rowView["departmentID"];
                    temp.Rows.Add(row);
                }
            }
        }
    }
}

