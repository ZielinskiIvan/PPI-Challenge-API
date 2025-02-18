using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PPI_Challenge_API.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Assets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetTypeID", "Name", "Ticker", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "Apple", "AAPL", 177.97m },
                    { 2, 1, "Alphabet Inc", "GOOGL", 138.21m },
                    { 3, 1, "Microsoft", "MSFT", 329.04m },
                    { 4, 1, "Coca Cola", "KO", 58.3m },
                    { 5, 1, "Walmart", "WMT", 163.42m },
                    { 6, 2, "BONOS ARGENTINA USD 2030 L.A", "AL30", 307.4m },
                    { 7, 2, "Bonos Globales Argentina USD Step Up 2030", "GD30", 336.1m },
                    { 8, 3, "Delta Pesos Clase A", "Delta.Pesos", 0.0181m },
                    { 9, 3, "Fima Premium Clase A", "Fima.Premium", 0.0317m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
