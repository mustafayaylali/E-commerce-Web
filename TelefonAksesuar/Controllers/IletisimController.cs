using System;
using System.Globalization;
using System.Threading;
using System.Web.Helpers;
using System.Web.Mvc;

namespace TelefonAksesuar.Controllers
{
    public class IletisimController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Gonder(string isim, string email, string telefon,string mesaj)
        {
            try
            {
                WebMail.SmtpServer = "smtp.live.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "mustafayaylali_@hotmail.com";
                WebMail.Password = "199567"; // 
                WebMail.SmtpPort = 587;
                WebMail.Send(
                        "b140910051@sakarya.edu.tr",
                        isim,
                        email,
                        telefon,
                        mesaj
                    );

                return RedirectToAction("Gonderildi");
            }
            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("_HATA", ex.Message);
            }

            return View("Index");
        }
        public string Gonderildi()
        {
            return "Mesajınız başarıyla gönderildi";
        }

    }
}
