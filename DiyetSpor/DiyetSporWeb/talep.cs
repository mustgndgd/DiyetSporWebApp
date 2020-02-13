using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiyetSporWeb.Models;
namespace DiyetSporWeb
{
    public class talep
    {
        dbdiyetsporEntities db = new dbdiyetsporEntities();
        public void danismantalepolustur(long talepEden )
        {
            var kullanici = db.tblKullanici.Where(x => x.kullaniciTc == talepEden);
            int? testkullaniciid=0;
            foreach (var kullanicilar in kullanici)
            {
                if(kullanicilar != null)
                {
             testkullaniciid = kullanicilar.kullaniciid;
                }  
            }
            //talep oluşturma
            tblTalep talep = new tblTalep();
            talep.talepEden = testkullaniciid;
            talep.talepEdilenDanisman = 100015;
            talep.talepTarihi = Convert.ToDateTime(DateTime.Now);
            talep.talepDurum = false;
            talep.talepTip = "DANONAY";
            db.tblTalep.Add(talep);
            db.SaveChanges();
        }
    }
}