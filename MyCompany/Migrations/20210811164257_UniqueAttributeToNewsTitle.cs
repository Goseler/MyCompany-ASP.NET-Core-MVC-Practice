using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCompany.Migrations
{
    public partial class UniqueAttributeToNewsTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "NewsItems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2B29F253-6559-45F0-83AC-611F6AB6103B",
                column: "ConcurrencyStamp",
                value: "5ac79a08-c486-4936-b0e7-bcd5bdd4d7dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "404E976E-F70E-43B6-BE11-8EA8BAF188B3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0c02251e-7dd1-48a3-9b25-c71eba5f0e7d", "AQAAAAEAACcQAAAAEO9mctp1xMNcfKeqfeKd02ehKZ8DMEkAc5mAGnbiQhjiM7s7ouv3YjYsGe9d5TLzJQ==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("215a0bcc-a960-4135-9147-cbc78a84dfa1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 11, 16, 42, 56, 959, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4269a391-b514-44ab-a7cc-df2c68f5bdb1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 11, 16, 42, 56, 960, DateTimeKind.Utc).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("67c3d69d-e26e-42bf-98f1-7de7382e3f02"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 11, 16, 42, 56, 960, DateTimeKind.Utc).AddTicks(1694));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("a1ee5619-a8c9-4732-88f6-0866b954aa4e"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 11, 16, 42, 56, 960, DateTimeKind.Utc).AddTicks(1791));

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_Title",
                table: "NewsItems",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NewsItems_Title",
                table: "NewsItems");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "NewsItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2B29F253-6559-45F0-83AC-611F6AB6103B",
                column: "ConcurrencyStamp",
                value: "8ec6ea2c-9c4c-459b-9981-c777a99ab111");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "404E976E-F70E-43B6-BE11-8EA8BAF188B3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b1b9595c-9367-4f33-b4f5-aa52a141903b", "AQAAAAEAACcQAAAAEAwoq7wKXhkGNutMYtqao1l8ZNcR8bnBTtPH+HoNDUVI1XSnH7sq1qUfIcgbjN2bQA==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("215a0bcc-a960-4135-9147-cbc78a84dfa1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 12, 37, 38, 868, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4269a391-b514-44ab-a7cc-df2c68f5bdb1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 12, 37, 38, 868, DateTimeKind.Utc).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("67c3d69d-e26e-42bf-98f1-7de7382e3f02"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 12, 37, 38, 868, DateTimeKind.Utc).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("a1ee5619-a8c9-4732-88f6-0866b954aa4e"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 12, 37, 38, 868, DateTimeKind.Utc).AddTicks(8040));
        }
    }
}
