using DiyetSporWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiyetSporWeb.Controllers
{
    [AllowAnonymous]
    public class UyeController : Controller
    {
        dbdiyetsporEntities db = new dbdiyetsporEntities();
        // GET: Uye
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UyeDanismanListele()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Blog()
        {
            var blog = db.tblBlog.Where(x => x.blogAktiflik == true).ToList();
            return View(blog);
        }

        [HttpGet]
        public ActionResult Bilgilerim()
        {
            int? id = Convert.ToInt32(HttpContext.User.Identity.Name);
            var kullanici = db.tblKullanici.Find(id);
            return View(kullanici);
        }
        [HttpGet]
        public ActionResult UyeBilgiGetir()
        {
            int? id = Convert.ToInt32(HttpContext.User.Identity.Name);
            var kullanici = db.tblKullanici.Find(id);
            return View(kullanici);
        }
        [HttpPost]
        public ActionResult UyeBilgiGuncelle(tblKullanici k)
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
        public ActionResult DanismanTalebindeBulun()
        {
            List<uyeDanismanTalepModel> danismanlar = new List<uyeDanismanTalepModel>();
            //AKTİF OLAN DANIŞMANLARI AL BİLGİLERİNİ ATA VE VİEW E TAŞI
            var kullanicilar = db.tblKullanici.Where(x => x.kullaniciTipi == "D" || x.kullaniciTipi == "S").ToList(); 
            foreach (var k in kullanicilar)
            {
                uyeDanismanTalepModel u = new uyeDanismanTalepModel();
                u.kullaniciAd = k.kullaniciAd;
                u.kullaniciSoyad = k.kullaniciSoyad;
                u.kullaniciid = k.kullaniciid;
                u.kullaniciTipi = k.kullaniciTipi;
                
                danismanlar.Add(u);
            }
            return View(danismanlar);
        }
        [HttpGet]
        public ActionResult UyeDanismanBasvur(int id)
        {
            int uyeid = Convert.ToInt32(HttpContext.User.Identity.Name);
            tblTalep talep = new tblTalep();
            talep.talepEden = uyeid;
            talep.talepEdilenDanisman = id;
            talep.talepDurum = false;
            talep.talepTarihi = Convert.ToDateTime(DateTime.Now);
            var danisman = db.tblKullanici.Find(id);
            if (danisman.kullaniciTipi == "D")
            {
                talep.talepTip = "DİYET";
            }
            else
            {
                talep.talepTip = "ANTREMAN";
            }
            db.tblTalep.Add(talep);
            db.SaveChanges();
            //TALEP OLUŞTURULDU
            return RedirectToAction("Index");
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