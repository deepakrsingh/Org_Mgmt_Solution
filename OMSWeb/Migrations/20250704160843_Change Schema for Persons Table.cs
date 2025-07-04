using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMSWeb.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSchemaforPersonsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Persons",
                newSchema: "Person");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Persons",
                schema: "Person",
                newName: "Persons");
        }
    }
}
