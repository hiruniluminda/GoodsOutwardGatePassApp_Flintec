using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePassApplicaation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatexyz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorizedBy_reasons_Reason",
                table: "authorizedBy");

            migrationBuilder.DropForeignKey(
                name: "FK_preparedBy_reasons_Reason",
                table: "preparedBy");

            migrationBuilder.DropIndex(
                name: "IX_preparedBy_Reason",
                table: "preparedBy");

            migrationBuilder.DropIndex(
                name: "IX_authorizedBy_Reason",
                table: "authorizedBy");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "preparedBy");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "authorizedBy");

            migrationBuilder.CreateIndex(
                name: "IX_preparedBy_ReasonId",
                table: "preparedBy",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_authorizedBy_ReasonId",
                table: "authorizedBy",
                column: "ReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_authorizedBy_reasons_ReasonId",
                table: "authorizedBy",
                column: "ReasonId",
                principalTable: "reasons",
                principalColumn: "ReasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_preparedBy_reasons_ReasonId",
                table: "preparedBy",
                column: "ReasonId",
                principalTable: "reasons",
                principalColumn: "ReasonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorizedBy_reasons_ReasonId",
                table: "authorizedBy");

            migrationBuilder.DropForeignKey(
                name: "FK_preparedBy_reasons_ReasonId",
                table: "preparedBy");

            migrationBuilder.DropIndex(
                name: "IX_preparedBy_ReasonId",
                table: "preparedBy");

            migrationBuilder.DropIndex(
                name: "IX_authorizedBy_ReasonId",
                table: "authorizedBy");

            migrationBuilder.AddColumn<int>(
                name: "Reason",
                table: "preparedBy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reason",
                table: "authorizedBy",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
