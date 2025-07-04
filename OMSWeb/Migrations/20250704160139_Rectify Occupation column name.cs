using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMSWeb.Migrations
{
    /// <inheritdoc />
    public partial class RectifyOccupationcolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Occuptation",
                table: "Persons",
                newName: "Occupation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Occupation",
                table: "Persons",
                newName: "Occuptation");
        }
    }
}
