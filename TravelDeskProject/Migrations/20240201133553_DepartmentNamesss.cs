using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelDeskProject.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentNamesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "CreateBy", "CreatedOn", "DepartmentName", "IsActive", "UpdateBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 2, 1, 19, 5, 53, 401, DateTimeKind.Local).AddTicks(959), "IT", false, null, null },
                    { 2, 0, new DateTime(2024, 2, 1, 19, 5, 53, 401, DateTimeKind.Local).AddTicks(974), "Sales", false, null, null },
                    { 3, 0, new DateTime(2024, 2, 1, 19, 5, 53, 401, DateTimeKind.Local).AddTicks(976), "HR", false, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);
        }
    }
}
