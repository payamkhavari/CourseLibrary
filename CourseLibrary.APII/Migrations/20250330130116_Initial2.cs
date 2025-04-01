using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseLibrary.APII.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("9a494ff2-697f-4496-99ce-bc6b997548e8"), new Guid("1c3c1278-f976-4fda-82e1-d90e8ef03e77"), "Griffin Beak Eldritch", "Romance of Arabica" },
                    { new Guid("dd569c04-6b46-4326-be09-c9cf9014a1c1"), new Guid("e5eb6801-effb-474f-aada-96d43e2a7994"), "Griffin Beak Eldritch", "Romance of Arabica" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("9a494ff2-697f-4496-99ce-bc6b997548e8"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("dd569c04-6b46-4326-be09-c9cf9014a1c1"));
        }
    }
}
