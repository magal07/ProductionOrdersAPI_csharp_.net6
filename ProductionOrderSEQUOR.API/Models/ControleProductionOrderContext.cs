﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductionOrderSEQUOR.API.Models
{
    public partial class ControleProductionOrderContext : DbContext
    {
        public ControleProductionOrderContext()
        {
        }

        public ControleProductionOrderContext(DbContextOptions<ControleProductionOrderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.MaterialCode)
                    .HasName("PK__Material__170C54BB56254DA7");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductCode)
                    .HasName("PK__Product__2F4E024E5BF9E9EF");

                entity.HasMany(d => d.MaterialCode)
                    .WithMany(p => p.ProductCode)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductMaterial",
                        l => l.HasOne<Material>().WithMany().HasForeignKey("MaterialCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProductMa__Mater__4CA06362"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProductMa__Produ__4BAC3F29"),
                        j =>
                        {
                            j.HasKey("ProductCode", "MaterialCode").HasName("PK__ProductM__8E3EC7052B8B4017");

                            j.ToTable("ProductMaterial");

                            j.IndexerProperty<string>("ProductCode").HasMaxLength(50).IsUnicode(false);

                            j.IndexerProperty<string>("MaterialCode").HasMaxLength(50).IsUnicode(false);
                        });
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Productio__Email__5165187F");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Productio__Order__52593CB8");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__User__A9D10535AE0AB1E6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}