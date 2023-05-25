using GUI_MAIN.DAL;
using GUI_MAIN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_MAIN.BLL
{
    public class ActionMain
    {
        public static string AddItem(ref Address address, ref DataTable listAfter)
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
    }
}
