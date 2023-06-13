using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTech.Models;
using PagedList;

namespace WebTech.Controllers
{
    public class PRODUCTsController : Controller
    {
        private DBTechEntities db = new DBTechEntities();

        // GET: PRODUCTs
        public ActionResult Index(string SearchString)
        {
            var products = db.PRODUCTs.Include(p => p.CATEGORY);
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.NAME_PRO.Contains(SearchString) || s.NAME_CATE.Contains(SearchString));
            }
            return View(products.ToList());
        }

        // GET: PRODUCTs/Details/5
        public ActionResult Details(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Where(s=>s.NAME_PRO.Contains(name)).FirstOrDefault();
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Create
        public ActionResult Create()
        {
            ViewBag.NAME_CATE = new SelectList(db.CATEGORies, "NAME_CATE", "NAME_CATE");
            return View();
        }

        // POST: PRODUCTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRO,NAME_PRO,IMAGE,NAME_CATE,PRICE,QUANTITY,IMAGEL,IMAGER")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTs.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NAME_CATE = new SelectList(db.CATEGORies, "NAME_CATE", "NAME_CATE", pRODUCT.NAME_CATE);
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Edit/5
        public ActionResult Edit(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Where(s => s.NAME_PRO == name).FirstOrDefault();
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.NAME_CATE = new SelectList(db.CATEGORies, "NAME_CATE", "NAME_CATE", pRODUCT.NAME_CATE);
            return View(pRODUCT);
        }

        // POST: PRODUCTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRO,NAME_PRO,IMAGE,NAME_CATE,PRICE,QUANTITY,IMAGEL,IMAGER")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NAME_CATE = new SelectList(db.CATEGORies, "NAME_CATE", "NAME_CATE", pRODUCT.NAME_CATE);
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Delete/5
        public ActionResult Delete(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Where(s => s.NAME_PRO == name).FirstOrDefault();
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: PRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string name)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Where(s => s.NAME_PRO == name).FirstOrDefault();
            db.PRODUCTs.Remove(pRODUCT);
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

        public ActionResult ProductList(int? page, string SearchString)
        {
            var products = db.PRODUCTs.Include(p => p.CATEGORY);
            //Tìm kiếm chuỗi theo name nếu chuỗi truy vấn khác rỗng
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.NAME_PRO.Contains(SearchString) || s.NAME_CATE.Contains(SearchString));
            }
            products = products.OrderByDescending(x => x.NAME_PRO);
            Session["NAMECATE"] = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            if (page == null) page = 1;
            return View(products.ToPagedList(pageNumber, pageSize));


        }
        public ActionResult ProductList_crumb(int? page,string SearchString)
        {
            var products = db.PRODUCTs.Include(p => p.CATEGORY);
            //Tìm kiếm chuỗi theo name nếu chuỗi truy vấn khác rỗng
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.NAME_PRO.Contains(SearchString) || s.NAME_CATE.Contains(SearchString));
            }
            products = products.OrderByDescending(x => x.NAME_PRO);
            Session["NAMECATE"] = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            if (page == null) page = 1;
            return View(products.ToPagedList(pageNumber, pageSize));
            
            
        }
        public ActionResult detailPro(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAIL pro = db.DETAILS.Where(s=>s.PRODUCT.NAME_PRO==id).FirstOrDefault();
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
        }
    }
}
