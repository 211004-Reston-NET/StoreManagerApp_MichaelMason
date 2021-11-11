using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class storemanagermigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    cust_number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cust_email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cust_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cust_address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    cust_phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customer__7B25FEEF81922A2D", x => x.cust_number);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    prod_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prod_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    prod_price = table.Column<decimal>(type: "money", nullable: false),
                    prod_description = table.Column<string>(type: "text", nullable: false),
                    prod_category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product__56958AB264BEA269", x => x.prod_id);
                });

            migrationBuilder.CreateTable(
                name: "storefront",
                columns: table => new
                {
                    store_number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    store_address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__storefro__0BBE57CCBCEBEE81", x => x.store_number);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    inv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_number = table.Column<int>(type: "int", nullable: true),
                    prod_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__inventor__A8749C2913F08965", x => x.inv_id);
                    table.ForeignKey(
                        name: "FK__inventory__prod___047AA831",
                        column: x => x.prod_id,
                        principalTable: "product",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__inventory__store__038683F8",
                        column: x => x.store_number,
                        principalTable: "storefront",
                        principalColumn: "store_number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "s_order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_number = table.Column<int>(type: "int", nullable: true),
                    cust_number = table.Column<int>(type: "int", nullable: true),
                    total_price = table.Column<decimal>(type: "money", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__s_order__4659622941C18C92", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__s_order__cust_nu__7CD98669",
                        column: x => x.cust_number,
                        principalTable: "customer",
                        principalColumn: "cust_number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__s_order__store_n__7BE56230",
                        column: x => x.store_number,
                        principalTable: "storefront",
                        principalColumn: "store_number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "line_item",
                columns: table => new
                {
                    line_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    prod_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__line_ite__F5AE5F62A3B8EF20", x => x.line_id);
                    table.ForeignKey(
                        name: "FK__line_item__order__7FB5F314",
                        column: x => x.order_id,
                        principalTable: "s_order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__line_item__prod___00AA174D",
                        column: x => x.prod_id,
                        principalTable: "product",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_prod_id",
                table: "inventory",
                column: "prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_store_number",
                table: "inventory",
                column: "store_number");

            migrationBuilder.CreateIndex(
                name: "IX_line_item_order_id",
                table: "line_item",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_line_item_prod_id",
                table: "line_item",
                column: "prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_s_order_cust_number",
                table: "s_order",
                column: "cust_number");

            migrationBuilder.CreateIndex(
                name: "IX_s_order_store_number",
                table: "s_order",
                column: "store_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "line_item");

            migrationBuilder.DropTable(
                name: "s_order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "storefront");
        }
    }
}
