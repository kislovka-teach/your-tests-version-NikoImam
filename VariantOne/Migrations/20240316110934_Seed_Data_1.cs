using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VariantOne.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Data_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "Country", "Name", "TeaType" },
                values: new object[,]
                {
                    { 1, "Шри-Ланка", "Майя", 1 },
                    { 2, "Казахстан", "Цейлон", 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Manufacturer", "PackagingType", "Price", "QuantityInStock", "TeaId", "Volume" },
                values: new object[,]
                {
                    { 1, "OOO Chai", 0, 450, 1000, 1, 100 },
                    { 2, "Bjenxci", 1, 1700, 550, 2, 500 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
