using GUI_MAIN.DAL;
using GUI_MAIN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_MAIN.BLL
{
    public class ActionChild
    {
        public static string CheckValueInput(ref History historyMain)
        {
            //Check dia chi ID cua ke xem co loi hay khong truong hop nay gap phai khi khong kip phan hoi chuong trinh
            if (historyMain.historyAddressID == MdlCommon.NOT_ADDRESS)
            {
                return RESULT.ERROR_VALIDATE_ADDRESS;
            }

            //check khong duoc de trong hieu dien the va dien tro
            if (string.IsNullOrWhiteSpace(historyMain.historyResistor) ||
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
    }
}
