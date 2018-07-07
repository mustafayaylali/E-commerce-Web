using System.Linq;
using System.Web.Mvc;
using TelefonAksesuar.Models;

namespace TelefonAksesuar.Controllers
{
    
    
    public class SepetController : Controller
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
                var sepettekiler = db.Sepetim.ToList();
                return View(sepettekiler);
            }
           
        }

        public ActionResult Sil(int? no,int? id)
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
                if (no != null)             // sepetten sadece o ürünü kaldır Sİpariş NO suna göre
                {
                    Sepetim urun = db.Sepetim.Find(no);
                    db.Sepetim.Remove(urun);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if(id!=null)           //Tüm sepeti temizle o idye ait
                {
                    
                    int a = 0;
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
                   
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");

        }
        
        
    }
}
