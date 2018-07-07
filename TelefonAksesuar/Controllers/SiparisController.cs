using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonAksesuar.Models;

namespace TelefonAksesuar.Controllers
{
    public class SiparisController : Controller
    {
        private TelefonAksesuarEntities db = new TelefonAksesuarEntities();
       
        public ActionResult Index()
        {
            
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
                var siparisler = db.Siparisler.ToList();
                return View(siparisler);
            }
        }
        public ActionResult Ekle(int Uyeid,string Ozet,string Adres,int Fiyat)
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
                Siparisler siparis = new Siparisler();      //Sİpariş tablosuna veriler eklenir

                siparis.SiparisOzet = Ozet;
                siparis.UyeID = Uyeid;
                siparis.Adres = Adres;
                siparis.Fiyat = Fiyat;
                siparis.Durum = "Siparişiniz alındı";
                siparis.Tarih = DateTime.Now.ToString();

               

                db.Siparisler.Add(siparis);
                db.SaveChanges();


                int a = 0;      // Sipariş verirken Sepet temizlenir
                do
                {
                    Sepetim item = db.Sepetim.FirstOrDefault(i => i.UyeID == Uyeid);
                    a = 1;
                    if (item != null)
                    {
                        a = 0;
                        db.Sepetim.Remove(item);
                        db.SaveChanges();
                    }
                } while (a == 0);

                Session["sepet"] = 0;

                return RedirectToAction("Index");
            }

        }
    }
}