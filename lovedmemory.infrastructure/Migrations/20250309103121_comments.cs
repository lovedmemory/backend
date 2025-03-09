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
                name: "fk_comments_comments_comment_id",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "ix_comments_comment_id",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "comment_id",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.AlterColumn<char>(
                name: "gender",
                schema: "lovedmemory",
                table: "memorials",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "ix_comments_parent_comment_id",
                schema: "lovedmemory",
                table: "comments",
                column: "parent_comment_id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_comments_parent_comment_id",
                schema: "lovedmemory",
                table: "comments",
                column: "parent_comment_id",
                principalSchema: "lovedmemory",
                principalTable: "comments",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_comments_parent_comment_id",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "ix_comments_parent_comment_id",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                schema: "lovedmemory",
                table: "memorials",
                type: "text",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)");

            migrationBuilder.AddColumn<int>(
                name: "comment_id",
                schema: "lovedmemory",
                table: "comments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_comments_comment_id",
                schema: "lovedmemory",
                table: "comments",
                column: "comment_id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_comments_comment_id",
                schema: "lovedmemory",
                table: "comments",
                column: "comment_id",
                principalSchema: "lovedmemory",
                principalTable: "comments",
                principalColumn: "id");
        }
    }
}
