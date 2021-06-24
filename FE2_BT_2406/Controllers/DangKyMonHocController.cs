using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FE2_BT_2406.Models;

namespace FE2_BT_2406.Controllers
{
    public class DangKyMonHocController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DangKyMonHoc
        public ActionResult Index()
        {
            var dangKyMonHocs = db.DangKyMonHocs.Include(d => d.MonHoc).Include(d => d.SinhVien);
            return View(dangKyMonHocs.ToList());
        }

        // GET: DangKyMonHoc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyMonHoc dangKyMonHoc = db.DangKyMonHocs.Find(id);
            if (dangKyMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(dangKyMonHoc);
        }

        // GET: DangKyMonHoc/Create
        public ActionResult Create()
        {
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc");
            ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "HoTen");
            return View();
        }

        // POST: DangKyMonHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDangKy,MaMonHoc,MaSinhVien,ThoiGianDangKy")] DangKyMonHoc dangKyMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.DangKyMonHocs.Add(dangKyMonHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", dangKyMonHoc.MaMonHoc);
            ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "HoTen", dangKyMonHoc.MaSinhVien);
            return View(dangKyMonHoc);
        }

        // GET: DangKyMonHoc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyMonHoc dangKyMonHoc = db.DangKyMonHocs.Find(id);
            if (dangKyMonHoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", dangKyMonHoc.MaMonHoc);
            ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "HoTen", dangKyMonHoc.MaSinhVien);
            return View(dangKyMonHoc);
        }

        // POST: DangKyMonHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDangKy,MaMonHoc,MaSinhVien,ThoiGianDangKy")] DangKyMonHoc dangKyMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dangKyMonHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", dangKyMonHoc.MaMonHoc);
            ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "HoTen", dangKyMonHoc.MaSinhVien);
            return View(dangKyMonHoc);
        }

        // GET: DangKyMonHoc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyMonHoc dangKyMonHoc = db.DangKyMonHocs.Find(id);
            if (dangKyMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(dangKyMonHoc);
        }

        // POST: DangKyMonHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DangKyMonHoc dangKyMonHoc = db.DangKyMonHocs.Find(id);
            db.DangKyMonHocs.Remove(dangKyMonHoc);
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
