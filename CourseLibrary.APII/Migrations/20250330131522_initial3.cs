using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseLibrary.APII.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[] { new Guid("292765b0-2627-433a-aae1-f58767bda127"), new Guid("1c3c1278-f976-4fda-82e1-d90e8ef03e77"), "Griffin Beak Eldritch", "Romance of Arabica" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("292765b0-2627-433a-aae1-f58767bda127"));
        }
    }
}
