using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

#nullable disable

namespace Data
{
    public partial class StoreManagerContext : DbContext
    {
        public StoreManagerContext()
        {
        }

        public StoreManagerContext(DbContextOptions<StoreManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SOrder> SOrders { get; set; }
        public virtual DbSet<Storefront> Storefronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustNumber)
                    .HasName("PK__customer__7B25FEEF81922A2D");

                entity.ToTable("customer");

                entity.Property(e => e.CustNumber).HasColumnName("cust_number");

                entity.Property(e => e.CustAddress)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("cust_address");

                entity.Property(e => e.CustEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_email");

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_name");

                entity.Property(e => e.CustPhone).HasColumnName("cust_phone");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.InvId)
                    .HasName("PK__inventor__A8749C2913F08965");

                entity.ToTable("inventory");

                entity.Property(e => e.InvId).HasColumnName("inv_id");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.StoreNumber).HasColumnName("store_number");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__inventory__prod___047AA831");

                entity.HasOne(d => d.StoreNumberNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreNumber)
                    .HasConstraintName("FK__inventory__store__038683F8");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasKey(e => e.LineId)
                    .HasName("PK__line_ite__F5AE5F62A3B8EF20");

                entity.ToTable("line_item");

                entity.Property(e => e.LineId).HasColumnName("line_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__line_item__order__7FB5F314");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__line_item__prod___00AA174D");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__product__56958AB264BEA269");

                entity.ToTable("product");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.ProdCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prod_category");

                entity.Property(e => e.ProdDescription)
                    .HasColumnType("text")
                    .HasColumnName("prod_description");

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prod_name");

                entity.Property(e => e.ProdPrice)
                    .HasColumnType("money")
                    .HasColumnName("prod_price");
            });

            modelBuilder.Entity<SOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__s_order__4659622941C18C92");

                entity.ToTable("s_order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustNumber).HasColumnName("cust_number");

                entity.Property(e => e.StoreNumber).HasColumnName("store_number");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasColumnName("total_price");

                entity.HasOne(d => d.CustNumberNavigation)
                    .WithMany(p => p.SOrders)
                    .HasForeignKey(d => d.CustNumber)
                    .HasConstraintName("FK__s_order__cust_nu__7CD98669");

                entity.HasOne(d => d.StoreNumberNavigation)
                    .WithMany(p => p.SOrders)
                    .HasForeignKey(d => d.StoreNumber)
                    .HasConstraintName("FK__s_order__store_n__7BE56230");
            });

            modelBuilder.Entity<Storefront>(entity =>
            {
                entity.HasKey(e => e.StoreNumber)
                    .HasName("PK__storefro__0BBE57CCBCEBEE81");

                entity.ToTable("storefront");

                entity.Property(e => e.StoreNumber).HasColumnName("store_number");

                entity.Property(e => e.StoreAddress)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("store_address");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("store_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
