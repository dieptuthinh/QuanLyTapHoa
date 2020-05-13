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
    public class HangDonHangNhapsController : Controller
    {
        private QLTapHoaEntities db = new QLTapHoaEntities();

        // GET: HangDonHangNhaps
        public ActionResult Index()
        {
            var hangDonHangNhaps = db.HangDonHangNhaps.Include(h => h.DonHangNhap).Include(h => h.Hang);
            return View(hangDonHangNhaps.ToList());
        }

        // GET: HangDonHangNhaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangDonHangNhap hangDonHangNhap = db.HangDonHangNhaps.Find(id);
            if (hangDonHangNhap == null)
            {
                return HttpNotFound();
            }
            return View(hangDonHangNhap);
        }

        // GET: HangDonHangNhaps/Create
        public ActionResult Create()
        {
            ViewBag.MaDHN = new SelectList(db.DonHangNhaps, "MaDHN", "MaNCC");
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "MaMH");
            return View();
        }

        // POST: HangDonHangNhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDHN,MaH,SoLuong")] HangDonHangNhap hangDonHangNhap)
        {
            if (ModelState.IsValid)
            {
                db.HangDonHangNhaps.Add(hangDonHangNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDHN = new SelectList(db.DonHangNhaps, "MaDHN", "MaNCC", hangDonHangNhap.MaDHN);
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "MaMH", hangDonHangNhap.MaH);
            return View(hangDonHangNhap);
        }

        // GET: HangDonHangNhaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangDonHangNhap hangDonHangNhap = db.HangDonHangNhaps.Find(id);
            if (hangDonHangNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDHN = new SelectList(db.DonHangNhaps, "MaDHN", "MaNCC", hangDonHangNhap.MaDHN);
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "MaMH", hangDonHangNhap.MaH);
            return View(hangDonHangNhap);
        }

        // POST: HangDonHangNhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDHN,MaH,SoLuong")] HangDonHangNhap hangDonHangNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangDonHangNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDHN = new SelectList(db.DonHangNhaps, "MaDHN", "MaNCC", hangDonHangNhap.MaDHN);
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "MaMH", hangDonHangNhap.MaH);
            return View(hangDonHangNhap);
        }

        // GET: HangDonHangNhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangDonHangNhap hangDonHangNhap = db.HangDonHangNhaps.Find(id);
            if (hangDonHangNhap == null)
            {
                return HttpNotFound();
            }
            return View(hangDonHangNhap);
        }

        // POST: HangDonHangNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HangDonHangNhap hangDonHangNhap = db.HangDonHangNhaps.Find(id);
            db.HangDonHangNhaps.Remove(hangDonHangNhap);
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
