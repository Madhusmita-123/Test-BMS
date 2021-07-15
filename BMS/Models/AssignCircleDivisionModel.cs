using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class AssignCircleDivisionModel
    {
        public List<Mst_Circle> Circle1 { get; set; }
        public List<Mst_Divison> division { get; set; }
        public Mst_AssignCircleDivison assigncd { get; set; }
    }
}