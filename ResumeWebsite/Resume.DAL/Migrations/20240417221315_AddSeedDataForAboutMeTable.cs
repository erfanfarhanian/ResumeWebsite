using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForAboutMeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AboutMe",
                columns: new[] { "ID", "Bio", "BirthDate", "CreateDate", "Email", "FirstName", "LastName", "Location", "Mobile", "Position" },
                values: new object[] { 1, "", new DateOnly(2024, 4, 18), new DateTime(2024, 4, 18, 1, 43, 14, 715, DateTimeKind.Local).AddTicks(9442), "", "", "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 18, 1, 43, 14, 715, DateTimeKind.Local).AddTicks(9277));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutMe",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 18, 1, 37, 7, 220, DateTimeKind.Local).AddTicks(8832));
        }
    }
}
