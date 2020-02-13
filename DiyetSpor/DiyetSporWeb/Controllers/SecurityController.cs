using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DiyetSporWeb.Models;

namespace DiyetSporWeb.Controllers
{
    public class SecurityController : Controller
    {
        dbdiyetsporEntities db = new dbdiyetsporEntities();
        // GET: Security
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous] 
        public ActionResult Login(loginModel kullanici)/*Entitden kullanıcı alıp kontrol edicez*/
        {

            var kullaniciInDb = db.tblKullanici.FirstOrDefault(x=>x.kullaniciEmail == kullanici.kullaniciEmail && x.kullaniciSifre==kullanici.kullaniciSifre) ;
            if(kullaniciInDb != null)
            {
                FormsAuthentication.SetAuthCookie(Convert.ToString(kullaniciInDb.kullaniciid),false);
                if (kullaniciInDb.kullaniciTipi == "U")
                {
                    return RedirectToAction("Index", "Uye");
                }
                else if (kullaniciInDb.kullaniciTipi=="A")
                {
                    return RedirectToAction("Index","Admin");
                }
                else if (kullaniciInDb.kullaniciTipi == "D")
                {
                    return RedirectToAction("Index", "DanismanDiyet");
                }
                else if (kullaniciInDb.kullaniciTipi == "S")
                {
                    return RedirectToAction("Index","DanismanSpor");
                }
                else
                {
                    return RedirectToAction("Index","Hata");
                } 
            }
            else
            {
                ViewBag.hatamesaji = "Hatalı Giriş Denemesi";
                return View();
            }
        }
        

        public ActionResult Singout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SingUp() // KAYIT OL GET
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SingUp(kullaniciKayitModel yeniuye)
        {
            if (!ModelState.IsValid)
            {
                return View("SingUp");
            }
            var kullanici = new tblKullanici();
            kullanici.kullaniciAd = yeniuye.kullaniciAd;
            kullanici.kullaniciSoyad = yeniuye.kullaniciSoyad;
            kullanici.kullaniciTc = yeniuye.kullaniciTc;
            kullanici.kullaniciCinsiyet = yeniuye.kullaniciCinsiyet;
            kullanici.kullaniciDogumTarihi = Convert.ToDateTime(yeniuye.kullaniciDogumTarihi);
            kullanici.kullaniciEmail = yeniuye.kullaniciEmail;
            kullanici.kullaniciSifre =Convert.ToInt32( yeniuye.kullaniciSifre);
            kullanici.kullaniciTelefon = yeniuye.kullaniciTelefon;
            kullanici.kullaniciTipi = yeniuye.kullaniciTipi;
            kullanici.kullaniciKayitTarihi = Convert.ToDateTime( DateTime.Now);
            kullanici.kullaniciHesapAKtiflik = true;
            if(yeniuye.kullaniciTipi != "U")
            {
                kullanici.kullaniciPuan = 0;
                kullanici.kullaniciDanismanDurum = false;
            }
            db.tblKullanici.Add(kullanici);
            db.SaveChanges();
            if (yeniuye.kullaniciTipi !="U")
            {
                //YENİ TALEP OLUŞTUR
                talep talepnesne = new talep();
                talepnesne.danismantalepolustur(yeniuye.kullaniciTc);           
            }
           
            return RedirectToAction("Index","Home");
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult SingUp( int i ,string musteriTip /* müsteri model nesnesi gelecek*/) //KAYIT OL POST
        //{
        //    // müşteri kaydet
        //    return View();
        //}
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ForgotPassword(int id) //GELECEK VERiYE DİKKAT
        {
            return View();
          
        }
    }
}