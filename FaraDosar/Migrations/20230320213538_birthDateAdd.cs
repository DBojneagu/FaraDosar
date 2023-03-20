using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaraDosar.Migrations
{
    /// <inheritdoc />
    public partial class birthDateAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Profiles",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Profiles");
        }
    }
}
