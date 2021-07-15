using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class DistrictModel
    {
        public List<Mst_Country> country { get; set; }
        public List<Mst_State> state { get; set; }
        public Mst_District District { get; set; }
    }
}