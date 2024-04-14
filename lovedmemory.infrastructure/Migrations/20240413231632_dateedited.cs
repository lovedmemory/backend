using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lovedmemory.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dateedited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateedited",
                schema: "lovedmemory",
                table: "comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "edited",
                schema: "lovedmemory",
                table: "comments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateedited",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "edited",
                schema: "lovedmemory",
                table: "comments");
        }
    }
}
