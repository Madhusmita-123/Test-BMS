using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class BankDetailsModel
    {
        public List<Mst_Bank> lstBank { get; set; }
        public Mst_BnkDtls BnkDtls { get; set; }
    }
}