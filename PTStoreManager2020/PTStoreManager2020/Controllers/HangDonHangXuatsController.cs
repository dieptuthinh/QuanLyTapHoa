using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PTStoreManager2020.Models;

namespace PTStoreManager2020.Controllers
{
    public class HangDonHangXuatsController : Controller
    {
        private QLTapHoaEntities db = new QLTapHoaEntities();

        // GET: HangDonHangXuats
        public ActionResult Index()
        {
            var hangDonHangXuats = db.HangDonHangXuats.Include(h => h.DonHangXuat).Include(h => h.Hang);
            return View(hangDonHangXuats.ToList());
        }

        // GET: HangDonHangXuats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangDonHangXuat hangDonHangXuat = db.HangDonHangXuats.Find(id);
            if (hangDonHangXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangDonHangXuat);
        }

        // GET: HangDonHangXuats/Create
        public ActionResult Create()
        {
            ViewBag.MaDHX = new SelectList(db.DonHangXuats, "MaDHX", "MaKH");
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "MaMH");
            return View();
        }

        // POST: HangDonHangXuats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDHX,MaH,SoLuong")] HangDonHangXuat hangDonHangXuat)
        {
            if (ModelState.IsValid)
            {
                db.HangDonHangXuats.Add(hangDonHangXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDHX = new SelectList(db.DonHangXuats, "MaDHX", "MaKH", hangDonHangXuat.MaDHX);
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "MaMH", hangDonHangXuat.MaH);
            return View(hangDonHangXuat);
        }

        // GET: HangDonHangXuats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangDonHangXuat hangDonHangXuat = db.HangDonHangXuats.Find(id);
            if (hangDonHangXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDHX = new SelectList(db.DonHangXuats, "MaDHX", "MaKH", hangDonHangXuat.MaDHX);
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "MaMH", hangDonHangXuat.MaH);
            return View(hangDonHangXuat);
        }

        // POST: HangDonHangXuats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDHX,MaH,SoLuong")] HangDonHangXuat hangDonHangXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangDonHangXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDHX = new SelectList(db.DonHangXuats, "MaDHX", "MaKH", hangDonHangXuat.MaDHX);
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "MaMH", hangDonHangXuat.MaH);
            return View(hangDonHangXuat);
        }

        // GET: HangDonHangXuats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangDonHangXuat hangDonHangXuat = db.HangDonHangXuats.Find(id);
            if (hangDonHangXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangDonHangXuat);
        }

        // POST: HangDonHangXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HangDonHangXuat hangDonHangXuat = db.HangDonHangXuats.Find(id);
            db.HangDonHangXuats.Remove(hangDonHangXuat);
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
