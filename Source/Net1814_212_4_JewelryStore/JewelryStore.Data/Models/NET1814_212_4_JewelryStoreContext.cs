﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.Data.Models;

public partial class NET1814_212_4_JewelryStoreContext : DbContext
{
    public NET1814_212_4_JewelryStoreContext()
    {
    }

    public NET1814_212_4_JewelryStoreContext(DbContextOptions<NET1814_212_4_JewelryStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<SiCompany> SiCompanies { get; set; }

    public virtual DbSet<SiCustomer> SiCustomers { get; set; }

    public virtual DbSet<SiOrder> SiOrders { get; set; }

    public virtual DbSet<SiProduct> SiProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-N9JBQMIC\\SQLEXPRESS02;Initial Catalog=NET1814_212_4_JewelryStore;Persist Security Info=True;User ID=Tannd;Password=12345;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("OrderItem");

            entity.Property(e => e.OrderItemId)
                .ValueGeneratedNever()
                .HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItem_SI_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderItem_SI_Product");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.ToTable("Promotion");

            entity.Property(e => e.PromotionId)
                .ValueGeneratedNever()
                .HasColumnName("PromotionID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.DiscountPercentage)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.EndDate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.StartDate)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Company).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Promotion_SI_Company");
        });

        modelBuilder.Entity<SiCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK_SI_Company_1");

            entity.ToTable("SI_Company");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedNever()
                .HasColumnName("CompanyID");
            entity.Property(e => e.CompanyAddress).HasMaxLength(255);
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<SiCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("SI_Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<SiOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("SI_Order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.PromotionId).HasColumnName("PromotionID");
            entity.Property(e => e.ShipmentStatus).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.SiOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_SI_Order_SI_Customer");

            entity.HasOne(d => d.Promotion).WithMany(p => p.SiOrders)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK_SI_Order_Promotion");
        });

        modelBuilder.Entity<SiProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("SI_Product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Barcode).HasMaxLength(50);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.SiProducts)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_SI_Product_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}