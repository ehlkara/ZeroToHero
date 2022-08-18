using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeroToHero.CodeFirst.Migrations
{
    public partial class addPriceDiscountCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Products",
                type: "decimal(9,2)",
                precision: 9,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name")
                .Annotation("SqlServer:Include", new[] { "Price", "Stock", "Barcode" });

            migrationBuilder.AddCheckConstraint(
                name: "PriceDiscountCheck",
                table: "Products",
                sql: "[Price]>[DiscountPrice]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.DropCheckConstraint(
                name: "PriceDiscountCheck",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");
        }
    }
}
