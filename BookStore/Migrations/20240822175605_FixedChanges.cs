using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class FixedChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfDeath",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Unknown",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Unknown");

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Unknown",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Unknown");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfDeath",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Unknown",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Unknown");

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Unknown",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Unknown");
        }
    }
}
