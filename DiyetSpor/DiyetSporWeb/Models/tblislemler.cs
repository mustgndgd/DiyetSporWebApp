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
    
    public partial class tblislemler
    {
        public int islemid { get; set; }
        public Nullable<System.DateTime> islemTarihi { get; set; }
        public int islemYapanid { get; set; }
        public string islemKonu { get; set; }
        public string islemAyrinti { get; set; }
    
        public virtual tblKullanici tblKullanici { get; set; }
    }
}
