using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatePassApplicaation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateonex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passNoteLeads_passHeaderLeads_Id",
                table: "passNoteLeads");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "passNoteLeads",
                newName: "PassHeaderLeadId");

            migrationBuilder.RenameIndex(
                name: "IX_passNoteLeads_Id",
                table: "passNoteLeads",
                newName: "IX_passNoteLeads_PassHeaderLeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_passNoteLeads_passHeaderLeads_PassHeaderLeadId",
                table: "passNoteLeads",
                column: "PassHeaderLeadId",
                principalTable: "passHeaderLeads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passNoteLeads_passHeaderLeads_PassHeaderLeadId",
                table: "passNoteLeads");

            migrationBuilder.RenameColumn(
                name: "PassHeaderLeadId",
                table: "passNoteLeads",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_passNoteLeads_PassHeaderLeadId",
                table: "passNoteLeads",
                newName: "IX_passNoteLeads_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_passNoteLeads_passHeaderLeads_Id",
                table: "passNoteLeads",
                column: "Id",
                principalTable: "passHeaderLeads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
