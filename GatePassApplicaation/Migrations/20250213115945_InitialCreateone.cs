using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePassApplicaation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passNoteAdmins_passHeaderAdmins_PassNo",
                table: "passNoteAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_passNoteLeads_passHeaderLeads_PassNo",
                table: "passNoteLeads");

            migrationBuilder.DropForeignKey(
                name: "FK_passNotes_passHeaders_PassNo",
                table: "passNotes");

            migrationBuilder.DropIndex(
                name: "IX_passNotes_PassNo",
                table: "passNotes");

            migrationBuilder.DropIndex(
                name: "IX_passNoteLeads_PassNo",
                table: "passNoteLeads");

            migrationBuilder.DropIndex(
                name: "IX_passNoteAdmins_PassNo",
                table: "passNoteAdmins");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "passNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "passNoteLeads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "passNoteAdmins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_passNotes_Id",
                table: "passNotes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_passNoteLeads_Id",
                table: "passNoteLeads",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_passNoteAdmins_Id",
                table: "passNoteAdmins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_passNoteAdmins_passHeaderAdmins_Id",
                table: "passNoteAdmins",
                column: "Id",
                principalTable: "passHeaderAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_passNoteLeads_passHeaderLeads_Id",
                table: "passNoteLeads",
                column: "Id",
                principalTable: "passHeaderLeads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_passNotes_passHeaders_Id",
                table: "passNotes",
                column: "Id",
                principalTable: "passHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passNoteAdmins_passHeaderAdmins_Id",
                table: "passNoteAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_passNoteLeads_passHeaderLeads_Id",
                table: "passNoteLeads");

            migrationBuilder.DropForeignKey(
                name: "FK_passNotes_passHeaders_Id",
                table: "passNotes");

            migrationBuilder.DropIndex(
                name: "IX_passNotes_Id",
                table: "passNotes");

            migrationBuilder.DropIndex(
                name: "IX_passNoteLeads_Id",
                table: "passNoteLeads");

            migrationBuilder.DropIndex(
                name: "IX_passNoteAdmins_Id",
                table: "passNoteAdmins");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "passNotes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "passNoteLeads");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "passNoteAdmins");

            migrationBuilder.CreateIndex(
                name: "IX_passNotes_PassNo",
                table: "passNotes",
                column: "PassNo");

            migrationBuilder.CreateIndex(
                name: "IX_passNoteLeads_PassNo",
                table: "passNoteLeads",
                column: "PassNo");

            migrationBuilder.CreateIndex(
                name: "IX_passNoteAdmins_PassNo",
                table: "passNoteAdmins",
                column: "PassNo");

            migrationBuilder.AddForeignKey(
                name: "FK_passNoteAdmins_passHeaderAdmins_PassNo",
                table: "passNoteAdmins",
                column: "PassNo",
                principalTable: "passHeaderAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_passNoteLeads_passHeaderLeads_PassNo",
                table: "passNoteLeads",
                column: "PassNo",
                principalTable: "passHeaderLeads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_passNotes_passHeaders_PassNo",
                table: "passNotes",
                column: "PassNo",
                principalTable: "passHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
