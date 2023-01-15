using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TWT.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCarSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "LincensePlate", "OwnerName", "Power" },
                values: new object[,]
                {
                    { "ABC-123", "Erős Pista", 100 },
                    { "BIG-999", "Nagy Karcsi", 300 },
                    { "BZS-150", "Bali Zsolt", 155 },
                    { "BZS-300", "Bali Zsolt", 300 },
                    { "KIS-111", "Kis Jani", 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "LincensePlate",
                keyValue: "ABC-123");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "LincensePlate",
                keyValue: "BIG-999");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "LincensePlate",
                keyValue: "BZS-150");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "LincensePlate",
                keyValue: "BZS-300");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "LincensePlate",
                keyValue: "KIS-111");
        }
    }
}
