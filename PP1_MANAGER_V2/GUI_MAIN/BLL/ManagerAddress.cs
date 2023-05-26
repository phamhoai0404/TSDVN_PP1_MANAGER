using GUI_MAIN.DAL;
using GUI_MAIN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(tempAddress.addressDepartment == -1)
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
    }
}
