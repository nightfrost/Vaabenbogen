using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaabenbogenConsumer.Migrations
{
    /// <inheritdoc />
    public partial class LadeFunktionExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ladefunktion",
                table: "Vaaben",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "LadefunktionFritekst",
                table: "Vaaben",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LadefunktionFritekst",
                table: "Vaaben");

            migrationBuilder.AlterColumn<int>(
                name: "Ladefunktion",
                table: "Vaaben",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
