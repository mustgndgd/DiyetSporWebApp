﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbdiyetsporEntities : DbContext
    {
        public dbdiyetsporEntities()
            : base("name=dbdiyetsporEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblAntreman> tblAntreman { get; set; }
        public virtual DbSet<tblAntremanAyrinti> tblAntremanAyrinti { get; set; }
        public virtual DbSet<tblBlog> tblBlog { get; set; }
        public virtual DbSet<tblDiyet> tblDiyet { get; set; }
        public virtual DbSet<tblHareketler> tblHareketler { get; set; }
        public virtual DbSet<tblislemler> tblislemler { get; set; }
        public virtual DbSet<tblKullanici> tblKullanici { get; set; }
        public virtual DbSet<tblKullaniciBilgi> tblKullaniciBilgi { get; set; }
        public virtual DbSet<tblMenu> tblMenu { get; set; }
        public virtual DbSet<tblMesaj> tblMesaj { get; set; }
        public virtual DbSet<tblProgram> tblProgram { get; set; }
        public virtual DbSet<tblTalep> tblTalep { get; set; }
        public virtual DbSet<tblYemekler> tblYemekler { get; set; }
        public virtual DbSet<tblDiyetAyrinti> tblDiyetAyrinti { get; set; }
    }
}