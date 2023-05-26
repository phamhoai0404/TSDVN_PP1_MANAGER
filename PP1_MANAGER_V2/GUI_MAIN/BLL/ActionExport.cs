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
    public class ActionExport
    {
        public static string ExportData(Export inputData, ref DataTable tempValue)
        {
            if(inputData.exportDate == true)
            {
                if(inputData.dateFrom?.Date > inputData.dateTo?.Date)
                {
                    return RESULT.ERROR_FORMEXPORT_DATE;
                }
            }

            tempValue.Clear();//Thuc hien clear du lieu
            string resultValue = HistoryAccess.SearchData(inputData, ref tempValue);
            if(resultValue != RESULT.OK)
            {
                return resultValue;
            }
            if(tempValue.Rows.Count == 0)
            {
                return RESULT.ERROR_FORMEXPORT_NOTDATA;
            }

            return RESULT.OK;
        }
        
    }
}
