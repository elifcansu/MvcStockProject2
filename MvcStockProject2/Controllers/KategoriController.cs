using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStockProject2.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStockProject2.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDBStokEntities db = new MvcDBStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var kategoriler = db.TBLKATEGORILER.ToList();
            var kategoriler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 4);
            return View(kategoriler);
        }
        [HttpGet] //sayfa yüklendiğinde herhangi bir işlem yapmazsam sayfayı döndür.
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost] //sayfada işlem yaparsam o değişikliği kaydedip sayfayı döndür.
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var kategori = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            kategori.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}