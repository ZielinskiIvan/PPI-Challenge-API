using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PPI_Challenge_API.Migrations
{
    /// <inheritdoc />
    public partial class state_seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "En proceso" },
                    { 2, "Ejecutada" },
                    { 3, "Cancelada" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
