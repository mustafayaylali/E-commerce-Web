using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonAksesuar.Models;

namespace TelefonAksesuar.Controllers
{
    public class UrunDuzenleController : Controller
    {
        private TelefonAksesuarEntities db = new TelefonAksesuarEntities();

        // GET: UrunDuzenle
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
                return View(db.Urunler.ToList());
            }
        }



        // GET: UrunDuzenle/Edit/5
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
                Urunler urunler = db.Urunler.Find(id);
                if (urunler == null)
                {
                    return HttpNotFound();
                }
                return View(urunler);
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "UrunID,Kategori,Marka,Model,Fiyat,Stok,Resim")] Urunler urunler)
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

                    db.Entry(urunler).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(urunler);
            }
        }

        // GET: UrunDuzenle/Delete/5
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
                Urunler urunler = db.Urunler.Find(id);
                if (urunler == null)
                {
                    return HttpNotFound();
                }
                return View(urunler);
            }
        }

        // POST: UrunDuzenle/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int a = 0;                  // SİLİNEN ÜYENİN SEPETİNİ TEMİZLER
            do
            {
                Yorumlar item = db.Yorumlar.FirstOrDefault(i => i.UrunID == id);
                a = 1;
                if (item != null)
                {
                    a = 0;
                    db.Yorumlar.Remove(item);
                    db.SaveChanges();
                }
            } while (a == 0);


            Urunler urunler = db.Urunler.Find(id);
            db.Urunler.Remove(urunler);
            System.IO.File.Delete(Server.MapPath("~/Images/Urunler/"+urunler.Resim));
            db.SaveChanges();
            return RedirectToAction("Index");
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
