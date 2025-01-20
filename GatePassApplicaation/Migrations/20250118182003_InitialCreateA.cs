using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePassApplicaation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "approveds",
                columns: table => new
                {
                    PreparedById = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    takenBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approveds", x => x.PreparedById);
                    table.ForeignKey(
                        name: "FK_approveds_reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "reasons",
                        principalColumn: "ReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approveds_ReasonId",
                table: "approveds",
                column: "ReasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approveds");
        }
    }
}
