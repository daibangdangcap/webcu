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
    public class ADMINUSERsController : Controller
    {
        private DBTechEntities db = new DBTechEntities();

        // GET: ADMINUSERs
        public ActionResult Index()
        {
            var aDMINUSERs = db.ADMINUSERs.Include(a => a.ROLEUSER);
            return View(aDMINUSERs.ToList());
        }

        // GET: ADMINUSERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINUSER aDMINUSER = db.ADMINUSERs.Find(id);
            if (aDMINUSER == null)
            {
                return HttpNotFound();
            }
            return View(aDMINUSER);
        }

        // GET: ADMINUSERs/Create
        public ActionResult Create()
        {
            ViewBag.ROLLUSER = new SelectList(db.ROLEUSERs, "ROLE", "ROLE");
            return View();
        }

        // POST: ADMINUSERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USER_AD,NAME,PASSWORD_AD,ROLLUSER")] ADMINUSER aDMINUSER)
        {
            if (ModelState.IsValid)
            {
                db.ADMINUSERs.Add(aDMINUSER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ROLLUSER = new SelectList(db.ROLEUSERs, "ROLE", "ROLE", aDMINUSER.ROLLUSER);
            return View(aDMINUSER);
        }

        // GET: ADMINUSERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINUSER aDMINUSER = db.ADMINUSERs.Find(id);
            if (aDMINUSER == null)
            {
                return HttpNotFound();
            }
            ViewBag.ROLLUSER = new SelectList(db.ROLEUSERs, "ROLE", "ROLE", aDMINUSER.ROLLUSER);
            return View(aDMINUSER);
        }

        // POST: ADMINUSERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,USER_AD,NAME,PASSWORD_AD,ROLLUSER")] ADMINUSER aDMINUSER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDMINUSER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details",new { id=aDMINUSER.ID});
            }
            ViewBag.ROLLUSER = new SelectList(db.ROLEUSERs, "ROLE", "ROLE", aDMINUSER.ROLLUSER);
            return View(aDMINUSER);
        }

        // GET: ADMINUSERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINUSER aDMINUSER = db.ADMINUSERs.Find(id);
            if (aDMINUSER == null)
            {
                return HttpNotFound();
            }
            return View(aDMINUSER);
        }

        // POST: ADMINUSERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADMINUSER aDMINUSER = db.ADMINUSERs.Find(id);
            db.ADMINUSERs.Remove(aDMINUSER);
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
        public ActionResult Informs(string inform)
        {

            if (inform == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINUSER ad = db.ADMINUSERs.Where(s => s.USER_AD == inform).FirstOrDefault();
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }
    }
}
