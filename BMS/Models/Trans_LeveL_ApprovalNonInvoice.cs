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
    
    public partial class Trans_LeveL_ApprovalNonInvoice
    {
        public int CashReqAprv_levelNonInvoiceId { get; set; }
        public Nullable<int> CashReq_NonInvoiceId { get; set; }
        public Nullable<int> Unit_Id { get; set; }
        public Nullable<int> BugtTyp_Id { get; set; }
        public Nullable<int> Fin_Id { get; set; }
        public Nullable<int> Bgt_Id { get; set; }
        public Nullable<int> Cap_TPbgt_Id { get; set; }
        public string Req_Num { get; set; }
        public string NonInvoiceNumber { get; set; }
        public Nullable<int> Level_Approver1 { get; set; }
        public Nullable<decimal> Approv_Quantity1 { get; set; }
        public Nullable<bool> Bit_Approv1 { get; set; }
        public string Approvr1_remarks { get; set; }
        public Nullable<int> Level_Approver2 { get; set; }
        public Nullable<decimal> Approv_Quantity2 { get; set; }
        public Nullable<bool> Bit_Approv2 { get; set; }
        public string Approvr2_remarks { get; set; }
        public Nullable<int> Level_Approver3 { get; set; }
        public Nullable<decimal> Approv_Quantity13 { get; set; }
        public Nullable<bool> Bit_Approv3 { get; set; }
        public string Approvr3_remarks { get; set; }
        public Nullable<int> Level_Approver4 { get; set; }
        public Nullable<decimal> Approv_Quantity4 { get; set; }
        public Nullable<bool> Bit_Approv4 { get; set; }
        public string Approvr4_remarks { get; set; }
        public Nullable<int> Level_Approver5 { get; set; }
        public Nullable<decimal> Approv_Quantity5 { get; set; }
        public Nullable<bool> Bit_Approv5 { get; set; }
        public string Approvr5_remarks { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<int> AddBy { get; set; }
        public Nullable<System.DateTime> AddOn { get; set; }
        public Nullable<int> ModBy { get; set; }
        public Nullable<System.DateTime> ModOn { get; set; }
        public string FileID { get; set; }
    
        public virtual Tran_Cap_TP_Budget Tran_Cap_TP_Budget { get; set; }
    }
}
