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
    
    public partial class Trans_Additional_allotment_Work
    {
        public int AddAltWork_Id { get; set; }
        public Nullable<int> Cap_Wok_Head_Id { get; set; }
        public Nullable<int> Unit_Id { get; set; }
        public Nullable<int> Cap_Work_Bgt_Id { get; set; }
        public Nullable<int> Fin_Id { get; set; }
        public Nullable<decimal> Exist_Altmnt { get; set; }
        public Nullable<decimal> Adtnal_Altmnt { get; set; }
        public Nullable<decimal> Lst_Yr_Expnd { get; set; }
        public Nullable<decimal> Cur_Yr_Expnd { get; set; }
        public Nullable<decimal> Aprov_Allotment { get; set; }
        public string Reasons { get; set; }
        public string Ho_Reasons { get; set; }
        public Nullable<bool> Bit_Aprove { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<int> AddBy { get; set; }
        public Nullable<System.DateTime> AddOn { get; set; }
        public Nullable<System.DateTime> ModOn { get; set; }
        public Nullable<int> ModBy { get; set; }
    }
}
