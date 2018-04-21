using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace portfeuilleService.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Personnes",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Personnes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
