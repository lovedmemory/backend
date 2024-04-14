using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lovedmemory.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_comments_commentid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.RenameColumn(
                name: "commentid",
                schema: "lovedmemory",
                table: "comments",
                newName: "parentcommentid");

            migrationBuilder.RenameIndex(
                name: "IX_comments_commentid",
                schema: "lovedmemory",
                table: "comments",
                newName: "IX_comments_parentcommentid");

            migrationBuilder.AlterColumn<string>(
                name: "ownerid",
                schema: "lovedmemory",
                table: "tributes",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_comments_parentcommentid",
                schema: "lovedmemory",
                table: "comments",
                column: "parentcommentid",
                principalSchema: "lovedmemory",
                principalTable: "comments",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_comments_parentcommentid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.RenameColumn(
                name: "parentcommentid",
                schema: "lovedmemory",
                table: "comments",
                newName: "commentid");

            migrationBuilder.RenameIndex(
                name: "IX_comments_parentcommentid",
                schema: "lovedmemory",
                table: "comments",
                newName: "IX_comments_commentid");

            migrationBuilder.AlterColumn<int>(
                name: "ownerid",
                schema: "lovedmemory",
                table: "tributes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_comments_commentid",
                schema: "lovedmemory",
                table: "comments",
                column: "commentid",
                principalSchema: "lovedmemory",
                principalTable: "comments",
                principalColumn: "id");
        }
    }
}
