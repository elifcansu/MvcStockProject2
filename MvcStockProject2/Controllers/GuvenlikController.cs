using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcStockProject2.Models.Entity;
namespace MvcStockProject2.Controllers
{
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        MvcDBStokEntities1 db = new MvcDBStokEntities1();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLKULLANICI t)
        {
            var bilgiler = db.TBLKULLANICI.FirstOrDefault(x => x.AD == t.AD && x.SIFRE == t.SIFRE);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AD,false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                return View();
            }
            
        }
    }
}