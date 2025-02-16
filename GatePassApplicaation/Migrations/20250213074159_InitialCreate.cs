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
                name: "actions",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actions", x => x.ActionId);
                });

            migrationBuilder.CreateTable(
                name: "reasons",
                columns: table => new
                {
                    ReasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reasons", x => x.ReasonId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "passHeaderAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassNo = table.Column<int>(type: "int", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_passHeaderAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_passHeaderAdmins_actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "actions",
                        principalColumn: "ActionId",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassNo = table.Column<int>(type: "int", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_passHeaderLeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_passHeaderLeads_actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "actions",
                        principalColumn: "ActionId",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassNo = table.Column<int>(type: "int", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_passHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_passHeaders_actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "actions",
                        principalColumn: "ActionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_passHeaders_reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "reasons",
                        principalColumn: "ReasonId",
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
                        name: "FK_passNoteAdmins_passHeaderAdmins_PassNo",
                        column: x => x.PassNo,
                        principalTable: "passHeaderAdmins",
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_passHeaderAdmins_ActionId",
                table: "passHeaderAdmins",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_passHeaderAdmins_ReasonId",
                table: "passHeaderAdmins",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_passHeaderLeads_ActionId",
                table: "passHeaderLeads",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_passHeaderLeads_ReasonId",
                table: "passHeaderLeads",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_passHeaders_ActionId",
                table: "passHeaders",
                column: "ActionId");

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
                name: "passNoteAdmins");

            migrationBuilder.DropTable(
                name: "passNoteLeads");

            migrationBuilder.DropTable(
                name: "passNotes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "passHeaderAdmins");

            migrationBuilder.DropTable(
                name: "passHeaderLeads");

            migrationBuilder.DropTable(
                name: "passHeaders");

            migrationBuilder.DropTable(
                name: "actions");

            migrationBuilder.DropTable(
                name: "reasons");
        }
    }
}
