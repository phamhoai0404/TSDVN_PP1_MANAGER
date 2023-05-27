using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_MAIN.DTO
{
    public class Address
    {
        public long addressID { get; set; }
        public string addressName { get; set; }
        public int addressDepartment { get; set; }
        public string departmentName { get; set; }

        public void SetValue(Address temp)
        {
            this.addressID = temp.addressID;
            this.addressName = temp.addressName;
        }
    }
    public class ImportAddress
    {
        public string addressName { get; set; }
        public int departmentID { get; set; }
     //   public int departmentName { get; set; }

        public ImportAddress()
        {

        }
        public ImportAddress(ImportAddress s)
        {
            this.addressName = s.addressName;
            this.departmentID = s.departmentID;
        }
    }
}
