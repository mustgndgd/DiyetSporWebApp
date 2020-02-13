using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiyetSporWeb.Controllers
{ 
    [AllowAnonymous]
    public class DanismanController : Controller
    {
        // GET: Danisman
        public ActionResult Index()
        {
            return View();
        }
        [Authorize (Roles ="D")]
        public ActionResult TestPage()
        {
            return View();
        }

        public ActionResult DenemeMinikKartlar()
        {
            return View();
        }
        public ActionResult DenemeGrafikler()
        {
            return View();
        }
        public ActionResult DenemeButonGeriKalanlar()
        {
            return View();
        }

    }
}