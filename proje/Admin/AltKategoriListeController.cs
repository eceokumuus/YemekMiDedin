using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje.Models;

namespace proje.Admin
{
    [Authorize]
    public class AltKategoriListeController : Controller
    {
        int aktifsayfa = 0;
        int toplamsayfa = 0;
        int sayfadakisatir = 5;
        int toplamkayit = 0;

        Model1 db = new Model1();
        // GET: KategoriListe

        public ActionResult Index(int sayfa = 0)
        {
            var liste = db.ALT_KATEGORI.ToList();

            if (Request["ara"] != null)
            {
                var txtAra = Request["ara"];
                liste = db.ALT_KATEGORI.Where(k => k.ALT_KATEGORI_ADI.Contains(txtAra)).ToList();
            }
            else
            {
                liste = db.ALT_KATEGORI.ToList();
            }
            List<KATEGORI> kategoriler = db.KATEGORIs.ToList();
            ViewData["kategoriler"] = kategoriler;

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
            var k = db.ALT_KATEGORI.Find(id);
            db.ALT_KATEGORI.Remove(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KayitFormu(int? id)
        {
            ALT_KATEGORI k = new ALT_KATEGORI();
            if (id != null)
            {
                k = db.ALT_KATEGORI.Find(id);
                if (k == null)
                {
                    k = new ALT_KATEGORI();
                }
            }
            var kategori = db.KATEGORIs.ToList();
            ViewData["kategori"] = kategori;

            return View(k);
        }

        [HttpPost]
        public ActionResult KayitFormu(ALT_KATEGORI k)
        {
            if (ModelState.IsValid)
            {
                if (k.ALT_KATEGORI_ID == 0) //yeni
                {
                    db.ALT_KATEGORI.Add(k);
                }
                else //eski
                {

                    db.Entry(k).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                var kategori = db.KATEGORIs.ToList();
                ViewData["kategori"] = kategori;
                               
                return View(k);
            }

        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", "AltKategoriListe", new { ara = txtAra }); //?ara=s
        }
    }
}