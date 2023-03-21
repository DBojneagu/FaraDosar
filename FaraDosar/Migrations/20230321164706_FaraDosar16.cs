using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaraDosar.Migrations
{
    /// <inheritdoc />
    public partial class FaraDosar16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNP",
                table: "Appointments",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NrTel",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nume",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prenume",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNP",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "NrTel",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Nume",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Prenume",
                table: "Appointments");
        }
    }
}
