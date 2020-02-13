using DiyetSporWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DiyetSporWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        dbdiyetsporEntities db = new dbdiyetsporEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var x = HttpContext.User.Identity.IsAuthenticated; 
            if(x ==true)       
            {
                var kullaniciInDb = db.tblKullanici.Find(Convert.ToInt32( HttpContext.User.Identity.Name));

                if (kullaniciInDb.kullaniciTipi == "U")
                {
                    return RedirectToAction("Index", "Uye");
                }
                else if (kullaniciInDb.kullaniciTipi == "A")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (kullaniciInDb.kullaniciTipi == "D")
                {
                    return RedirectToAction("Index", "DanismanDiyet");
                }
                else if (kullaniciInDb.kullaniciTipi == "S")
                {
                    return RedirectToAction("Index", "DanismanSpor");
                }
                else
                {
                    return RedirectToAction("Index", "Hata");
                }
            }
            else
            {
                return View();
            }
        }



        

     
    }
}