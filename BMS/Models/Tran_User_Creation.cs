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
    
    public partial class Tran_User_Creation
    {
        public int Usr_Id { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> Dept_ID { get; set; }
        public Nullable<int> Desg_ID { get; set; }
        public Nullable<int> Unit_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Usr_Nm { get; set; }
        public string Pwd { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> AddOn { get; set; }
        public Nullable<int> AddBy { get; set; }
        public Nullable<System.DateTime> ModOn { get; set; }
        public Nullable<int> ModBy { get; set; }
        public string EmpCode { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Regine { get; set; }
        public Nullable<int> circleid { get; set; }
        public Nullable<int> divisonid { get; set; }
        public Nullable<int> zoneid { get; set; }
        public string ProfileName { get; set; }
    }
}
