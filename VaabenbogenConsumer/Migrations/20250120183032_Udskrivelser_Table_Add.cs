using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VaabenbogenConsumer.Migrations
{
    /// <inheritdoc />
    public partial class Udskrivelser_Table_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Virksomheder",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Virksomheder",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Jaegere",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Jaegere",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "Udskrivelser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UdskrevetTilVirksomhedId = table.Column<int>(type: "integer", nullable: true),
                    UdskrevetTilJaegerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Udskrivelser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Udskrivelser_Jaegere_UdskrevetTilJaegerId",
                        column: x => x.UdskrevetTilJaegerId,
                        principalTable: "Jaegere",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Udskrivelser_Virksomheder_UdskrevetTilVirksomhedId",
                        column: x => x.UdskrevetTilVirksomhedId,
                        principalTable: "Virksomheder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Udskrivelser_UdskrevetTilJaegerId",
                table: "Udskrivelser",
                column: "UdskrevetTilJaegerId");

            migrationBuilder.CreateIndex(
                name: "IX_Udskrivelser_UdskrevetTilVirksomhedId",
                table: "Udskrivelser",
                column: "UdskrevetTilVirksomhedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Udskrivelser");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Virksomheder",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Virksomheder",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Jaegere",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Jaegere",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
