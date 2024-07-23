using CrawlerDotnet.Data.Models;
using Microsoft.EntityFrameworkCore;
//using System;

namespace CrawlerDotnet.Data.Context
{
    public partial class DbContextEshop : DbContext
    {
        public DbContextEshop()
        {
        }

        public DbContextEshop(DbContextOptions<DbContextEshop> options)
            : base(options)
        {
        }

        public virtual DbSet<BasketItem> BasketItem { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Catalog> Catalog { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Microsoft.eShopOnWeb.CatalogDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.HasIndex(e => e.BasketId);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.BasketItems)
                    .HasForeignKey(d => d.BasketId);
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.HasIndex(e => e.CatalogBrandId);

                entity.HasIndex(e => e.CatalogTypeId);

                entity.Property(e => e.Id).ValueGeneratedNever();
                //entity.Property(e => e.Id).ForSqlServerUseSequenceHiLo("catalog_hilo").IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CatalogBrand)
                    .WithMany(p => p.Catalogs)
                    .HasForeignKey(d => d.CatalogBrandId);

                entity.HasOne(d => d.CatalogType)
                    .WithMany(p => p.Catalogs)
                    .HasForeignKey(d => d.CatalogTypeId);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.ItemOrderedCatalogItemId).HasColumnName("ItemOrdered_CatalogItemId");

                entity.Property(e => e.ItemOrderedPictureUri).HasColumnName("ItemOrdered_PictureUri");

                entity.Property(e => e.ItemOrderedProductName)
                    .IsRequired()
                    .HasColumnName("ItemOrdered_ProductName")
                    .HasMaxLength(50);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.ShipToAddressCity)
                    .IsRequired()
                    .HasColumnName("ShipToAddress_City")
                    .HasMaxLength(100);

                entity.Property(e => e.ShipToAddressCountry)
                    .IsRequired()
                    .HasColumnName("ShipToAddress_Country")
                    .HasMaxLength(90);

                entity.Property(e => e.ShipToAddressState)
                    .HasColumnName("ShipToAddress_State")
                    .HasMaxLength(60);

                entity.Property(e => e.ShipToAddressStreet)
                    .IsRequired()
                    .HasColumnName("ShipToAddress_Street")
                    .HasMaxLength(180);

                entity.Property(e => e.ShipToAddressZipCode)
                    .IsRequired()
                    .HasColumnName("ShipToAddress_ZipCode")
                    .HasMaxLength(18);
            });

            modelBuilder.HasSequence("catalog_brand_hilo").IncrementsBy(10);

            modelBuilder.HasSequence("catalog_hilo").IncrementsBy(10);

            modelBuilder.HasSequence("catalog_type_hilo").IncrementsBy(10);
        }
    }
}