//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mst_Department
    {
        public int Dept_ID { get; set; }
        public string Dept_Code { get; set; }
        public string Dept_Name { get; set; }
        public Nullable<bool> isactive { get; set; }
        public Nullable<bool> isdelete { get; set; }
        public Nullable<System.DateTime> addon { get; set; }
        public Nullable<int> addby { get; set; }
        public Nullable<System.DateTime> modon { get; set; }
        public Nullable<int> modby { get; set; }
    }
}
