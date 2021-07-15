using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class DesignationModel
    {
        public List<Mst_Department> lstDepartment { get; set; }
        public Mst_Designation Designation { get; set; }
    }
}