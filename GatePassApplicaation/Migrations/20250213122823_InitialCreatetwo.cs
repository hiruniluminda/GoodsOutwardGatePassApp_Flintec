using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePassApplicaation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatetwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passNotes_passHeaders_Id",
                table: "passNotes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "passNotes",
                newName: "PassHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_passNotes_Id",
                table: "passNotes",
                newName: "IX_passNotes_PassHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_passNotes_passHeaders_PassHeaderId",
                table: "passNotes",
                column: "PassHeaderId",
                principalTable: "passHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passNotes_passHeaders_PassHeaderId",
                table: "passNotes");

            migrationBuilder.RenameColumn(
                name: "PassHeaderId",
                table: "passNotes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_passNotes_PassHeaderId",
                table: "passNotes",
                newName: "IX_passNotes_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_passNotes_passHeaders_Id",
                table: "passNotes",
                column: "Id",
                principalTable: "passHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
