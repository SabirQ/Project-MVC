﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_MVC.Migrations
{
    public partial class changeBasketItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "BasketItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "BasketItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ColorId",
                table: "BasketItems",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_SizeId",
                table: "BasketItems",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Colors_ColorId",
                table: "BasketItems",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Sizes_SizeId",
                table: "BasketItems",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Colors_ColorId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Sizes_SizeId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_ColorId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_SizeId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "BasketItems");
        }
    }
}
