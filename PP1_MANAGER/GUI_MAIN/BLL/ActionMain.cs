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
    public class ActionMain
    {
        public static string CheckAddress(ref Address address, ref DataTable listAfter)
        {
            //Kiem tra xem co nhap du lieu khong
            if (string.IsNullOrWhiteSpace(address.addressName))
            {
                return string.Format(RESULT.ERROR_NOT_NULL_INPUT, "Vị trí");
            }
            address.addressName = address.addressName.Trim();
            
            //Check su ton tai cua vi tri
            string resultTemp = AddressAccess.CheckExistAddress(ref address);
            if (resultTemp != RESULT.OK)
            {
                return resultTemp;
            }

            //Check su ton tai cua no trong History
            resultTemp = HistoryAccess.CheckAddress(address, ref listAfter);
            if(resultTemp != RESULT.OK)//Truong hop co loi ve check duong truyen cac kieu se dung lai
            {
                return resultTemp;
            }
            
            if(listAfter.Rows.Count == 0)//Neu khong co ban ghi nao tra ve true
            {
                return RESULT.OK;
            }

            //Neu ma co du lieu thi tra ve co loi
            return RESULT.ERROR_HAS_DATA;
        }

        /// <summary>
        /// Thuc hien check du lieu nhap vao cua nguoi dung
        /// </summary>
        /// <param name="historyMain"></param>
        /// <returns>
        /// OK: Tra ve du lieu
        /// !OK: Bi loi
        /// </returns>
        public static string CheckValueInput(ref History historyMain)
        {
            //Check dia chi ID cua ke xem co loi hay khong truong hop nay gap phai khi khong kip phan hoi chuong trinh
            if(historyMain.historyAddressID == MdlCommon.NOT_ADDRESS)
            {
                return RESULT.ERROR_VALIDATE_ADDRESS;
            }

            //check khong duoc de trong hieu dien the va dien tro
            if(string.IsNullOrWhiteSpace(historyMain.historyResistor) ||
                string.IsNullOrWhiteSpace(historyMain.historyVoltage))
            {
                return RESULT.ERROR_VALIDATE_NOTNULL;
            }

            historyMain.TrimObject();//Loai bo nhung ki tu thua

            return RESULT.OK;
        }

        public static string AddHistory(History historyMain)
        {
            return HistoryAccess.AddHistory(historyMain);
        }

        public static string GetData(ref string totalSum, ref DataGridView dgv)
        {
            DataTable dataTemp = new DataTable();

            string resultValue = HistoryAccess.GetData(ref totalSum, ref dataTemp);
            if(resultValue != RESULT.OK)
            {
                return resultValue;
            }
            
            dgv.Rows.Clear();
            
            foreach (DataRow row in dataTemp.Rows)
            {
                dgv.Rows.Add(row.ItemArray);
                //dgv.Rows.Add(
                //    row["historyDate"].ToString(), 
                //    row["addressName"].ToString(), 
                //    row["historyStatus"].ToString(),
                //    row["historyResistor"].ToString(),
                //    row["historyVoltage"].ToString(),
                //    row["historyNote"].ToString()
                //    );
            }
            return RESULT.OK;


        }
    }
}
