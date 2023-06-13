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
    public class ROLEUSERsController : Controller
    {
        private DBTechEntities db = new DBTechEntities();

        // GET: ROLEUSERs
        public ActionResult Index()
        {
            return View(db.ROLEUSERs.ToList());
        }

        // GET: ROLEUSERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLEUSER rOLEUSER = db.ROLEUSERs.Find(id);
            if (rOLEUSER == null)
            {
                return HttpNotFound();
            }
            return View(rOLEUSER);
        }

        // GET: ROLEUSERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ROLEUSERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ROLE")] ROLEUSER rOLEUSER)
        {
            if (ModelState.IsValid)
            {
                db.ROLEUSERs.Add(rOLEUSER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rOLEUSER);
        }

        // GET: ROLEUSERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLEUSER rOLEUSER = db.ROLEUSERs.Find(id);
            if (rOLEUSER == null)
            {
                return HttpNotFound();
            }
            return View(rOLEUSER);
        }

        // POST: ROLEUSERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ROLE")] ROLEUSER rOLEUSER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOLEUSER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rOLEUSER);
        }

        // GET: ROLEUSERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLEUSER rOLEUSER = db.ROLEUSERs.Find(id);
            if (rOLEUSER == null)
            {
                return HttpNotFound();
            }
            return View(rOLEUSER);
        }

        // POST: ROLEUSERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ROLEUSER rOLEUSER = db.ROLEUSERs.Find(id);
            db.ROLEUSERs.Remove(rOLEUSER);
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
    }
}
