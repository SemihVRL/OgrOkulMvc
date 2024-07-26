using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrOkul.Models.EntityFramework;

namespace MvcOgrOkul.Controllers
{
    public class ÖğrenciController : Controller
    {
        // GET: Öğrenci
        MvcDbOkulEntities MvcDbOkulEntities = new MvcDbOkulEntities();
        public ActionResult Ogrenci()
        {
            var ogrenciler = MvcDbOkulEntities.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult OgrEkle()
        {
            List<SelectListItem> ogrler = (from i in MvcDbOkulEntities.TBLKULUPLER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KULUPAD,
                                               Value = i.KULUPID.ToString()
                                           }).ToList();
            ViewBag.ogrenciler = ogrler;
            return View();
        }

        [HttpPost]
        public ActionResult OgrEkle(TBLOGRENCILER tblogr)
        {
            var klp = MvcDbOkulEntities.TBLKULUPLER.Where(m => m.KULUPID == tblogr.TBLKULUPLER.KULUPID).FirstOrDefault();
            tblogr.TBLKULUPLER = klp;
            MvcDbOkulEntities.TBLOGRENCILER.Add(tblogr);
            MvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Ogrenci");
        }

        public ActionResult OgrSil(int id)
        {
            var ogr = MvcDbOkulEntities.TBLOGRENCILER.Find(id);
            MvcDbOkulEntities.TBLOGRENCILER.Remove(ogr);
            MvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Ogrenci");
        }
        public ActionResult OgrGetir(int id)
        {
            List<SelectListItem> guncelle = (from i in MvcDbOkulEntities.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()

                                             }).ToList();
               
            ViewBag.guncelleyenler=guncelle;
            

            var getir = MvcDbOkulEntities.TBLOGRENCILER.Find(id);
            return View("OgrGetir", getir);
        }

        public ActionResult OgrGuncelle(TBLOGRENCILER tblogrenciler)
        {
            var klp = MvcDbOkulEntities.TBLKULUPLER.Where(m => m.KULUPID == tblogrenciler.TBLKULUPLER.KULUPID).FirstOrDefault();
            tblogrenciler.TBLKULUPLER = klp;
            var guncelle = MvcDbOkulEntities.TBLOGRENCILER.Find(tblogrenciler.OGRID);
            guncelle.OGRAD = tblogrenciler.OGRAD;
            guncelle.OGRSOYAD = tblogrenciler.OGRSOYAD;
            guncelle.OGRFOTOGRAF = tblogrenciler.OGRFOTOGRAF;
            guncelle.OGRCINSIYET = tblogrenciler.OGRCINSIYET;
            guncelle.OGRKULUP=tblogrenciler.OGRKULUP;
            MvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Ogrenci");
        }

    }
}