using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lovedmemory.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class commentstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "visible",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "lovedmemory",
                table: "comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.AddColumn<bool>(
                name: "visible",
                schema: "lovedmemory",
                table: "comments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
