using DiyetSporWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace DiyetSporWeb.Controllers
{

    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        dbdiyetsporEntities db = new dbdiyetsporEntities();
        public ActionResult Index()//ADMİN ANA SAYFASI
        {
            adminindexmodel i = new adminindexmodel();
            i.antremansayisi = 0; 
            i.blogsayisi = 0; 
            i.diyetsayisi= 0;
            var bloglar = db.tblBlog.Where(x=>x.blogAktiflik==true).ToList();
            foreach (var a in bloglar)
            {
                i.blogsayisi++;
            }
            var diyetler = db.tblDiyet.Where(x=>x.diyetAktiflik==true).ToList();
            foreach (var x in diyetler)
            {
                i.diyetsayisi++;
            }
            var antremanlar = db.tblAntreman.Where(x => x.antremanAktiflik == true).ToList();
            foreach (var asd in antremanlar)
            {
                i.antremansayisi++;
            }
            
            return View(i);
        }

        [HttpGet]
        public ActionResult UyeListele() //UYELERİ LİSTELEME
        {
            var uyeler = db.tblKullanici.Where(x => x.kullaniciTipi == "U").ToList();
            return View(uyeler);
        }
        [HttpGet]
        public ActionResult DanismanListele()//DANIŞMAN LİSTELEME 
        {
            var danismanlar = db.tblKullanici.Where(x => x.kullaniciTipi == "D" || x.kullaniciTipi == "S").ToList();
            return View(danismanlar);
        }

        [HttpGet]
        public ActionResult Blog()
        {
            var blog = db.tblBlog.ToList();
            return View(blog);
        }
        public ActionResult BlogAktiflik(int id)
        {
            var blog = db.tblBlog.Find(id);
            blog.blogAktiflik = !(blog.blogAktiflik);
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
        public ActionResult AdminBilgiGetir()
        {
            int? id = Convert.ToInt32(HttpContext.User.Identity.Name);
            var kullanici = db.tblKullanici.Find(id);
            return View(kullanici);
        }
        [HttpPost]
        public ActionResult AdminBilgiGuncelle(tblKullanici k)
        {
            int? id = Convert.ToInt32(HttpContext.User.Identity.Name);
            var kullanici = db.tblKullanici.Find(id);
            kullanici.kullaniciEmail = k.kullaniciEmail;
            kullanici.kullaniciSifre = k.kullaniciSifre;
            db.SaveChanges();
            return RedirectToAction("Bilgilerim");
        }

        public ActionResult UyeGoruntule(int id) //UYE BİLGİ GÖRÜNTÜLEME
        {
            var uye = db.tblKullanici.Find(id);
            return View(uye);
        }

        public ActionResult DanismanGoruntule(int id) //DANIŞMAN BİLGİ GÖRUNTULEME
        {
            var danisman = db.tblKullanici.Find(id);
            return View(danisman);
        }


        [HttpGet]
        public ActionResult DanismanAktiflik(int id)//DANIŞMAN SİLME AKTİF ETME
        {
            var danisman = db.tblKullanici.Find(id);
            if (danisman.kullaniciHesapAKtiflik == true)
            {
                danisman.kullaniciHesapAKtiflik = false;
            }
            else
            {
                danisman.kullaniciHesapAKtiflik = true;
            }
            db.SaveChanges();
            return RedirectToAction("DanismanListele");
        }


        [HttpGet]

        public ActionResult UyeAktiflik(int id)// UYE SİLME AKTİF ETME
        {
            var uye = db.tblKullanici.Find(id);
            if (uye.kullaniciHesapAKtiflik == true)
            {
                uye.kullaniciHesapAKtiflik = false;
            }
            else
            {
                uye.kullaniciHesapAKtiflik = true;
            }
            db.SaveChanges();
            return RedirectToAction("UyeListele");
        }

        [HttpGet]
        public ActionResult DanismanOnayEkrani()//DANIŞMAN ONAYI BEKLEYEN DANIŞMANLARIN LİSTELENMESİ
        {
            var onayBekleyenDanisman = db.tblKullanici.Where(x => x.kullaniciDanismanDurum == false).ToList();
            return View(onayBekleyenDanisman);
        }
        [HttpGet]
        public ActionResult DanismanOnayla(int id)//DANIŞMAN ONAYI
        {
            var danisman = db.tblKullanici.Find(id);
            danisman.kullaniciDanismanDurum = true;
            db.SaveChanges();
            return RedirectToAction("DanismanOnayEkrani");
        }


        public ActionResult TalepAkisListeleme()
        {
            var talepler = db.tblTalep.Where(x => x.talepTip == "DİYET" || x.talepTip == "ANTREMAN").ToList();
            List<admintalepmodel> admintalep = new List<admintalepmodel>();
            foreach (var x in talepler)
            {
                admintalepmodel a = new admintalepmodel();
                a.talepEdenAd = db.tblKullanici.Find(x.talepEden).kullaniciAd + " " + db.tblKullanici.Find(x.talepEden).kullaniciSoyad;
                a.talepEden = x.talepEden;
                a.talepEdilenDanismanAd = db.tblKullanici.Find(x.talepEden).kullaniciAd + " " + db.tblKullanici.Find(x.talepEden).kullaniciSoyad;
                a.talepEdilenDanisman = x.talepEdilenDanisman;
                a.talepTarihi = Convert.ToDateTime(x.talepTarihi);
                a.talepTip = x.talepTip;
                a.talepid = x.talepid;
                if (x.talepDurum == true)
                    a.talepDurum = true;
                else
                    a.talepDurum = false;

                admintalep.Add(a);
            }

            return View(admintalep);
        }
        [HttpGet]
        public ActionResult TalepAktifEt(int? id)
        {
            tblTalep talep = db.tblTalep.Find(id);
            talep.talepDurum = true;
            db.SaveChanges();
            return RedirectToAction("TalepAkisListeleme");
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