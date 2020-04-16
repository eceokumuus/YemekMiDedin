using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using proje.Models;

namespace proje.Admin
{
    public class SiteLoginController : Controller
    {
        // GET: SiteLogin
        Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string YONETICI_ADI, string SIFRE)
        {
            var yönetici = db.YONETICIs.Where(k => k.YONETICI_ADI == YONETICI_ADI &&
                                                    k.SIFRE == SIFRE && k.DURUMU == true).SingleOrDefault();
            if (yönetici != null)
            {
                //Login olduğumuz yazılama bildiriliyor
                FormsAuthentication.SetAuthCookie(yönetici.YONETICI_ADI, false);
                return RedirectToAction("../Anasayfa/Index");
            }
            else
            {
                ViewData["Mesaj"] = "Yönetici Adı veya Şifresi Yanlış";
                ViewBag.Mesaj = "Yönetici Adı veya Şifresi Yanlış";

                TempData["Mesaj"] = "Yönetici Adı veya Şifresi Yanlış";

                return RedirectToAction("Index");
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}