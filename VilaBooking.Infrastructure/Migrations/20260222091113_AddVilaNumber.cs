using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VilaBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVilaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VilaNumbers",
                columns: new[] { "vila_Number", "SpecialDetails", "VillaID" },
                values: new object[,]
                {
                    { 101, null, 1 },
                    { 102, null, 1 },
                    { 103, null, 1 },
                    { 104, null, 1 },
                    { 201, null, 2 },
                    { 202, null, 2 },
                    { 203, null, 2 },
                    { 204, null, 2 },
                    { 302, null, 3 },
                    { 303, null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "vila_Number",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "vila_Number",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "vila_Number",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "vila_Number",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "vila_Number",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "vila_Number",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "vila_Number",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "vila_Number",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "vila_Number",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "vila_Number",
                keyValue: 303);
        }
    }
}
