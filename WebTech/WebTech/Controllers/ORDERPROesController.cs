using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTech.Models;

namespace WebTech.Controllers
{
    public class ORDERPROesController : Controller
    {
        private DBTechEntities db = new DBTechEntities();

        // GET: ORDERPROes
        public ActionResult Index()
        {
            var oRDERPROes = db.ORDERPROes.Include(o => o.CUSTOMER);
            return View(oRDERPROes.ToList());
        }

        // GET: ORDERPROes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERPRO oRDERPRO = db.ORDERPROes.Find(id);
            if (oRDERPRO == null)
            {
                return HttpNotFound();
            }
            return View(oRDERPRO);
        }

        // GET: ORDERPROes/Create
        public ActionResult Create()
        {
            ViewBag.USERNAME = new SelectList(db.CUSTOMERs, "USERNAME", "NAME_CUS");
            return View();
        }

        // POST: ORDERPROes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ORDER,USERNAME,SDT,ORDER_ADDRESS,DATEORDER")] ORDERPRO oRDERPRO)
        {
            if (ModelState.IsValid)
            {
                db.ORDERPROes.Add(oRDERPRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USERNAME = new SelectList(db.CUSTOMERs, "USERNAME", "NAME_CUS", oRDERPRO.USERNAME);
            return View(oRDERPRO);
        }

        // GET: ORDERPROes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERPRO oRDERPRO = db.ORDERPROes.Find(id);
            if (oRDERPRO == null)
            {
                return HttpNotFound();
            }
            ViewBag.USERNAME = new SelectList(db.CUSTOMERs, "USERNAME", "NAME_CUS", oRDERPRO.USERNAME);
            return View(oRDERPRO);
        }

        // POST: ORDERPROes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ORDER,USERNAME,SDT,ORDER_ADDRESS,DATEORDER")] ORDERPRO oRDERPRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDERPRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USERNAME = new SelectList(db.CUSTOMERs, "USERNAME", "NAME_CUS", oRDERPRO.USERNAME);
            return View(oRDERPRO);
        }

        // GET: ORDERPROes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERPRO oRDERPRO = db.ORDERPROes.Find(id);
            if (oRDERPRO == null)
            {
                return HttpNotFound();
            }
            return View(oRDERPRO);
        }

        // POST: ORDERPROes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ORDERPRO oRDERPRO = db.ORDERPROes.Find(id);
            db.ORDERPROes.Remove(oRDERPRO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult MyOrder(string username)
        {
            var or = db.ORDERPROes.Where(s => s.USERNAME == username);
            return View(or);
        }
    }
}
