using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Merchandise.Migrations
{
    /// <inheritdoc />
    public partial class utcNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3649561e-c5fa-4f6c-8aaa-46b767e6c96a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55e8f281-8f1e-4c46-acee-24dff9ec4fe6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("791d8d05-a8c2-4a53-99a6-5aedd14dbbe5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96167e60-2330-4bd9-8d49-f921b998264a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9b5f93e1-00dc-45be-822d-ccd024818310"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0ef4a0c-3cf0-4988-be46-42d77d485dbf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c3ac4aa3-f30a-4835-87ac-7e2ea08b459c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ec02d42c-d4cd-459b-8d97-935dfdad44c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef21dd3f-6bf6-48a2-93f5-37a6c5d92ab4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fcc25fda-03c0-403f-9528-5bd4c694afe2"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Number", "Price" },
                values: new object[,]
                {
                    { new Guid("3649561e-c5fa-4f6c-8aaa-46b767e6c96a"), "Red tomatoes", "Tomatoes", 100, 100 },
                    { new Guid("55e8f281-8f1e-4c46-acee-24dff9ec4fe6"), "", "Sausages", 200, 100 },
                    { new Guid("791d8d05-a8c2-4a53-99a6-5aedd14dbbe5"), "Cow's milk", "Milk", 100, 100 },
                    { new Guid("96167e60-2330-4bd9-8d49-f921b998264a"), "Tasty cookies", "Cookies", 15, 100 },
                    { new Guid("9b5f93e1-00dc-45be-822d-ccd024818310"), "A loaf of bread", "Bread", 20, 40 },
                    { new Guid("a0ef4a0c-3cf0-4988-be46-42d77d485dbf"), "Bottled water", "Water", 30, 20 },
                    { new Guid("c3ac4aa3-f30a-4835-87ac-7e2ea08b459c"), "Cheese with mold", "Cheese", 40, 400 },
                    { new Guid("ec02d42c-d4cd-459b-8d97-935dfdad44c0"), "Fresh fish", "Fish", 100, 300 },
                    { new Guid("ef21dd3f-6bf6-48a2-93f5-37a6c5d92ab4"), "Fresh meat", "Meat", 50, 300 },
                    { new Guid("fcc25fda-03c0-403f-9528-5bd4c694afe2"), "Ripe bananas", "Bananas", 10, 30 }
                });
        }
    }
}
