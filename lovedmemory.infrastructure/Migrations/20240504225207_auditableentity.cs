using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lovedmemory.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class auditableentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ownerid",
                schema: "lovedmemory",
                table: "tributes",
                newName: "createdby");

            migrationBuilder.AddColumn<DateTime>(
                name: "lastmodified",
                schema: "lovedmemory",
                table: "tributes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastmodifiedby",
                schema: "lovedmemory",
                table: "tributes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastmodified",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.DropColumn(
                name: "lastmodifiedby",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.RenameColumn(
                name: "createdby",
                schema: "lovedmemory",
                table: "tributes",
                newName: "ownerid");
        }
    }
}
