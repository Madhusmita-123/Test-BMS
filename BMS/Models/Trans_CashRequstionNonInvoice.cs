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
    
    public partial class Trans_CashRequstionNonInvoice
    {
        public int CashReq_NonInvoiceId { get; set; }
        public string NonInvoiceNumber { get; set; }
        public Nullable<int> Unit_Id { get; set; }
        public Nullable<int> Fin_Id { get; set; }
        public Nullable<int> Bgt_Id { get; set; }
        public Nullable<int> Cap_TPbgt_Id { get; set; }
        public Nullable<System.DateTime> Req_Date { get; set; }
        public string Req_Num { get; set; }
        public Nullable<decimal> Cur_bnk_Balance { get; set; }
        public Nullable<decimal> Cur_csh_Balance { get; set; }
        public string ReasonCash_Maintain { get; set; }
        public Nullable<int> bnkid { get; set; }
        public Nullable<int> Bnk_DtlsId { get; set; }
        public string Created_By { get; set; }
        public string Checked_By { get; set; }
        public string Authorized_By { get; set; }
        public string Invoice_Type { get; set; }
        public string Invoice_Catagory { get; set; }
        public Nullable<int> BugtTyp_Id { get; set; }
        public Nullable<int> Head_Id { get; set; }
        public Nullable<int> SubHead_Id { get; set; }
        public string SubHeadCode { get; set; }
        public Nullable<decimal> Dues { get; set; }
        public Nullable<decimal> Requeted_Amt { get; set; }
        public decimal Budget_Amt { get; set; }
        public Nullable<decimal> Approved_Amt { get; set; }
        public string DivisonOfficer_Comment { get; set; }
        public string Ho_Initator { get; set; }
        public string Ho_AprovedLevel1 { get; set; }
        public string Final_approver { get; set; }
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
