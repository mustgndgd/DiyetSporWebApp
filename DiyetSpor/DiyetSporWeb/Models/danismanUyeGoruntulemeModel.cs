using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiyetSporWeb.Models
{
    public class danismanUyeGoruntulemeModel
    {
        public int kullaniciid { get; set; }
        public string kullaniciAd { get; set; }
        public string kullaniciSoyad { get; set; }
        public string kullaniciEmail { get; set; }
        public DateTime basvuruTarihi { get; set; }
    }
}