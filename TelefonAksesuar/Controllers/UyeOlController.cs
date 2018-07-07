using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using TelefonAksesuar.Models;
using TelefonAksesuar.ViewModels;

namespace TelefonAksesuar.Controllers
{
    public class UyeOlController : Controller
    {
        public ActionResult Index()
        {
            if (Session["yetki"] == null)
            {
                UyeOlModel model = ModelAl();
                return View(model);
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            
        }

        [HttpPost]
        public ActionResult Index(UyeOlModel model) 
        {
            if (ModelState.IsValid) // formdaki kontroller istenilen şekildeyse ( Required vs gibi)
            {
                TelefonAksesuar.Models.TelefonAksesuarEntities db = new Models.TelefonAksesuarEntities();
                Uyeler uyelerModel = new Uyeler();                      //KAYIT İŞLEMİ      Postla alınanlar ekleniyor
                uyelerModel.Ad = model.Ad;
                uyelerModel.Soyad = model.Soyad;
                uyelerModel.EMail = model.Email;
                uyelerModel.KullaniciAdi = model.KullaniciAdi;
                uyelerModel.Sifre = model.Sifre;
                uyelerModel.Yas = model.Yas;
                uyelerModel.Sehir = model.Sehir;
                uyelerModel.Adres = model.Adres;
                uyelerModel.Yetki = "uye";

                db.Uyeler.Add(uyelerModel);

                db.SaveChanges();

                //MODELİ YENİLİYORUZ EKRANDA MESAJI GÖSTERMEK İÇİN
                ModelState.Clear();
                model = ModelAl();
                model.KullaniciyaMesaj = "Üye kaydınız başarıyla gerçekleşti. Sisteme giriş yapabilirsiniz.";
            }
            
            return View(model);
        }

        // oluşturulan modeli view e göndermek için
        private UyeOlModel ModelAl()
        {
            UyeOlModel model = new UyeOlModel();
            //Veri tabanı bağlantısı
            TelefonAksesuar.Models.TelefonAksesuarEntities db = new Models.TelefonAksesuarEntities();

            return model;
        }


	}
}