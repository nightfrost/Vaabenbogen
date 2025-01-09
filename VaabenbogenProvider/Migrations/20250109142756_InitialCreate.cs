using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VaabenbogenProvider.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jaegere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fornavn = table.Column<string>(type: "text", nullable: false),
                    Efternavn = table.Column<string>(type: "text", nullable: false),
                    Foedselsdato = table.Column<DateOnly>(type: "date", nullable: false),
                    JaegerId = table.Column<string>(type: "text", nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: true),
                    Mobil = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jaegere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Virksomheder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cvr = table.Column<string>(type: "text", nullable: false),
                    Navn = table.Column<string>(type: "text", nullable: false),
                    Adresse = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    By = table.Column<string>(type: "text", nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    StartDato = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDato = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Virksomheder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaaben",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Navn = table.Column<string>(type: "text", nullable: false),
                    Fabrikat = table.Column<string>(type: "text", nullable: false),
                    Ladefunktion = table.Column<string>(type: "text", nullable: false),
                    Loebenummer = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    JaegerId = table.Column<int>(type: "integer", nullable: true),
                    VirksomhedId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaaben", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaaben_Jaegere_JaegerId",
                        column: x => x.JaegerId,
                        principalTable: "Jaegere",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vaaben_Virksomheder_VirksomhedId",
                        column: x => x.VirksomhedId,
                        principalTable: "Virksomheder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaaben_JaegerId",
                table: "Vaaben",
                column: "JaegerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaaben_VirksomhedId",
                table: "Vaaben",
                column: "VirksomhedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaaben");

            migrationBuilder.DropTable(
                name: "Jaegere");

            migrationBuilder.DropTable(
                name: "Virksomheder");
        }
    }
}
