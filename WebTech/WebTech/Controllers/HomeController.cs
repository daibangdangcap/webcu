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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult TrangChu(string SearchString)
        {
            string sp = SearchString;
            if (!String.IsNullOrEmpty(SearchString))
            {
                return RedirectToAction("ProductList", "PRODUCTs", new { SearchString = sp });
            }
            else
            {
                return View();
            }

        }
        public ActionResult Admin()
        {
            return View();
        }
        
    }
}