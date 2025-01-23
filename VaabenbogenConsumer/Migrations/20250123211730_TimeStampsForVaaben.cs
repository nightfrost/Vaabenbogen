using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaabenbogenConsumer.Migrations
{
    /// <inheritdoc />
    public partial class TimeStampsForVaaben : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Vaaben",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Vaaben",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Vaaben",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Vaaben",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Vaaben");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Vaaben");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Vaaben");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Vaaben");
        }
    }
}
