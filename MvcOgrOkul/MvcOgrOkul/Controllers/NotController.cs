using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrOkul.Models;
using MvcOgrOkul.Models.EntityFramework;



namespace MvcOgrOkul.Controllers
{
    public class NotController : Controller
    {
        // GET: Not
        MvcDbOkulEntities mvcDbOkulEntities = new MvcDbOkulEntities();
        public ActionResult Not()
        {
            var notlar = mvcDbOkulEntities.TBLNOTLAR.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniNot()
        {
            List<SelectListItem> notlar = (from i in mvcDbOkulEntities.TBLDERSLER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DERSAD,
                                               Value = i.DERSID.ToString()
                                           }).ToList();
            ViewBag.not = notlar;
            return View();
        }
        [HttpPost]
        public ActionResult YeniNot(TBLNOTLAR tblnotlar)
        {
            var nt = mvcDbOkulEntities.TBLDERSLER.Where(m => m.DERSID == tblnotlar.TBLDERSLER.DERSID).FirstOrDefault();
            tblnotlar.TBLDERSLER = nt;
            mvcDbOkulEntities.TBLNOTLAR.Add(tblnotlar);
            mvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Not");
        }
        public ActionResult NotSil(int id)
        {
            var not = mvcDbOkulEntities.TBLNOTLAR.Find(id);
            mvcDbOkulEntities.TBLNOTLAR.Remove(not);
            mvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Not");
        }
        public ActionResult NotGetir(int id)
        {
            var getir = mvcDbOkulEntities.TBLNOTLAR.Find(id);
            return View("NotGetir",getir);
        }
       
        [HttpPost]
        public ActionResult NotGetir(Class1 model,TBLNOTLAR tblnotlar, int SINAV1=0, int SINAV2=0, int SINAV3 = 0, int PROJE = 0)
        {
            if (model.islem=="HESAPLA")
            {
                int ortalama = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
               ViewBag.ort=ortalama;
            }
            if (model.islem=="GUNCELLE")
            {

                var guncelle = mvcDbOkulEntities.TBLNOTLAR.Find(tblnotlar.NOTID);
              
                guncelle.SINAV1 = tblnotlar.SINAV1;
                guncelle.SINAV2 = tblnotlar.SINAV2;
                guncelle.SINAV3 = tblnotlar.SINAV3;
                guncelle.PROJE = tblnotlar.PROJE;
                guncelle.ORTALAMA = tblnotlar.ORTALAMA;
                guncelle.DURUM = tblnotlar.DURUM;
                mvcDbOkulEntities.SaveChanges();
                return RedirectToAction("Not");
            }
            return View();
        }
    }

}