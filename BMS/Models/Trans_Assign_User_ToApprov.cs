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
    
    public partial class Trans_Assign_User_ToApprov
    {
        public int Asgn_usr_Aprv_ID { get; set; }
        public Nullable<int> Unit_Id { get; set; }
        public Nullable<int> Usr_Id { get; set; }
        public Nullable<int> Aprov_Type_ID { get; set; }
        public Nullable<System.DateTime> FromDt { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> Addon { get; set; }
        public Nullable<int> Addby { get; set; }
        public Nullable<System.DateTime> Modon { get; set; }
        public Nullable<int> Modby { get; set; }
    }
}
