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
    
    public partial class Role
    {
        public int RoleID { get; set; }
        public string RoleDesc { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> addon { get; set; }
        public Nullable<int> addby { get; set; }
        public Nullable<System.DateTime> modon { get; set; }
        public Nullable<int> modby { get; set; }
    }
}