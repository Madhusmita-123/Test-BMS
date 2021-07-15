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
    public class UserController : Controller
    {
        private readonly IApplicationRepository applicationRepository;
        public UserController(IApplicationRepository appRepository)
        {
            applicationRepository = appRepository;
        }
        // GET: User
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
        public ActionResult CreateUser()
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    UserModel userModel = new UserModel();
                    userModel.lstRole = applicationRepository.GetAllRole();
                    userModel.department = applicationRepository.GetAllDepartment();
                    userModel.designation = applicationRepository.GetAllDesignation(0);
                    userModel.Unit = applicationRepository.GetAllUnit();
                    ViewBag.GridData = applicationRepository.GetAllUserList().ToList();

                    return View(userModel);
                }
                else
                {
                    return RedirectToAction("CreateUser", "User");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult CreateUser(UserModel userModel)
        {
            try
            {
                if (Session["Usr_Nm"] != null)
                {
                    //userModel.User.AddBy = Session["Usr_Nm"].ToString();


                    int data = applicationRepository.SaveUser(userModel);
                    if (data > 0)
                    {
                        var userdata = applicationRepository.GetUserData(data);
                        string name = userdata.Name;

                        if (data == 1)
                        {
                            TempData["Message"] = "User updated successfully";
                            return RedirectToAction("CreateUser", "User");
                        }
                        else
                        {
                            TempData["Message"] = "User created successfully";
                            return RedirectToAction("CreateUser", "User");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Something went wrong";
                        return RedirectToAction("CreateUser", "User");
                    }
                }
                else
                {
                    return RedirectToAction("CreateUser", "User");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("CreateUser", "User");
            }
        }
        [HttpPost]
        public ActionResult BindDesignation(int deptid)
        {
            var data = applicationRepository.GetAllDesignation(deptid);

            var des = (from a in data
                       select new
                       {
                           a.Desg_ID,
                           a.Designation_Name
                       }).ToList();

            return Json(des, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EditUser(int usrid)
        {
            var data = applicationRepository.GetAllUser(usrid).FirstOrDefault();

            UserModel userModel = new UserModel();
            userModel.lstRole = applicationRepository.GetAllRole();
            userModel.department = applicationRepository.GetAllDepartment();
            userModel.designation = applicationRepository.GetAllDesignation(data.Dept_ID);
            userModel.Unit = applicationRepository.GetAllUnit();
            userModel.User = data;


            return PartialView("_EditUserPartial", userModel);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            var data = applicationRepository.DeleteUser(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
    }
}