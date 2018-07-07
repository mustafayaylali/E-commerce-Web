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
    public class ProfilController : Controller
    {
        private TelefonAksesuarEntities db = new TelefonAksesuarEntities();

        // GET: Profil
        public ActionResult Index()
        {
            if (Session["yetki"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }        
            else
            {
                return View(db.Uyeler.ToList());
            }
           
        }


        // GET: Profil/Edit/5
        public ActionResult Duzenle(int? id)
        {
            if (Session["yetki"] == null)
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

        // POST: Profil/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "UyeID,Ad,Soyad,EMail,KullaniciAdi,Sifre,Yas,Sehir,Adres,Yetki")] Uyeler uyeler)
        {
            if (Session["yetki"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }      
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(uyeler).State = EntityState.Modified;
                    db.SaveChanges();
                    Session["adres"] = uyeler.Adres;
                    Session["ad"] = uyeler.Ad;
                    Session["kadi"] = uyeler.KullaniciAdi;
                    return RedirectToAction("Index");
                }
                return View(uyeler);
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
