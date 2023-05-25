using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_MAIN.DTO
{
    public class History
    {
        public long historyID { get; set; }
        public long historyAddressID { get; set; }
        public string historyAddressString { get; set; }
        public DateTime historyDate { get; set; }
        public int historyStatus { get; set; }
        public string historyResistor { get; set; }
        public string historyVoltage { get; set; }
        public string historyNote { get; set; }
        
    }
}
