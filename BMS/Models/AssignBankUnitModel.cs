using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class AssignBankUnitModel
    {
        public List<Mst_Unit> unit { get; set; }
        public List<Mst_Bank> bank { get; set; }
        public Mst_AssignUnitToBank assignbankunit { get; set; }
    }
}