﻿using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.Models
{
    public class KickAssDataBaseContext : DbContext
    {
        //DB
        public DbSet<News> Inbetween_News { get; set; }
        public DbSet<Albums> Inbetween_Albums { get; set; }
        //public DbSet<Security> Securitys { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<ProductInOrder> ProductsInOrder { get; set; }
        //public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<News>().ToTable("Inbetween_News");
            modelBuilder.Entity<Albums>().ToTable("Inbetween_Albums");
            //modelBuilder.Entity<Security>().ToTable("Securitys");
            //modelBuilder.Entity<Order>().ToTable("Orders");
            //modelBuilder.Entity<ProductInOrder>().ToTable("ProductsInOrder");
            //modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
