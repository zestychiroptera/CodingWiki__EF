using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "IDBook", "ISBN", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "0060838671", 9.99m, "Their Eyes Were Watching God" },
                    { 2, "1250178614", 10.76m, "The Four Winds" },
                    { 3, "0765387573", 13.50m, "The Invisible Life of Addie LaRue" },
                    { 4, "9780307455475", 14.49m, "The Year of the Flood" },
                    { 5, "0399590528", 11.41m, "Educated" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 5);
        }
    }
}
