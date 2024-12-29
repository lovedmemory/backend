using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lovedmemory.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "lovedmemory");

            migrationBuilder.EnsureSchema(
                name: "tributes");

            migrationBuilder.CreateTable(
                name: "aspnetroles",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true)
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
                    firstname = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    othername = table.Column<string>(type: "text", nullable: true),
                    nickname = table.Column<string>(type: "text", nullable: true),
                    avatar = table.Column<string>(type: "text", nullable: true),
                    countrycode = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedusername = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedemail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(type: "text", nullable: true),
                    securitystamp = table.Column<string>(type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "coverphoto",
                schema: "lovedmemory",
                columns: table => new
                {
                    coverphotoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    imageurl = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false),
                    width = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coverphoto", x => x.coverphotoid);
                });

            migrationBuilder.CreateTable(
                name: "eventdetails",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tributeid = table.Column<int>(type: "integer", nullable: false),
                    eventdate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    eventlocation = table.Column<string>(type: "text", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_eventdetails", x => x.id);
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
                    roleid = table.Column<string>(type: "text", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroleclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetroleclaims_aspnetroles_roleid",
                        column: x => x.roleid,
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
                    userid = table.Column<string>(type: "text", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetuserclaims_aspnetusers_userid",
                        column: x => x.userid,
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
                    loginprovider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    providerkey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    providerdisplayname = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserlogins", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "fk_aspnetuserlogins_aspnetusers_userid",
                        column: x => x.userid,
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
                    userid = table.Column<string>(type: "text", nullable: false),
                    roleid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserroles", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetusers_userid",
                        column: x => x.userid,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusertokens",
                schema: "lovedmemory",
                columns: table => new
                {
                    userid = table.Column<string>(type: "text", nullable: false),
                    loginprovider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusertokens", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "fk_aspnetusertokens_aspnetusers_userid",
                        column: x => x.userid,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tributes",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    viewcount = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    personalphrase = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    othernames = table.Column<string>(type: "text", nullable: false),
                    about = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    slug = table.Column<string>(type: "text", nullable: false),
                    template = table.Column<string>(type: "text", nullable: false),
                    mainimageurl = table.Column<string>(type: "text", nullable: false),
                    edited = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    rundate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    published = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    isprivate = table.Column<bool>(type: "boolean", nullable: false),
                    coverphotoid = table.Column<int>(type: "integer", nullable: false),
                    createdbyuserid = table.Column<string>(type: "text", nullable: false),
                    lastmodified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lastmodifiedbyuserid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tributes", x => x.id);
                    table.ForeignKey(
                        name: "FK_tributes_aspnetusers_createdbyuserid",
                        column: x => x.createdbyuserid,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tributes_coverphoto_coverphotoid",
                        column: x => x.coverphotoid,
                        principalSchema: "lovedmemory",
                        principalTable: "coverphoto",
                        principalColumn: "coverphotoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rolepermissions",
                schema: "lovedmemory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<string>(type: "text", nullable: false),
                    permissionid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rolepermissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_rolepermissions_permissions_permissionid",
                        column: x => x.permissionid,
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
                    tributeid = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    tags = table.Column<string>(type: "text", nullable: false),
                    userid = table.Column<string>(type: "text", nullable: false),
                    addedbyid = table.Column<string>(type: "text", nullable: false),
                    added = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audio", x => x.id);
                    table.ForeignKey(
                        name: "fk_audio_aspnetusers_addedbyid",
                        column: x => x.addedbyid,
                        principalSchema: "lovedmemory",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_audio_tributes_tributeid",
                        column: x => x.tributeid,
                        principalSchema: "lovedmemory",
                        principalTable: "tributes",
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
                    tributeid = table.Column<int>(type: "integer", nullable: false),
                    treelevel = table.Column<int>(type: "integer", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    visible = table.Column<bool>(type: "boolean", nullable: false),
                    edited = table.Column<bool>(type: "boolean", nullable: false),
                    parentcommentid = table.Column<int>(type: "integer", nullable: true),
                    commentid = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    createdbyuserid = table.Column<string>(type: "text", nullable: false),
                    lastmodified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lastmodifiedbyuserid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.id);
                    table.ForeignKey(
                        name: "fk_comments_comments_commentid",
                        column: x => x.commentid,
                        principalSchema: "lovedmemory",
                        principalTable: "comments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_comments_tributes_tributeid",
                        column: x => x.tributeid,
                        principalSchema: "lovedmemory",
                        principalTable: "tributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gallery",
                schema: "lovedmemory",
                columns: table => new
                {
                    tributeid = table.Column<int>(type: "integer", nullable: false),
                    mediaurl = table.Column<string>(type: "text", nullable: false),
                    mediatype = table.Column<int>(type: "integer", nullable: false),
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
                name: "lifestory",
                schema: "tributes",
                columns: table => new
                {
                    tributeid = table.Column<int>(type: "integer", nullable: false),
                    storysection = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    story = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lifestory", x => x.tributeid);
                    table.ForeignKey(
                        name: "fk_lifestory_tributes_tributeid",
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
                    relationship = table.Column<int>(type: "integer", nullable: false),
                    dateofbirth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    dateofdeath = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    birthcountry = table.Column<string>(type: "text", nullable: true),
                    deathcountry = table.Column<string>(type: "text", nullable: false),
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
                name: "IX_aspnetroleclaims_roleid",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "lovedmemory",
                table: "aspnetroles",
                column: "normalizedname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserclaims_userid",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserlogins_userid",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserroles_roleid",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "lovedmemory",
                table: "aspnetusers",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "lovedmemory",
                table: "aspnetusers",
                column: "normalizedusername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_audio_addedbyid",
                schema: "lovedmemory",
                table: "audio",
                column: "addedbyid");

            migrationBuilder.CreateIndex(
                name: "IX_audio_tributeid",
                schema: "lovedmemory",
                table: "audio",
                column: "tributeid");

            migrationBuilder.CreateIndex(
                name: "IX_comments_commentid",
                schema: "lovedmemory",
                table: "comments",
                column: "commentid");

            migrationBuilder.CreateIndex(
                name: "IX_comments_tributeid",
                schema: "lovedmemory",
                table: "comments",
                column: "tributeid");

            migrationBuilder.CreateIndex(
                name: "IX_gallery_addedbyid",
                schema: "lovedmemory",
                table: "gallery",
                column: "addedbyid");

            migrationBuilder.CreateIndex(
                name: "IX_rolepermissions_permissionid",
                schema: "lovedmemory",
                table: "rolepermissions",
                column: "permissionid");

            migrationBuilder.CreateIndex(
                name: "IX_tributes_coverphotoid",
                schema: "lovedmemory",
                table: "tributes",
                column: "coverphotoid");

            migrationBuilder.CreateIndex(
                name: "IX_tributes_createdbyuserid",
                schema: "lovedmemory",
                table: "tributes",
                column: "createdbyuserid");
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
                name: "eventdetails",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "gallery",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "lifestory",
                schema: "tributes");

            migrationBuilder.DropTable(
                name: "rolepermissions",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "tributedetails",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "aspnetroles",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "tributes",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "aspnetusers",
                schema: "lovedmemory");

            migrationBuilder.DropTable(
                name: "coverphoto",
                schema: "lovedmemory");
        }
    }
}
