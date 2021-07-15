﻿using System;
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
    public class Sec_Lvl_Rev_Bgt_ApprovalController : Controller
    {
        // GET: Sec_Lvl_Rev_Bgt_Approval
        private readonly IApplicationRepository applicationRepository;
        public Sec_Lvl_Rev_Bgt_ApprovalController(IApplicationRepository appRepository)
        {
            applicationRepository = appRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DownloadFile(string FileID)
        {
            try
            {

                var finalFilePath = "G:\\BMS\\BMS\\BMS\\FileUploaded\\" + FileID;
                byte[] fileBytes = System.IO.File.ReadAllBytes(finalFilePath);
                string contentType = MimeMapping.GetMimeMapping(finalFilePath);
                string fileTitle = FileID.Substring(0, FileID.LastIndexOf("_"));
                //File.Move(finalFilePath,  + @"\" + fileTitle + fileExtension);

                return File(fileBytes, contentType, fileTitle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult UpdateRevenueListholevelsec(List<RevenueSecLevelModel> customers, int id)
        {


            var data = applicationRepository.Updateholevelsec(customers, id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SecondLevelViewRequestedBudgetToApprove()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    int Usr_Id = Convert.ToInt32(Session["Usr_Id"].ToString());

                    RevenueProposalByUnitModel revenueModel = new RevenueProposalByUnitModel();
                    revenueModel.Unit = applicationRepository.GetAllUnit();
                    revenueModel.head = applicationRepository.Gethead();
                    var data = applicationRepository.GetAllUnitbyid(Usr_Id).FirstOrDefault();
                    revenueModel.Unit_Name = data.Unit_Name;

                    var data1 = applicationRepository.GetAllFinanceList().FirstOrDefault();
                    var data2 = applicationRepository.Gethead().FirstOrDefault();


                    return View(revenueModel);
                }
                else
                {
                    return RedirectToAction("SecondLevelViewRequestedBudgetToApprove", "Sec_Lvl_Rev_Bgt_Approval");
                }
            }
            catch (Exception ex)


            {
                return RedirectToAction("Index", "Login");
            }

        }
        public ActionResult GetrevenuehoseclvlDetailsdata(int? Fin_Id, int? Unit_Id, int? Head_Id)
        {
            if (Unit_Id != 0)
            {
                RevenueProposalByUnitModel revenueModel = new RevenueProposalByUnitModel();
                revenueModel.head = applicationRepository.Gethead();
                var data2 = applicationRepository.Getheadseclvl(Fin_Id, Unit_Id).FirstOrDefault();
                int Usr_Id = Convert.ToInt32(Session["Usr_Id"].ToString());
                var data = applicationRepository.GetAllRevenueDetailsListsecbudget(Fin_Id, Unit_Id, data2.Head_Id).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int Usr_Id = Convert.ToInt32(Session["Usr_Id"].ToString());
                var data = applicationRepository.GetAllRevenueDetailsListsecbudget(0, 0, 0).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

    }
}