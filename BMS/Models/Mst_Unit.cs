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
    
    public partial class Mst_Unit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mst_Unit()
        {
            this.Mst_AssignUnitToBank = new HashSet<Mst_AssignUnitToBank>();
            this.Trans_RequsitionNumber = new HashSet<Trans_RequsitionNumber>();
            this.Trans_Salary = new HashSet<Trans_Salary>();
        }
    
        public int Unit_Id { get; set; }
        public Nullable<int> Con_Id { get; set; }
        public Nullable<int> St_Id { get; set; }
        public Nullable<int> Dst_Id { get; set; }
        public Nullable<int> zoneid { get; set; }
        public Nullable<int> circleid { get; set; }
        public Nullable<int> divisonid { get; set; }
        public Nullable<int> bnkid { get; set; }
        public Nullable<int> Bnk_DtlsId { get; set; }
        public string Office_Type { get; set; }
        public string Unit_Name { get; set; }
        public string Unit_Code { get; set; }
        public string Plot_No { get; set; }
        public string AT { get; set; }
        public string PO { get; set; }
        public string PS { get; set; }
        public string Land_Mark { get; set; }
        public string Area { get; set; }
        public string Pin { get; set; }
        public string Contact_No { get; set; }
        public string CP_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> AddOn { get; set; }
        public Nullable<int> AddBy { get; set; }
        public Nullable<System.DateTime> ModOn { get; set; }
        public Nullable<int> ModBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mst_AssignUnitToBank> Mst_AssignUnitToBank { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trans_RequsitionNumber> Trans_RequsitionNumber { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trans_Salary> Trans_Salary { get; set; }
    }
}
