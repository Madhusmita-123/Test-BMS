using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class SubHeadModel
    {
        public List<BudgetType> lstBudget { get; set; }
        public Mst_SubHead SubHead { get; set; }
        public List<Head_Master> Head { get; set; }
    }
}