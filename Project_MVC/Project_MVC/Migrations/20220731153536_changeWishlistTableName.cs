using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_MVC.Migrations
{
    public partial class changeWishlistTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItem_AspNetUsers_AppUserId",
                table: "WishlistItem");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItem_Products_ProductId",
                table: "WishlistItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishlistItem",
                table: "WishlistItem");

            migrationBuilder.RenameTable(
                name: "WishlistItem",
                newName: "WishlistItems");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItem_ProductId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItem_AppUserId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_AppUserId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "WishlistItems",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishlistItems",
                table: "WishlistItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_AspNetUsers_AppUserId",
                table: "WishlistItems",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Products_ProductId",
                table: "WishlistItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_AspNetUsers_AppUserId",
                table: "WishlistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Products_ProductId",
                table: "WishlistItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishlistItems",
                table: "WishlistItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "WishlistItems");

            migrationBuilder.RenameTable(
                name: "WishlistItems",
                newName: "WishlistItem");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_ProductId",
                table: "WishlistItem",
                newName: "IX_WishlistItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_AppUserId",
                table: "WishlistItem",
                newName: "IX_WishlistItem_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishlistItem",
                table: "WishlistItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItem_AspNetUsers_AppUserId",
                table: "WishlistItem",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItem_Products_ProductId",
                table: "WishlistItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
