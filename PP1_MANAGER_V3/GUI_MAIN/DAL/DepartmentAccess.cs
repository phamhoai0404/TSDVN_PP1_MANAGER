using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_MAIN.DAL
{
    public class DepartmentAccess : BaseAccess
    {
        public static string GetData(ref DataTable tempData)
        {
            string sql = "Select * from Department";
            return GetListDataTable(sql, ref tempData);
        }
    }
}
