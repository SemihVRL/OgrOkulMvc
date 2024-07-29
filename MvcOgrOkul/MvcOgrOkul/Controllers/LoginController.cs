using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrOkul.Models.EntityFramework;
using System.Web.Security;

namespace MvcOgrOkul.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MvcDbOkulEntities db = new MvcDbOkulEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {

            var bilgiler = db.Admin.FirstOrDefault(x => x.KullaniciAdi == admin.KullaniciAdi && x.sifre == admin.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                return RedirectToAction("AnaSayfa","AnaSayfa");
            
            }
            else
            {
                return View();
            }


        }
    }
}