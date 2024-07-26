 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using MvcOgrOkul.Models.EntityFramework;

namespace MvcOgrOkul.Controllers
{
    public class KulupController : Controller
    {
        // GET: Kulup
       MvcDbOkulEntities MvcDbOkulEntities=new MvcDbOkulEntities();
        public ActionResult Kulup()
        {
            var kulupler=MvcDbOkulEntities.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult KulupEkle()
        {
           return View();
        }

        [HttpPost]
        public ActionResult KulupEkle(TBLKULUPLER tblkulup)
        {
            MvcDbOkulEntities.TBLKULUPLER.Add(tblkulup);
            MvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Kulup");
        }
        public ActionResult KulupSil(int id)
        {
            var kulup = MvcDbOkulEntities.TBLKULUPLER.Find(id);
            MvcDbOkulEntities.TBLKULUPLER.Remove(kulup);
            MvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Kulup");
        }
        public ActionResult KulupGetir(int id)
        {
            var getir = MvcDbOkulEntities.TBLKULUPLER.Find(id);
           return View("KulupGetir",getir);
        }
        public ActionResult KulupGuncelle(TBLKULUPLER tblkulupler)
        {
            var guncelle = MvcDbOkulEntities.TBLKULUPLER.Find(tblkulupler.KULUPID);
            guncelle.KULUPAD = tblkulupler.KULUPAD;
            guncelle.KULUPKONTENJAN = tblkulupler.KULUPKONTENJAN;
            MvcDbOkulEntities.SaveChanges();
            return RedirectToAction("Kulup");
        }
    }
}