using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiyetSporWeb.Models;
namespace DiyetSporWeb.Controllers
{  
    [AllowAnonymous]
    public class DanismanDiyetController : Controller
    {
        dbdiyetsporEntities db = new dbdiyetsporEntities();
        // GET: DanismanDiyet
        public ActionResult Index()
        {
           // HttpContext.User.Identity.Name; string şekilde geliyo int e çevir
            return View();
        }
        [HttpGet]
        public ActionResult Blog()
        {
            var blog = db.tblBlog.Where(x => x.blogAktiflik == true).ToList();
            ViewBag.id = Convert.ToInt32(HttpContext.User.Identity.Name);
            return View(blog);
        }
        [HttpGet]
        public ActionResult BlogYaz()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogYaz(tblBlog b)
        {
            b.blogAktiflik = false;
            b.blogPuan = 0;
            b.kullaniciid = Convert.ToInt32(HttpContext.User.Identity.Name);
            db.tblBlog.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BlogAktiflik (int id)
        {
            var blog = db.tblBlog.Find(id);
            blog.blogAktiflik = false;
            db.SaveChanges();
            return RedirectToAction("Blog");
        }


        [HttpGet]
        public ActionResult Bilgilerim()
        {
            int? id = Convert.ToInt32(HttpContext.User.Identity.Name);
            var kullanici = db.tblKullanici.Find(id);
            return View(kullanici);
        }
        [HttpGet]
        public ActionResult DiyetBilgiGetir()
        {
            int? id = Convert.ToInt32(HttpContext.User.Identity.Name);
            var kullanici = db.tblKullanici.Find(id);
            return View(kullanici);
        }
        [HttpPost]
        public ActionResult DiyetBilgiGuncelle(tblKullanici k)
        {
            int? id = Convert.ToInt32(HttpContext.User.Identity.Name);
            var kullanici = db.tblKullanici.Find(id);
            kullanici.kullaniciAd = k.kullaniciAd;
            kullanici.kullaniciSoyad = k.kullaniciSoyad;
            kullanici.kullaniciTelefon = k.kullaniciTelefon;
            kullanici.kullaniciEmail = k.kullaniciEmail;
            kullanici.kullaniciSifre = k.kullaniciSifre;
            db.SaveChanges();
            return RedirectToAction("Bilgilerim");
        }



        [HttpGet]
        public ActionResult DiyetUyeGoruntule( )
        {
            List<danismanUyeGoruntulemeModel> uyeler = new List<danismanUyeGoruntulemeModel>();
            int danismanid = Convert.ToInt32(HttpContext.User.Identity.Name);
            var diyetler = db.tblDiyet.Where(x => x.diyetistenid == danismanid).ToList();
            foreach (var x in diyetler)
            {
                tblKullanici k = new tblKullanici();
                danismanUyeGoruntulemeModel testk = new danismanUyeGoruntulemeModel();
                k = db.tblKullanici.Find(x.kullaniciid);
                testk.basvuruTarihi =Convert.ToDateTime( x.diyetBaslamTarihi);
                testk.kullaniciAd = k.kullaniciAd;
                testk.kullaniciSoyad = k.kullaniciSoyad;
                testk.kullaniciEmail = k.kullaniciEmail;
                uyeler.Add(testk);
            }
               return View(uyeler);
        }
        [HttpGet]
         public ActionResult DiyetUyeTalepListele()
         {
            int? id = Convert.ToInt32(HttpContext.User.Identity.Name);
            var diyettalep = db.tblTalep.Where(x => x.talepEdilenDanisman == id ).ToList();
            List<admintalepmodel> modelliste = new List<admintalepmodel>();
            foreach (var x in diyettalep)
            {
                admintalepmodel a = new admintalepmodel();
                a.talepEdenAd = db.tblKullanici.Find(x.talepEden).kullaniciAd + " " + db.tblKullanici.Find(x.talepEden).kullaniciSoyad;
                a.talepEden = x.talepEden;
                a.talepTarihi = Convert.ToDateTime(x.talepTarihi);                
                a.talepid = x.talepid;
                a.talepEdilenDanismanAd = db.tblKullanici.Find(x.talepEden).kullaniciAd + " " + db.tblKullanici.Find(x.talepEden).kullaniciSoyad;
                a.talepEdilenDanisman = x.talepEdilenDanisman;
                a.talepTip = x.talepTip;
                
                if (x.talepDurum == true)
                    a.talepDurum = true;
                else
                    a.talepDurum = false;

                modelliste.Add(a);
            }
            return View(modelliste);
         }
        [HttpGet]
        public ActionResult TalepAktifEt(int? id)
        {
            tblTalep talep = db.tblTalep.Find(id);
            talep.talepDurum = true;
            db.SaveChanges();
            return RedirectToAction("DiyetUyeTalepListele/"+ talep.talepEdilenDanisman);
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