using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class AssignUserApprovalMappingModel
    {
        public List<Mst_ApproveType> Approvetype { get; set; }
        public List<Mst_Unit> Unit { get; set; }
        public List<Tran_User_Creation> User { get; set; }
        public List<User_Create_Details_Result> Usernew { get; set; }
        public Trans_Assign_User_ToApprov Assignusertoapprove { get; set; }
    }
}