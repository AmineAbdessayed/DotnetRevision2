using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assurance",
                columns: table => new
                {
                    AssuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEffet = table.Column<DateTime>(type: "Date", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "Date", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assurance", x => x.AssuranceId);
                });

            migrationBuilder.CreateTable(
                name: "Expert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomaineExpertise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarifHoraire = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sinistre",
                columns: table => new
                {
                    SinistreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datedeclaration = table.Column<DateTime>(type: "Date", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssuranceFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinistre", x => x.SinistreId);
                    table.ForeignKey(
                        name: "FK_Sinistre_Assurance_AssuranceFk",
                        column: x => x.AssuranceFk,
                        principalTable: "Assurance",
                        principalColumn: "AssuranceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expertise",
                columns: table => new
                {
                    DateExpertise = table.Column<DateTime>(type: "Date", nullable: false),
                    ExpertFk = table.Column<int>(type: "int", nullable: false),
                    SinistreFk = table.Column<int>(type: "int", nullable: false),
                    AvisTechnique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantEstime = table.Column<double>(type: "float", nullable: false),
                    Duree = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertise", x => new { x.ExpertFk, x.SinistreFk, x.DateExpertise });
                    table.ForeignKey(
                        name: "FK_Expertise_Expert_ExpertFk",
                        column: x => x.ExpertFk,
                        principalTable: "Expert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expertise_Sinistre_SinistreFk",
                        column: x => x.SinistreFk,
                        principalTable: "Sinistre",
                        principalColumn: "SinistreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expertise_SinistreFk",
                table: "Expertise",
                column: "SinistreFk");

            migrationBuilder.CreateIndex(
                name: "IX_Sinistre_AssuranceFk",
                table: "Sinistre",
                column: "AssuranceFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expertise");

            migrationBuilder.DropTable(
                name: "Expert");

            migrationBuilder.DropTable(
                name: "Sinistre");

            migrationBuilder.DropTable(
                name: "Assurance");
        }
    }
}
