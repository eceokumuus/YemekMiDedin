using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje.Models;

namespace proje.Admin
{
    [Authorize]
    public class KategoriListeController : Controller
    {
        int aktifsayfa = 0;
        int toplamsayfa = 0;
        int sayfadakisatir = 5;
        int toplamkayit = 0;

        Model1 db = new Model1();
        // GET: KategoriListe

        public ActionResult Index(int sayfa = 0)
        {
            var liste = db.KATEGORIs.ToList();

            if (Request["ara"] != null)
            {
                var txtAra = Request["ara"];
                liste = db.KATEGORIs.Where(k => k.KATEGORI_ADI.Contains(txtAra)).ToList();
            }
            else
            {
                liste = db.KATEGORIs.ToList();
            }

            List<MEKAN> mekanlar = db.MEKANs.ToList();
            ViewData["mekanlar"] = mekanlar;

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
            var k = db.KATEGORIs.Find(id);
            db.KATEGORIs.Remove(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KayitFormu(int? id)
        {
            KATEGORI k = new KATEGORI();
            if (id != null)
            {
                k = db.KATEGORIs.Find(id);
                if (k == null)
                {
                    k = new KATEGORI();
                }
            }
            return View(k);
        }

        [HttpPost]
        public ActionResult KayitFormu(KATEGORI k)
        {
            if (k.KATEGORI_ID == 0) //yeni
            {
                db.KATEGORIs.Add(k);
            }
            else //eski
            {
                db.Entry(k).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", "KategoriListe", new { ara = txtAra }); //?ara=s
        }
    }
}