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
    public class LoginController : Controller
    {
        private readonly IApplicationRepository applicationRepository;
        public LoginController(IApplicationRepository appRepository)
        {
            applicationRepository = appRepository;
        }
        // GET: Login
        
        public ActionResult test()
        {
            return View();
        }
        #region---------------------Registration and Login Section--------------------------
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var data = applicationRepository.Getuser(username, password);
            if (data != null)
            {
                var role = applicationRepository.GetRole(data.RoleID);

                Session["role"] = role.RoleDesc;
                Session["roleid"] = role.RoleID;
                Session["Usr_Nm"] = data.Usr_Nm;
                Session["Usr_Id"] = data.Usr_Id;
                if (role.RoleDesc == "ADMINISTRATOR")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else if (role.RoleDesc == "HO")
                {
                    return RedirectToAction("Dashboard", "HO");
                }
                else if (role.RoleDesc == "UNIT")
                {
                    return RedirectToAction("Dashboard", "Unit");
                }
                else 
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
            }
            else
            {
                TempData["Message"] = "User name or password is incorrect";
                return View();
            }
        }
        [HttpGet]
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        #endregion
    }
}