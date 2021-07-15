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
using System.IO;
using System.Configuration;

namespace BMS.Controllers
{
    public class FinanceController : Controller
    {
        private readonly IApplicationRepository applicationRepository;
        public FinanceController(IApplicationRepository appRepository)
        {
            applicationRepository = appRepository;
        }
        // GET: Finance
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
        [HttpGet]
        public ActionResult BankDetails()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    BankDetailsModel bnkModel = new BankDetailsModel();
                    bnkModel.lstBank = applicationRepository.GetAllBank();

                    ViewBag.GridData = applicationRepository.GetAllBankDetailsList().ToList();

                    return View(bnkModel);
                }
                else
                {
                    return RedirectToAction("BankDetails", "Finance");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult BankDetails(BankDetailsModel bankDetailsModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {


                    int data = applicationRepository.SaveBankDetails(bankDetailsModel);
                    if (data > 0)
                    {
                        var bankdetaildata = applicationRepository.GetBankDetailsData(data);

                        string name = bankdetaildata.Branch;

                        if (data == 1)
                        {
                            TempData["Message"] = "BankDetails Updated successfully";
                            return RedirectToAction("BankDetails", "Finance");
                        }
                        else
                        {
                            TempData["Message"] = "BankDetails created successfully";
                            return RedirectToAction("BankDetails", "Finance");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("BankDetails", "Finance");
                    }
                }
                else
                {
                    return RedirectToAction("BankDetails", "Finance");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("BankDetails", "Finance");
            }
        }
        [HttpPost]
        public ActionResult BindBankDetails(int id)
        {

            var data = applicationRepository.GetBankDetailsData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteBankDtls(int id)
        {
            var data = applicationRepository.DeleteBankDetailData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult RevenueProposalByUnit()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    int Usr_Id = Convert.ToInt32(Session["Usr_Id"].ToString());
                    
                    RevenueProposalByUnitModel revenueModel = new RevenueProposalByUnitModel();
                    revenueModel.head = applicationRepository.Gethead();
                    revenueModel.SubHead = applicationRepository.GetSubheaddatabyhead(0);
                    var data = applicationRepository.GetAllUnitbyid(Usr_Id).FirstOrDefault();
                    revenueModel.Unit_Name = data.Unit_Name;
                    var data1 = applicationRepository.GetAllFinanceList().FirstOrDefault();
                    //revenueModel.Fin_Yr = data.Fin_Yr;
                     //ViewBag.GridData = applicationRepository.GetAllRevenueDetailsList(data1.Fin_Id, data.Unit_Id).ToList();

                    return View(revenueModel);

                }
                else
                {
                    return RedirectToAction("RevenueProposalByUnit", "Finance");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

            
        }
        [HttpGet]
        public ActionResult GetUnitDetails()
        {
            int Usr_Id = Convert.ToInt32(Session["Usr_Id"].ToString());
            var data = applicationRepository.GetAllUnitbyid(Usr_Id).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult GetActivefyr()
        {

            var data = applicationRepository.GetAllFinanceList().FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);

        }
        
        [HttpGet]
        public ActionResult Getunitlist()
        {

            var data = applicationRepository.GetAllUnit().ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Fileupload()
        {
            HttpPostedFileBase postedFile = Request.Files[0];
            string FileName = Path.GetFileName(postedFile.FileName);
            //string FileName1 = FileName + "_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "_" + DateTime.Today.Date.Hour.ToString() + DateTime.Today.Date.Minute.ToString() + DateTime.Today.Date.Second.ToString();
            string FileName1 = FileName + "_" + DateTime.Now.ToString("MMddyyyyhhmmsstt");
            string FileID = string.Concat(Path.GetFileNameWithoutExtension(postedFile.FileName), DateTime.Now.ToString("_yyyy_MM_dd_HH:mm:ss"));

            Session["FileID"] = FileID;
            if (!(System.IO.Directory.Exists(HttpContext.Server.MapPath($"~/{ConfigurationManager.AppSettings["FileUploadFolder"]}"))))
            {
                Directory.CreateDirectory(HttpContext.Server.MapPath($"~/{ConfigurationManager.AppSettings["FileUploadFolder"]}"));
            }
            string path = Path.Combine(HttpContext.Server.MapPath($"~/{ConfigurationManager.AppSettings["FileUploadFolder"]}"),
                                       Path.GetFileName(FileName1));
            postedFile.SaveAs(Server.MapPath("~/FileUploaded/") + FileName1);

            if (postedFile.ContentLength > 0)
            {
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(postedFile.InputStream))
                {
                    //string content = br.ReadBytes(postedFile.ContentType);
                    bytes = br.ReadBytes(postedFile.ContentLength);
                }

            }

            return Json(FileName1, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DownloadFile(string FileName)
        {
            try
            {

                var finalFilePath = "G:\\BMS\\BMS\\BMS\\FileUploaded\\" + FileName;
                byte[] fileBytes = System.IO.File.ReadAllBytes(finalFilePath);
                string contentType = MimeMapping.GetMimeMapping(finalFilePath);
                string fileTitle = FileName.Substring(0, FileName.LastIndexOf("_"));
                //File.Move(finalFilePath,  + @"\" + fileTitle + fileExtension);

                return File(fileBytes, contentType, fileTitle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        [HttpPost]
        public ActionResult BindHead(int id)
        {

            var data = applicationRepository.GetHeadData(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }






        
        
        [HttpPost]
        public ActionResult BindSubheaddata(int subheadid)
        {
            var data = applicationRepository.GetSubheaddatabyhead(subheadid);

            var des = (from a in data
                       select new
                       {
                           a.SubHead_Id,
                           a.SubHead_Name
                       }).ToList();

            return Json(des, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult BindsubheadCode(int subheadid)
        {
            var data = applicationRepository.GetAllsubheadCode(subheadid).FirstOrDefault();
            return Json(data.SubHead_Code, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult CreateRevenue(List<Trans_Revnu_Expenditure_By_Unit> customers)
        {
           
            var data = applicationRepository.SaveRevenue(customers);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateRevenueList(List<RevenueSecLevelModel> customers,int id)
        {


            var data = applicationRepository.UpdateRevenue(customers,id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewBudgetDetails()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    int Usr_Id = Convert.ToInt32(Session["Usr_Id"].ToString());

                    RevenueProposalByUnitModel revenueModel = new RevenueProposalByUnitModel();
                    revenueModel.Unit = applicationRepository.GetAllUnit();
                    var data = applicationRepository.GetAllUnitbyid(Usr_Id).FirstOrDefault();
                    revenueModel.Unit_Name = data.Unit_Name;
                    
                    var data1 = applicationRepository.GetAllFinanceList().FirstOrDefault();
                    //revenueModel.Fin_Yr = data.Fin_Yr;
                    ViewBag.GridData = applicationRepository.GetAllRevenueDetailsList(data1.Fin_Id, data.Unit_Id).ToList();

                    return View(revenueModel);
                }
                else
                {
                    return RedirectToAction("ViewBudgetDetails", "Finance");
                }
            }
            catch (Exception ex)


            {
                return RedirectToAction("Index", "Login");
            }


        }
        [HttpGet]
        public ActionResult Sec_Lvl_RevenueProposalByUnit()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    int Usr_Id = Convert.ToInt32(Session["Usr_Id"].ToString());

                    RevenueProposalByUnitModel revenueModel = new RevenueProposalByUnitModel();
                    revenueModel.Unit = applicationRepository.GetAllUnit();
                    var data = applicationRepository.GetAllUnitbyid(Usr_Id).FirstOrDefault();
                    revenueModel.Unit_Name = data.Unit_Name;

                    var data1 = applicationRepository.GetAllFinanceList().FirstOrDefault();
                    //revenueModel.Fin_Yr = data.Fin_Yr;
                    ViewBag.GridData = applicationRepository.GetAllRevenueDetailsListsec(data1.Fin_Id, data.Unit_Id).ToList();

                    return View(revenueModel);
                }
                else
                {
                    return RedirectToAction("ViewBudgetDetails", "Finance");
                }
            }
            catch (Exception ex)


            {
                return RedirectToAction("Index", "Login");
            }
        }
        
    }

}