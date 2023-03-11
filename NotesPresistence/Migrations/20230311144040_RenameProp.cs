using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesPresistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deatails",
                table: "Notes",
                newName: "Details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Notes",
                newName: "Deatails");
        }
    }
}
