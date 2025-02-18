using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PPI_Challenge_API.Migrations
{
    /// <inheritdoc />
    public partial class Orders_Tax1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Tax",
                table: "CommissionTaxes",
                type: "float(18)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<double>(
                name: "Commission",
                table: "CommissionTaxes",
                type: "float(18)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.UpdateData(
                table: "CommissionTaxes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Commission", "Tax" },
                values: new object[] { 0.0060000000000000001, 0.20999999999999999 });

            migrationBuilder.UpdateData(
                table: "CommissionTaxes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Commission", "Tax" },
                values: new object[] { 0.002, 0.20999999999999999 });

            migrationBuilder.UpdateData(
                table: "CommissionTaxes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Commission", "Tax" },
                values: new object[] { 0.0, 0.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "CommissionTaxes",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Commission",
                table: "CommissionTaxes",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.UpdateData(
                table: "CommissionTaxes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Commission", "Tax" },
                values: new object[] { 0.006m, 0.21m });

            migrationBuilder.UpdateData(
                table: "CommissionTaxes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Commission", "Tax" },
                values: new object[] { 0.002m, 0.21m });

            migrationBuilder.UpdateData(
                table: "CommissionTaxes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Commission", "Tax" },
                values: new object[] { 0.0m, 0.0m });
        }
    }
}
