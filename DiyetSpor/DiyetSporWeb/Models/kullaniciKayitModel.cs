using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiyetSporWeb.Models
{
    public class kullaniciKayitModel
    {
        [Required(ErrorMessage ="TC numarasını boş bırakamazsınız...")]
        public long kullaniciTc { get; set; }


        [Required(ErrorMessage = "Ad alanını boş bırakamazsınız...")]
        public string kullaniciAd { get; set; }


        [Required(ErrorMessage = "Soyad alanını boş bırakamazsınız...")]
        public string kullaniciSoyad { get; set; }


        [Required(ErrorMessage = "Doğum tarihi alanını boş bırakamazsınız...")]
        public DateTime kullaniciDogumTarihi { get; set; }


        [Required(ErrorMessage = "Email alanını boş bırakamazsınız...")]
        public string kullaniciEmail { get; set; }

        [Required(ErrorMessage = "Şifre alanını boş bırakamazsınız...")]
        public long kullaniciSifre { get; set; }

        [Required(ErrorMessage = "Telefona alanını boş bırakamazsınız...")]
        public Nullable<long> kullaniciTelefon { get; set; }

        [Required(ErrorMessage = "Cinsiyet alanını boş bırakamazsınız...")]

        public Nullable<bool> kullaniciCinsiyet { get; set; }

        [Required(ErrorMessage = "Üyelik alanını boş bırakamazsınız...")]
        public string kullaniciTipi { get; set; }
    }
}