// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(StoreManagerContext))]
    [Migration("20211116194241_storemanager_migrations")]
    partial class storemanager_migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<int>("CustNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cust_number")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("cust_address");

                    b.Property<string>("CustEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("cust_email");

                    b.Property<string>("CustName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("cust_name");

                    b.Property<string>("CustPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cust_phone");

                    b.HasKey("CustNumber")
                        .HasName("PK__customer__7B25FEEF81922A2D");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Models.Inventory", b =>
                {
                    b.Property<int>("InvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("inv_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProdId")
                        .HasColumnType("int")
                        .HasColumnName("prod_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int?>("StoreNumber")
                        .HasColumnType("int")
                        .HasColumnName("store_number");

                    b.HasKey("InvId")
                        .HasName("PK__inventor__A8749C2913F08965");

                    b.HasIndex("ProdId");

                    b.HasIndex("StoreNumber");

                    b.ToTable("inventory");
                });

            modelBuilder.Entity("Models.LineItem", b =>
                {
                    b.Property<int>("LineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("line_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int?>("ProdId")
                        .HasColumnType("int")
                        .HasColumnName("prod_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("LineId")
                        .HasName("PK__line_ite__F5AE5F62A3B8EF20");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProdId");

                    b.ToTable("line_item");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Property<int>("ProdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("prod_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProdCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("prod_category");

                    b.Property<string>("ProdDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("prod_description");

                    b.Property<string>("ProdName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("prod_name");

                    b.Property<decimal>("ProdPrice")
                        .HasColumnType("money")
                        .HasColumnName("prod_price");

                    b.HasKey("ProdId")
                        .HasName("PK__product__56958AB264BEA269");

                    b.ToTable("product");
                });

            modelBuilder.Entity("Models.SOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustNumber")
                        .HasColumnType("int")
                        .HasColumnName("cust_number");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("date");

                    b.Property<int?>("StoreNumber")
                        .HasColumnType("int")
                        .HasColumnName("store_number");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money")
                        .HasColumnName("total_price");

                    b.HasKey("OrderId")
                        .HasName("PK__s_order__4659622941C18C92");

                    b.HasIndex("CustNumber");

                    b.HasIndex("StoreNumber");

                    b.ToTable("s_order");
                });

            modelBuilder.Entity("Models.SkiResort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("resort_latitude");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("resort_longitude");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("resort_name");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("resort_state");

                    b.Property<string>("Terrain")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("resort_terrain");

                    b.HasKey("Id");

                    b.ToTable("resort");
                });

            modelBuilder.Entity("Models.Storefront", b =>
                {
                    b.Property<int>("StoreNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("store_number")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StoreAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("store_address");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("store_name");

                    b.HasKey("StoreNumber")
                        .HasName("PK__storefro__0BBE57CCBCEBEE81");

                    b.ToTable("storefront");
                });

            modelBuilder.Entity("Models.Inventory", b =>
                {
                    b.HasOne("Models.Product", "Prod")
                        .WithMany("Inventories")
                        .HasForeignKey("ProdId")
                        .HasConstraintName("FK__inventory__prod___047AA831")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("Models.Storefront", "StoreNumberNavigation")
                        .WithMany("Inventories")
                        .HasForeignKey("StoreNumber")
                        .HasConstraintName("FK__inventory__store__038683F8")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Prod");

                    b.Navigation("StoreNumberNavigation");
                });

            modelBuilder.Entity("Models.LineItem", b =>
                {
                    b.HasOne("Models.SOrder", "Order")
                        .WithMany("LineItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__line_item__order__7FB5F314")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("Models.Product", "Prod")
                        .WithMany("LineItems")
                        .HasForeignKey("ProdId")
                        .HasConstraintName("FK__line_item__prod___00AA174D")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Order");

                    b.Navigation("Prod");
                });

            modelBuilder.Entity("Models.SOrder", b =>
                {
                    b.HasOne("Models.Customer", "CustNumberNavigation")
                        .WithMany("SOrders")
                        .HasForeignKey("CustNumber")
                        .HasConstraintName("FK__s_order__cust_nu__7CD98669")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("Models.Storefront", "StoreNumberNavigation")
                        .WithMany("SOrders")
                        .HasForeignKey("StoreNumber")
                        .HasConstraintName("FK__s_order__store_n__7BE56230")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("CustNumberNavigation");

                    b.Navigation("StoreNumberNavigation");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Navigation("SOrders");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("LineItems");
                });

            modelBuilder.Entity("Models.SOrder", b =>
                {
                    b.Navigation("LineItems");
                });

            modelBuilder.Entity("Models.Storefront", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("SOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
