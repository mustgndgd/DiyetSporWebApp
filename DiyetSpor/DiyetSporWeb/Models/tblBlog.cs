//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiyetSporWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblBlog
    {
        public int blogid { get; set; }
        public string blogBaslik { get; set; }
        public string blogDetay { get; set; }
        public int kullaniciid { get; set; }
        public Nullable<int> blogPuan { get; set; }
        public Nullable<bool> blogAktiflik { get; set; }
    
        public virtual tblKullanici tblKullanici { get; set; }
    }
}
