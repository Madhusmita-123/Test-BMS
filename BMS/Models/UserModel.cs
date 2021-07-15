using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class UserModel
    {
        public List<Role> lstRole { get; set; }
        public List<Mst_Unit> Unit { get; set; }
        public List<Mst_Department> department { get; set; }
        public List<Mst_Designation> designation { get; set; }
        public Tran_User_Creation User { get; set; }
    }
}