using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebTech.Models;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace WebTech.Controllers
{
    
    public class LoginAdminController : Controller
    {
        // GET: LoginAdmin
        private DBTechEntities db=new DBTechEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogAdmin(ADMINUSER ad)
        {
            var check = db.ADMINUSERs.Where(s => s.USER_AD == ad.USER_AD && s.PASSWORD_AD == ad.PASSWORD_AD).FirstOrDefault();
            if(check==null)
            {
                ViewBag.ErrorInfo = "Sai Info";
                return View("LogAdmin");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = ad.ID;
                Session["USER_AD"] = ad.USER_AD;
                Session["PASSWORD_AD"] = ad.PASSWORD_AD;
                Session["NAME"] = ad.NAME;
                Session["ROLEUSER"] = ad.ROLEUSER;
                return RedirectToAction("Details","ADMINUSERs",new { id=check.ID});
            }
        }
    }
}