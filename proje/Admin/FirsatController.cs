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

    public class FirsatController : Controller
    {
        int aktifsayfa = 0;
        int toplamsayfa = 0;
        int sayfadakisatir = 5;
        int toplamkayit = 0;

        Model1 db = new Model1();
        // GET: Firsat
        public ActionResult Index(int sayfa=0)
        {
            var firsat = new List<FIRSAT>();

            if (Request["ara"] != null)
            {
                var kelime = Request["ara"].ToString();
                firsat = db.FIRSATs.Where(e => e.FIRSAT_ADI.Contains(kelime)).ToList();
            }
            else
            {
                firsat = db.FIRSATs.ToList();
            }
            List<MEKAN> mekanlar= db.MEKANs.ToList();
            ViewData["mekanlar"] = mekanlar;

            aktifsayfa = sayfa;
            toplamkayit = firsat.Count();
            //sayfalama yapılıyor
            firsat = firsat.Skip(sayfa * sayfadakisatir).Take(sayfadakisatir).ToList();

            toplamsayfa = toplamkayit / sayfadakisatir;
            if (toplamkayit % sayfadakisatir != 0) toplamsayfa++;

            ViewData["sayfa"] = sayfa;
            ViewData["toplamsayfa"] = toplamsayfa;
            ViewData["toplamkayit"] = toplamkayit;

            return View(firsat);
        }

        public ActionResult Sil(int? id)
        {
            if (id != null)
            {
                var firsat = db.FIRSATs.Find(id);
                if (firsat != null)
                {
                    db.FIRSATs.Remove(firsat);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult KayitFormu(int? id)
        {
            FIRSAT firsat = new FIRSAT();
            if (id != null)
            {
                firsat = db.FIRSATs.Find(id);
                if (firsat == null)
                {
                    firsat = new FIRSAT();
                }
            }
            var mekan = db.MEKANs.ToList();
            ViewData["mekan"] = mekan;

            return View(firsat);
        }


        [HttpPost]
        public ActionResult KayitFormu(FIRSAT firsat)
        {
            if (ModelState.IsValid)
            {
                if (firsat.FIRSAT_ID == 0)
                {
                    db.FIRSATs.Add(firsat);
                }
                else
                {
                    db.Entry(firsat).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var mekan = db.MEKANs.ToList();
                ViewData["mekan"] = mekan;

                return View(firsat);
            }
        }

        public ActionResult Ara(string txtAra)
        {
            return RedirectToAction("Index", new { ara = txtAra });
        }
    }
}