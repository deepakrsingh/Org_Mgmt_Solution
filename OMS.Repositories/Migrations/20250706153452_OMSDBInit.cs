using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class OMSDBInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.CreateTable(
                name: "AddressType",
                schema: "Person",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rowguid = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEntity",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rowguid = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntity", x => x.BusinessEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Person",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonType = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rowguid = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_BusinessEntity_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Person",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Person",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Person",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTypeId = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpatialLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rowguid = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalSchema: "Person",
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Person",
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressTypeId",
                schema: "Person",
                table: "Address",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                schema: "Person",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_BusinessEntityId",
                schema: "Person",
                table: "Person",
                column: "BusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                schema: "Person",
                table: "State",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "AddressType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "BusinessEntity",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Person");
        }
    }
}
