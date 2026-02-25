using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VilaBookingService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyVilaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VilaNumbers_Vilas_VillaID",
                table: "VilaNumbers");

            migrationBuilder.RenameColumn(
                name: "vila_Number",
                table: "VilaNumbers",
                newName: "Vila_Number");

            migrationBuilder.RenameColumn(
                name: "VillaID",
                table: "VilaNumbers",
                newName: "VilaID");

            migrationBuilder.RenameIndex(
                name: "IX_VilaNumbers_VillaID",
                table: "VilaNumbers",
                newName: "IX_VilaNumbers_VilaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VilaNumbers_Vilas_VilaID",
                table: "VilaNumbers",
                column: "VilaID",
                principalTable: "Vilas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VilaNumbers_Vilas_VilaID",
                table: "VilaNumbers");

            migrationBuilder.RenameColumn(
                name: "Vila_Number",
                table: "VilaNumbers",
                newName: "vila_Number");

            migrationBuilder.RenameColumn(
                name: "VilaID",
                table: "VilaNumbers",
                newName: "VillaID");

            migrationBuilder.RenameIndex(
                name: "IX_VilaNumbers_VilaID",
                table: "VilaNumbers",
                newName: "IX_VilaNumbers_VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VilaNumbers_Vilas_VillaID",
                table: "VilaNumbers",
                column: "VillaID",
                principalTable: "Vilas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
