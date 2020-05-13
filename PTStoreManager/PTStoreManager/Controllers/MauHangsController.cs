using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PTStoreManager.Models;

namespace PTStoreManager.Controllers
{
    public class MauHangsController : Controller
    {
        private QLTapHoaEntities db = new QLTapHoaEntities();

        // GET: MauHangs
        public ActionResult Index()
        {
            return View(db.MauHangs.ToList());
        }

        // GET: MauHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauHang mauHang = db.MauHangs.Find(id);
            if (mauHang == null)
            {
                return HttpNotFound();
            }
            return View(mauHang);
        }

        // GET: MauHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MauHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMH,TenMH,DonVi,Anh,ChuThich")] MauHang mauHang)
        {
            if (ModelState.IsValid)
            {
                db.MauHangs.Add(mauHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mauHang);
        }

        // GET: MauHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauHang mauHang = db.MauHangs.Find(id);
            if (mauHang == null)
            {
                return HttpNotFound();
            }
            return View(mauHang);
        }

        // POST: MauHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMH,TenMH,DonVi,Anh,ChuThich")] MauHang mauHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mauHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mauHang);
        }

        // GET: MauHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauHang mauHang = db.MauHangs.Find(id);
            if (mauHang == null)
            {
                return HttpNotFound();
            }
            return View(mauHang);
        }

        // POST: MauHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MauHang mauHang = db.MauHangs.Find(id);
            db.MauHangs.Remove(mauHang);
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
