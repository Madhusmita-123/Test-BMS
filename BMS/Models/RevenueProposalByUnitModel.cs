using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class RevenueProposalByUnitModel
    { 
        public Trans_Revnu_Expenditure_By_Unit Revenue { get; set; }
        public List<Head_Master> head { get; set; }
        public List<Mst_SubHead> SubHead { get; set; }
        public List<Mst_Unit> Unit { get; set; }
        public List<Tran_User_Creation> user { get; set; }
        public string Unit_Name { get; set; }
        
        public List<Financial_Year> fyr { get; set; }
        public string Fin_Yr { get; set; }
        public int Unit_RevExp_Id { get; set; }
       
    }
}