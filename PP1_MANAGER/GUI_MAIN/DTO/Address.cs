﻿using System;
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

        public void SetValue(Address temp)
        {
            this.addressID = temp.addressID;
            this.addressName = temp.addressName;
        }
    }
}
