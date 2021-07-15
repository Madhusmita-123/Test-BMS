using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BMS.Models;
using BMS.Abstract;
using System.Data;
using System.Data.Entity;
using System.Text;
namespace BMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly IApplicationRepository applicationRepository;
        public AdminController(IApplicationRepository appRepository)
        {
            applicationRepository = appRepository;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }
        }
        #region----------------Role-------------------------------
        [HttpGet]
        public ActionResult Role()
        {
            try
            {
                if (Session["RoleID"] != null)
                {
                    RoleModel roleModel = new RoleModel();
                    
                    ViewBag.GridData = applicationRepository.GetAllRoleList().ToList();

                    return View(roleModel);
                }
                else
                {
                    return RedirectToAction("Role", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
        [HttpPost]
        public ActionResult CreateRole(RoleModel roleModel)
        {
            try
            {
                if (Session["RoleID"] != null)
                {
                    

                    int data = applicationRepository.SaveRole(roleModel);
                    if (data > 0)
                    {
                        var rolldata = applicationRepository.GetRoleData(data);
                        string name = rolldata.RoleDesc ;

                      if (data==1)
                        {
                            TempData["Message"] = "Role Updated successfully";
                            return RedirectToAction("Role", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "Role created successfully";
                            return RedirectToAction("Role", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("Role", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Role", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Role", "Admin");
            }
        }
        [HttpPost]
        public ActionResult BindRole(int id)
        {

            var data = applicationRepository.GetRoleData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteRole(int id)
        {
            var data = applicationRepository.DeleteRoleData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion-------------------------------------------------

        #region----------------------Department----------------------------
        [HttpGet]
        public ActionResult Department()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    DepartmentModel departmentModel = new DepartmentModel();

                    ViewBag.GridData = applicationRepository.GetAllDepartment().ToList();

                    return View(departmentModel);
                }
                else
                {
                    return RedirectToAction("Department", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult Department(DepartmentModel departmentModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveDepartment(departmentModel);
                    if (data > 0)
                    {
                        var deptdata = applicationRepository.GetDepartmentData(data);
                        string name = deptdata.Dept_Code;
                        string name1 = deptdata.Dept_Name;
                        if (data == 1)
                        {
                            TempData["Message"] = "Department Updated successfully";
                            return RedirectToAction("Department", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "Department created successfully";
                            return RedirectToAction("Department", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("Department", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Department", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Department", "Admin");
            }
        }
        [HttpPost]
        public ActionResult BindDepartment(int id)
        {

            var data = applicationRepository.GetDepartmentData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteDepartment(int id)
        {
            var data = applicationRepository.DeleteDepartmentData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion-------------------------------------------------
        #region----------------------Designation----------------------------
        [HttpGet]
        public ActionResult Designation()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    DesignationModel designationModel = new DesignationModel();
                    designationModel.lstDepartment = applicationRepository.GetAllDepartment();

                    ViewBag.GridData = applicationRepository.GetDesignationList().ToList();

                    return View(designationModel);
                }
                else
                {
                    return RedirectToAction("Designation", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult Designation(DesignationModel designationModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveDesignation(designationModel);
                    if (data > 0)
                    {
                        var designationdata = applicationRepository.GetDesignationData(data);
                       
                        string name1 = designationdata.Designation_Name;
                        string name2 = designationdata.Desg_Code;
                        if (data == 1)
                        {
                            TempData["Message"] = "Designation Updated successfully";
                            return RedirectToAction("Designation", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "Designation created successfully";
                            return RedirectToAction("Designation", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("Designation", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Designation", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Designation", "Admin");
            }
        }
        [HttpPost]
        public ActionResult BindDesignation(int id)
        {
            DesignationModel designationModel = new DesignationModel();
            designationModel.lstDepartment = applicationRepository.GetAllDepartment();
            var data = applicationRepository.GetDesignationData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteDesignation(int id)
        {
            var data = applicationRepository.DeleteDesignationData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion-------------------------------------------------
        #region----------------------Head----------------------------
        [HttpGet]
        public ActionResult Head()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    HeadModel headmodel = new HeadModel();
                    headmodel.lstBudget = applicationRepository.GetAllBudget();

                    ViewBag.GridData = applicationRepository.GetHeadList().ToList();

                    return View(headmodel);
                }
                else
                {
                    return RedirectToAction("Head", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult Head(HeadModel headModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveHead(headModel);
                    if (data > 0)
                    {
                        var headdata = applicationRepository.GetHeadData(data);

                        string name1 = headdata.hdnm;
                        string name2 = headdata.hdcode;
                        if (data == 1)
                        {
                            TempData["Message"] = "Head Updated successfully";
                            return RedirectToAction("Head", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "Head created successfully";
                            return RedirectToAction("Head", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("Head", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Head", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Head", "Admin");
            }
        }
        [HttpPost]
        public ActionResult BindHead(int id)
        {

            var data = applicationRepository.GetHeadData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Bindheaddata(int budgetid)
        {
            var data = applicationRepository.Getheaddatabybudget(budgetid);

            var des = (from a in data
                       select new
                       {
                           a.Head_Id,
                           a.hdnm
                       }).ToList();

            return Json(des, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteHead(int id)
        {
            var data = applicationRepository.DeleteHeadData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion-------------------------------------------------
        #region----------------------Divison----------------------------
        [HttpGet]
        public ActionResult Divison()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    DivisionModel divisonModel = new DivisionModel();

                    ViewBag.GridData = applicationRepository.GetAllDivison().ToList();

                    return View(divisonModel);
                }
                else
                {
                    return RedirectToAction("Divison", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult Divison(DivisionModel divisonModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveDivison(divisonModel);
                    if (data > 0)
                    {
                        var divisondata = applicationRepository.GetDivisonData(data);
                        string name = divisondata.divisonname;

                        if (data == 1)
                        {
                            TempData["Message"] = "Divison Updated successfully";
                            return RedirectToAction("Divison", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "Divison created successfully";
                            return RedirectToAction("Divison", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("Divison", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Divison", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Divison", "Admin");
            }
        }
        [HttpPost]
        public ActionResult BindDivison(int id)
        {

            var data = applicationRepository.GetDivisonData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteDivison(int id)
        {
            var data = applicationRepository.DeleteDivisonData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion-------------------------------------------------
        #region----------------------Zone----------------------------
        [HttpPost]
        public ActionResult BindZone(int id)
        {

            var data = applicationRepository.GetZoneData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteZone(int id)
        {
            var data = applicationRepository.DeleteZoneData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult Zone()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    ZoneModel zoneModel = new ZoneModel();

                    ViewBag.GridData = applicationRepository.GetAllZone().ToList();

                    return View(zoneModel);
                }
                else
                {
                    return RedirectToAction("Zone", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult Zone(ZoneModel zoneModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveZone(zoneModel);
                    if (data > 0)
                    {
                        var zonedata = applicationRepository.GetZoneData(data);
                        string name = zonedata.zonename;
                       
                        if (data == 1)
                        {
                            TempData["Message"] = "Zone Updated successfully";
                            return RedirectToAction("Zone", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "Zone created successfully";
                            return RedirectToAction("Zone", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("Zone", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Zone", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Zone", "Admin");
            }
        }
        #endregion-------------------------------------------------
        #region----------------SubHead-------------------------------
        [HttpGet]
        public ActionResult SubHead()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    SubHeadModel subheadmodel = new SubHeadModel();
                    subheadmodel.lstBudget = applicationRepository.GetAllBudget();
                    subheadmodel.Head = applicationRepository.Getheaddatabybudget(0);
                    ViewBag.GridData = applicationRepository.GetSubheadList().ToList();

                    return View(subheadmodel);
                }
                else
                {
                    return RedirectToAction("SubHead", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult SubHead(SubHeadModel subheadmodel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveSubHead(subheadmodel);
                    if (data > 0)
                    {
                        //var subheaddata = applicationRepository.GetSubHeadData(data);

                        //string name = subheaddata.SubHead_Code;
                        
                        if (data == 1)
                        {
                            TempData["Message"] = "SubHead Updated successfully";
                            return RedirectToAction("SubHead", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "SubHead created successfully";
                            return RedirectToAction("SubHead", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("SubHead", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("SubHead", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("SubHead", "Admin");
            }
        }
        public ActionResult BindsubHead(int id)
        {

            var data = applicationRepository.GetSubHeadData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteSubhead(int id)
        {
            var data = applicationRepository.DeleteSubHeadData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion-------------------------------------------------
        #region-----------------------------Country----------------------
        [HttpGet]
        public ActionResult Country()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    CountryModel cntModel = new CountryModel();

                    ViewBag.GridData = applicationRepository.GetAllcountryList().ToList();

                    return View(cntModel);
                }
                else
                {
                    return RedirectToAction("Country", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult Country(CountryModel CuntryModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveCountry(CuntryModel);
                    if (data > 0)
                    {
                        var cndata = applicationRepository.GetAllcountrydata(data);
                        string name = cndata.Con_Nm;

                        if (data == 1)
                        {
                            TempData["Message"] = "Country Updated successfully";
                            return RedirectToAction("Country", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "Country created successfully";
                            return RedirectToAction("Country", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("Country", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Country", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Country", "Admin");
            }
        }
        [HttpPost]
        public ActionResult EditCountry(int cid)
        {
            var data = applicationRepository.GetAllCountryDetails(cid);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteCountry(int id)
        {
            var data = applicationRepository.DeleteCountry(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        [HttpGet]
        public ActionResult CreateState()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    StateModel userModel = new StateModel();

                    userModel.country = applicationRepository.GetAllcountryList();
                    ViewBag.GridData = applicationRepository.GetAllsateList().ToList();

                    return View(userModel);
                }
                else
                {
                    return RedirectToAction("CreateState", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult CreateState(StateModel stModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveState(stModel);
                    if (data > 0)
                    {
                        var cndata = applicationRepository.GetAllstatedata(data);
                        string name = cndata.St_Nm;

                        if (data == 1)
                        {
                            TempData["Message"] = "State Updated successfully";
                            return RedirectToAction("CreateState", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "State created successfully";
                            return RedirectToAction("CreateState", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("CreateState", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("CreateState", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("CreateState", "Admin");
            }
        }


        [HttpPost]
        public ActionResult EditState(int cid)
        {
            var data = applicationRepository.GetAllState(cid);
            StateModel stModel = new StateModel();
            stModel.country = applicationRepository.GetAllcountryList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteState(int id)
        {
            var data = applicationRepository.DeleteState(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateDistrict()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    DistrictModel userModel = new DistrictModel();
                    userModel.country = applicationRepository.GetAllcountryList();
                    userModel.state = applicationRepository.GetStatedata(0);

                    ViewBag.GridData = applicationRepository.GetAllDistrictList().ToList();

                    return View(userModel);
                }
                else
                {
                    return RedirectToAction("CreateDistrict", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult CreateDistrict(DistrictModel stModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveDistrict(stModel);
                    if (data > 0)
                    {
                        var cndata = applicationRepository.GetAllDistrictdata(data);
                        string name = cndata.Dst_Nm;

                        if (data == 1)
                        {
                            TempData["Message"] = "State Updated successfully";
                            return RedirectToAction("CreateDistrict", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "State created successfully";
                            return RedirectToAction("CreateDistrict", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("CreateDistrict", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("CreateDistrict", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("CreateDistrict", "Admin");
            }
        }
        [HttpPost]
        public ActionResult BindState(int conid)
        {
            var data = applicationRepository.GetStatedata(conid);

            var des = (from a in data
                       select new
                       {
                           a.St_Id,
                           a.St_Nm
                       }).ToList();

            return Json(des, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditDistrict(int cid)
        {
            var data = applicationRepository.GetAllDistrict(cid).FirstOrDefault();
            DistrictModel stModel = new DistrictModel();
            stModel.country = applicationRepository.GetAllcountryList();
            stModel.state = applicationRepository.GetStatedata(data.Con_Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteDistrict(int id)
        {
            var data = applicationRepository.DeleteDistrict(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #region-----------------------------Circle----------------------
        [HttpGet]
        public ActionResult CreateCircle()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    CircleModel cntModel = new CircleModel();

                    ViewBag.GridData = applicationRepository.GetAllCircleList().ToList();

                    return View(cntModel);
                }
                else
                {
                    return RedirectToAction("CreateCircle", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult CreateCircle(CircleModel circleModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveCircle(circleModel);
                    if (data > 0)
                    {
                        var cndata = applicationRepository.GetAllcircledata(data);
                        string name = cndata.circlename;

                        if (data == 1)
                        {
                            TempData["Message"] = "Circle Updated successfully";
                            return RedirectToAction("CreateCircle", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "Circle created successfully";
                            return RedirectToAction("CreateCircle", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("CreateCircle", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("CreateCircle", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("CreateCircle", "Admin");
            }
        }
        [HttpPost]
        public ActionResult EditCircle(int cid)
        {
            var data = applicationRepository.GetAllCircleDetails(cid);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteCircle(int id)
        {
            var data = applicationRepository.DeleteCircle(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region-------------------------AssignedCircleDivision----------------------------
        [HttpGet]
        public ActionResult CreateAssignCircleDivision()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    AssignCircleDivisionModel userModel = new AssignCircleDivisionModel();
                    userModel.Circle1 = applicationRepository.GetAllCircleList();
                    userModel.division = applicationRepository.GetAllDivisionList();
                    ViewBag.GridData = applicationRepository.GetAllAssignCircleDivisionList().ToList();

                    return View(userModel);
                }
                else
                {
                    return RedirectToAction("CreateAssignCircleDivision", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult CreateAssignCircleDivision(AssignCircleDivisionModel circleModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveAssignCircleDivision(circleModel);
                    if (data > 0)
                    {
                        var cndata = applicationRepository.GetAllassigncircledivisiondata(data);
                        //string name = cndata.divisonid 


                        if (data == 1)
                        {
                            TempData["Message"] = "AssignCircleDivision Updated successfully";
                            return RedirectToAction("CreateAssignCircleDivision", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "AssignCircleDivision created successfully";
                            return RedirectToAction("CreateAssignCircleDivision", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("CreateAssignCircleDivision", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("CreateAssignCircleDivision", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("CreateAssignCircleDivision", "Admin");
            }
        }
        [HttpPost]
        public ActionResult EditAssignCircle(int cid)
        {
            var data = applicationRepository.GetAllCircledivisionDetails(cid);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteassignCircleDivision(int id)
        {
            var data = applicationRepository.DeleteAssignCircleDivision(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region-----------------------------Financial_Year----------------------
        [HttpGet]
        public ActionResult CreateFinancialYear()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    FinancialYearModel cntModel = new FinancialYearModel();

                    ViewBag.GridData = applicationRepository.GetAllFinanceList().ToList();

                    return View(cntModel);
                }
                else
                {
                    return RedirectToAction("CreateFinancialYear", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult CreateFinancialYear(FinancialYearModel CuntryModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    CuntryModel.finance.AddBy = Convert.ToInt32(Session["userid"]);

                    int data = applicationRepository.SavefinanceYear(CuntryModel);
                    if (data > 0)
                    {
                        var cndata = applicationRepository.GetAllfinancedata(data);
                        string name = cndata.Fin_Yr;

                        if (data == 1)
                        {
                            TempData["Message"] = "FinanceYear Updated successfully";
                            return RedirectToAction("CreateFinancialYear", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "FinanceYear created successfully";
                            return RedirectToAction("CreateFinancialYear", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("CreateFinancialYear", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("CreateFinancialYear", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("CounCreateFinancialYeartry", "Admin");
            }
        }
        [HttpPost]
        public ActionResult EditFinancialYear(int cid)
        {
            var data = applicationRepository.GetAllFinanceDetails(cid);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteFinancialYear(int id)
        {
            var data = applicationRepository.DeleteFinanceyear(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region-------------------------AssignedCircleDivision----------------------------
        [HttpGet]
        public ActionResult CreateAssignUnitToBank()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    AssignBankUnitModel userModel = new AssignBankUnitModel();
                    userModel.unit = applicationRepository.GetAllUnit();
                    userModel.bank = applicationRepository.GetAllBankList();
                    ViewBag.GridData = applicationRepository.GetAllAssignUnitToBankList().ToList();

                    return View(userModel);
                }
                else
                {
                    return RedirectToAction("CreateAssignUnitToBank", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult CreateAssignUnitToBank(AssignBankUnitModel circleModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveAssignUnitToBank(circleModel);
                    if (data > 0)
                    {
                        var cndata = applicationRepository.GetAllassignUnitToBankdata(data);



                        if (data == 1)
                        {
                            TempData["Message"] = "Assign Unit To Bank Updated successfully";
                            return RedirectToAction("CreateAssignUnitToBank", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "Assign Unit To Bank created successfully";
                            return RedirectToAction("CreateAssignUnitToBank", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("CreateAssignUnitToBank", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("CreateAssignUnitToBank", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("CreateAssignUnitToBank", "Admin");
            }
        }
        [HttpPost]
        public ActionResult EditAssignUnitToBank(int cid)
        {
            var data = applicationRepository.GetAllUnitToBankDetails(cid);

            return Json(data.FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteassignUnitToBank(int id)
        {
            var data = applicationRepository.DeleteAssignUnitToBank(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region-------------------------Assign User Approve Mapping----------------------------
        [HttpGet]
        public ActionResult CreateAssignUserApprove()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    AssignUserApprovalMappingModel userModel = new AssignUserApprovalMappingModel();
                    userModel.Unit = applicationRepository.GetAllUnit();
                    userModel.Usernew = applicationRepository.GetAllUserList().ToList();
                    userModel.Approvetype = applicationRepository.GetAllDescriptionList();
                    ViewBag.GridData = applicationRepository.GetAllAssignUserApproveList().ToList();

                    return View(userModel);
                }
                else
                {
                    return RedirectToAction("CreateAssignUserApprove", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult CreateAssignUserApprove(AssignUserApprovalMappingModel circleModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveAssignUserApprove(circleModel);
                    if (data > 0)
                    {

                        if (data == 1)
                        {
                            TempData["Message"] = "Assign User Approve Updated successfully";
                            return RedirectToAction("CreateAssignUserApprove", "Admin");
                        }
                        else
                        {
                            TempData["Message"] = "Assign User Approve created successfully";
                            return RedirectToAction("CreateAssignUserApprove", "Admin");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("CreateAssignUserApprove", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("CreateAssignUserApprove", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("CreateAssignUserApprove", "Admin");
            }
        }
        [HttpPost]
        public ActionResult EditAssignUserApprove(int cid)
        {
            var data = applicationRepository.GetAllUserApproveDetails(cid).FirstOrDefault();
            int? userid = data.Usr_Id;
            var data1 = applicationRepository.GetAllEmpCode(userid).FirstOrDefault();

            return Json(new { data, data1 }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteAssignUserApprove(int id)
        {
            var data = applicationRepository.DeleteAssignUserApprove(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult BindName(int unitid)
        {
            var data = applicationRepository.GetAllName(unitid);

            var des = (from a in data
                       select new
                       {
                           a.Usr_Id,
                           a.Name
                       }).ToList();

            return Json(des, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult BindEmpCode(int userid)
        {
            var data = applicationRepository.GetAllEmpCode(userid).FirstOrDefault();
            return Json(data.EmpCode, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}