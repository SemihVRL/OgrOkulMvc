using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOgrOkul.Controllers
{
    public class HesapMakinesiController : Controller
    {
        // GET: HesapMakinesi
        public ActionResult HesapMakinesi(double sayi1=0,double sayi2=0)
        {
            var degerler = sayi1;
            ViewBag.sayinin = degerler;

            var degerler2 = sayi2;
            ViewBag.sayininn=degerler2;

            var sonuc=sayi1 + sayi2;
            ViewBag.snc =sonuc;

            var sonuc1=sayi1 - sayi2;
            ViewBag.snc1=sonuc1;

            var sonuc2 = sayi1 * sayi2;
            ViewBag.snc2 = sonuc2;

            var sonuc3 = sayi1 / sayi2;
            ViewBag.snc3 = sonuc3;

            return View();
        }

      

    }
}