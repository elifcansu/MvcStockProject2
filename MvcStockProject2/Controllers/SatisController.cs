using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStockProject2.Models.Entity;

namespace MvcStockProject2.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDBStokEntities db = new MvcDBStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
         public ActionResult YeniSatis(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");

        }

    }
}