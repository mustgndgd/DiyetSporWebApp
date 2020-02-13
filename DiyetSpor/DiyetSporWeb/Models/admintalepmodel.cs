using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiyetSporWeb.Models
{
    public class admintalepmodel
    {
        public int talepid { get; set; }      
        public string talepTip { get; set; }
        public DateTime talepTarihi { get; set; }
        public int? talepEden { get; set; }
        public string talepEdenAd { get; set; }
        public int? talepEdilenDanisman { get; set; }
        public string talepEdilenDanismanAd { get; set; }
        public bool talepDurum { get; set; }
    }
}