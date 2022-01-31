using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NimapInfotech.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoryMaster",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 1, 31, 12, 41, 2, 2, DateTimeKind.Local).AddTicks(5478));

            migrationBuilder.InsertData(
                table: "ProductMaster",
                columns: new[] { "Id", "CreatedBy", "CreatedByIP", "CreatedOn", "DepartmentId", "ModifiedBy", "ModifiedByIP", "ModifiedOn", "Name", "isActive" },
                values: new object[] { 1, "Yashi", null, new DateTime(2022, 1, 31, 12, 41, 2, 2, DateTimeKind.Local).AddTicks(5575), 1, null, null, null, "Prime Video", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductMaster",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "CategoryMaster",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 1, 31, 12, 35, 48, 760, DateTimeKind.Local).AddTicks(2795));
        }
    }
}
