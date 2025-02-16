using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaabenbogenConsumer.Migrations
{
    /// <inheritdoc />
    public partial class EditLoebenummerSplit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Loebenummer",
                table: "Vaaben");

            migrationBuilder.AddColumn<string>(
                name: "Bundstykkenummer",
                table: "Vaaben",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pibenummer",
                table: "Vaaben",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Systemnummer",
                table: "Vaaben",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bundstykkenummer",
                table: "Udskrivelser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pibenummer",
                table: "Udskrivelser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Systemnummer",
                table: "Udskrivelser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaabenId",
                table: "Udskrivelser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bundstykkenummer",
                table: "Vaaben");

            migrationBuilder.DropColumn(
                name: "Pibenummer",
                table: "Vaaben");

            migrationBuilder.DropColumn(
                name: "Systemnummer",
                table: "Vaaben");

            migrationBuilder.DropColumn(
                name: "Bundstykkenummer",
                table: "Udskrivelser");

            migrationBuilder.DropColumn(
                name: "Pibenummer",
                table: "Udskrivelser");

            migrationBuilder.DropColumn(
                name: "Systemnummer",
                table: "Udskrivelser");

            migrationBuilder.DropColumn(
                name: "VaabenId",
                table: "Udskrivelser");

            migrationBuilder.AddColumn<string>(
                name: "Loebenummer",
                table: "Vaaben",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
