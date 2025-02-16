using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePassApplicaation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatetwox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passNoteAdmins_passHeaderAdmins_Id",
                table: "passNoteAdmins");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "passNoteAdmins",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_passNoteAdmins_Id",
                table: "passNoteAdmins",
                newName: "IX_passNoteAdmins_AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_passNoteAdmins_passHeaderAdmins_AdminId",
                table: "passNoteAdmins",
                column: "AdminId",
                principalTable: "passHeaderAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passNoteAdmins_passHeaderAdmins_AdminId",
                table: "passNoteAdmins");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "passNoteAdmins",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_passNoteAdmins_AdminId",
                table: "passNoteAdmins",
                newName: "IX_passNoteAdmins_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_passNoteAdmins_passHeaderAdmins_Id",
                table: "passNoteAdmins",
                column: "Id",
                principalTable: "passHeaderAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
