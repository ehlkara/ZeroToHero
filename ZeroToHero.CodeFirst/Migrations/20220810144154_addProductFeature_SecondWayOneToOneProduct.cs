using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeroToHero.CodeFirst.Migrations
{
    public partial class addProductFeature_SecondWayOneToOneProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeature_Products_ProductId",
                table: "ProductFeature");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductFeature",
                newName: "ProductRef_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFeature_ProductId",
                table: "ProductFeature",
                newName: "IX_ProductFeature_ProductRef_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeature_Products_ProductRef_Id",
                table: "ProductFeature",
                column: "ProductRef_Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeature_Products_ProductRef_Id",
                table: "ProductFeature");

            migrationBuilder.RenameColumn(
                name: "ProductRef_Id",
                table: "ProductFeature",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFeature_ProductRef_Id",
                table: "ProductFeature",
                newName: "IX_ProductFeature_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeature_Products_ProductId",
                table: "ProductFeature",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
