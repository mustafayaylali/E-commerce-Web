using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TelefonAksesuar.Models;
using TelefonAksesuar.ViewModels;

namespace TelefonAksesuar.Controllers
{
    public class GirisController : Controller
    {
        public ActionResult Index()
        {
            if (Session["yetki"] == null)
            {
                UyeGirisModel model = ModelAl();
                return View(model);
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UyeGirisModel model)
        {
            if(ModelState.IsValid)
            {
                using (TelefonAksesuarEntities db = new TelefonAksesuarEntities())
                {
                    
                    var v = db.Uyeler.Where(m => m.KullaniciAdi.Equals(model.KullaniciAdi) && m.Sifre.Equals(model.Sifre)).FirstOrDefault();
                    
                    if(v !=null)
                    {
                        Session["id"] = v.UyeID;
                        Session["ad"] = v.Ad.ToString();
                        Session["kadi"] = v.KullaniciAdi.ToString();
                        Session["adres"] = v.Adres.ToString();
                        Session["yetki"] = v.Yetki.ToString();

                        var ss = db.Sepetim.Count(x => x.UyeID == v.UyeID);
                        Session["sepet"] = ss;

                        if(model.Hatirla==true)
                        {
                            HttpCookie cerez = new HttpCookie("cerez");
                            cerez.Values.Add("kadi", v.KullaniciAdi.ToString());
                            cerez.Values.Add("sifre", v.Sifre.ToString());
                            cerez.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(cerez);
                        }
                        else
                        {
                            Response.Cookies["cerez"].Expires = DateTime.Now.AddDays(-1);
                        }

                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        //MODELİ YENİLİYORUZ EKRANDA MESAJI GÖSTERMEK İÇİN
                        ModelState.Clear();
                        model = ModelAl();
                        model.KullaniciyaMesaj = "Kullanıcı adı veya şifre hatalı!";
                    }
                }
            }
            else
            {
                //MODELİ YENİLİYORUZ EKRANDA MESAJI GÖSTERMEK İÇİN
                ModelState.Clear();
                model = ModelAl();
                model.KullaniciyaMesaj = "Kullanıcı adı veya şifre hatalı!";
            }
            
            return View(model);
        }
        private UyeGirisModel ModelAl()
        {
            UyeGirisModel model = new UyeGirisModel();
            //Veri tabanı bağlantısı
            TelefonAksesuar.Models.TelefonAksesuarEntities db = new Models.TelefonAksesuarEntities();

            return model;
        }

        public ActionResult Cikis()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Giris");
        }
        
	}
}