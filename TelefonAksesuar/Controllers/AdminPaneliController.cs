using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace TelefonAksesuar.Controllers
{
    public class AdminPaneliController : Controller
    {
        // GET: AdminPanel

        public ActionResult Index()
        {
            if (Session["yetki"] == null)
            {               
                return View("~/Views/Shared/Error.cshtml");
            }
            else if(Session["yetki"].ToString() == "uye")
                {
                    return View("~/Views/Shared/Error.cshtml");
                }
            else
            {
                return View();
            }
        }
    }
}