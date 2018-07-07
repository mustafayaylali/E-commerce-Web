using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonAksesuar.Models;

namespace TelefonAksesuar.Controllers
{
    public class UyeDuzenleController : Controller
    {
        private TelefonAksesuarEntities db = new TelefonAksesuarEntities();

        // GET: UyeDuzenle
        public ActionResult Index()
        {            
            if (Session["yetki"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else if (Session["yetki"].ToString() == "uye")
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                return View(db.Uyeler.ToList());
            }

        }


        public ActionResult Ekle()
        {
            if (Session["yetki"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else if (Session["yetki"].ToString() == "uye")
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                return View();
            }
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "UyeID,Ad,Soyad,EMail,KullaniciAdi,Sifre,Yas,Sehir,Adres,Yetki")] Uyeler uyeler)
        {
            if (Session["yetki"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else if (Session["yetki"].ToString() == "uye")
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Uyeler.Add(uyeler);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(uyeler);
            }
        }

        
        public ActionResult Duzenle(int? id)
        {
            if (Session["yetki"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else if (Session["yetki"].ToString() == "uye")
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Uyeler uyeler = db.Uyeler.Find(id);
                if (uyeler == null)
                {
                    return HttpNotFound();
                }
                return View(uyeler);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "UyeID,Ad,Soyad,EMail,KullaniciAdi,Sifre,Yas,Sehir,Adres,Yetki")] Uyeler uyeler)
        {
            if (Session["yetki"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else if (Session["yetki"].ToString() == "uye")
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(uyeler).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(uyeler);
            }
        }

       
        public ActionResult Sil(int? id)
        {
            if (Session["yetki"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else if (Session["yetki"].ToString() == "uye")
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Uyeler uyeler = db.Uyeler.Find(id);
                if (uyeler == null)
                {
                    return HttpNotFound();
                }
                return View(uyeler);
            }
        }

       
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult SilConfirmed(int id)
        {
            if (Session["yetki"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else if (Session["yetki"].ToString() == "uye")
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                
                int a = 0;                  // SİLİNEN ÜYENİN SEPETİNİ TEMİZLER
                do
                {
                    Sepetim item = db.Sepetim.FirstOrDefault(i => i.UyeID == id);
                    a = 1;
                    if (item != null)
                    {
                        a = 0;
                        db.Sepetim.Remove(item);
                        db.SaveChanges();
                    }
                } while (a == 0);

                int b = 0;                  // SİLİNEN ÜYENİN SİPARİŞLERİNİ TEMİZLER
                do
                {
                    Siparisler siparis = db.Siparisler.FirstOrDefault(i => i.UyeID == id);
                    b = 1;
                    if (siparis != null)
                    {
                        b = 0;
                        db.Siparisler.Remove(siparis);
                        db.SaveChanges();
                    }
                } while (b == 0);

                
                Uyeler uyeler = db.Uyeler.Find(id);     // ÜYEYİ SİLER
                db.Uyeler.Remove(uyeler);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
