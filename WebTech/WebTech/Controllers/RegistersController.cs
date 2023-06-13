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

namespace DBPhone_demo_.Controllers
{
    public class RegistersController : Controller
    {
        DBTechEntities db = new DBTechEntities();
        // GET: Registers

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register customer)
        {
            
            if (ModelState.IsValid)
            {
                customer.cus = new CUSTOMER();
                customer.cus.USERNAME = customer.USERNAME;
                customer.cus.PASSWORD = customer.PASSWORD;
                customer.cus.EMAIL = customer.EMAIL;
                customer.cus.ADDRESS = customer.ADDRESS;
                customer.cus.SDT = customer.SDT;
                customer.cus.NAME_CUS = customer.NAME_CUS;
                db.CUSTOMERs.Add(customer.cus);
                    db.SaveChanges();
                    return RedirectToAction("Login");
            }
            else return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login lg)
        {
            if (ModelState.IsValid)
            {
                var data = db.CUSTOMERs.Where(s => s.USERNAME.Equals(lg.USERNAME) && s.PASSWORD.Equals(lg.PASSWORD)).ToList();
                if (data.Count() > 0)
                {
                    //add session

                    Session["NAME_CUS"] = data.FirstOrDefault().NAME_CUS;
                    Session["ADDRESS"] = data.FirstOrDefault().ADDRESS;
                    Session["EMAIL"] = data.FirstOrDefault().EMAIL;
                    Session["SDT"] = data.FirstOrDefault().SDT;
                    Session["USERNAME"] = data.FirstOrDefault().USERNAME;
                    Session["PASSWORD"] = data.FirstOrDefault().PASSWORD;
                    Session["IMAGE"] = data.FirstOrDefault().IMAGE;
                    return RedirectToAction("TrangChu", "Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        [HttpPost]
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}