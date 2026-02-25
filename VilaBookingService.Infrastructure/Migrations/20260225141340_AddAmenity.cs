using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VilaBookingService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAmenity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VilaNumbers_Vilas_VilaID",
                table: "VilaNumbers");

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "Vila_Number",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "Vila_Number",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "Vila_Number",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "Vila_Number",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "Vila_Number",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "Vila_Number",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "Vila_Number",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "Vila_Number",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "Vila_Number",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "VilaNumbers",
                keyColumn: "Vila_Number",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Vilas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vilas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vilas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "VilaID",
                table: "VilaNumbers",
                newName: "VilaId");

            migrationBuilder.RenameIndex(
                name: "IX_VilaNumbers_VilaID",
                table: "VilaNumbers",
                newName: "IX_VilaNumbers_VilaId");

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VilaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Vilas_VilaId",
                        column: x => x.VilaId,
                        principalTable: "Vilas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "VilaId" },
                values: new object[,]
                {
                    { 1, null, "Private Pool", 45 },
                    { 2, null, "Microwave", 45 },
                    { 3, null, "Private Balcony", 45 },
                    { 4, null, "1 king bed and 1 sofa bed", 45 },
                    { 5, null, "Private Plunge Pool", 46 },
                    { 6, null, "Microwave and Mini Refrigerator", 46 },
                    { 7, null, "Private Balcony", 46 },
                    { 8, null, "king bed or 2 double beds", 46 },
                    { 9, null, "Private Pool", 47 },
                    { 10, null, "Jacuzzi", 47 },
                    { 11, null, "Private Balcony", 47 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_VilaId",
                table: "Amenities",
                column: "VilaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VilaNumbers_Vilas_VilaId",
                table: "VilaNumbers",
                column: "VilaId",
                principalTable: "Vilas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VilaNumbers_Vilas_VilaId",
                table: "VilaNumbers");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.RenameColumn(
                name: "VilaId",
                table: "VilaNumbers",
                newName: "VilaID");

            migrationBuilder.RenameIndex(
                name: "IX_VilaNumbers_VilaId",
                table: "VilaNumbers",
                newName: "IX_VilaNumbers_VilaID");

            migrationBuilder.InsertData(
                table: "Vilas",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x400", "Royal Villa", 4, 200m, 550, null },
                    { 2, null, "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x401", "Premium Pool Villa", 4, 300m, 550, null },
                    { 3, null, "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x402", "Luxury Pool Villa", 4, 400m, 750, null }
                });

            migrationBuilder.InsertData(
                table: "VilaNumbers",
                columns: new[] { "Vila_Number", "SpecialDetails", "VilaID" },
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

            migrationBuilder.AddForeignKey(
                name: "FK_VilaNumbers_Vilas_VilaID",
                table: "VilaNumbers",
                column: "VilaID",
                principalTable: "Vilas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
