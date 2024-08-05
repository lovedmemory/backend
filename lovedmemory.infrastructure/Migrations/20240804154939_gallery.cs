using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lovedmemory.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class gallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nickname",
                schema: "lovedmemory",
                table: "tributes",
                newName: "template");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "lovedmemory",
                table: "tributes",
                newName: "othernames");

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                schema: "lovedmemory",
                table: "tributes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                schema: "lovedmemory",
                table: "tributes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "published",
                schema: "lovedmemory",
                table: "tributes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "treelevel",
                schema: "lovedmemory",
                table: "comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "gallery",
                schema: "lovedmemory",
                columns: table => new
                {
                    tributeid = table.Column<int>(type: "integer", nullable: false),
                    mediaurl = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    approved = table.Column<bool>(type: "boolean", nullable: false),
                    added = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    mediatitle = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    tags = table.Column<string>(type: "text", nullable: false),
                    userid = table.Column<string>(type: "text", nullable: false),
                    addedbyid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gallery", x => x.tributeid);
                    table.ForeignKey(
                        name: "fk_gallary_aspnetusers_addedbyid",
                        column: x => x.addedbyid,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_gallary_tributes_tributeid",
                        column: x => x.tributeid,
                        principalSchema: "lovedmemory",
                        principalTable: "tributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tributedetails",
                schema: "lovedmemory",
                columns: table => new
                {
                    tributeid = table.Column<int>(type: "integer", nullable: false),
                    nickname = table.Column<string>(type: "text", nullable: false),
                    dateofbirth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    dateofdeath = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    lifestory = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tributedetails", x => x.tributeid);
                    table.ForeignKey(
                        name: "fk_tributedetails_tributes_tributeid",
                        column: x => x.tributeid,
                        principalSchema: "lovedmemory",
                        principalTable: "tributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gallery_addedbyid",
                schema: "lovedmemory",
                table: "gallery",
                column: "addedbyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gallery",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "tributedetails",
                schema: "lovedmemory");

            migrationBuilder.DropColumn(
                name: "firstname",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.DropColumn(
                name: "lastname",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.DropColumn(
                name: "published",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.DropColumn(
                name: "treelevel",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.RenameColumn(
                name: "template",
                schema: "lovedmemory",
                table: "tributes",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "othernames",
                schema: "lovedmemory",
                table: "tributes",
                newName: "name");
        }
    }
}
