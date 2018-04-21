using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace portfeuilleService.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    PersonneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresse = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.PersonneID);
                });

            migrationBuilder.CreateTable(
                name: "Periodiques",
                columns: table => new
                {
                    PeriodiqueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Commentaire = table.Column<string>(nullable: true),
                    Periode = table.Column<int>(nullable: false),
                    PersonneID = table.Column<int>(nullable: true),
                    isRevenu = table.Column<bool>(nullable: false),
                    valeur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodiques", x => x.PeriodiqueID);
                    table.ForeignKey(
                        name: "FK_Periodiques_Personnes_PersonneID",
                        column: x => x.PersonneID,
                        principalTable: "Personnes",
                        principalColumn: "PersonneID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historiques",
                columns: table => new
                {
                    HistoriqueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Commentaire = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PeriodiqueID = table.Column<int>(nullable: true),
                    PersonneID = table.Column<int>(nullable: true),
                    isRevenu = table.Column<bool>(nullable: false),
                    valeur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiques", x => x.HistoriqueID);
                    table.ForeignKey(
                        name: "FK_Historiques_Periodiques_PeriodiqueID",
                        column: x => x.PeriodiqueID,
                        principalTable: "Periodiques",
                        principalColumn: "PeriodiqueID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historiques_Personnes_PersonneID",
                        column: x => x.PersonneID,
                        principalTable: "Personnes",
                        principalColumn: "PersonneID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_PeriodiqueID",
                table: "Historiques",
                column: "PeriodiqueID");

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_PersonneID",
                table: "Historiques",
                column: "PersonneID");

            migrationBuilder.CreateIndex(
                name: "IX_Periodiques_PersonneID",
                table: "Periodiques",
                column: "PersonneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historiques");

            migrationBuilder.DropTable(
                name: "Periodiques");

            migrationBuilder.DropTable(
                name: "Personnes");
        }
    }
}
