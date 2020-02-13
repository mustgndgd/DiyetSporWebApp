using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiyetSporWeb.Controllers
{
    public class HataController : Controller
    {
        [AllowAnonymous]
        // GET: Hata
        public ActionResult NotFound()
        {
            return View();
        }
    }
}