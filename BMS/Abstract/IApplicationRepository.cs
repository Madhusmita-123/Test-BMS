using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.Models;


namespace BMS.Abstract
{
    public interface IApplicationRepository 
    {
        #region---------------------Registration and Login Section--------------------------
        Tran_User_Creation Getuser(string username, string password);
        #region----------------------------Role-------------------
        Role GetRole(int? RoleId);
        List<Role> GetAllRole();
        Role GetRoleData(int roleid);
        bool DeleteRoleData(int id);
        List<Role> GetAllRoleList();
        int SaveRole(RoleModel roleModel);
        #endregion-------------------------------------------------
        #region----------------------------Department-------------------
        List<Mst_Department> GetAllDepartment();
        Mst_Department GetDepartmentData(int deptid);
        bool DeleteDepartmentData(int id);
        int SaveDepartment(DepartmentModel departmentModel);
        #endregion-------------------------------------------------
        #region----------------------------Divison-------------------
        List<Mst_Divison> GetAllDivison();
        Mst_Divison GetDivisonData(int divisonid);
        bool DeleteDivisonData(int id);
        int SaveDivison(DivisionModel divisionModel);
        #endregion-------------------------------------------------
        #region----------------------------Zone-------------------
        List<Mst_Zone> GetAllZone();
        Mst_Zone GetZoneData(int zoneid);
        bool DeleteZoneData(int id);
        int SaveZone(ZoneModel zoneModel);
        #endregion-------------------------------------------------
        List<BudgetType> GetAllBudget();
        List<Head_Master> Gethead();
        #region----------------------------Designation-------------------
        List<Mst_Designation> GetAllDesignation(int? id);
        List<Mst_Designation> GetDesignationList();
        Mst_Designation GetDesignationData(int designationid);
        int SaveDesignation(DesignationModel designationModel);
        bool DeleteDesignationData(int id);
        #endregion-------------------------------------------------
        #region----------------------------Head-------------------
        List<Head_MasterSelectAll_Result> GetHeadList();
        Head_Master GetHeadData(int headid);
        List<Head_Master> Getheaddatabybudget(int? id);
        List<Mst_SubHead> GetSubheaddatabyhead(int? id);
        bool DeleteHeadData(int id);
        int SaveHead(HeadModel headModel);
        #endregion-------------------------------------------------
        #region----------------------------SubHead-------------------
        List<SubHeadMasterAll_Result> GetSubheadList();
        Mst_SubHead GetSubHeadData(int subheadid);
        bool DeleteSubHeadData(int id);
        int SaveSubHead(SubHeadModel subheadModel);
        #endregion-------------------------------------------------
        List<Mst_Unit> GetAllUnit();
        //List<Tran_User_Creation> GetAllUserList();
        #region----------------------------Bank Details-------------------
        List<BankDetails_SelectAll_Result> GetAllBankDetailsList();
        
        Mst_BnkDtls GetBankDetailsData(int bnk_DtlsId);
       
        //List<Role> GetRoleData(int? roleid);
       
        bool DeleteBankDetailData(int id);
        
        int SaveBankDetails(BankDetailsModel bankDetailsModel);
        List<Mst_Bank> GetAllBank();
        #endregion-------------------------------------------------
        #region---------------------Registration and Login Section--------------------------
        
       
       
        
        List<User_Create_Details_Result> GetAllUserList();
        int SaveUser(UserModel userModel);
        Tran_User_Creation GetUserData(int userid);
        List<Tran_User_Creation> GetAllUser(int? id);
        bool DeleteUser(int id);
        #endregion
        #region---------------------country section--------------------------
        int SaveCountry(CountryModel countrymodel);
        List<Mst_Country> GetAllcountryList();
        Mst_Country GetAllcountrydata(int id);
        List<Mst_Country> GetAllCountryDetails(int? id);
        bool DeleteCountry(int id);
        #endregion
        #region---------------------State section--------------------------
        List<StateSelectAll_Result> GetAllsateList();
        int SaveState(StateModel stmodel);
        Mst_State GetAllstatedata(int id);
        //List<Mst_State> GetAllState(int? id);
        bool DeleteState(int id);
        List<Mst_State> GetAllStateDetails();
        List<Mst_State> GetAllState(int? id);
        List<Mst_State> GetStatedata(int? id);
        #endregion
        #region---------------------District section--------------------------
        List<DistrictSelectAll_Result> GetAllDistrictList();
        int SaveDistrict(DistrictModel distmodel);
        Mst_District GetAllDistrictdata(int id);
        List<Mst_District> GetAllDistrict(int? id);
        bool DeleteDistrict(int id);
        #endregion
        #region---------------------Cicle section--------------------------
        List<Mst_Circle> GetAllCircleList();
        int SaveCircle(CircleModel cirmodel);
        Mst_Circle GetAllcircledata(int id);
        List<Mst_Circle> GetAllCircleDetails(int? id);
        bool DeleteCircle(int id);
        List<Mst_Divison> GetAllDivisionList();
        #endregion
        #region---------------------Assign Circle Division section--------------------------
        List<AssignCircleDivisonAll_Result> GetAllAssignCircleDivisionList();
        int SaveAssignCircleDivision(AssignCircleDivisionModel cirmodel);
        Mst_AssignCircleDivison GetAllassigncircledivisiondata(int id);
        List<Mst_AssignCircleDivison> GetAllCircledivisionDetails(int? id);
        bool DeleteAssignCircleDivision(int id);
        #endregion
        #region---------------------Finance section--------------------------
        int SavefinanceYear(FinancialYearModel finmodel);
        List<Financial_Year> GetAllFinanceList();
        Financial_Year GetAllfinancedata(int id);
        List<Financial_Year> GetAllFinanceDetails(int? id);
        bool DeleteFinanceyear(int id);
        #endregion
        #region---------------------Assign Unit To Bank section--------------------------
        List<AssignUnitBankAll_Result> GetAllAssignUnitToBankList();
        int SaveAssignUnitToBank(AssignBankUnitModel cirmodel);
        Mst_AssignUnitToBank GetAllassignUnitToBankdata(int id);
        List<Mst_AssignUnitToBank> GetAllUnitToBankDetails(int? id);
        bool DeleteAssignUnitToBank(int id);
        List<Mst_Bank> GetAllBankList();
        #endregion
        #region---------------------Assign User Approve section--------------------------
        List<AssigneToUser_SelectAll_Result> GetAllAssignUserApproveList();
        //List<User_SelectById_Result> Getunitbyid();
        int SaveAssignUserApprove(AssignUserApprovalMappingModel cirmodel);
        Trans_Assign_User_ToApprov GetAllassignUserToApprovedata(int id);
        List<Trans_Assign_User_ToApprov> GetAllUserApproveDetails(int? id);
        bool DeleteAssignUserApprove(int id);
        List<Mst_ApproveType> GetAllDescriptionList();
        List<Tran_User_Creation> GetAllName(int? id);
        List<Tran_User_Creation> GetAllEmpCode(int? id);
        List<Mst_SubHead> GetAllsubheadCode(int? id);
        List<User_SelectById_Result> GetAllUnitbyid(int? Usr_Id );
        List<SelectAllByUnitAllbyId_Result> GetAllRevenueDetailsList(int? Fin_Id, int? Unit_Id);
        List<SelectAllByUnitAllbyIdd_Result> GetAllRevenueDetailsListsec(int? Fin_Id, int? Unit_Id);
        List<GetRevenueHeadforProposalByUnit_Result> Getheadfrstlvl(int? Fin_Id, int? Unit_Id);
        List<GetRevenueHeadforProposalByUnit_Result> Getheadseclvl(int? Fin_Id, int? Unit_Id);
        List<GetRevenueHeadforProposalByUnit_Result> Getheadfinallvl(int? Fin_Id, int? Unit_Id);
        List<ExpenditureSelectAllByUnit_Result> GetAllRevenueDetailsListfstbudget(int? Fin_Id, int? Unit_Id, int? Head_Id);
        List<ExpenditureSelectAllByUnitForFinal_Result> GetAllRevenueDetailsListfinalbudget(int? Fin_Id, int? Unit_Id, int? Head_Id);
        List<ExpendSelectAllForHoApprove_Result> GetAllRevenueDetailsListsecbudget(int? Fin_Id, int? Unit_Id, int? Head_Id);
        //int SaveRevenue(RevenueProposalByUnitModel revenueModel);
        bool SaveRevenue(List<Trans_Revnu_Expenditure_By_Unit> customers);
        bool UpdateRevenue(List<RevenueSecLevelModel> customers,int?id);
        bool Updateholevelfinal(List<RevenueSecLevelModel> customers, int? id);
        bool Updateholevelfrst(List<RevenueSecLevelModel> customers, int? id);
        bool Updateholevelsec(List<RevenueSecLevelModel> customers, int? id);
        #endregion

        #endregion--------------------------------------------
    }
}
