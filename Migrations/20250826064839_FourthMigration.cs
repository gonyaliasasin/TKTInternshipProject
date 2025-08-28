using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TktInternshipProject.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("53e9054e-7028-4efc-ad10-4fc21da7a7c8"),
                column: "Role",
                value: "Employee");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bdc567-73b3-425d-a0e3-ca5243435da1"),
                column: "Role",
                value: "Manager");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ad6fc80-aedc-453f-86f6-ae1daee3bdd2"),
                column: "Role",
                value: "Employee");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("702a82ba-02ca-4ab8-82d1-94f501e535e0"),
                column: "Role",
                value: "Employee");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86dfdcd5-bd0e-4d0c-b754-7d36055761cb"),
                column: "Role",
                value: "Manager");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("954f60ae-b788-4bc2-b2a1-45abb9a8e6fd"),
                column: "Role",
                value: "Manager");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2a90398-fbb9-42c5-8831-b838c3948f86"),
                column: "Role",
                value: "Employee");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e21dbfee-6bc8-44fc-b921-5a703cb0ba84"),
                column: "Role",
                value: "Employee");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fbe707f5-4ded-46e9-8f96-499efc03425b"),
                column: "Role",
                value: "Employee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
