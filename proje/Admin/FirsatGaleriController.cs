using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje.Models;

namespace proje.Admin
{
    [Authorize]

    public class FirsatGaleriController : Controller
    {
        int aktifsayfa = 0;
        int toplamsayfa = 0;
        int sayfadakisatir = 5;
        int toplamkayit = 0;

        Model1 db = new Model1();
        // GET: Galeri
        public ActionResult Index(int sayfa = 0)
        {
            var liste = new List<FIRSAT_GALERI>();
            if (Request["ara"] != null)
            {
                var txtAra = Request["ara"].ToString();
                liste = db.FIRSAT_GALERI.Where(e => e.BASLIK.Contains(txtAra)).ToList();
            }
            else
            {
                liste = db.FIRSAT_GALERI.ToList();
            }
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

        public ActionResult Sil(int? id)  /*?=null olabilir integer*/
        {
            if (id != null)
            {
                var galeri = db.FIRSAT_GALERI.Find(id);
                if (galeri != null)
                {
                    db.FIRSAT_GALERI.Remove(galeri);

                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult KayitFormu(int? id)
        {
            FIRSAT_GALERI galeri = new FIRSAT_GALERI();
            if (id != null)
            {
                galeri = db.FIRSAT_GALERI.Find(id);

                if (galeri == null)
                {
                    galeri = new FIRSAT_GALERI();
                }
            }

            var mekan = db.MEKANs.ToList();
            ViewData["mekan"] = mekan;

            return View(galeri);
        }

        [HttpPost]

        public ActionResult KayitFormu(HttpPostedFileBase resim, FIRSAT_GALERI galeri)
        {
            if (ModelState.IsValid)
            {
                if (galeri.FIRSAT_GALERI_ID == 0)//YENİ
                {
                    db.FIRSAT_GALERI.Add(galeri);

                    string path = string.Empty;
                    string fileName = Path.GetFileName(resim.FileName);
                    path = Path.Combine(Server.MapPath("~/Image"), fileName);
                    resim.SaveAs(path);
                    var path2 = Server.MapPath("~/Image/test.jpg");
                    //TempData["resimcekildimi"] = true;
                    galeri.RESIM = fileName;

                }
                else//ESKİ
                {

                    string path = string.Empty;
                    string fileName = Path.GetFileName(resim.FileName);
                    path = Path.Combine(Server.MapPath("~/Image"), fileName);
                    resim.SaveAs(path);
                    galeri.RESIM = fileName;
                    db.Entry(galeri).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                var mekan = db.MEKANs.ToList();
                ViewData["mekan"] = mekan;

                return View(galeri);

            }

        }


        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }
    }
}