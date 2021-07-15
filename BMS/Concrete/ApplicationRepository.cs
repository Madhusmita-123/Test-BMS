using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using BMS.Abstract;
using System.Text;
using BMS.Models;

namespace BMS.Concrete
{
    public class ApplicationRepository : IApplicationRepository
    {
        BMSEntities con = new BMSEntities();

        public Tran_User_Creation Getuser(string username, string password)
        {
            var data = con.Tran_User_Creation.Where(x => x.Usr_Nm == username && x.Pwd== password).FirstOrDefault();

            return data;
        }
        #region----------------------------Role-------------------
        public Role GetRole(int? RoleId)
        {
            var data = con.Roles.Where(x => x.RoleID == RoleId).FirstOrDefault();

            return data;
        }

        public List<Role> GetAllRole()
        {
            var data = con.Roles.ToList();

            return data;
        }
        public List<Role> GetAllRoleList()
        {

            var data = con.Roles.Where(o => o.IsActive == true).ToList();

            return data;
        }
        public Role GetRoleData(int roleid)
        {
            var data = con.Roles.Where(x => x.RoleID == roleid).FirstOrDefault();

            return data;
        }
        public int SaveRole(RoleModel roleModel)
        {
            if (roleModel.Role.RoleID != null && roleModel.Role.RoleID != 0)
            {
                var role = con.Roles.Where(x => x.RoleID == roleModel.Role.RoleID).FirstOrDefault();
                role.RoleDesc = roleModel.Role.RoleDesc;


                role.modon = DateTime.Now;
                role.modby = roleModel.Role.addby;
                con.SaveChanges();

                return 1;
            }
            else
            {
                Role role = new Role();
                role.RoleDesc = roleModel.Role.RoleDesc;
                role.IsActive = true;
                role.IsDelete = false;


                role.addon = DateTime.Now;
                role.addby = roleModel.Role.addby;
                con.Roles.Add(role);
                con.SaveChanges();

                return 2;
            }
        }
        public bool DeleteRoleData(int id)
        {
            var data = con.Roles.Where(x => x.RoleID == id).FirstOrDefault();
            data.IsActive = false;
            // con.Roles.Remove(data);
            con.SaveChanges();
            return true;
        }
        #endregion-------------------------------------------------
        public List<Mst_Unit> GetAllUnit()
        {
            var data = con.Mst_Unit.ToList();

            return data;
        }
        #region----------------------------Designation-------------------
        public List<Mst_Designation> GetDesignationList()
        {
            var data = con.Mst_Designation.Where(o => o.IsActive == true).ToList();

            return data;
        }
        public List<Mst_Designation> GetAllDesignation(int? id)
        {

            if (id != 0)
            {
                var data = con.Mst_Designation.Where(x => x.Dept_ID == id).ToList();

                return data;
            }
            else
            {
                var data = con.Mst_Designation.ToList();

                return data;
            }

        }
        public Mst_Designation GetDesignationData(int designationid)
        {
            var data = con.Mst_Designation.Where(x => x.Desg_ID == designationid).FirstOrDefault();

            return data;
        }
        public bool DeleteDesignationData(int id)
        {
            var data = con.Mst_Designation.Where(x => x.Desg_ID == id).FirstOrDefault();
            data.IsActive = false;
            // con.Roles.Remove(data);
            con.SaveChanges();
            return true;
        }
        public int SaveDesignation(DesignationModel designationModel)
        {
            if (designationModel.Designation.Desg_ID != null && designationModel.Designation.Desg_ID != 0)
            {
                var designation = con.Mst_Designation.Where(x => x.Desg_ID == designationModel.Designation.Desg_ID).FirstOrDefault();
                designation.Dept_ID = designationModel.Designation.Dept_ID;
                designation.Designation_Name = designationModel.Designation.Designation_Name;
                designation.Desg_Code = designationModel.Designation.Desg_Code;
                designation.modon = DateTime.Now;
                designation.modby = designationModel.Designation.addby;
                con.SaveChanges();

                return 1;
            }
            else
            {
                Mst_Designation designation = new Mst_Designation();
                designation.Dept_ID = designationModel.Designation.Dept_ID;
                designation.Designation_Name = designationModel.Designation.Designation_Name;
                designation.Desg_Code = designationModel.Designation.Desg_Code;
                designation.IsActive = true;
                designation.IsDelete = false;


                designation.addon = DateTime.Now;
                designation.addby = designationModel.Designation.addby;
                con.Mst_Designation.Add(designation);
                con.SaveChanges();

                return 2;
            }
        }
        #endregion-------------------------------------------------
        #region----------------------------Department-------------------
        public List<Mst_Department> GetAllDepartment()
        {
            var data = con.Mst_Department.Where(o => o.isactive == true).ToList();

            return data;
        }
        public int SaveDepartment(DepartmentModel departmentModel)
        {
            if (departmentModel.Department.Dept_ID != null && departmentModel.Department.Dept_ID != 0)
            {
                var department = con.Mst_Department.Where(x => x.Dept_ID == departmentModel.Department.Dept_ID).FirstOrDefault();
                department.Dept_Code = departmentModel.Department.Dept_Code;
                department.Dept_Name = departmentModel.Department.Dept_Name;

                department.modon = DateTime.Now;
                department.modby = departmentModel.Department.addby;
                con.SaveChanges();

                return 1;
            }
            else
            {
                Mst_Department department = new Mst_Department();
                department.Dept_Code = departmentModel.Department.Dept_Code;
                department.Dept_Name = departmentModel.Department.Dept_Name;
                department.isactive = true;
                department.isdelete = false;


                department.addon = DateTime.Now;
                department.addby = departmentModel.Department.addby;
                con.Mst_Department.Add(department);
                con.SaveChanges();

                return 2;
            }
        }
        public Mst_Department GetDepartmentData(int deptid)
        {
            var data = con.Mst_Department.Where(x => x.Dept_ID == deptid).FirstOrDefault();

            return data;
        }
        public bool DeleteDepartmentData(int id)
        {
            var data = con.Mst_Department.Where(x => x.Dept_ID == id).FirstOrDefault();
            data.isactive = false;
            // con.Roles.Remove(data);
            con.SaveChanges();
            return true;
        }
        #endregion-------------------------------------------------
        #region----------------------------Divison-------------------
        public List<Mst_Divison> GetAllDivison()
        {
            var data = con.Mst_Divison.Where(o => o.IsActive == true).ToList();

            return data;
        }
        public int SaveDivison(DivisionModel divisonModel)
        {
            if (divisonModel.divison.divisonid != null && divisonModel.divison.divisonid != 0)
            {
                var divison = con.Mst_Divison.Where(x => x.divisonid == divisonModel.divison.divisonid).FirstOrDefault();
                divison.divisonname = divisonModel.divison.divisonname;


                divison.ModOn = DateTime.Now;
                divison.ModBy = divisonModel.divison.AddBy;
                con.SaveChanges();

                return 1;
            }
            else
            {
                Mst_Divison divison = new Mst_Divison();
                divison.divisonname = divisonModel.divison.divisonname;
                divison.IsActive = true;
                divison.IsDelete = false;


                divison.AddOn = DateTime.Now;
                divison.AddBy = divisonModel.divison.AddBy;
                con.Mst_Divison.Add(divison);
                con.SaveChanges();

                return 2;
            }
        }
        public Mst_Divison GetDivisonData(int divisonid)
        {
            var data = con.Mst_Divison.Where(x => x.divisonid == divisonid).FirstOrDefault();

            return data;
        }
        public bool DeleteDivisonData(int id)
        {
            var data = con.Mst_Divison.Where(x => x.divisonid == id).FirstOrDefault();
            data.IsActive = false;
            // con.Roles.Remove(data);
            con.SaveChanges();
            return true;
        }
        #endregion-------------------------------------------------
        #region----------------------------Zone-------------------
        public List<Mst_Zone> GetAllZone()
        {
            var data = con.Mst_Zone.Where(o => o.IsActive == true).ToList();

            return data;
        }
        #endregion-------------------------------------------------
        
        public List<BudgetType> GetAllBudget()
        {
            var data = con.BudgetTypes.ToList();

            return data;
        }

        public List<Head_Master> Gethead()
        {
            var data = con.Head_Master.ToList();

            return data;
        }

        #region-------------------Head----------------------------------
        public int SaveHead(HeadModel headModel)
        {
            if (headModel.Head.Head_Id != null && headModel.Head.Head_Id != 0)
            {
                var head = con.Head_Master.Where(x => x.Head_Id == headModel.Head.Head_Id).FirstOrDefault();
                head.BugtTyp_Id = headModel.Head.BugtTyp_Id;
                head.Head_Id = headModel.Head.Head_Id;
                head.hdnm = headModel.Head.hdnm;
                head.hdcode = headModel.Head.hdcode;
                head.modon = DateTime.Now;
                head.modby = headModel.Head.addby;
                con.SaveChanges();

                return 1;
            }
            else
            {
                Head_Master head = new Head_Master();
                head.BugtTyp_Id = headModel.Head.BugtTyp_Id;
                head.Head_Id = headModel.Head.Head_Id;
                head.hdnm = headModel.Head.hdnm;
                head.hdcode = headModel.Head.hdcode;
                head.IsActive = true;
                head.isdelete = false;


                head.addon = DateTime.Now;
                head.addby = headModel.Head.addby;
                con.Head_Master.Add(head);
                con.SaveChanges();

                return 2;
            }
        }
        public List<Head_MasterSelectAll_Result> GetHeadList()
        {
            var data = con.Head_MasterSelectAll().ToList();

            return data;
        }
       
        public Head_Master GetHeadData(int headid)
        {
            var data = con.Head_Master.Where(x => x.Head_Id == headid).FirstOrDefault();

            return data;
        }
        public bool DeleteHeadData(int id)
        {
            var data = con.Head_Master.Where(x => x.Head_Id == id).FirstOrDefault();
            data.IsActive = false;
            // con.Roles.Remove(data);
            con.SaveChanges();
            return true;
        }
        public List<Head_Master> Getheaddatabybudget(int? id)
        {

            if (id != 0)
            {
                var data = con.Head_Master.Where(x => x.BugtTyp_Id == id).ToList();

                return data;
            }
            else
            {
                var data = con.Head_Master.ToList();

                return data;
            }

        }
        public List<Mst_SubHead> GetSubheaddatabyhead(int? id)
        {

            if (id != 0)
            {
                var data = con.Mst_SubHead.Where(x => x.Head_Id == id).ToList();

                return data;
            }
            else
            {
                var data = con.Mst_SubHead.ToList();

                return data;
            }

        }
        #endregion-------------------------------------------------

        //public List<Tran_User_Creation> GetAllUserList()
        //{
        //    var data = con.Tran_User_Creation.ToList();

        //    return data;
        //}


        #region-------------------SubHead----------------------------------
        public int SaveSubHead(SubHeadModel subheadModel)
        {
            if (subheadModel.SubHead.SubHead_Id != null && subheadModel.SubHead.SubHead_Id != 0)
            {
                var Subhead = con.Mst_SubHead.Where(x => x.SubHead_Id == subheadModel.SubHead.SubHead_Id).FirstOrDefault();
                Subhead.BugtTyp_Id = subheadModel.SubHead.BugtTyp_Id;
                Subhead.SubHead_Id = subheadModel.SubHead.SubHead_Id;
                Subhead.Head_Id = subheadModel.SubHead.Head_Id;
                Subhead.SubHead_Name = subheadModel.SubHead.SubHead_Name;
                Subhead.SubHead_Code = subheadModel.SubHead.SubHead_Code;
                Subhead.ModOn = DateTime.Now;
                Subhead.ModBy = subheadModel.SubHead.AddBy;
                con.SaveChanges();

                return 1;
            }
            else
            {
                Mst_SubHead Subhead = new Mst_SubHead();
                Subhead.BugtTyp_Id = subheadModel.SubHead.BugtTyp_Id;
                Subhead.SubHead_Id = subheadModel.SubHead.SubHead_Id;
                Subhead.Head_Id = subheadModel.SubHead.Head_Id;
                Subhead.SubHead_Name = subheadModel.SubHead.SubHead_Name;
                Subhead.SubHead_Code = subheadModel.SubHead.SubHead_Code;
                Subhead.IsActive = true;
                Subhead.IsDelete = false;


                Subhead.AddOn = DateTime.Now;
                Subhead.AddBy = subheadModel.SubHead.AddBy;
                con.Mst_SubHead.Add(Subhead);
                con.SaveChanges();

                return 2;
            }
        }
        public List<SubHeadMasterAll_Result> GetSubheadList()
        {
            var data = con.SubHeadMasterAll().ToList();

            return data;
        }
        public Mst_SubHead GetSubHeadData(int subheadid)
        {
            var data = con.Mst_SubHead.Where(x => x.SubHead_Id == subheadid).FirstOrDefault();

            return data;
        }
        public bool DeleteSubHeadData(int id)
        {
            var data = con.Mst_SubHead.Where(x => x.SubHead_Id == id).FirstOrDefault();
            data.IsActive = false;
            // con.Roles.Remove(data);
            con.SaveChanges();
            return true;
        }

        #endregion-------------------------------------------------
        #region-------------------Zone---------------------------------
        public int SaveZone(ZoneModel zoneModel)
        {
            if (zoneModel.Zone.zoneid != null && zoneModel.Zone.zoneid != 0)
            {
                var zone = con.Mst_Zone.Where(x => x.zoneid == zoneModel.Zone.zoneid).FirstOrDefault();
                zone.zonename = zoneModel.Zone.zonename;


                zone.ModOn = DateTime.Now;
                zone.ModBy = zoneModel.Zone.AddBy;
                con.SaveChanges();

                return 1;
            }
            else
            {
                Mst_Zone zone = new Mst_Zone();
                zone.zonename = zoneModel.Zone.zonename;
                zone.IsActive = true;
                zone.IsDelete = false;


                zone.AddOn = DateTime.Now;
                zone.AddBy = zoneModel.Zone.AddBy;
                con.Mst_Zone.Add(zone);
                con.SaveChanges();

                return 2;
            }
        }
        public Mst_Zone GetZoneData(int zoneid)
        {
            var data = con.Mst_Zone.Where(x => x.zoneid == zoneid).FirstOrDefault();

            return data;
        }
        public bool DeleteZoneData(int id)
        {
            var data = con.Mst_Zone.Where(x => x.zoneid == id).FirstOrDefault();
            data.IsActive = false;
            // con.Roles.Remove(data);
            con.SaveChanges();
            return true;
        }
        #endregion-------------------------------------------------
        #region-------------------BankDetails---------------------------------
        public int SaveBankDetails(BankDetailsModel bankDetailsModel)
        {
            if (bankDetailsModel.BnkDtls.Bnk_DtlsId != null && bankDetailsModel.BnkDtls.Bnk_DtlsId != 0)
            {
                var bankdetail = con.Mst_BnkDtls.Where(x => x.Bnk_DtlsId == bankDetailsModel.BnkDtls.Bnk_DtlsId).FirstOrDefault();
                bankdetail.bnkid = bankDetailsModel.BnkDtls.bnkid;
                bankdetail.Branch = bankDetailsModel.BnkDtls.Branch;
                bankdetail.Acnt_holderName = bankDetailsModel.BnkDtls.Acnt_holderName;
                bankdetail.IFSC_Code = bankDetailsModel.BnkDtls.IFSC_Code;
                bankdetail.AccountType = bankDetailsModel.BnkDtls.AccountType;
                bankdetail.Account_Number = bankDetailsModel.BnkDtls.Account_Number;
                bankdetail.Address = bankDetailsModel.BnkDtls.Address;
                bankdetail.ModOn = DateTime.Now;
                bankdetail.ModBy = bankDetailsModel.BnkDtls.AddBy;
                con.SaveChanges();

                return 1;
            }
            else
            {
                Mst_BnkDtls bankdetail = new Mst_BnkDtls();
                bankdetail.bnkid = bankDetailsModel.BnkDtls.bnkid;
                bankdetail.Branch = bankDetailsModel.BnkDtls.Branch;
                bankdetail.Acnt_holderName = bankDetailsModel.BnkDtls.Acnt_holderName;
                bankdetail.IFSC_Code = bankDetailsModel.BnkDtls.IFSC_Code;
                bankdetail.AccountType = bankDetailsModel.BnkDtls.AccountType;
                bankdetail.Account_Number = bankDetailsModel.BnkDtls.Account_Number;
                bankdetail.Address = bankDetailsModel.BnkDtls.Address;
                bankdetail.IsActive = true;
                bankdetail.IsDelete = false;


                bankdetail.AddOn = DateTime.Now;
                bankdetail.AddBy = bankDetailsModel.BnkDtls.AddBy;
                con.Mst_BnkDtls.Add(bankdetail);
                con.SaveChanges();

                return 2;
            }
        }
      
        public Mst_BnkDtls GetBankDetailsData(int bnk_DtlsId)
        {
            var data = con.Mst_BnkDtls.Where(x => x.Bnk_DtlsId == bnk_DtlsId).FirstOrDefault();

            return data;
        }
       
        public bool DeleteBankDetailData(int id)
        {
            var data = con.Mst_BnkDtls.Where(x => x.Bnk_DtlsId == id).FirstOrDefault();
            data.IsActive = false;
            // con.Roles.Remove(data);
            con.SaveChanges();
            return true;
        }
        public List<Mst_Bank> GetAllBank()
        {
            var data = con.Mst_Bank.ToList();

            return data;
        }
        public List<BankDetails_SelectAll_Result> GetAllBankDetailsList()
        {

            var data = con.BankDetails_SelectAll().ToList();

            return data;
        }
        #endregion-------------------------------------------------
        public string Pwd(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }




        //public List<Mst_Unit> GetAllUnit()
        //{
        //    var data = con.Mst_Unit.ToList();

        //    return data;
        //}


        #region-------------------------Create UserDetails---------------------
        public List<User_Create_Details_Result> GetAllUserList()
        {
            var data = con.User_Create_Details().ToList();

            return data;
        }
        public int SaveUser(UserModel userModel)
        {
            if (userModel.User.Usr_Id != null && userModel.User.Usr_Id != 0)
            {
                Tran_User_Creation user = con.Tran_User_Creation.Where(x => x.Usr_Id == userModel.User.Usr_Id).FirstOrDefault();
                user.Name = userModel.User.Name;
                user.Unit_Id = userModel.User.Unit_Id;
                user.Usr_Nm = userModel.User.Usr_Nm;
                user.Email = userModel.User.Email;
                user.EmpCode = userModel.User.EmpCode;
                user.Phone = userModel.User.Phone;
                user.RoleID = userModel.User.RoleID;
                user.Dept_ID = userModel.User.Dept_ID;
                user.Desg_ID = userModel.User.Desg_ID;
                user.ModOn = DateTime.Now;
                user.ModBy = userModel.User.AddBy;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Tran_User_Creation user = new Tran_User_Creation();
                user.Name = userModel.User.Name;
                user.Unit_Id = userModel.User.Unit_Id;
                user.Usr_Nm = userModel.User.Usr_Nm;
                user.Pwd = Pwd(6);
                user.Email = userModel.User.Email;
                user.EmpCode = userModel.User.EmpCode;
                user.Phone = userModel.User.Phone;
                user.RoleID = userModel.User.RoleID;
                user.Dept_ID = userModel.User.Dept_ID;
                user.Desg_ID = userModel.User.Desg_ID;
                user.IsActive = true;
                user.IsDelete = false;
                user.AddOn = DateTime.Now;
                user.AddBy = userModel.User.AddBy;
                con.Tran_User_Creation.Add(user);
                con.SaveChanges();
                return 2;
            }
        }
        //public string Pwd(int length)
        //{
        //    const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //    StringBuilder res = new StringBuilder();
        //    Random rnd = new Random();
        //    while (0 < length--)
        //    {
        //        res.Append(valid[rnd.Next(valid.Length)]);
        //    }
        //    return res.ToString();
        //}

        public Tran_User_Creation GetUserData(int userid)
        {
            var data = con.Tran_User_Creation.Where(x => x.Usr_Id == userid).FirstOrDefault();

            return data;
        }
        public List<Tran_User_Creation> GetAllUser(int? id)
        {
            var data = con.Tran_User_Creation.Where(x => x.Usr_Id == id).ToList();

            return data;
        }
        public bool DeleteUser(int id)
        {
            var data = con.Tran_User_Creation.Where(x => x.Usr_Id == id).FirstOrDefault();

            data.IsActive = false;
            con.SaveChanges();

            return true;
        }
        #endregion
        #region---------------------country section--------------------------
        public int SaveCountry(CountryModel countrymodel)
        {
            if (countrymodel.country1.Con_Id != null && countrymodel.country1.Con_Id != 0)
            {
                Mst_Country cnt = con.Mst_Country.Where(x => x.Con_Id == countrymodel.country1.Con_Id).FirstOrDefault();
                cnt.Con_Nm = countrymodel.country1.Con_Nm;
                cnt.ModOn = DateTime.Now;
                cnt.ModBy = countrymodel.country1.AddBy;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Mst_Country cnt = new Mst_Country();
                cnt.Con_Nm = countrymodel.country1.Con_Nm;
                cnt.IsActive = true;
                cnt.IsDelete = false;
                cnt.AddOn = DateTime.Now;
                cnt.AddBy = countrymodel.country1.AddBy;
                con.Mst_Country.Add(cnt);
                con.SaveChanges();
                return 2;
            }

        }
        public List<Mst_Country> GetAllcountryList()
        {
            var data = con.Mst_Country.Where(x => x.IsActive == true).ToList();

            return data;
        }
        public Mst_Country GetAllcountrydata(int id)
        {
            var data = con.Mst_Country.Where(x => x.Con_Id == id).FirstOrDefault();

            return data;
        }
        public List<Mst_Country> GetAllCountryDetails(int? id)
        {
            var data = con.Mst_Country.Where(x => x.Con_Id == id).ToList();

            return data;
        }

        public bool DeleteCountry(int id)
        {
            var data = con.Mst_Country.Where(x => x.Con_Id == id).FirstOrDefault();

            data.IsActive = false;
            con.SaveChanges();

            return true;
        }
        #endregion
        #region---------------------State section--------------------------
        public List<StateSelectAll_Result> GetAllsateList()
        {
            var data = con.StateSelectAll().ToList();

            return data;
        }

        public int SaveState(StateModel stmodel)
        {
            if (stmodel.state1.St_Id != null && stmodel.state1.St_Id != 0)
            {
                Mst_State st = con.Mst_State.Where(x => x.St_Id == stmodel.state1.St_Id).FirstOrDefault();
                st.Con_Id = stmodel.state1.Con_Id;
                st.St_Nm = stmodel.state1.St_Nm;
                st.ModOn = DateTime.Now;
                st.ModBy = stmodel.state1.AddBy;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Mst_State st = new Mst_State();
                st.Con_Id = stmodel.state1.Con_Id;
                st.St_Nm = stmodel.state1.St_Nm;
                st.IsActive = true;
                st.IsDelete = false;
                st.AddOn = DateTime.Now;
                st.AddBy = stmodel.state1.AddBy;
                con.Mst_State.Add(st);
                con.SaveChanges();
                return 2;
            }

        }
        public Mst_State GetAllstatedata(int id)
        {
            var data = con.Mst_State.Where(x => x.St_Id == id).FirstOrDefault();

            return data;
        }
        public List<Mst_State> GetAllState(int? id)
        {
            var data = con.Mst_State.Where(x => x.St_Id == id).ToList();

            return data;
        }
        public bool DeleteState(int id)
        {
            var data = con.Mst_State.Where(x => x.St_Id == id).FirstOrDefault();

            data.IsActive = false;
            con.SaveChanges();

            return true;
        }
        public List<Mst_State> GetAllStateDetails()
        {
            var data = con.Mst_State.ToList();

            return data;
        }
        public List<Mst_State> GetStatedata(int? id)
        {

            if (id != 0)
            {
                var data = con.Mst_State.Where(x => x.Con_Id == id).ToList();

                return data;
            }
            else
            {
                var data = con.Mst_State.ToList();

                return data;
            }

        }
        #endregion
        #region---------------------District section--------------------------
        public List<DistrictSelectAll_Result> GetAllDistrictList()
        {
            var data = con.DistrictSelectAll().ToList();

            return data;
        }

        public int SaveDistrict(DistrictModel distmodel)
        {
            if (distmodel.District.Dst_Id != null && distmodel.District.Dst_Id != 0)
            {
                Mst_District st = con.Mst_District.Where(x => x.Dst_Id == distmodel.District.Dst_Id).FirstOrDefault();
                st.Con_Id = distmodel.District.Con_Id;
                st.St_Id = distmodel.District.St_Id;
                st.Dst_Nm = distmodel.District.Dst_Nm;
                st.ModOn = DateTime.Now;
                st.ModBy = distmodel.District.AddBy;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Mst_District st = new Mst_District();
                st.Con_Id = distmodel.District.Con_Id;
                st.St_Id = distmodel.District.St_Id;
                st.Dst_Nm = distmodel.District.Dst_Nm;
                st.IsActive = true;
                st.IsDelete = false;
                st.AddOn = DateTime.Now;
                st.AddBy = distmodel.District.AddBy;
                con.Mst_District.Add(st);
                con.SaveChanges();
                return 2;
            }

        }
        public Mst_District GetAllDistrictdata(int id)
        {
            var data = con.Mst_District.Where(x => x.Dst_Id == id).FirstOrDefault();

            return data;
        }
        public List<Mst_District> GetAllDistrict(int? id)
        {
            var data = con.Mst_District.Where(x => x.Dst_Id == id).ToList();

            return data;
        }
        public bool DeleteDistrict(int id)
        {
            var data = con.Mst_District.Where(x => x.Dst_Id == id).FirstOrDefault();

            data.IsActive = false;
            con.SaveChanges();

            return true;
        }
        #endregion
        #region---------------------circle section--------------------------
        public int SaveCircle(CircleModel cirmodel)
        {
            if (cirmodel.circle.circleid != null && cirmodel.circle.circleid != 0)
            {
                Mst_Circle cnt = con.Mst_Circle.Where(x => x.circleid == cirmodel.circle.circleid).FirstOrDefault();
                cnt.circlename = cirmodel.circle.circlename;
                cnt.ModOn = DateTime.Now;
                cnt.ModBy = cirmodel.circle.AddBy;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Mst_Circle cnt = new Mst_Circle();
                cnt.circlename = cirmodel.circle.circlename;
                cnt.IsActive = true;
                cnt.IsDelete = false;
                cnt.AddOn = DateTime.Now;
                cnt.AddBy = cirmodel.circle.AddBy;
                con.Mst_Circle.Add(cnt);
                con.SaveChanges();
                return 2;
            }

        }
        public List<Mst_Circle> GetAllCircleList()
        {
            var data = con.Mst_Circle.Where(x => x.IsActive == true).ToList();

            return data;
        }
        public Mst_Circle GetAllcircledata(int id)
        {
            var data = con.Mst_Circle.Where(x => x.circleid == id).FirstOrDefault();

            return data;
        }
        public List<Mst_Circle> GetAllCircleDetails(int? id)
        {
            var data = con.Mst_Circle.Where(x => x.circleid == id).ToList();

            return data;
        }

        public bool DeleteCircle(int id)
        {
            var data = con.Mst_Circle.Where(x => x.circleid == id).FirstOrDefault();

            data.IsActive = false;
            con.SaveChanges();

            return true;
        }
        public List<Mst_Divison> GetAllDivisionList()
        {
            var data = con.Mst_Divison.Where(x => x.IsActive == true).ToList();

            return data;
        }
        #endregion
        #region---------------------Assign circle Division section--------------------------
        public List<AssignCircleDivisonAll_Result> GetAllAssignCircleDivisionList()
        {
            var data = con.AssignCircleDivisonAll().ToList();

            return data;
        }
        public int SaveAssignCircleDivision(AssignCircleDivisionModel cirmodel)
        {
            if (cirmodel.assigncd.AssignCircleDivisonid != null && cirmodel.assigncd.AssignCircleDivisonid != 0)
            {
                Mst_AssignCircleDivison cnt = con.Mst_AssignCircleDivison.Where(x => x.AssignCircleDivisonid == cirmodel.assigncd.AssignCircleDivisonid).FirstOrDefault();
                cnt.circleid = cirmodel.assigncd.circleid;
                cnt.divisonid = cirmodel.assigncd.divisonid;
                cnt.ModOn = DateTime.Now;
                cnt.ModBy = cirmodel.assigncd.AddBy;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Mst_AssignCircleDivison cnt = new Mst_AssignCircleDivison();
                cnt.circleid = cirmodel.assigncd.circleid;
                cnt.divisonid = cirmodel.assigncd.divisonid;
                cnt.IsActive = true;
                cnt.IsDelete = false;
                cnt.AddOn = DateTime.Now;
                cnt.AddBy = cirmodel.assigncd.AddBy;
                con.Mst_AssignCircleDivison.Add(cnt);
                con.SaveChanges();
                return 2;
            }

        }
        public Mst_AssignCircleDivison GetAllassigncircledivisiondata(int id)
        {
            var data = con.Mst_AssignCircleDivison.Where(x => x.AssignCircleDivisonid == id).FirstOrDefault();

            return data;
        }
        public List<Mst_AssignCircleDivison> GetAllCircledivisionDetails(int? id)
        {
            var data = con.Mst_AssignCircleDivison.Where(x => x.AssignCircleDivisonid == id).ToList();

            return data;
        }

        public bool DeleteAssignCircleDivision(int id)
        {
            var data = con.Mst_AssignCircleDivison.Where(x => x.AssignCircleDivisonid == id).FirstOrDefault();

            data.IsActive = false;
            con.SaveChanges();

            return true;
        }

        #endregion

        #region---------------------Finance section--------------------------
        public int SavefinanceYear(FinancialYearModel finmodel)
        {
            if (finmodel.finance.Fin_Id != null && finmodel.finance.Fin_Id != 0)
            {
                Financial_Year cnt = con.Financial_Year.Where(x => x.Fin_Id == finmodel.finance.Fin_Id).FirstOrDefault();
                cnt.Fin_Yr = finmodel.finance.Fin_Yr;
                cnt.ModOn = DateTime.Now;
                cnt.ModBy = finmodel.finance.AddBy;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Financial_Year cnt = new Financial_Year();
                cnt.Fin_Yr = finmodel.finance.Fin_Yr;
                cnt.IsActive = true;
                cnt.IsDelete = false;
                cnt.AddOn = DateTime.Now;
                cnt.AddBy = finmodel.finance.AddBy;
                con.Financial_Year.Add(cnt);
                con.SaveChanges();
                return 2;
            }

        }
        public List<Financial_Year> GetAllFinanceList()
        {
            var data = con.Financial_Year.Where(x => x.IsActive == true).ToList();

            return data;
        }
        public Financial_Year GetAllfinancedata(int id)
        {
            var data = con.Financial_Year.Where(x => x.Fin_Id == id).FirstOrDefault();

            return data;
        }
        public List<Financial_Year> GetAllFinanceDetails(int? id)
        {
            var data = con.Financial_Year.Where(x => x.Fin_Id == id).ToList();

            return data;
        }

        public bool DeleteFinanceyear(int id)
        {
            var data = con.Financial_Year.Where(x => x.Fin_Id == id).FirstOrDefault();

            data.IsActive = false;
            con.SaveChanges();

            return true;
        }
        #endregion
        #region---------------------Assign Unit to Bank section--------------------------
        public List<AssignUnitBankAll_Result> GetAllAssignUnitToBankList()
        {
            var data = con.AssignUnitBankAll().ToList();

            return data;
        }
        public int SaveAssignUnitToBank(AssignBankUnitModel cirmodel)
        {
            if (cirmodel.assignbankunit.Assg_unitbnkid != null && cirmodel.assignbankunit.Assg_unitbnkid != 0)
            {
                Mst_AssignUnitToBank cnt = con.Mst_AssignUnitToBank.Where(x => x.Assg_unitbnkid == cirmodel.assignbankunit.Assg_unitbnkid).FirstOrDefault();
                cnt.Unit_Id = cirmodel.assignbankunit.Unit_Id;
                cnt.bnkid = cirmodel.assignbankunit.bnkid;
                cnt.ModOn = DateTime.Now;
                cnt.ModBy = cirmodel.assignbankunit.AddBy;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Mst_AssignUnitToBank cnt = new Mst_AssignUnitToBank();
                cnt.Unit_Id = cirmodel.assignbankunit.Unit_Id;
                cnt.bnkid = cirmodel.assignbankunit.bnkid;
                cnt.IsActive = true;
                cnt.IsDelete = false;
                cnt.AddOn = DateTime.Now;
                cnt.AddBy = cirmodel.assignbankunit.AddBy;
                con.Mst_AssignUnitToBank.Add(cnt);
                con.SaveChanges();
                return 2;
            }

        }
        public Mst_AssignUnitToBank GetAllassignUnitToBankdata(int id)
        {
            var data = con.Mst_AssignUnitToBank.Where(x => x.Assg_unitbnkid == id).FirstOrDefault();

            return data;
        }
        public List<Mst_AssignUnitToBank> GetAllUnitToBankDetails(int? id)
        {
            var data = con.Mst_AssignUnitToBank.Where(x => x.Assg_unitbnkid == id).ToList();

            return data;
        }

        public bool DeleteAssignUnitToBank(int id)
        {
            var data = con.Mst_AssignUnitToBank.Where(x => x.Assg_unitbnkid == id).FirstOrDefault();

            data.IsActive = false;
            con.SaveChanges();
            return true;
        }
        public List<Mst_Bank> GetAllBankList()
        {
            var data = con.Mst_Bank.ToList();

            return data;
        }
        #endregion
        #region---------------------Assign User Approve--------------------------
        public List<AssigneToUser_SelectAll_Result> GetAllAssignUserApproveList()
        {
            var data = con.AssigneToUser_SelectAll().ToList();

            return data;
        }
        public int SaveAssignUserApprove(AssignUserApprovalMappingModel cirmodel)
        {
            if (cirmodel.Assignusertoapprove.Asgn_usr_Aprv_ID != null && cirmodel.Assignusertoapprove.Asgn_usr_Aprv_ID != 0)
            {
                Trans_Assign_User_ToApprov cnt = con.Trans_Assign_User_ToApprov.Where(x => x.Asgn_usr_Aprv_ID == cirmodel.Assignusertoapprove.Asgn_usr_Aprv_ID).FirstOrDefault();
                cnt.Unit_Id = cirmodel.Assignusertoapprove.Unit_Id;
                cnt.Aprov_Type_ID = cirmodel.Assignusertoapprove.Aprov_Type_ID;
                cnt.Usr_Id = cirmodel.Assignusertoapprove.Usr_Id;
                cnt.FromDt = cirmodel.Assignusertoapprove.FromDt;
                cnt.Modon = DateTime.Now;
                cnt.Modby = cirmodel.Assignusertoapprove.Addby;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Trans_Assign_User_ToApprov cnt = new Trans_Assign_User_ToApprov();
                cnt.Unit_Id = cirmodel.Assignusertoapprove.Unit_Id;
                cnt.Aprov_Type_ID = cirmodel.Assignusertoapprove.Aprov_Type_ID;
                cnt.Usr_Id = cirmodel.Assignusertoapprove.Usr_Id;
                cnt.FromDt = cirmodel.Assignusertoapprove.FromDt;
                cnt.IsActive = true;
                cnt.IsDelete = false;
                cnt.Addon = DateTime.Now;
                cnt.Addby = cirmodel.Assignusertoapprove.Addby;
                con.Trans_Assign_User_ToApprov.Add(cnt);
                con.SaveChanges();
                return 2;
            }

        }
        public Trans_Assign_User_ToApprov GetAllassignUserToApprovedata(int id)
        {
            var data = con.Trans_Assign_User_ToApprov.Where(x => x.Asgn_usr_Aprv_ID == id).FirstOrDefault();

            return data;
        }
        public List<Trans_Assign_User_ToApprov> GetAllUserApproveDetails(int? id)
        {
            var data = con.Trans_Assign_User_ToApprov.Where(x => x.Asgn_usr_Aprv_ID == id).ToList();

            return data;
        }

        public bool DeleteAssignUserApprove(int id)
        {
            var data = con.Trans_Assign_User_ToApprov.Where(x => x.Asgn_usr_Aprv_ID == id).FirstOrDefault();

            data.IsActive = false;
            con.SaveChanges();
            return true;
        }
        public List<Mst_ApproveType> GetAllDescriptionList()
        {
            var data = con.Mst_ApproveType.ToList();

            return data;
        }
        public List<Tran_User_Creation> GetAllName(int? id)
        {

            if (id != 0)
            {
                var data = con.Tran_User_Creation.Where(x => x.Unit_Id == id).ToList();

                return data;
            }
            else
            {
                var data = con.Tran_User_Creation.ToList();

                return data;
            }

        }
        public List<Tran_User_Creation> GetAllEmpCode(int? id)
        {

            if (id != 0)
            {
                var data = con.Tran_User_Creation.Where(x => x.Usr_Id == id).ToList();

                return data;
            }
            else
            {
                var data = con.Tran_User_Creation.ToList();

                return data;
            }

        }
        public List<Mst_SubHead> GetAllsubheadCode(int? id)
        {

            if (id != 0)
            {
                var data = con.Mst_SubHead.Where(x => x.SubHead_Id == id).ToList();

                return data;
            }
            else
            {
                var data = con.Mst_SubHead.ToList();

                return data;
            }

        }
        #endregion

        public List<User_SelectById_Result> GetAllUnitbyid(int? Usr_Id )
        {
            var data = con.User_SelectById(Usr_Id).ToList();

            return data;
        }

        public bool SaveRevenue(List<Trans_Revnu_Expenditure_By_Unit> customers)
        {
            Trans_Revnu_Expenditure_By_Unit revenue = new Trans_Revnu_Expenditure_By_Unit();


            if (customers != null)
            {
                foreach (var item in customers)
                {

                    
                    revenue.Unit_Id = item.Unit_Id;
                    revenue.Fin_Id = item.Fin_Id;
                    revenue.Head_Id = item.Head_Id;
                    revenue.Subhead_Id = item.Subhead_Id;
                    revenue.Lt_Fy_Exp = item.Lt_Fy_Exp;
                    revenue.Bgt_Id = item.Bgt_Id;
                    revenue.Lb_Pr_Paid = item.Lb_Pr_Paid;
                    revenue.Current_expdr = item.Current_expdr;
                    revenue.Total_Pmt = item.Total_Pmt;
                    revenue.Prob_Exp = item.Prob_Exp;
                    revenue.Total_Prop_Exp = item.Total_Prop_Exp;
                    revenue.Fst_Bdgt_Nxt_Fy = item.Fst_Bdgt_Nxt_Fy;
                    revenue.Fst_remarks = item.Fst_remarks;
                    revenue.Fst_Prop_Re_Curnt = item.Fst_Prop_Re_Curnt;
                    revenue.fst_Arop_BIT = false;
                    revenue.Sec_Arop_BIT= false;
                    revenue.bit_Second_Aprov = false;
                    revenue.bit_Aproved = false;
                    revenue.FileID = item.FileID;
                    revenue.IsActive = true;
                    revenue.IsDelete = false;
                    revenue.Addon = DateTime.Now;
                    revenue.Addby = item.Addby;
                    con.Trans_Revnu_Expenditure_By_Unit.Add(revenue);
                    con.SaveChanges();
                }
            }
            return true;
        }

        
        public bool UpdateRevenue(List<RevenueSecLevelModel> customers, int? id)
        {

            Trans_Revnu_Expenditure_By_Unit revenue = new Trans_Revnu_Expenditure_By_Unit();
            Tarn_Add_Budget buget = new Tarn_Add_Budget();

            if (customers != null)
            {
                foreach (var item in customers)
                {

                    var data = con.Trans_Revnu_Expenditure_By_Unit.Where(x => x.Unit_RevExp_Id == id).FirstOrDefault();

                    if (data != null)
                    {
                        data.Prop_Re_Curnt = item.Prop_Re_Curnt;

                        data.Bdgt_Nxt_Fy = item.Bdgt_Nxt_Fy;
                        data.Remarks = item.Remarks;
                        data.bit_Second_Aprov = true;

                        data.Modon = DateTime.Now;
                        data.Modby = item.Modby;

                        con.SaveChanges();

                        var data1 = con.Financial_Year.Where(x => x.Fin_Id == item.Fin_Id && x.IsActive == true).FirstOrDefault();

                        if (data1 != null)
                        {
                            Tarn_Add_Budget obj = new Tarn_Add_Budget();
                            obj.Head_Id = data.Head_Id;
                            obj.SubHead_Id = data.Subhead_Id;
                            obj.Fin_Id = item.Fin_Id;
                            obj.Unit_Id = item.Unit_Id;
                            obj.Prop_Amnt = item.Bdgt_Nxt_Fy;
                            obj.Proposed_Re_For_Current = item.Prop_Re_Curnt;
                            obj.Bit_Approved = false;
                            obj.fst_Arop_BIT = false;
                            obj.Sec_Arop_BIT = false;
                            obj.AddOn = DateTime.Now;
                            obj.AddBy = item.AddBy;
                            obj.IsActive = true;
                            obj.IsDelete = false;

                            con.Tarn_Add_Budget.Add(obj);
                            con.SaveChanges();

                            int bgtid = obj.Bgt_Id;

                            data.Bgt_Id = bgtid;
                            con.SaveChanges();
                        }
                       
                    }

                }
            }
            return true;
        }
        public bool Updateholevelfrst(List<RevenueSecLevelModel> customers, int? id)
        {

           
            Tarn_Add_Budget buget = new Tarn_Add_Budget();

            if (customers != null)
            {
                foreach (var item in customers)
                {

                    var data = con.Tarn_Add_Budget.Where(x => x.Bgt_Id == id && x.IsDelete == false).FirstOrDefault();


                    if (data != null)
                    {
                    
                        data.First_Lvl_Re_For_Current = item.First_Lvl_Re_For_Current;
                        data.fst_Aprov_Bdgt_Amnt = item.fst_Aprov_Bdgt_Amnt;
                        data.fst_Arop_Remarks = item.fst_Arop_Remarks;
                        data.Bit_Approved = false;
                        data.fst_Arop_BIT = true;
                        data.Sec_Arop_BIT = false;
                        data.ModOn = DateTime.Now;
                        data.ModBy = item.Modby;


                        con.SaveChanges();
                        var data1 = con.Trans_Revnu_Expenditure_By_Unit.Where(x => x.Bgt_Id == id && x.IsDelete == false).FirstOrDefault();
                        if (data.fst_Arop_BIT==true && data1!=null)
                        {
                            data1.fst_Arop_BIT = true;
                            
                            con.SaveChanges();
                        }
                    }
                }
            }
            return true;
        }
        public bool Updateholevelsec(List<RevenueSecLevelModel> customers, int? id)
        {


            Tarn_Add_Budget buget = new Tarn_Add_Budget();

            if (customers != null)
            {
                foreach (var item in customers)
                {

                    var data = con.Tarn_Add_Budget.Where(x => x.Bgt_Id == id && x.IsDelete == false).FirstOrDefault();


                    if (data != null)
                    {

                        data.Sec_Lvl_Re_For_Current = item.Sec_Lvl_Re_For_Current;
                        data.Sec_Aprov_Bdgt_Amnt = item.Sec_Aprov_Bdgt_Amnt;
                        data.Sec_Arop_Remarks = item.Sec_Arop_Remarks;
                        data.Bit_Approved = false;
                       
                        data.Sec_Arop_BIT = true;
                        data.ModOn = DateTime.Now;
                        data.ModBy = item.Modby;


                        con.SaveChanges();
                        var data1 = con.Trans_Revnu_Expenditure_By_Unit.Where(x => x.Bgt_Id == id && x.IsDelete == false).FirstOrDefault();
                        if (data.Sec_Arop_BIT == true && data1 != null)
                        {
                            data1.Sec_Arop_BIT = true;

                            con.SaveChanges();
                        }
                    }
                }
            }
            return true;
        }
        public bool Updateholevelfinal(List<RevenueSecLevelModel> customers, int? id)
        {


            Tarn_Add_Budget buget = new Tarn_Add_Budget();

            if (customers != null)
            {
                foreach (var item in customers)
                {

                    var data = con.Tarn_Add_Budget.Where(x => x.Bgt_Id == id && x.IsDelete == false).FirstOrDefault();


                    if (data != null)
                    {

                        data.Bdgt_Amnt = item.Bdgt_Amnt;
                        data.Avlb_Amnt = item.Bdgt_Amnt;
                        data.Re_For_Current = item.Re_For_Current;
                        data.Remarks = item.Remarks;
                        data.Bit_Approved = true;

                       
                        data.ModOn = DateTime.Now;
                        data.ModBy = item.Modby;


                        con.SaveChanges();
                        var data1 = con.Trans_Revnu_Expenditure_By_Unit.Where(x => x.Bgt_Id == id && x.IsDelete == false).FirstOrDefault();
                        if (data.Bit_Approved == true && data1 != null)

                        {
                           
                            data1.Bdgt_Amnt = item.Bdgt_Amnt;
                            data1.Re_For_Current = item.Re_For_Current;
                            data1.Ho_Remarks = item.Remarks;
                            data1.bit_Aproved = true;
                            
                            con.SaveChanges();
                        }
                    }
                }
            }
            return true;
        }
        public List<SelectAllByUnitAllbyId_Result> GetAllRevenueDetailsList(int? Fin_Id, int? Unit_Id)
        {

            var data = con.SelectAllByUnitAllbyId(Fin_Id, Unit_Id).Where(o => o.IsActive == true).ToList();

            return data;
        }
        public List<SelectAllByUnitAllbyIdd_Result> GetAllRevenueDetailsListsec(int? Fin_Id, int? Unit_Id)
        {

            var data = con.SelectAllByUnitAllbyIdd(Fin_Id, Unit_Id).Where(o => o.IsActive == true).ToList();

            return data;
        }
        public List<ExpenditureSelectAllByUnit_Result> GetAllRevenueDetailsListfstbudget(int? Fin_Id, int? Unit_Id, int? Head_Id)
        {

            var data = con.ExpenditureSelectAllByUnit(Fin_Id, Unit_Id, Head_Id).ToList();

            return data;
        }
        public List<GetRevenueHeadforProposalByUnit_Result> Getheadfrstlvl(int? Fin_Id, int? Unit_Id)
        {

            var data = con.GetRevenueHeadforProposalByUnit(Fin_Id, Unit_Id).ToList();

            return data;
        }
        public List<ExpendSelectAllForHoApprove_Result> GetAllRevenueDetailsListsecbudget(int? Fin_Id, int? Unit_Id, int? Head_Id)
        {

            var data = con.ExpendSelectAllForHoApprove(Fin_Id, Unit_Id, Head_Id).ToList();

            return data;
        }
        public List<GetRevenueHeadforProposalByUnit_Result> Getheadseclvl(int? Fin_Id, int? Unit_Id)
        {

            var data = con.GetRevenueHeadforProposalByUnit(Fin_Id, Unit_Id).ToList();

            return data;
        }
        public List<ExpenditureSelectAllByUnitForFinal_Result> GetAllRevenueDetailsListfinalbudget(int? Fin_Id, int? Unit_Id, int? Head_Id)
        {

            var data = con.ExpenditureSelectAllByUnitForFinal(Fin_Id, Unit_Id, Head_Id).ToList();

            return data;
        }
        public List<GetRevenueHeadforProposalByUnit_Result> Getheadfinallvl(int? Fin_Id, int? Unit_Id)
        {

            var data = con.GetRevenueHeadforProposalByUnit(Fin_Id, Unit_Id).ToList();

            return data;
        }

    }
}