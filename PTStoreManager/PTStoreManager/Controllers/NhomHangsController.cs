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
    public class NhomHangsController : Controller
    {
        private QLTapHoaEntities db = new QLTapHoaEntities();

        // GET: NhomHangs
        public ActionResult Index()
        {
            return View(db.NhomHangs.ToList());
        }

        // GET: NhomHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomHang nhomHang = db.NhomHangs.Find(id);
            if (nhomHang == null)
            {
                return HttpNotFound();
            }
            return View(nhomHang);
        }

        // GET: NhomHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhomHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNH,TenNH")] NhomHang nhomHang)
        {
            if (ModelState.IsValid)
            {
                db.NhomHangs.Add(nhomHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhomHang);
        }

        // GET: NhomHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomHang nhomHang = db.NhomHangs.Find(id);
            if (nhomHang == null)
            {
                return HttpNotFound();
            }
            return View(nhomHang);
        }

        // POST: NhomHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNH,TenNH")] NhomHang nhomHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhomHang);
        }

        // GET: NhomHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomHang nhomHang = db.NhomHangs.Find(id);
            if (nhomHang == null)
            {
                return HttpNotFound();
            }
            return View(nhomHang);
        }

        // POST: NhomHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhomHang nhomHang = db.NhomHangs.Find(id);
            db.NhomHangs.Remove(nhomHang);
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
