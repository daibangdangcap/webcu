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
    public class DETAILsController : Controller
    {
        private DBTechEntities db = new DBTechEntities();

        // GET: DETAILs
        public ActionResult Index()
        {
            var dETAILS = db.DETAILS.Include(d => d.CATEGORY).Include(d => d.PRODUCT);
            return View(dETAILS.ToList());
        }

        // GET: DETAILs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAIL dETAIL = db.DETAILS.Find(id);
            if (dETAIL == null)
            {
                return HttpNotFound();
            }
            return View(dETAIL);
        }

        // GET: DETAILs/Create
        public ActionResult Create()
        {
            ViewBag.NAME_CATE = new SelectList(db.CATEGORies, "NAME_CATE", "NAME_CATE");
            ViewBag.ID_PRO = new SelectList(db.PRODUCTs, "ID_PRO", "ID_PRO");
            return View();
        }

        // POST: DETAILs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_PRO,NAME_CATE,HEDIEUHANH,SIZE,WEIGHT")] DETAIL dETAIL)
        {
            if (ModelState.IsValid)
            {
                db.DETAILS.Add(dETAIL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NAME_CATE = new SelectList(db.CATEGORies, "NAME_CATE", "NAME_CATE", dETAIL.NAME_CATE);
            ViewBag.ID_PRO = new SelectList(db.PRODUCTs, "ID_PRO", "ID_PRO", dETAIL.ID_PRO);
            return View(dETAIL);
        }

        // GET: DETAILs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAIL dETAIL = db.DETAILS.Find(id);
            if (dETAIL == null)
            {
                return HttpNotFound();
            }
            ViewBag.NAME_CATE = new SelectList(db.CATEGORies, "NAME_CATE", "NAME_CATE", dETAIL.NAME_CATE);
            ViewBag.ID_PRO = new SelectList(db.PRODUCTs, "ID_PRO", "ID_PRO", dETAIL.ID_PRO);
            return View(dETAIL);
        }

        // POST: DETAILs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_PRO,NAME_CATE,HEDIEUHANH,SIZE,WEIGHT")] DETAIL dETAIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETAIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NAME_CATE = new SelectList(db.CATEGORies, "NAME_CATE", "NAME_CATE", dETAIL.NAME_CATE);
            ViewBag.ID_PRO = new SelectList(db.PRODUCTs, "ID_PRO", "ID_PRO", dETAIL.ID_PRO);
            return View(dETAIL);
        }

        // GET: DETAILs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAIL dETAIL = db.DETAILS.Find(id);
            if (dETAIL == null)
            {
                return HttpNotFound();
            }
            return View(dETAIL);
        }

        // POST: DETAILs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETAIL dETAIL = db.DETAILS.Find(id);
            db.DETAILS.Remove(dETAIL);
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
