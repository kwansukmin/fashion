﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FASHIONWS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FashionDbContext : DbContext
    {
        public FashionDbContext()
            : base("name=FashionConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<DatHang> DatHangs { get; set; }
        public DbSet<DatHangCT> DatHangCTs { get; set; }
        public DbSet<HopThu> HopThus { get; set; }
        public DbSet<Nhomsp> Nhomsps { get; set; }
        public DbSet<PhanLoai> PhanLoais { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
    }
}
