using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lovedmemory.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class commetns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_comments_parentcommentid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_parentcommentid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.AddColumn<int>(
                name: "commentid",
                schema: "lovedmemory",
                table: "comments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_commentid",
                schema: "lovedmemory",
                table: "comments",
                column: "commentid");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_comments_commentid",
                schema: "lovedmemory",
                table: "comments",
                column: "commentid",
                principalSchema: "lovedmemory",
                principalTable: "comments",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_comments_commentid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_commentid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "commentid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.CreateIndex(
                name: "IX_comments_parentcommentid",
                schema: "lovedmemory",
                table: "comments",
                column: "parentcommentid");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_comments_parentcommentid",
                schema: "lovedmemory",
                table: "comments",
                column: "parentcommentid",
                principalSchema: "lovedmemory",
                principalTable: "comments",
                principalColumn: "id");
        }
    }
}
