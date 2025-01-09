using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePassApplicaation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authorizedBy",
                columns: table => new
                {
                    PreparedById = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    takenBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorizedBy", x => x.PreparedById);
                });

            migrationBuilder.CreateTable(
                name: "preparedBy",
                columns: table => new
                {
                    PreparedById = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    takenBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preparedBy", x => x.PreparedById);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authorizedBy");

            migrationBuilder.DropTable(
                name: "preparedBy");
        }
    }
}
