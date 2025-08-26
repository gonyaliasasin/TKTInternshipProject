using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Taskms.Api.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86dfdcd5-bd0e-4d0c-b754-7d36055761cb"),
                column: "Password",
                value: "john1234!");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("954f60ae-b788-4bc2-b2a1-45abb9a8e6fd"),
                column: "Title",
                value: "Human Resources Manager");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DepartmentId", "Email", "Name", "Password", "Surname", "Title" },
                values: new object[,]
                {
                    { new Guid("53e9054e-7028-4efc-ad10-4fc21da7a7c8"), new Guid("60bece64-d9fe-4533-a326-08569eaa37df"), "sedat@company.com", "Sedat", "sedat1234!", "Akkuş", "Human Resources Specialist" },
                    { new Guid("69bdc567-73b3-425d-a0e3-ca5243435da1"), new Guid("fd9e1927-baaa-4d65-8380-f7b0cb35beed"), "semih@company.com", "Semih", "semih1234!", "Özdoğan", "Marketing Department Manager" },
                    { new Guid("6ad6fc80-aedc-453f-86f6-ae1daee3bdd2"), new Guid("fd9e1927-baaa-4d65-8380-f7b0cb35beed"), "murat@company.com", "Murat", "murat1234!", "Atalik", "Marketing Specialist" },
                    { new Guid("702a82ba-02ca-4ab8-82d1-94f501e535e0"), new Guid("927759d0-61d9-49e9-9f04-48536964b6c9"), "yağizhan@company.com", "Yağizhan", "yağizhan1234!", "Avci", "Sales Specialist" },
                    { new Guid("b2a90398-fbb9-42c5-8831-b838c3948f86"), new Guid("927759d0-61d9-49e9-9f04-48536964b6c9"), "ceyda@company.com", "Ceyda", "ceyda1234!", "Aksaç", "Sales Specialist" },
                    { new Guid("e21dbfee-6bc8-44fc-b921-5a703cb0ba84"), new Guid("fd9e1927-baaa-4d65-8380-f7b0cb35beed"), "arya@company.com", "Arya", "arya1234!", "Açikgöz", "Marketing Specialist" },
                    { new Guid("fbe707f5-4ded-46e9-8f96-499efc03425b"), new Guid("60bece64-d9fe-4533-a326-08569eaa37df"), "mustafa@company.com", "Mustafa", "mustafa1234!", "Ocak", "Human Resources Specialist" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("53e9054e-7028-4efc-ad10-4fc21da7a7c8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bdc567-73b3-425d-a0e3-ca5243435da1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ad6fc80-aedc-453f-86f6-ae1daee3bdd2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("702a82ba-02ca-4ab8-82d1-94f501e535e0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2a90398-fbb9-42c5-8831-b838c3948f86"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e21dbfee-6bc8-44fc-b921-5a703cb0ba84"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fbe707f5-4ded-46e9-8f96-499efc03425b"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86dfdcd5-bd0e-4d0c-b754-7d36055761cb"),
                column: "Password",
                value: "john4321!");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("954f60ae-b788-4bc2-b2a1-45abb9a8e6fd"),
                column: "Title",
                value: "Human Resources Specialist");
        }
    }
}
