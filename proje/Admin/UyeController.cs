using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using proje.Models;

namespace proje.Admin
{
    [Authorize]

    public class UyeController : Controller
    {
        int aktifsayfa = 0;
        int toplamsayfa = 0;
        int sayfadakisatir = 5;
        int toplamkayit = 0;
        Model1 db = new Model1();
        // GET: Uye
        public ActionResult Index(int sayfa = 0)
        {
            var liste = new List<UYE>();

            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                liste = db.UYEs.Where(e => e.ADI.Contains(kelime)).ToList();
            }
            else
            {
                liste = db.UYEs.ToList();
            }

            List<IL> iller = db.ILs.ToList();
            List<ILCE> ilceler = db.ILCEs.ToList();
            ViewData["iller"] = iller;
            ViewData["ilceler"] = ilceler;
            aktifsayfa = sayfa;
            toplamkayit = liste.Count();
            //sayfalama yapılıyor
            liste = liste.Skip(sayfa * sayfadakisatir).Take(sayfadakisatir).ToList();

            toplamsayfa = toplamkayit / sayfadakisatir;
            if (toplamkayit % sayfadakisatir != 0) toplamsayfa++;

            ViewData["sayfa"] = sayfa;
            ViewData["toplamsayfa"] = toplamsayfa;
            ViewData["toplamkayit"] = toplamkayit;
            return View(liste);
        }
        public ActionResult Sil(int id)
        {
            var k = db.UYEs.Find(id);
            db.UYEs.Remove(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KayitFormu(int? id)
        {
            UYE uye = new UYE();
            if (id != null)
            {
                uye = db.UYEs.Find(id);
                if (uye == null)
                {
                    uye = new UYE();
                }
            }
            var il = db.ILs.ToList();
            ViewData["il"] = il;
            return View(uye);
        }

        [HttpPost]
        public ActionResult KayitFormu(UYE uye)
        {
            if (ModelState.IsValid)
            {
                if (uye.UYE_ID == 0) //yeni
                {
                    db.UYEs.Add(uye);
                }
                else //eski
                {
                    db.Entry(uye).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var il = db.UYEs.ToList();
                ViewData["il"] = il;
                return View(uye);
            }

        }
        public JsonResult Ilce(int ilid)
        {
            var ilceid = db.ILCEs.Where(k => k.IL_ID == ilid).ToList();

            return Json(ilceid, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", "Uye", new { ara = txtAra });
        }

    }
}