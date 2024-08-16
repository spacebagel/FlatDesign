using System;
using System.Collections.Generic;
using FlatDesignApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FlatDesignApp.Data;

public partial class ProductDeliveryContext : DbContext
{
    public ProductDeliveryContext()
    {
    }

    public ProductDeliveryContext(DbContextOptions<ProductDeliveryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<BankDetail> BankDetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientType> ClientTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DeliveryNote> DeliveryNotes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=;Database=;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuildingNumber)
                .HasMaxLength(80)
                .HasColumnName("building_number");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.StreetName)
                .HasMaxLength(150)
                .HasColumnName("street_name");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_address_city");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.ToTable("Bank");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<BankDetail>(entity =>
        {
            entity.ToTable("bank_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.Number)
                .HasMaxLength(100)
                .HasColumnName("number");

            entity.HasOne(d => d.Bank).WithMany(p => p.BankDetails)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_bank_detail_Bank");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("city");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_city_country");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.BankDetailId).HasColumnName("bank_detail_id");
            entity.Property(e => e.IdentityDocument)
                .HasMaxLength(150)
                .HasColumnName("identity_document");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Address).WithMany(p => p.Clients)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_client_address");

            entity.HasOne(d => d.BankDetail).WithMany(p => p.Clients)
                .HasForeignKey(d => d.BankDetailId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_client_bank_detail");

            entity.HasOne(d => d.Type).WithMany(p => p.Clients)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_client_client_type");
        });

        modelBuilder.Entity<ClientType>(entity =>
        {
            entity.ToTable("client_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DeliveryNote>(entity =>
        {
            entity.ToTable("delivery_note");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Address).WithMany(p => p.DeliveryNotes)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_delivery_note_address");

            entity.HasOne(d => d.Client).WithMany(p => p.DeliveryNotes)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_delivery_note_client");

            entity.HasOne(d => d.Product).WithMany(p => p.DeliveryNotes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_delivery_note_product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_product_category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(150)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
