using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje.Models;
using Newtonsoft.Json;

namespace proje.Admin
{
    [Authorize]
    public class MekanController : Controller
    {
        Model1 db = new Model1();
        int aktifsayfa = 0;
        int toplamsayfa = 0;
        int sayfadakisatir = 5;
        int toplamkayit = 0;
        // GET: Mekan
        public ActionResult Index(int sayfa = 0)
        {
          

            var liste = new List<MEKAN>();

            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                liste = db.MEKANs.Where(e => e.MEKAN_ADI.Contains(kelime)).ToList();
            }
            else
            {
                liste = db.MEKANs.ToList();
            }

            List<KATEGORI> kategoriler = db.KATEGORIs.ToList();
            List<ALT_KATEGORI> altkategoriler = db.ALT_KATEGORI.ToList();
            ViewData["kategoriler"] = kategoriler;
            ViewData["altkategoriler"] = altkategoriler;

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

        public ActionResult KayitFormu(int? id)
        {
            MEKAN mekan = new MEKAN();
            if (id != null)
            {
                mekan = db.MEKANs.Find(id);
                if (mekan == null)
                {
                    mekan = new MEKAN();
                }
            }

            var kategori = db.KATEGORIs.ToList();
            ViewData["kategori"] = kategori;

            var il = db.ILs.ToList();
            ViewData["il"] = il;

            return View(mekan);
        }

        [HttpPost]
        public ActionResult KayitFormu(MEKAN mekan)
        {
            if (ModelState.IsValid)
            {
                if (mekan.MEKAN_ID == 0)
                {
                    db.MEKANs.Add(mekan);
                }
                else
                {
                    db.Entry(mekan).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var kategori = db.KATEGORIs.ToList();
                ViewData["kategori"] = kategori;

                var il = db.ILs.ToList();
                ViewData["il"] = il;


                return View(mekan);
            }
        }

        public JsonResult AltKategori(int kategoriid)
        {
            var altkategori = db.ALT_KATEGORI.Where(k => k.KATEGORI_ID == kategoriid).ToList();
            return Json(altkategori, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Ilce(int ilid)
        {
            var ilce = db.ILCEs.Where(k => k.IL_ID == ilid).ToList();
            return Json(ilce, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Sil(int? id)
        {
            if (id != null)
            {
                var mekan = db.MEKANs.Find(id);
                if (mekan != null)
                {
                    db.MEKANs.Remove(mekan);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}