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
    public class ActionExport
    {
        public static string ExportData(SearchData inputData, ref DataTable tempValue)
        {
            if(inputData.exportDate == true)
            {
                if(inputData.dateFrom?.Date > inputData.dateTo?.Date)
                {
                    return RESULT.ERROR_FORMEXPORT_DATE;
                }
            }

            tempValue.Clear();//Thuc hien clear du lieu
            string resultValue = HistoryAccess.SearchDataExport(inputData, ref tempValue);
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

        public static string GetDataSearch(SearchData inputData, ref DataGridView dgv, ref string totalRow)
        {
            if (inputData.exportDate == true)
            {
                if (inputData.dateFrom?.Date > inputData.dateTo?.Date)
                {
                    return RESULT.ERROR_FORMEXPORT_DATE;
                }
            }

            DataTable tempValue = new DataTable();
            string resultValue = HistoryAccess.SearchDataView(inputData, ref tempValue, ref totalRow);
            if (resultValue != RESULT.OK)
            {
                return resultValue;
            }

            dgv.Rows.Clear();
            foreach (DataRow row in tempValue.Rows)
            {
                dgv.Rows.Add(row.ItemArray);
            }
            return RESULT.OK;

        }

    }
}
