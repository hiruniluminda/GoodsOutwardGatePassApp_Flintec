using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePassApplicaation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facility",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Reason",
                table: "preparedBy",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ReasonId",
                table: "preparedBy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Reason",
                table: "authorizedBy",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ReasonId",
                table: "authorizedBy",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_preparedBy_Reason",
                table: "preparedBy",
                column: "Reason");

            migrationBuilder.CreateIndex(
                name: "IX_authorizedBy_Reason",
                table: "authorizedBy",
                column: "Reason");

            migrationBuilder.AddForeignKey(
                name: "FK_authorizedBy_reasons_Reason",
                table: "authorizedBy",
                column: "Reason",
                principalTable: "reasons",
                principalColumn: "ReasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_preparedBy_reasons_Reason",
                table: "preparedBy",
                column: "Reason",
                principalTable: "reasons",
                principalColumn: "ReasonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorizedBy_reasons_Reason",
                table: "authorizedBy");

            migrationBuilder.DropForeignKey(
                name: "FK_preparedBy_reasons_Reason",
                table: "preparedBy");

            migrationBuilder.DropTable(
                name: "reasons");

            migrationBuilder.DropIndex(
                name: "IX_preparedBy_Reason",
                table: "preparedBy");

            migrationBuilder.DropIndex(
                name: "IX_authorizedBy_Reason",
                table: "authorizedBy");

            migrationBuilder.DropColumn(
                name: "Facility",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ReasonId",
                table: "preparedBy");

            migrationBuilder.DropColumn(
                name: "ReasonId",
                table: "authorizedBy");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "preparedBy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "authorizedBy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
