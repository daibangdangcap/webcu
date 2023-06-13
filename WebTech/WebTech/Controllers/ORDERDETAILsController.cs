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
    public class ORDERDETAILsController : Controller
    {
        private DBTechEntities db = new DBTechEntities();

        // GET: ORDERDETAILs
        public ActionResult Index(int? id)
        {
            var oRDERDETAILs = db.ORDERDETAILs.Include(o => o.ORDERPRO).Include(o => o.PRODUCT).Where(s=>s.IDOrder==id);
            ORDERPRO op = db.ORDERPROes.Where(s => s.ID_ORDER == id).FirstOrDefault();
            Session["NAMECUSTOMER"] = op.NAMECUSTOMER;
            Session["SDT"] = op.SDT;
            Session["ORDER_ADDRESS"] = op.ORDER_ADDRESS;
            Session["PRICE"] = op.PRICE;
            Session["USERNAME"] = op.USERNAME;
            Session["NAMECUS"] = op.CUSTOMER.NAME_CUS;
            return View(oRDERDETAILs.ToList());
        }

        // GET: ORDERDETAILs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERDETAIL oRDERDETAIL = db.ORDERDETAILs.Where(s=>s.IDOrder==id).FirstOrDefault();
            if (oRDERDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(oRDERDETAIL);
        }

        // GET: ORDERDETAILs/Create
        public ActionResult Create()
        {
            ViewBag.IDOrder = new SelectList(db.ORDERPROes, "ID_ORDER", "USERNAME");
            ViewBag.IDProduct = new SelectList(db.PRODUCTs, "ID_PRO", "NAME_PRO");
            return View();
        }

        // POST: ORDERDETAILs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDProduct,IDOrder,Quantity,UnitPrice")] ORDERDETAIL oRDERDETAIL)
        {
            if (ModelState.IsValid)
            {
                db.ORDERDETAILs.Add(oRDERDETAIL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDOrder = new SelectList(db.ORDERPROes, "ID_ORDER", "USERNAME", oRDERDETAIL.IDOrder);
            ViewBag.IDProduct = new SelectList(db.PRODUCTs, "ID_PRO", "NAME_PRO", oRDERDETAIL.IDProduct);
            return View(oRDERDETAIL);
        }

        // GET: ORDERDETAILs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERDETAIL oRDERDETAIL = db.ORDERDETAILs.Find(id);
            if (oRDERDETAIL == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOrder = new SelectList(db.ORDERPROes, "ID_ORDER", "USERNAME", oRDERDETAIL.IDOrder);
            ViewBag.IDProduct = new SelectList(db.PRODUCTs, "ID_PRO", "NAME_PRO", oRDERDETAIL.IDProduct);
            return View(oRDERDETAIL);
        }

        // POST: ORDERDETAILs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDProduct,IDOrder,Quantity,UnitPrice")] ORDERDETAIL oRDERDETAIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDERDETAIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDOrder = new SelectList(db.ORDERPROes, "ID_ORDER", "USERNAME", oRDERDETAIL.IDOrder);
            ViewBag.IDProduct = new SelectList(db.PRODUCTs, "ID_PRO", "NAME_PRO", oRDERDETAIL.IDProduct);
            return View(oRDERDETAIL);
        }

        // GET: ORDERDETAILs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERDETAIL oRDERDETAIL = db.ORDERDETAILs.Find(id);
            if (oRDERDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(oRDERDETAIL);
        }

        // POST: ORDERDETAILs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ORDERDETAIL oRDERDETAIL = db.ORDERDETAILs.Find(id);
            db.ORDERDETAILs.Remove(oRDERDETAIL);
            db.SaveChanges();
            return RedirectToAction("Index","ORDERPROes");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult OrderDetail(int id)
        {
            var or = db.ORDERDETAILs.Where(s => s.IDOrder == id);
            ORDERPRO op = db.ORDERPROes.Where(s => s.ID_ORDER == id).FirstOrDefault();
            Session["NAMECUSTOMER"] = op.NAMECUSTOMER;
            Session["SDT"] = op.SDT;
            Session["ORDER_ADDRESS"] = op.ORDER_ADDRESS;
            Session["PRICE"] = op.PRICE;
            Session["USERNAME"] = op.USERNAME;
            Session["NAMECUS"] = op.CUSTOMER.NAME_CUS;
            return View(or);
        }
    }
}
