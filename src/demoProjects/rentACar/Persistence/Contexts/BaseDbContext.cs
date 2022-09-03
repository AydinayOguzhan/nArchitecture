﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    //Nuget'ten Microsoft.EntityFrameworkCore.SqlServer indir
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }
       

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(a =>
            {
                a.ToTable("Brands").HasKey(k => k.Id); //Primary key konfigurasyonu
                a.Property(p => p.Id).HasColumnName("Id"); //Kolon konfigurasyonu
                a.Property(p => p.Name).HasColumnName("Name"); //kolon konfigurasyonu
            });


            //Development ortamı için oluşturulan örnek datalar
            Brand[] brandEntitySeeds = { new(1, "BMW"), new(2, "Mercedes"), new(3, "Ford") };
            modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);

           
        }
    }
}
