using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCompany.Migrations
{
    public partial class TechMessageEmailAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TechMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2B29F253-6559-45F0-83AC-611F6AB6103B",
                column: "ConcurrencyStamp",
                value: "8c0a10da-b761-4511-ae14-fcb60e6f5a17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "404E976E-F70E-43B6-BE11-8EA8BAF188B3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33f3f784-2cc4-4baa-a01e-62876903779a", "AQAAAAEAACcQAAAAEEbmbOfKR6F234+RcfxEldomomO5M13cbxzL5SWAegWXQlH9Ve49w41LXhET4Sf6Dg==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("215a0bcc-a960-4135-9147-cbc78a84dfa1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 9, 11, 48, 45, 983, DateTimeKind.Utc).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4269a391-b514-44ab-a7cc-df2c68f5bdb1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 9, 11, 48, 45, 983, DateTimeKind.Utc).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("67c3d69d-e26e-42bf-98f1-7de7382e3f02"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 9, 11, 48, 45, 983, DateTimeKind.Utc).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("a1ee5619-a8c9-4732-88f6-0866b954aa4e"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 9, 11, 48, 45, 983, DateTimeKind.Utc).AddTicks(9533));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "TechMessages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2B29F253-6559-45F0-83AC-611F6AB6103B",
                column: "ConcurrencyStamp",
                value: "b32a6093-7ce8-47a9-a741-fca39d8a12c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "404E976E-F70E-43B6-BE11-8EA8BAF188B3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e9522159-f4fb-4f8e-8f69-2c0147582eb7", "AQAAAAEAACcQAAAAEBdkZl7aB6/rwYsHj5mEC6JLDkThomu/7Q/1XrXBPHw35dfx0x77nffhVU7+fOqEZA==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("215a0bcc-a960-4135-9147-cbc78a84dfa1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 9, 11, 20, 48, 880, DateTimeKind.Utc).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4269a391-b514-44ab-a7cc-df2c68f5bdb1"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 9, 11, 20, 48, 880, DateTimeKind.Utc).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("67c3d69d-e26e-42bf-98f1-7de7382e3f02"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 9, 11, 20, 48, 880, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("a1ee5619-a8c9-4732-88f6-0866b954aa4e"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 9, 11, 20, 48, 880, DateTimeKind.Utc).AddTicks(4855));
        }
    }
}
