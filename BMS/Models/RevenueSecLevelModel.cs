using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class RevenueSecLevelModel
    {
        public Trans_Revnu_Expenditure_By_Unit Revenue { get; set; }
        public Nullable<int> Unit_Id { get; set; }
        public Nullable<int> Fin_Id { get; set; }
        public Nullable<int> Head_Id { get; set; }
        public Nullable<int> Subhead_Id { get; set; }
        public Nullable<int> Bgt_Id { get; set; }
        public List<Head_Master> head { get; set; }
        public List<Mst_SubHead> SubHead { get; set; }
        public List<Mst_Unit> Unit { get; set; }
        public List<Tran_User_Creation> user { get; set; }
        public string Unit_Name { get; set; }

        public List<Financial_Year> fyr { get; set; }
        public string Fin_Yr { get; set; }
        public int id { get; set; }
       
        public Nullable<decimal> Prop_Re_Curnt { get; set; }
        public Nullable<decimal> Bdgt_Nxt_Fy { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> bit_Aproved { get; set; }
        public Nullable<bool> bit_Second_Aprov { get; set; }
        public Nullable<decimal> First_Lvl_Re_For_Current { get; set; }
        public Nullable<decimal> fst_Aprov_Bdgt_Amnt { get; set; }
        public string fst_Arop_Remarks { get; set; }
        public Nullable<decimal> Sanc_Amnt { get; set; }
        public Nullable<decimal> Avlb_Amnt { get; set; }
        public Nullable<decimal> Re_For_Current { get; set; }
        public Nullable<decimal> Bdgt_Amnt { get; set; }
        public Nullable<decimal> Sec_Lvl_Re_For_Current { get; set; }
        public Nullable<decimal> Sec_Aprov_Bdgt_Amnt { get; set; }
        public string Sec_Arop_Remarks { get; set; }
        public Nullable<bool> Sec_Arop_BIT { get; set; }
        public Nullable<int> AddBy { get; set; }
        public Nullable<int> Modby { get; set; }
        public Nullable<System.DateTime> Modon { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}