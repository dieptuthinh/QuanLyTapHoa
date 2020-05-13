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
    public class DonHangNhapsController : Controller
    {
        private QLTapHoaEntities db = new QLTapHoaEntities();

        // GET: DonHangNhaps
        public ActionResult Index()
        {
            var donHangNhaps = db.DonHangNhaps.Include(d => d.NhaCungCap);
            return View(donHangNhaps.ToList());
        }

        // GET: DonHangNhaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangNhap donHangNhap = db.DonHangNhaps.Find(id);
            if (donHangNhap == null)
            {
                return HttpNotFound();
            }
            return View(donHangNhap);
        }

        // GET: DonHangNhaps/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            return View();
        }

        // POST: DonHangNhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDHN,MaNCC,NgayNhap,GiamGia,KieuGiamGia")] DonHangNhap donHangNhap)
        {
            if (ModelState.IsValid)
            {
                db.DonHangNhaps.Add(donHangNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", donHangNhap.MaNCC);
            return View(donHangNhap);
        }

        // GET: DonHangNhaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangNhap donHangNhap = db.DonHangNhaps.Find(id);
            if (donHangNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", donHangNhap.MaNCC);
            return View(donHangNhap);
        }

        // POST: DonHangNhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDHN,MaNCC,NgayNhap,GiamGia,KieuGiamGia")] DonHangNhap donHangNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHangNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", donHangNhap.MaNCC);
            return View(donHangNhap);
        }

        // GET: DonHangNhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangNhap donHangNhap = db.DonHangNhaps.Find(id);
            if (donHangNhap == null)
            {
                return HttpNotFound();
            }
            return View(donHangNhap);
        }

        // POST: DonHangNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonHangNhap donHangNhap = db.DonHangNhaps.Find(id);
            db.DonHangNhaps.Remove(donHangNhap);
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
