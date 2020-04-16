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

    public class GaleriController : Controller
    {
        int aktifsayfa = 0;
        int toplamsayfa = 0;
        int sayfadakisatir = 5;
        int toplamkayit = 0;

        Model1 db = new Model1();
        // GET: Galeri
        public ActionResult Index(int sayfa = 0)
        {
            var liste = new List<GALERI>();
            if (Request["ara"] != null)
            {
                var txtAra = Request["ara"].ToString();
                liste = db.GALERIs.Where(e => e.BASLIK.Contains(txtAra)).ToList();
            }
            else
            {
                liste = db.GALERIs.ToList();
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
                var galeri = db.GALERIs.Find(id);
                if (galeri != null)
                {
                    db.GALERIs.Remove(galeri);
               
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult KayitFormu(int? id)
        {
            GALERI galeri = new GALERI();
            if (id != null)
            {
                galeri = db.GALERIs.Find(id);

                if (galeri == null)
                {
                    galeri = new GALERI();
                } 
            }

            var mekan = db.MEKANs.ToList();
            ViewData["mekan"] = mekan;

            return View(galeri);
        }

        [HttpPost]

        public ActionResult KayitFormu(HttpPostedFileBase resim,GALERI galeri)
        {
            if (ModelState.IsValid)
            {
                if (galeri.GALERI_ID == 0)//YENİ
                {
                    db.GALERIs.Add(galeri);

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
                    try
                    {
                        string path = string.Empty;
                        string fileName = Path.GetFileName(resim.FileName);
                        path = Path.Combine(Server.MapPath("~/Image"), fileName);
                        resim.SaveAs(path);
                        galeri.RESIM = fileName;

                    }
                    catch (Exception)
                    {

                        
                    }
                    
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