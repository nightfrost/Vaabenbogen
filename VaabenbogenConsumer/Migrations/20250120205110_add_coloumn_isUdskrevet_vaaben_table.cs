using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaabenbogenConsumer.Migrations
{
    /// <inheritdoc />
    public partial class add_coloumn_isUdskrevet_vaaben_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUdskrevet",
                table: "Vaaben",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUdskrevet",
                table: "Vaaben");
        }
    }
}
