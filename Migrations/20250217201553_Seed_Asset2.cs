using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PPI_Challenge_API.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Asset2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AssetTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Bono" },
                    { 3, "FCI" }
                });

            migrationBuilder.InsertData(
                table: "CommissionTaxes",
                columns: new[] { "Id", "AssetTypeId", "Commission", "Tax" },
                values: new object[,]
                {
                    { 1, 1, 0.006m, 0.21m },
                    { 2, 2, 0.002m, 0.21m },
                    { 3, 3, 0.0m, 0.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommissionTaxes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CommissionTaxes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CommissionTaxes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AssetTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssetTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssetTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
