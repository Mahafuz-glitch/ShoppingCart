using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace shoppingCartWebApi.Models
{
    public partial class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext()
        {
        }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressTable> AddressTable { get; set; }
        public virtual DbSet<OrderDetailsTable> OrderDetailsTable { get; set; }
        public virtual DbSet<OrderTable> OrderTable { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MAHAFUZ\\SQLEXPRESS;Database=Shopping Cart;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressTable>(entity =>
            {
                entity.ToTable("Address Table");

                entity.Property(e => e.AddressTableId).HasColumnName("Address Table ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode).HasColumnName("Postal Code");

                entity.Property(e => e.ProfileId).HasColumnName("Profile ID");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasColumnName("Street Name")
                    .IsUnicode(false);

                entity.Property(e => e.StreetNumber).HasColumnName("Street Number");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.AddressTable)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address Table_User");
            });

            modelBuilder.Entity<OrderDetailsTable>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId);

                entity.ToTable("Order Details Table");

                entity.Property(e => e.OrderDetailsId).HasColumnName("Order Details ID");

                entity.Property(e => e.OrderId).HasColumnName("Order ID");

                entity.Property(e => e.ProfileId).HasColumnName("Profile ID");

                entity.Property(e => e.TotalPrice).HasColumnName("Total Price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetailsTable)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order Details Table_User");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.OrderDetailsTable)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order Details Table_User1");
            });

            modelBuilder.Entity<OrderTable>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Order Table");

                entity.Property(e => e.OrderId).HasColumnName("Order ID");

                entity.Property(e => e.ProfileId).HasColumnName("Profile ID");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.OrderTable)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order Table_User");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("Payment ID");

                entity.Property(e => e.OrderId).HasColumnName("Order ID");

                entity.Property(e => e.PaymentOption)
                    .IsRequired()
                    .HasColumnName("Payment Option")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileId).HasColumnName("Profile ID");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_User");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("Product ID");

                entity.Property(e => e.ProductCategory)
                    .IsRequired()
                    .HasColumnName("Product Category")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("PRoduct Description")
                    .IsUnicode(false);

                entity.Property(e => e.ProductImageLink)
                    .IsRequired()
                    .HasColumnName("Product Image Link")
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("Product Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnName("Product Price");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.Property(e => e.ProfileId).HasColumnName("Profile ID");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("Date Of Birth")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("Email ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("Full Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("Mobile Number")
                    .HasMaxLength(10);

                entity.Property(e => e.ProfilePassword)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProfileRole)
                    .IsRequired()
                    .HasColumnName("Profile Role")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
