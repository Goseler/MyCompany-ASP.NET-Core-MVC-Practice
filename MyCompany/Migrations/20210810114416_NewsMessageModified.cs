using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCompany.Migrations
{
    public partial class NewsMessageModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "NewsMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "NewsMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                table: "NewsMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "NewsMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleImagePath",
                table: "NewsMessages",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "NewsMessages");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "NewsMessages");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                table: "NewsMessages");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "NewsMessages");

            migrationBuilder.DropColumn(
                name: "TitleImagePath",
                table: "NewsMessages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2B29F253-6559-45F0-83AC-611F6AB6103B",
                column: "ConcurrencyStamp",
                value: "c7d4ccf3-8cf2-49bc-873d-d3c1af96ce06");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "404E976E-F70E-43B6-BE11-8EA8BAF188B3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c14d3d5-f43f-4cf7-8520-d81b08dbe3a4", "AQAAAAEAACcQAAAAEHnVnaoALAVAUWsrpI2hWz62jWb3krjfCqc7t/6jImRCvHvNwZ/ZDleQM/BBR4FjEA==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("215a0bcc-a960-4135-9147-cbc78a84dfa1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 7, 47, 13, 752, DateTimeKind.Utc).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4269a391-b514-44ab-a7cc-df2c68f5bdb1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 7, 47, 13, 752, DateTimeKind.Utc).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("67c3d69d-e26e-42bf-98f1-7de7382e3f02"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 7, 47, 13, 752, DateTimeKind.Utc).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("a1ee5619-a8c9-4732-88f6-0866b954aa4e"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 10, 7, 47, 13, 752, DateTimeKind.Utc).AddTicks(2991));
        }
    }
}
