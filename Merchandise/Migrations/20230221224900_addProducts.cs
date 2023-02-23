using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Merchandise.Migrations
{
    /// <inheritdoc />
    public partial class addProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedProducts",
                table: "OrderedProducts");

            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "OrderedProducts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderedProducts");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "OrderedProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedProducts",
                table: "OrderedProducts",
                columns: new[] { "ProductId", "OrderId" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedProducts",
                table: "OrderedProducts");

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

            migrationBuilder.DropColumn(
                name: "Number",
                table: "OrderedProducts");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AddDate",
                table: "OrderedProducts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderedProducts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedProducts",
                table: "OrderedProducts",
                columns: new[] { "ProductId", "OrderId", "AddDate" });
        }
    }
}
