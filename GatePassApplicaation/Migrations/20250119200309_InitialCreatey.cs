using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePassApplicaation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approveds");

            migrationBuilder.DropTable(
                name: "authorizedBy");

            migrationBuilder.DropTable(
                name: "preparedBy");

            migrationBuilder.CreateTable(
                name: "passHeaderAdmins",
                columns: table => new
                {
                    PassNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    takenBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passHeaderAdmins", x => x.PassNo);
                    table.ForeignKey(
                        name: "FK_passHeaderAdmins_reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "reasons",
                        principalColumn: "ReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "passHeaderLeads",
                columns: table => new
                {
                    PassNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    takenBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passHeaderLeads", x => x.PassNo);
                    table.ForeignKey(
                        name: "FK_passHeaderLeads_reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "reasons",
                        principalColumn: "ReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "passHeaders",
                columns: table => new
                {
                    PassNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    takenBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passHeaders", x => x.PassNo);
                    table.ForeignKey(
                        name: "FK_passHeaders_reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "reasons",
                        principalColumn: "ReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "passNoteLeads",
                columns: table => new
                {
                    GoodsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    PassNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passNoteLeads", x => x.GoodsId);
                    table.ForeignKey(
                        name: "FK_passNoteLeads_passHeaderLeads_PassNo",
                        column: x => x.PassNo,
                        principalTable: "passHeaderLeads",
                        principalColumn: "PassNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "passNoteAdmins",
                columns: table => new
                {
                    GoodsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    PassNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passNoteAdmins", x => x.GoodsId);
                    table.ForeignKey(
                        name: "FK_passNoteAdmins_passHeaders_PassNo",
                        column: x => x.PassNo,
                        principalTable: "passHeaders",
                        principalColumn: "PassNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "passNotes",
                columns: table => new
                {
                    GoodsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    PassNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passNotes", x => x.GoodsId);
                    table.ForeignKey(
                        name: "FK_passNotes_passHeaders_PassNo",
                        column: x => x.PassNo,
                        principalTable: "passHeaders",
                        principalColumn: "PassNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_passHeaderAdmins_ReasonId",
                table: "passHeaderAdmins",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_passHeaderLeads_ReasonId",
                table: "passHeaderLeads",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_passHeaders_ReasonId",
                table: "passHeaders",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_passNoteAdmins_PassNo",
                table: "passNoteAdmins",
                column: "PassNo");

            migrationBuilder.CreateIndex(
                name: "IX_passNoteLeads_PassNo",
                table: "passNoteLeads",
                column: "PassNo");

            migrationBuilder.CreateIndex(
                name: "IX_passNotes_PassNo",
                table: "passNotes",
                column: "PassNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passHeaderAdmins");

            migrationBuilder.DropTable(
                name: "passNoteAdmins");

            migrationBuilder.DropTable(
                name: "passNoteLeads");

            migrationBuilder.DropTable(
                name: "passNotes");

            migrationBuilder.DropTable(
                name: "passHeaderLeads");

            migrationBuilder.DropTable(
                name: "passHeaders");

            migrationBuilder.CreateTable(
                name: "approveds",
                columns: table => new
                {
                    PreparedById = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    AuthorizedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    NameOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SendTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    takenBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "authorizedBy",
                columns: table => new
                {
                    PreparedById = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    AuthorizedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    NameOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SendTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    takenBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorizedBy", x => x.PreparedById);
                    table.ForeignKey(
                        name: "FK_authorizedBy_reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "reasons",
                        principalColumn: "ReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "preparedBy",
                columns: table => new
                {
                    PreparedById = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    NameOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SendTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    takenBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preparedBy", x => x.PreparedById);
                    table.ForeignKey(
                        name: "FK_preparedBy_reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "reasons",
                        principalColumn: "ReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approveds_ReasonId",
                table: "approveds",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_authorizedBy_ReasonId",
                table: "authorizedBy",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_preparedBy_ReasonId",
                table: "preparedBy",
                column: "ReasonId");
        }
    }
}
