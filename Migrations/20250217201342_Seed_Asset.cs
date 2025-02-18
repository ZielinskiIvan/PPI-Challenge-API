using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPI_Challenge_API.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Asset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
