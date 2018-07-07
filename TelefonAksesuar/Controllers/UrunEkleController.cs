using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TelefonAksesuar.Models;
using TelefonAksesuar.ViewModels;

namespace TelefonAksesuar.Controllers
{
    public class UrunEkleController : Controller
    {
        // GET: UrunEkle

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
                UrunEkleModel model = ModelAl();
                return View(model);
            }

        }

        [HttpPost]
        public ActionResult Ekle(UrunEkleModel Umodel)
        {
            if (ModelState.IsValid) // formdaki kontroller istenilen şekildeyse ( Required vs gibi)
            {
                TelefonAksesuar.Models.TelefonAksesuarEntities db = new Models.TelefonAksesuarEntities();
                Urunler urunModel = new Urunler();                      //KAYIT İŞLEMİ      Postla alınanlar ekleniyor

               
                urunModel.Kategori = Umodel.Kategori;
                urunModel.Marka = Umodel.Marka;
                urunModel.Model = Umodel.Model;
                urunModel.Fiyat = Umodel.Fiyat;            
                urunModel.Stok = Umodel.Stok;

                if(Umodel.Resim !=null && Umodel.Resim.ContentLength>0)
                {
                    Umodel.Resim.SaveAs(Server.MapPath("~/Images/Urunler/" +Umodel.Kategori+ Umodel.Marka+Umodel.Model + Path.GetExtension(Umodel.Resim.FileName))); // MapPath Ana dizine gider
                    urunModel.Resim =Umodel.Kategori+ Umodel.Marka + Umodel.Model + Path.GetExtension(Umodel.Resim.FileName);

                }

                db.Urunler.Add(urunModel);         
                db.SaveChanges();

                //MODELİ YENİLİYORUZ EKRANDA MESAJI GÖSTERMEK İÇİN
                ModelState.Clear();
                Umodel = ModelAl();
                Umodel.AdmineMesaj = "Ürün başarı ile eklendi."; 
            }
                return View(Umodel);
        }

        private UrunEkleModel ModelAl()
        {
            UrunEkleModel Umodel = new UrunEkleModel();

            TelefonAksesuar.Models.TelefonAksesuarEntities db = new Models.TelefonAksesuarEntities();

            return Umodel;
        }
    }
}