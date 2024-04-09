using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lovedmemory.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class lowercase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "lovedmemory",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "lovedmemory",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "lovedmemory",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "lovedmemory",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "lovedmemory",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "lovedmemory",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_comments_CommentId",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_tributes_TributeId",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tributes",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_eventdetails",
                schema: "lovedmemory",
                table: "eventdetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "lovedmemory",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                schema: "lovedmemory",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                schema: "lovedmemory",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                schema: "lovedmemory",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                schema: "lovedmemory",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                schema: "lovedmemory",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                schema: "lovedmemory",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "lovedmemory",
                newName: "aspnetusers",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "lovedmemory",
                newName: "aspnetusertokens",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "lovedmemory",
                newName: "aspnetuserroles",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "lovedmemory",
                newName: "aspnetuserlogins",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "lovedmemory",
                newName: "aspnetuserclaims",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "lovedmemory",
                newName: "aspnetroles",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "lovedmemory",
                newName: "aspnetroleclaims",
                newSchema: "lovedmemory");

            migrationBuilder.RenameColumn(
                name: "ViewCount",
                schema: "lovedmemory",
                table: "tributes",
                newName: "viewcount");

            migrationBuilder.RenameColumn(
                name: "Slug",
                schema: "lovedmemory",
                table: "tributes",
                newName: "slug");

            migrationBuilder.RenameColumn(
                name: "RunDate",
                schema: "lovedmemory",
                table: "tributes",
                newName: "rundate");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                schema: "lovedmemory",
                table: "tributes",
                newName: "ownerid");

            migrationBuilder.RenameColumn(
                name: "NickName",
                schema: "lovedmemory",
                table: "tributes",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "lovedmemory",
                table: "tributes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MainImageUrl",
                schema: "lovedmemory",
                table: "tributes",
                newName: "mainimageurl");

            migrationBuilder.RenameColumn(
                name: "Edited",
                schema: "lovedmemory",
                table: "tributes",
                newName: "edited");

            migrationBuilder.RenameColumn(
                name: "Created",
                schema: "lovedmemory",
                table: "tributes",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Active",
                schema: "lovedmemory",
                table: "tributes",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "lovedmemory",
                table: "tributes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TributeId",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "tributeid");

            migrationBuilder.RenameColumn(
                name: "EventLocation",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "eventlocation");

            migrationBuilder.RenameColumn(
                name: "EventDate",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "eventdate");

            migrationBuilder.RenameColumn(
                name: "Details",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "details");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Visible",
                schema: "lovedmemory",
                table: "comments",
                newName: "visible");

            migrationBuilder.RenameColumn(
                name: "TributeId",
                schema: "lovedmemory",
                table: "comments",
                newName: "tributeid");

            migrationBuilder.RenameColumn(
                name: "Details",
                schema: "lovedmemory",
                table: "comments",
                newName: "details");

            migrationBuilder.RenameColumn(
                name: "DatePosted",
                schema: "lovedmemory",
                table: "comments",
                newName: "dateposted");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                schema: "lovedmemory",
                table: "comments",
                newName: "commentid");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "lovedmemory",
                table: "comments",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_comments_TributeId",
                schema: "lovedmemory",
                table: "comments",
                newName: "IX_comments_tributeid");

            migrationBuilder.RenameIndex(
                name: "IX_comments_CommentId",
                schema: "lovedmemory",
                table: "comments",
                newName: "IX_comments_commentid");

            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "twofactorenabled");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "securitystamp");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberConfirmed",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "phonenumberconfirmed");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "passwordhash");

            migrationBuilder.RenameColumn(
                name: "OtherName",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "othername");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "normalizedusername");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmail",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "normalizedemail");

            migrationBuilder.RenameColumn(
                name: "NickName",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "lockoutend");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "lockoutenabled");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "emailconfirmed");

            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "accessfailedcount");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                newName: "loginprovider");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                newName: "IX_aspnetuserroles_roleid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "ProviderDisplayName",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "providerdisplayname");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "providerkey");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "loginprovider");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "IX_aspnetuserlogins_userid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "claimtype");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "IX_aspnetuserclaims_userid");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                schema: "lovedmemory",
                table: "aspnetroles",
                newName: "normalizedname");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "lovedmemory",
                table: "aspnetroles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                schema: "lovedmemory",
                table: "aspnetroles",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "lovedmemory",
                table: "aspnetroles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "claimtype");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "IX_aspnetroleclaims_roleid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tributes",
                schema: "lovedmemory",
                table: "tributes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_eventdetails",
                schema: "lovedmemory",
                table: "eventdetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_comments",
                schema: "lovedmemory",
                table: "comments",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetusers",
                schema: "lovedmemory",
                table: "aspnetusers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetusertokens",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                columns: new[] { "userid", "loginprovider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetuserroles",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                columns: new[] { "userid", "roleid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetuserlogins",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                columns: new[] { "loginprovider", "providerkey" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetuserclaims",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetroles",
                schema: "lovedmemory",
                table: "aspnetroles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetroleclaims",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetroleclaims_aspnetroles_roleid",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                column: "roleid",
                principalSchema: "lovedmemory",
                principalTable: "aspnetroles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserclaims_aspnetusers_userid",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                column: "userid",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserlogins_aspnetusers_userid",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                column: "userid",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserroles_aspnetroles_roleid",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                column: "roleid",
                principalSchema: "lovedmemory",
                principalTable: "aspnetroles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserroles_aspnetusers_userid",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                column: "userid",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetusertokens_aspnetusers_userid",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                column: "userid",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_comments_comments_commentid",
                schema: "lovedmemory",
                table: "comments",
                column: "commentid",
                principalSchema: "lovedmemory",
                principalTable: "comments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_tributes_tributeid",
                schema: "lovedmemory",
                table: "comments",
                column: "tributeid",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_aspnetroleclaims_aspnetroles_roleid",
                schema: "lovedmemory",
                table: "aspnetroleclaims");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserclaims_aspnetusers_userid",
                schema: "lovedmemory",
                table: "aspnetuserclaims");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserlogins_aspnetusers_userid",
                schema: "lovedmemory",
                table: "aspnetuserlogins");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserroles_aspnetroles_roleid",
                schema: "lovedmemory",
                table: "aspnetuserroles");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserroles_aspnetusers_userid",
                schema: "lovedmemory",
                table: "aspnetuserroles");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetusertokens_aspnetusers_userid",
                schema: "lovedmemory",
                table: "aspnetusertokens");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_comments_commentid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_tributes_tributeid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tributes",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_eventdetails",
                schema: "lovedmemory",
                table: "eventdetails");

            migrationBuilder.DropPrimaryKey(
                name: "pk_comments",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetusertokens",
                schema: "lovedmemory",
                table: "aspnetusertokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetusers",
                schema: "lovedmemory",
                table: "aspnetusers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetuserroles",
                schema: "lovedmemory",
                table: "aspnetuserroles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetuserlogins",
                schema: "lovedmemory",
                table: "aspnetuserlogins");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetuserclaims",
                schema: "lovedmemory",
                table: "aspnetuserclaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetroles",
                schema: "lovedmemory",
                table: "aspnetroles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetroleclaims",
                schema: "lovedmemory",
                table: "aspnetroleclaims");

            migrationBuilder.RenameTable(
                name: "aspnetusertokens",
                schema: "lovedmemory",
                newName: "AspNetUserTokens",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "aspnetusers",
                schema: "lovedmemory",
                newName: "AspNetUsers",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "aspnetuserroles",
                schema: "lovedmemory",
                newName: "AspNetUserRoles",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "aspnetuserlogins",
                schema: "lovedmemory",
                newName: "AspNetUserLogins",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "aspnetuserclaims",
                schema: "lovedmemory",
                newName: "AspNetUserClaims",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "aspnetroles",
                schema: "lovedmemory",
                newName: "AspNetRoles",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "aspnetroleclaims",
                schema: "lovedmemory",
                newName: "AspNetRoleClaims",
                newSchema: "lovedmemory");

            migrationBuilder.RenameColumn(
                name: "viewcount",
                schema: "lovedmemory",
                table: "tributes",
                newName: "ViewCount");

            migrationBuilder.RenameColumn(
                name: "slug",
                schema: "lovedmemory",
                table: "tributes",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "rundate",
                schema: "lovedmemory",
                table: "tributes",
                newName: "RunDate");

            migrationBuilder.RenameColumn(
                name: "ownerid",
                schema: "lovedmemory",
                table: "tributes",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "nickname",
                schema: "lovedmemory",
                table: "tributes",
                newName: "NickName");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "lovedmemory",
                table: "tributes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "mainimageurl",
                schema: "lovedmemory",
                table: "tributes",
                newName: "MainImageUrl");

            migrationBuilder.RenameColumn(
                name: "edited",
                schema: "lovedmemory",
                table: "tributes",
                newName: "Edited");

            migrationBuilder.RenameColumn(
                name: "created",
                schema: "lovedmemory",
                table: "tributes",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "active",
                schema: "lovedmemory",
                table: "tributes",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "lovedmemory",
                table: "tributes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tributeid",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "TributeId");

            migrationBuilder.RenameColumn(
                name: "eventlocation",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "EventLocation");

            migrationBuilder.RenameColumn(
                name: "eventdate",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "EventDate");

            migrationBuilder.RenameColumn(
                name: "details",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "visible",
                schema: "lovedmemory",
                table: "comments",
                newName: "Visible");

            migrationBuilder.RenameColumn(
                name: "tributeid",
                schema: "lovedmemory",
                table: "comments",
                newName: "TributeId");

            migrationBuilder.RenameColumn(
                name: "details",
                schema: "lovedmemory",
                table: "comments",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "dateposted",
                schema: "lovedmemory",
                table: "comments",
                newName: "DatePosted");

            migrationBuilder.RenameColumn(
                name: "commentid",
                schema: "lovedmemory",
                table: "comments",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "lovedmemory",
                table: "comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_comments_tributeid",
                schema: "lovedmemory",
                table: "comments",
                newName: "IX_comments_TributeId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_commentid",
                schema: "lovedmemory",
                table: "comments",
                newName: "IX_comments_CommentId");

            migrationBuilder.RenameColumn(
                name: "value",
                schema: "lovedmemory",
                table: "AspNetUserTokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "lovedmemory",
                table: "AspNetUserTokens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "loginprovider",
                schema: "lovedmemory",
                table: "AspNetUserTokens",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "lovedmemory",
                table: "AspNetUserTokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "username",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "twofactorenabled",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "securitystamp",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "phonenumberconfirmed",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "passwordhash",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "othername",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "OtherName");

            migrationBuilder.RenameColumn(
                name: "normalizedusername",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "normalizedemail",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "NormalizedEmail");

            migrationBuilder.RenameColumn(
                name: "nickname",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "NickName");

            migrationBuilder.RenameColumn(
                name: "lockoutend",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "lockoutenabled",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "lastname",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "emailconfirmed",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "email",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "accessfailedcount",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "lovedmemory",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "roleid",
                schema: "lovedmemory",
                table: "AspNetUserRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "lovedmemory",
                table: "AspNetUserRoles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_aspnetuserroles_roleid",
                schema: "lovedmemory",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "lovedmemory",
                table: "AspNetUserLogins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "providerdisplayname",
                schema: "lovedmemory",
                table: "AspNetUserLogins",
                newName: "ProviderDisplayName");

            migrationBuilder.RenameColumn(
                name: "providerkey",
                schema: "lovedmemory",
                table: "AspNetUserLogins",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "loginprovider",
                schema: "lovedmemory",
                table: "AspNetUserLogins",
                newName: "LoginProvider");

            migrationBuilder.RenameIndex(
                name: "IX_aspnetuserlogins_userid",
                schema: "lovedmemory",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "lovedmemory",
                table: "AspNetUserClaims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                schema: "lovedmemory",
                table: "AspNetUserClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                schema: "lovedmemory",
                table: "AspNetUserClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "lovedmemory",
                table: "AspNetUserClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_aspnetuserclaims_userid",
                schema: "lovedmemory",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "normalizedname",
                schema: "lovedmemory",
                table: "AspNetRoles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "lovedmemory",
                table: "AspNetRoles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                schema: "lovedmemory",
                table: "AspNetRoles",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "lovedmemory",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "roleid",
                schema: "lovedmemory",
                table: "AspNetRoleClaims",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                schema: "lovedmemory",
                table: "AspNetRoleClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                schema: "lovedmemory",
                table: "AspNetRoleClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "lovedmemory",
                table: "AspNetRoleClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_aspnetroleclaims_roleid",
                schema: "lovedmemory",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tributes",
                schema: "lovedmemory",
                table: "tributes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_eventdetails",
                schema: "lovedmemory",
                table: "eventdetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                schema: "lovedmemory",
                table: "comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                schema: "lovedmemory",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "lovedmemory",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                schema: "lovedmemory",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                schema: "lovedmemory",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                schema: "lovedmemory",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                schema: "lovedmemory",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                schema: "lovedmemory",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "lovedmemory",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "lovedmemory",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "lovedmemory",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "lovedmemory",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "lovedmemory",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "lovedmemory",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "lovedmemory",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "lovedmemory",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "lovedmemory",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "lovedmemory",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "lovedmemory",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "lovedmemory",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_comments_CommentId",
                schema: "lovedmemory",
                table: "comments",
                column: "CommentId",
                principalSchema: "lovedmemory",
                principalTable: "comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_tributes_TributeId",
                schema: "lovedmemory",
                table: "comments",
                column: "TributeId",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
