using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaraDosar.Migrations
{
    /// <inheritdoc />
    public partial class backtothebasics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Profiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Profiles",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
