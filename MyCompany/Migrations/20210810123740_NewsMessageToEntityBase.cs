using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCompany.Migrations
{
    public partial class NewsMessageToEntityBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSent",
                table: "NewsMessages");

            migrationBuilder.AddColumn<string>(
                name: "ResponsetText",
                table: "NewsMessages",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponsetText",
                table: "NewsMessages");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSent",
                table: "NewsMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2B29F253-6559-45F0-83AC-611F6AB6103B",
                column: "ConcurrencyStamp",
                value: "57f56235-4a12-4ad8-9d70-45f407efc1aa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "404E976E-F70E-43B6-BE11-8EA8BAF188B3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "869374ad-c12a-4100-b146-83762028e4ee", "AQAAAAEAACcQAAAAEEmZziNgDP9WJkUY05UqZWSwRSnkt49haHRy5/ImGhAbG8jAMIkVFabJ4KUHdgAZWw==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("215a0bcc-a960-4135-9147-cbc78a84dfa1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 11, 44, 15, 220, DateTimeKind.Utc).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4269a391-b514-44ab-a7cc-df2c68f5bdb1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 11, 44, 15, 221, DateTimeKind.Utc).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("67c3d69d-e26e-42bf-98f1-7de7382e3f02"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 11, 44, 15, 221, DateTimeKind.Utc).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("a1ee5619-a8c9-4732-88f6-0866b954aa4e"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 11, 44, 15, 221, DateTimeKind.Utc).AddTicks(1645));
        }
    }
}
