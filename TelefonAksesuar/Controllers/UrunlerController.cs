using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using TelefonAksesuar.Models;

namespace TelefonAksesuar.Controllers
{


    public class UrunlerController : Controller
    {
        private TelefonAksesuarEntities db = new TelefonAksesuarEntities();

        public ActionResult Index(string arama)
        {
            //arama

            var urunler = from s in db.Urunler select s;
            if(!String.IsNullOrEmpty(arama))
            {
                urunler = urunler.Where(s => s.Marka.ToUpper().Contains(arama.ToUpper()) || s.Kategori.ToUpper().Contains(arama.ToUpper())
                                            || s.Model.ToUpper().Contains(arama.ToUpper()) || (s.Marka+" "+s.Model).ToUpper().Contains(arama.ToUpper()) );
            }
            //          

            ViewData["arananKelime"] = arama;
            return View(urunler.ToList());
        }

        public ActionResult SarjCihazlari()
        {
            var SarjCihazlari = db.Urunler.ToList();
            return View(SarjCihazlari);
        }

        public ActionResult Kulakliklar()
        {

            var Kulakliklar = db.Urunler.ToList();
            return View(Kulakliklar);
        }

        public ActionResult Kiliflar()
        {
            var Kiliflar = db.Urunler.ToList();
            return View(Kiliflar);
        }

        public ActionResult UrunDetay(int id)
        {
            ViewBag.urunID = id;
            ViewBag.Urunler = db.Urunler.ToList();

            ViewBag.Yorumlar = db.Yorumlar.ToList();

           
            return View();
        }
        public ActionResult YorumEkle(int urunID,string kadi,string tarih,Yorumlar model)
        {
            if (ModelState.IsValid) // formdaki kontroller istenilen şekildeyse ( Required vs gibi)
            {
                TelefonAksesuar.Models.TelefonAksesuarEntities db = new Models.TelefonAksesuarEntities();
                Yorumlar yorumModel = new Yorumlar();                      //KAYIT İŞLEMİ      Postla alınanlar ekleniyor
                yorumModel.UrunID = urunID;
                yorumModel.KullaniciAdi = kadi;
                yorumModel.YorumTarih = tarih;
                yorumModel.Yorum = model.Yorum;

                db.Yorumlar.Add(yorumModel);

                db.SaveChanges();
            }

                return RedirectToAction("UrunDetay",new { id = urunID });
        }
        public ActionResult SepeteEkle(int Uyeid, string urunAd, int fiyat)
        {
            TelefonAksesuar.Models.TelefonAksesuarEntities db = new Models.TelefonAksesuarEntities();
            if (Session["yetki"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else if (Session["yetki"].ToString() == "admin")
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                Sepetim sepet = new Sepetim();
                sepet.UyeID = Uyeid;
                sepet.UrunAd = urunAd;
                sepet.Adet = 1;
                sepet.Fiyat = fiyat;
                sepet.ToplamFiyat = sepet.Adet * fiyat;


                db.Sepetim.Add(sepet);
                db.SaveChanges();

                return RedirectToAction("Index", "Sepet");
            }
                   
        }
       
    }
}