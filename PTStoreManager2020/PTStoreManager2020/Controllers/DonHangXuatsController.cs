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
    public class DonHangXuatsController : Controller
    {
        private QLTapHoaEntities db = new QLTapHoaEntities();

        // GET: DonHangXuats
        public ActionResult Index()
        {
            var donHangXuats = db.DonHangXuats.Include(d => d.KhachHang);
            return View(donHangXuats.ToList());
        }

        // GET: DonHangXuats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangXuat donHangXuat = db.DonHangXuats.Find(id);
            if (donHangXuat == null)
            {
                return HttpNotFound();
            }
            return View(donHangXuat);
        }

        // GET: DonHangXuats/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen");
            return View();
        }

        // POST: DonHangXuats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDHX,MaKH,NgayXuat,GiamGia,KieuGiamGia")] DonHangXuat donHangXuat)
        {
            if (ModelState.IsValid)
            {
                db.DonHangXuats.Add(donHangXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", donHangXuat.MaKH);
            return View(donHangXuat);
        }

        // GET: DonHangXuats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangXuat donHangXuat = db.DonHangXuats.Find(id);
            if (donHangXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", donHangXuat.MaKH);
            return View(donHangXuat);
        }

        // POST: DonHangXuats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDHX,MaKH,NgayXuat,GiamGia,KieuGiamGia")] DonHangXuat donHangXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHangXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", donHangXuat.MaKH);
            return View(donHangXuat);
        }

        // GET: DonHangXuats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangXuat donHangXuat = db.DonHangXuats.Find(id);
            if (donHangXuat == null)
            {
                return HttpNotFound();
            }
            return View(donHangXuat);
        }

        // POST: DonHangXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonHangXuat donHangXuat = db.DonHangXuats.Find(id);
            db.DonHangXuats.Remove(donHangXuat);
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
