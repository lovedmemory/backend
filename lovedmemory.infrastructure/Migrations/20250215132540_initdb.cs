using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lovedmemory.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "lovedmemory");

            migrationBuilder.CreateTable(
                name: "aspnetroles",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusers",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    other_name = table.Column<string>(type: "text", nullable: true),
                    nick_name = table.Column<string>(type: "text", nullable: true),
                    avatar = table.Column<string>(type: "text", nullable: true),
                    country_code = table.Column<string>(type: "text", nullable: true),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contact_messages",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    privacy_agree = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contact_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "event_details",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    memorial_id = table.Column<int>(type: "integer", nullable: false),
                    event_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    event_location = table.Column<string>(type: "text", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_event_details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    desc = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetroleclaims",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroleclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetroleclaims_aspnetroles_role_id",
                        column: x => x.role_id,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserclaims",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetuserclaims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserlogins",
                schema: "lovedmemory",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    provider_key = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserlogins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_aspnetuserlogins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserroles",
                schema: "lovedmemory",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserroles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetroles_role_id",
                        column: x => x.role_id,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusertokens",
                schema: "lovedmemory",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    login_provider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusertokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_aspnetusertokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "memorials",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    view_count = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    personal_phrase = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    other_names = table.Column<string>(type: "text", nullable: true),
                    biography = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<string>(type: "text", nullable: false),
                    slug = table.Column<string>(type: "text", nullable: false),
                    template = table.Column<string>(type: "text", nullable: false),
                    main_image_url = table.Column<string>(type: "text", nullable: true),
                    edited = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    run_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    published = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    is_private = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    last_modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_modified_by_user_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_memorials", x => x.id);
                    table.ForeignKey(
                        name: "fk_memorials_aspnetusers_created_by_user_id",
                        column: x => x.created_by_user_id,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(type: "text", nullable: false),
                    permission_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_permissions_permissions_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "lovedmemory",
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "audio",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    memorial_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    tags = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    added_by_id = table.Column<string>(type: "text", nullable: false),
                    added = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audio", x => x.id);
                    table.ForeignKey(
                        name: "fk_audio_memorials_memorial_id",
                        column: x => x.memorial_id,
                        principalSchema: "lovedmemory",
                        principalTable: "memorials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_audio_users_added_by_id",
                        column: x => x.added_by_id,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    memorial_id = table.Column<int>(type: "integer", nullable: false),
                    tree_level = table.Column<int>(type: "integer", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    visible = table.Column<bool>(type: "boolean", nullable: false),
                    edited = table.Column<bool>(type: "boolean", nullable: false),
                    parent_comment_id = table.Column<int>(type: "integer", nullable: true),
                    comment_id = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    last_modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_modified_by_user_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.id);
                    table.ForeignKey(
                        name: "fk_comments_comments_comment_id",
                        column: x => x.comment_id,
                        principalSchema: "lovedmemory",
                        principalTable: "comments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_comments_memorials_memorial_id",
                        column: x => x.memorial_id,
                        principalSchema: "lovedmemory",
                        principalTable: "memorials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cover_photo",
                schema: "lovedmemory",
                columns: table => new
                {
                    cover_photo_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    memorial_id = table.Column<int>(type: "integer", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false),
                    width = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cover_photo", x => x.cover_photo_id);
                    table.ForeignKey(
                        name: "fk_cover_photo_memorials_memorial_id",
                        column: x => x.memorial_id,
                        principalSchema: "lovedmemory",
                        principalTable: "memorials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "extra_details",
                schema: "lovedmemory",
                columns: table => new
                {
                    memorial_id = table.Column<int>(type: "integer", nullable: false),
                    nick_name = table.Column<string>(type: "text", nullable: true),
                    relationship = table.Column<int>(type: "integer", nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    date_of_death = table.Column<DateOnly>(type: "date", nullable: true),
                    birth_country = table.Column<string>(type: "text", nullable: true),
                    death_country = table.Column<string>(type: "text", nullable: true),
                    life_story = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_extra_details", x => x.memorial_id);
                    table.ForeignKey(
                        name: "fk_extra_details_memorials_memorial_id",
                        column: x => x.memorial_id,
                        principalSchema: "lovedmemory",
                        principalTable: "memorials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gallery",
                schema: "lovedmemory",
                columns: table => new
                {
                    memorial_id = table.Column<int>(type: "integer", nullable: false),
                    media_url = table.Column<string>(type: "text", nullable: false),
                    media_type = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    approved = table.Column<bool>(type: "boolean", nullable: false),
                    added = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    media_title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    tags = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    added_by_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gallery", x => x.memorial_id);
                    table.ForeignKey(
                        name: "fk_gallary_memorials_memorial_id",
                        column: x => x.memorial_id,
                        principalSchema: "lovedmemory",
                        principalTable: "memorials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_gallary_users_added_by_id",
                        column: x => x.added_by_id,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "life_story",
                schema: "lovedmemory",
                columns: table => new
                {
                    memorial_id = table.Column<int>(type: "integer", nullable: false),
                    story_section = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    story = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_life_story", x => x.memorial_id);
                    table.ForeignKey(
                        name: "fk_life_story_memorials_memorial_id",
                        column: x => x.memorial_id,
                        principalSchema: "lovedmemory",
                        principalTable: "memorials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_aspnetroleclaims_role_id",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "lovedmemory",
                table: "aspnetroles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserclaims_user_id",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserlogins_user_id",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserroles_role_id",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "lovedmemory",
                table: "aspnetusers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "lovedmemory",
                table: "aspnetusers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_audio_added_by_id",
                schema: "lovedmemory",
                table: "audio",
                column: "added_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_audio_memorial_id",
                schema: "lovedmemory",
                table: "audio",
                column: "memorial_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_comment_id",
                schema: "lovedmemory",
                table: "comments",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_memorial_id",
                schema: "lovedmemory",
                table: "comments",
                column: "memorial_id");

            migrationBuilder.CreateIndex(
                name: "ix_cover_photo_memorial_id",
                schema: "lovedmemory",
                table: "cover_photo",
                column: "memorial_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_gallery_added_by_id",
                schema: "lovedmemory",
                table: "gallery",
                column: "added_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_memorials_created_by_user_id",
                schema: "lovedmemory",
                table: "memorials",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_permissions_permission_id",
                schema: "lovedmemory",
                table: "role_permissions",
                column: "permission_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aspnetroleclaims",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "aspnetuserclaims",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "aspnetuserlogins",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "aspnetuserroles",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "aspnetusertokens",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "audio",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "comments",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "contact_messages",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "cover_photo",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "event_details",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "extra_details",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "gallery",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "life_story",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "role_permissions",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "aspnetroles",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "memorials",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "aspnetusers",
                schema: "lovedmemory");
        }
    }
}
