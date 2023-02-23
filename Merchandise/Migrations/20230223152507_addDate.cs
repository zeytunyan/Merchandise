using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Merchandise.Migrations
{
    /// <inheritdoc />
    public partial class addDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("335a43d0-6b6c-423c-9218-a1e2695d2ba7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("82de0fe6-d60f-4aae-9a5f-855695a85cc1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fbcef5f-8d6b-47a9-810b-55f9c93442d1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0653228-011d-4fbb-826c-2ed37d81166d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1164ae0-25f8-448f-9006-f777ad080682"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("acf6afbe-803b-41ca-867d-03350e354206"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be4073d7-8982-4bcd-96d5-fa9995a6b1b8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cb4652f6-fed1-4580-a944-20d23c411dc7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8fe41a8-163f-4787-99aa-d42c209b5c8c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd565820-4363-4912-ae81-0c3173811163"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AddDate",
                table: "OrderedProducts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Number", "Price" },
                values: new object[,]
                {
                    { new Guid("12cc3b5e-3334-4ccc-9e9d-e4605a52c6ac"), "Cheese with mold", "Cheese", 40, 400 },
                    { new Guid("4ecdb9eb-b125-4e36-912d-3ac45de2540f"), "A loaf of bread", "Bread", 20, 40 },
                    { new Guid("8f025bc5-7d87-4241-8cda-62f80a27dd36"), "Bottled water", "Water", 30, 20 },
                    { new Guid("a923378b-e8da-478d-856e-4b6e818b9eb4"), "", "Sausages", 200, 100 },
                    { new Guid("ca542733-8611-4c97-a86b-753217f96522"), "Fresh meat", "Meat", 50, 300 },
                    { new Guid("cf6c3480-f550-4f02-9af2-3c3c9019690c"), "Red tomatoes", "Tomatoes", 100, 100 },
                    { new Guid("db1f5561-838f-4f6d-8828-50c9f8638576"), "Tasty cookies", "Cookies", 15, 100 },
                    { new Guid("e045493d-0301-4789-a8c3-41362aa34bfb"), "Ripe bananas", "Bananas", 10, 30 },
                    { new Guid("e9684898-0c61-4189-aa12-7a1366a5eb3a"), "Fresh fish", "Fish", 100, 300 },
                    { new Guid("f62cc352-4493-47c1-886d-749858a9d54c"), "Cow's milk", "Milk", 100, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("12cc3b5e-3334-4ccc-9e9d-e4605a52c6ac"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ecdb9eb-b125-4e36-912d-3ac45de2540f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f025bc5-7d87-4241-8cda-62f80a27dd36"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a923378b-e8da-478d-856e-4b6e818b9eb4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ca542733-8611-4c97-a86b-753217f96522"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cf6c3480-f550-4f02-9af2-3c3c9019690c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db1f5561-838f-4f6d-8828-50c9f8638576"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e045493d-0301-4789-a8c3-41362aa34bfb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e9684898-0c61-4189-aa12-7a1366a5eb3a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f62cc352-4493-47c1-886d-749858a9d54c"));

            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "OrderedProducts");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Number", "Price" },
                values: new object[,]
                {
                    { new Guid("335a43d0-6b6c-423c-9218-a1e2695d2ba7"), "Ripe bananas", "Bananas", 10, 30 },
                    { new Guid("82de0fe6-d60f-4aae-9a5f-855695a85cc1"), "Cheese with mold", "Cheese", 40, 400 },
                    { new Guid("9fbcef5f-8d6b-47a9-810b-55f9c93442d1"), "A loaf of bread", "Bread", 20, 40 },
                    { new Guid("a0653228-011d-4fbb-826c-2ed37d81166d"), "Fresh fish", "Fish", 100, 300 },
                    { new Guid("a1164ae0-25f8-448f-9006-f777ad080682"), "Tasty cookies", "Cookies", 15, 100 },
                    { new Guid("acf6afbe-803b-41ca-867d-03350e354206"), "Fresh meat", "Meat", 50, 300 },
                    { new Guid("be4073d7-8982-4bcd-96d5-fa9995a6b1b8"), "Cow's milk", "Milk", 100, 100 },
                    { new Guid("cb4652f6-fed1-4580-a944-20d23c411dc7"), "", "Sausages", 200, 100 },
                    { new Guid("e8fe41a8-163f-4787-99aa-d42c209b5c8c"), "Bottled water", "Water", 30, 20 },
                    { new Guid("fd565820-4363-4912-ae81-0c3173811163"), "Red tomatoes", "Tomatoes", 100, 100 }
                });
        }
    }
}
