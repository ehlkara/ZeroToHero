using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeroToHero.CodeFirst.Migrations
{
    public partial class addCategory_OneToManyDefaultWayProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Category_Id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Category_Id",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "Category_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Category_Id",
                table: "Products",
                column: "Category_Id",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
