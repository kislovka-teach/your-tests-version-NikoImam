using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VariantTwo.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Data_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarModelId", "Color", "HorsePowers", "OwnerId", "PowerPlant", "Year" },
                values: new object[,]
                {
                    { 1, 2, "White", 130, 1, 0, 2003 },
                    { 2, 3, "Silver", 210, 1, 0, 1994 }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "CarId", "PublishDate", "Rating", "Text", "Title", "Topic" },
                values: new object[] { 1, 1, 1, new DateOnly(2024, 3, 16), 0, "KDjnvfkdnjvnjfedvkjnfdkvlnljrsdvlanfvlaeh aei ufhae", "Ремонт хрома", "Ремонт" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "Text", "UserId" },
                values: new object[] { 1, 1, "Норм", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
