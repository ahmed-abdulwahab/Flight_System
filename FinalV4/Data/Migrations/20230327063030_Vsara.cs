using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalV4.Data.Migrations
{
    public partial class Vsara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Cities_CityId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Hotels");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Hotels",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<int>(
                name: "City_id",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_City_id",
                table: "Hotels",
                column: "City_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Cities_City_id",
                table: "Hotels",
                column: "City_id",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Cities_City_id",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_City_id",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "City_id",
                table: "Hotels");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Hotels",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Cities_CityId",
                table: "Hotels",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
