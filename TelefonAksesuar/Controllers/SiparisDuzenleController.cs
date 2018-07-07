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
    public class SiparisDuzenleController : Controller
    {
        private TelefonAksesuarEntities db = new TelefonAksesuarEntities();

        // GET: SiparisDuzenle
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
                var siparisler = db.Siparisler.Include(s => s.Uyeler);
                return View(siparisler.ToList());
            }
        }

       

        // GET: SiparisDuzenle/Edit/5
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
                Siparisler siparisler = db.Siparisler.Find(id);
                if (siparisler == null)
                {
                    return HttpNotFound();
                }
                ViewBag.UyeID = new SelectList(db.Uyeler, "UyeID", "Ad", siparisler.UyeID);
                return View(siparisler);
            }
        }

        // POST: SiparisDuzenle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "SiparisID,SiparisOzet,UyeID,Tarih,Adres,Durum,Fiyat")] Siparisler siparisler)
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
                    db.Entry(siparisler).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.UyeID = new SelectList(db.Uyeler, "UyeID", "Ad", siparisler.UyeID);
                return View(siparisler);
            }
        }

        // GET: SiparisDuzenle/Delete/5
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
                Siparisler siparisler = db.Siparisler.Find(id);
                if (siparisler == null)
                {
                    return HttpNotFound();
                }
                return View(siparisler);
            }
        }

        // POST: SiparisDuzenle/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
                Siparisler siparisler = db.Siparisler.Find(id);
                db.Siparisler.Remove(siparisler);
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
