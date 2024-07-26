using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrOkul.Models.EntityFramework;

namespace MvcOgrOkul.Controllers
{
    public class DersController : Controller
    {
        // GET: Ders
        MvcDbOkulEntities MvcDbOkulEntities = new MvcDbOkulEntities();
        public ActionResult Ders()
        {
            var dersler = MvcDbOkulEntities.TBLDERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER tblders)
        {
            MvcDbOkulEntities.TBLDERSLER.Add(tblders);
            MvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Ders");
        }
        public ActionResult DersSil(int id)
        {
            var ders = MvcDbOkulEntities.TBLDERSLER.Find(id);
            MvcDbOkulEntities.TBLDERSLER.Remove(ders);
            MvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Ders");
        }
        public ActionResult DersGetir(int id)
        {
            var getir = MvcDbOkulEntities.TBLDERSLER.Find(id);
            return View("DersGetir",getir);
        }
        public ActionResult DersGuncelle(TBLDERSLER tbldersler)
        {
            var guncelle = MvcDbOkulEntities.TBLDERSLER.Find(tbldersler.DERSID);
            guncelle.DERSAD = tbldersler.DERSAD;
            MvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Ders");

        }

    }
}