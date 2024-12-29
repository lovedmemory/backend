using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lovedmemory.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "fk_audio_aspnetusers_addedbyid",
                schema: "lovedmemory",
                table: "audio");

            migrationBuilder.DropForeignKey(
                name: "fk_audio_tributes_tributeid",
                schema: "lovedmemory",
                table: "audio");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_comments_commentid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_tributes_tributeid",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_gallary_aspnetusers_addedbyid",
                schema: "lovedmemory",
                table: "gallery");

            migrationBuilder.DropForeignKey(
                name: "fk_gallary_tributes_tributeid",
                schema: "lovedmemory",
                table: "gallery");

            migrationBuilder.DropForeignKey(
                name: "fk_lifestory_tributes_tributeid",
                schema: "tributes",
                table: "lifestory");

            migrationBuilder.DropForeignKey(
                name: "fk_rolepermissions_permissions_permissionid",
                schema: "lovedmemory",
                table: "rolepermissions");

            migrationBuilder.DropForeignKey(
                name: "fk_tributedetails_tributes_tributeid",
                schema: "lovedmemory",
                table: "tributedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_tributes_aspnetusers_createdbyuserid",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.DropForeignKey(
                name: "fk_tributes_coverphoto_coverphotoid",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tributedetails",
                schema: "lovedmemory",
                table: "tributedetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lifestory",
                schema: "tributes",
                table: "lifestory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gallery",
                schema: "lovedmemory",
                table: "gallery");

            migrationBuilder.DropPrimaryKey(
                name: "pk_eventdetails",
                schema: "lovedmemory",
                table: "eventdetails");

            migrationBuilder.DropPrimaryKey(
                name: "pk_rolepermissions",
                schema: "lovedmemory",
                table: "rolepermissions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_coverphoto",
                schema: "lovedmemory",
                table: "coverphoto");

            migrationBuilder.RenameTable(
                name: "rolepermissions",
                schema: "lovedmemory",
                newName: "role_permissions",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "coverphoto",
                schema: "lovedmemory",
                newName: "cover_photo",
                newSchema: "lovedmemory");

            migrationBuilder.RenameColumn(
                name: "viewcount",
                schema: "lovedmemory",
                table: "tributes",
                newName: "view_count");

            migrationBuilder.RenameColumn(
                name: "rundate",
                schema: "lovedmemory",
                table: "tributes",
                newName: "run_date");

            migrationBuilder.RenameColumn(
                name: "personalphrase",
                schema: "lovedmemory",
                table: "tributes",
                newName: "personal_phrase");

            migrationBuilder.RenameColumn(
                name: "othernames",
                schema: "lovedmemory",
                table: "tributes",
                newName: "other_names");

            migrationBuilder.RenameColumn(
                name: "mainimageurl",
                schema: "lovedmemory",
                table: "tributes",
                newName: "main_image_url");

            migrationBuilder.RenameColumn(
                name: "lastname",
                schema: "lovedmemory",
                table: "tributes",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "lastmodifiedbyuserid",
                schema: "lovedmemory",
                table: "tributes",
                newName: "last_modified_by_user_id");

            migrationBuilder.RenameColumn(
                name: "lastmodified",
                schema: "lovedmemory",
                table: "tributes",
                newName: "last_modified");

            migrationBuilder.RenameColumn(
                name: "isprivate",
                schema: "lovedmemory",
                table: "tributes",
                newName: "is_private");

            migrationBuilder.RenameColumn(
                name: "firstname",
                schema: "lovedmemory",
                table: "tributes",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "createdbyuserid",
                schema: "lovedmemory",
                table: "tributes",
                newName: "created_by_user_id");

            migrationBuilder.RenameColumn(
                name: "coverphotoid",
                schema: "lovedmemory",
                table: "tributes",
                newName: "cover_photo_id");

            migrationBuilder.RenameIndex(
                name: "IX_tributes_createdbyuserid",
                schema: "lovedmemory",
                table: "tributes",
                newName: "ix_tributes_created_by_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_tributes_coverphotoid",
                schema: "lovedmemory",
                table: "tributes",
                newName: "ix_tributes_cover_photo_id");

            migrationBuilder.RenameColumn(
                name: "nickname",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "nick_name");

            migrationBuilder.RenameColumn(
                name: "lifestory",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "life_story");

            migrationBuilder.RenameColumn(
                name: "deathcountry",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "death_country");

            migrationBuilder.RenameColumn(
                name: "dateofdeath",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "date_of_death");

            migrationBuilder.RenameColumn(
                name: "dateofbirth",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "date_of_birth");

            migrationBuilder.RenameColumn(
                name: "birthcountry",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "birth_country");

            migrationBuilder.RenameColumn(
                name: "tributeid",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "tribute_id");

            migrationBuilder.RenameColumn(
                name: "storysection",
                schema: "tributes",
                table: "lifestory",
                newName: "story_section");

            migrationBuilder.RenameColumn(
                name: "tributeid",
                schema: "tributes",
                table: "lifestory",
                newName: "tribute_id");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "lovedmemory",
                table: "gallery",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "mediaurl",
                schema: "lovedmemory",
                table: "gallery",
                newName: "media_url");

            migrationBuilder.RenameColumn(
                name: "mediatype",
                schema: "lovedmemory",
                table: "gallery",
                newName: "media_type");

            migrationBuilder.RenameColumn(
                name: "mediatitle",
                schema: "lovedmemory",
                table: "gallery",
                newName: "media_title");

            migrationBuilder.RenameColumn(
                name: "addedbyid",
                schema: "lovedmemory",
                table: "gallery",
                newName: "added_by_id");

            migrationBuilder.RenameColumn(
                name: "tributeid",
                schema: "lovedmemory",
                table: "gallery",
                newName: "tribute_id");

            migrationBuilder.RenameIndex(
                name: "IX_gallery_addedbyid",
                schema: "lovedmemory",
                table: "gallery",
                newName: "ix_gallery_added_by_id");

            migrationBuilder.RenameColumn(
                name: "tributeid",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "tribute_id");

            migrationBuilder.RenameColumn(
                name: "eventlocation",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "event_location");

            migrationBuilder.RenameColumn(
                name: "eventdate",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "event_date");

            migrationBuilder.RenameColumn(
                name: "tributeid",
                schema: "lovedmemory",
                table: "comments",
                newName: "tribute_id");

            migrationBuilder.RenameColumn(
                name: "treelevel",
                schema: "lovedmemory",
                table: "comments",
                newName: "tree_level");

            migrationBuilder.RenameColumn(
                name: "parentcommentid",
                schema: "lovedmemory",
                table: "comments",
                newName: "parent_comment_id");

            migrationBuilder.RenameColumn(
                name: "lastmodifiedbyuserid",
                schema: "lovedmemory",
                table: "comments",
                newName: "last_modified_by_user_id");

            migrationBuilder.RenameColumn(
                name: "lastmodified",
                schema: "lovedmemory",
                table: "comments",
                newName: "last_modified");

            migrationBuilder.RenameColumn(
                name: "createdbyuserid",
                schema: "lovedmemory",
                table: "comments",
                newName: "created_by_user_id");

            migrationBuilder.RenameColumn(
                name: "commentid",
                schema: "lovedmemory",
                table: "comments",
                newName: "comment_id");

            migrationBuilder.RenameIndex(
                name: "IX_comments_tributeid",
                schema: "lovedmemory",
                table: "comments",
                newName: "ix_comments_tribute_id");

            migrationBuilder.RenameIndex(
                name: "IX_comments_commentid",
                schema: "lovedmemory",
                table: "comments",
                newName: "ix_comments_comment_id");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "lovedmemory",
                table: "audio",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "tributeid",
                schema: "lovedmemory",
                table: "audio",
                newName: "tribute_id");

            migrationBuilder.RenameColumn(
                name: "addedbyid",
                schema: "lovedmemory",
                table: "audio",
                newName: "added_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_audio_tributeid",
                schema: "lovedmemory",
                table: "audio",
                newName: "ix_audio_tribute_id");

            migrationBuilder.RenameIndex(
                name: "IX_audio_addedbyid",
                schema: "lovedmemory",
                table: "audio",
                newName: "ix_audio_added_by_id");

            migrationBuilder.RenameColumn(
                name: "loginprovider",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                newName: "login_provider");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "username",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "twofactorenabled",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "two_factor_enabled");

            migrationBuilder.RenameColumn(
                name: "securitystamp",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "security_stamp");

            migrationBuilder.RenameColumn(
                name: "phonenumberconfirmed",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "phone_number_confirmed");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "passwordhash",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "othername",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "other_name");

            migrationBuilder.RenameColumn(
                name: "normalizedusername",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "normalized_user_name");

            migrationBuilder.RenameColumn(
                name: "normalizedemail",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "normalized_email");

            migrationBuilder.RenameColumn(
                name: "nickname",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "nick_name");

            migrationBuilder.RenameColumn(
                name: "lockoutend",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "lockout_end");

            migrationBuilder.RenameColumn(
                name: "lockoutenabled",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "lockout_enabled");

            migrationBuilder.RenameColumn(
                name: "lastname",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "firstname",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "emailconfirmed",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "email_confirmed");

            migrationBuilder.RenameColumn(
                name: "countrycode",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "country_code");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "accessfailedcount",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "access_failed_count");

            migrationBuilder.RenameColumn(
                name: "roleid",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_aspnetuserroles_roleid",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                newName: "ix_aspnetuserroles_role_id");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "providerdisplayname",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "provider_display_name");

            migrationBuilder.RenameColumn(
                name: "providerkey",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "provider_key");

            migrationBuilder.RenameColumn(
                name: "loginprovider",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "login_provider");

            migrationBuilder.RenameIndex(
                name: "IX_aspnetuserlogins_userid",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "ix_aspnetuserlogins_user_id");

            migrationBuilder.RenameColumn(
                name: "userid",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_aspnetuserclaims_userid",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "ix_aspnetuserclaims_user_id");

            migrationBuilder.RenameColumn(
                name: "normalizedname",
                schema: "lovedmemory",
                table: "aspnetroles",
                newName: "normalized_name");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                schema: "lovedmemory",
                table: "aspnetroles",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "roleid",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_aspnetroleclaims_roleid",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "ix_aspnetroleclaims_role_id");

            migrationBuilder.RenameColumn(
                name: "roleid",
                schema: "lovedmemory",
                table: "role_permissions",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "permissionid",
                schema: "lovedmemory",
                table: "role_permissions",
                newName: "permission_id");

            migrationBuilder.RenameIndex(
                name: "IX_rolepermissions_permissionid",
                schema: "lovedmemory",
                table: "role_permissions",
                newName: "ix_role_permissions_permission_id");

            migrationBuilder.RenameColumn(
                name: "imageurl",
                schema: "lovedmemory",
                table: "cover_photo",
                newName: "image_url");

            migrationBuilder.RenameColumn(
                name: "coverphotoid",
                schema: "lovedmemory",
                table: "cover_photo",
                newName: "cover_photo_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tributedetails",
                schema: "lovedmemory",
                table: "tributedetails",
                column: "tribute_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_lifestory",
                schema: "tributes",
                table: "lifestory",
                column: "tribute_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_gallery",
                schema: "lovedmemory",
                table: "gallery",
                column: "tribute_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_event_details",
                schema: "lovedmemory",
                table: "eventdetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role_permissions",
                schema: "lovedmemory",
                table: "role_permissions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cover_photo",
                schema: "lovedmemory",
                table: "cover_photo",
                column: "cover_photo_id");

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetroleclaims_aspnetroles_role_id",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                column: "role_id",
                principalSchema: "lovedmemory",
                principalTable: "aspnetroles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserclaims_asp_net_users_user_id",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                column: "user_id",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserlogins_asp_net_users_user_id",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                column: "user_id",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserroles_asp_net_users_user_id",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                column: "user_id",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserroles_aspnetroles_role_id",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                column: "role_id",
                principalSchema: "lovedmemory",
                principalTable: "aspnetroles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetusertokens_asp_net_users_user_id",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                column: "user_id",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_audio_tributes_tribute_id",
                schema: "lovedmemory",
                table: "audio",
                column: "tribute_id",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_audio_users_added_by_id",
                schema: "lovedmemory",
                table: "audio",
                column: "added_by_id",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_comments_comments_comment_id",
                schema: "lovedmemory",
                table: "comments",
                column: "comment_id",
                principalSchema: "lovedmemory",
                principalTable: "comments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_tributes_tribute_id",
                schema: "lovedmemory",
                table: "comments",
                column: "tribute_id",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_gallary_tributes_tribute_id",
                schema: "lovedmemory",
                table: "gallery",
                column: "tribute_id",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_gallary_users_added_by_id",
                schema: "lovedmemory",
                table: "gallery",
                column: "added_by_id",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_life_story_tributes_tribute_id",
                schema: "tributes",
                table: "lifestory",
                column: "tribute_id",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_permissions_permissions_permission_id",
                schema: "lovedmemory",
                table: "role_permissions",
                column: "permission_id",
                principalSchema: "lovedmemory",
                principalTable: "permissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tribute_details_tributes_tribute_id",
                schema: "lovedmemory",
                table: "tributedetails",
                column: "tribute_id",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tributes_aspnetusers_created_by_user_id",
                schema: "lovedmemory",
                table: "tributes",
                column: "created_by_user_id",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_tributes_cover_photo_cover_photo_id",
                schema: "lovedmemory",
                table: "tributes",
                column: "cover_photo_id",
                principalSchema: "lovedmemory",
                principalTable: "cover_photo",
                principalColumn: "cover_photo_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_aspnetroleclaims_aspnetroles_role_id",
                schema: "lovedmemory",
                table: "aspnetroleclaims");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserclaims_asp_net_users_user_id",
                schema: "lovedmemory",
                table: "aspnetuserclaims");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserlogins_asp_net_users_user_id",
                schema: "lovedmemory",
                table: "aspnetuserlogins");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserroles_asp_net_users_user_id",
                schema: "lovedmemory",
                table: "aspnetuserroles");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserroles_aspnetroles_role_id",
                schema: "lovedmemory",
                table: "aspnetuserroles");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetusertokens_asp_net_users_user_id",
                schema: "lovedmemory",
                table: "aspnetusertokens");

            migrationBuilder.DropForeignKey(
                name: "fk_audio_tributes_tribute_id",
                schema: "lovedmemory",
                table: "audio");

            migrationBuilder.DropForeignKey(
                name: "fk_audio_users_added_by_id",
                schema: "lovedmemory",
                table: "audio");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_comments_comment_id",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_tributes_tribute_id",
                schema: "lovedmemory",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_gallary_tributes_tribute_id",
                schema: "lovedmemory",
                table: "gallery");

            migrationBuilder.DropForeignKey(
                name: "fk_gallary_users_added_by_id",
                schema: "lovedmemory",
                table: "gallery");

            migrationBuilder.DropForeignKey(
                name: "fk_life_story_tributes_tribute_id",
                schema: "tributes",
                table: "lifestory");

            migrationBuilder.DropForeignKey(
                name: "fk_role_permissions_permissions_permission_id",
                schema: "lovedmemory",
                table: "role_permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_tribute_details_tributes_tribute_id",
                schema: "lovedmemory",
                table: "tributedetails");

            migrationBuilder.DropForeignKey(
                name: "fk_tributes_aspnetusers_created_by_user_id",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.DropForeignKey(
                name: "fk_tributes_cover_photo_cover_photo_id",
                schema: "lovedmemory",
                table: "tributes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tributedetails",
                schema: "lovedmemory",
                table: "tributedetails");

            migrationBuilder.DropPrimaryKey(
                name: "pk_lifestory",
                schema: "tributes",
                table: "lifestory");

            migrationBuilder.DropPrimaryKey(
                name: "pk_gallery",
                schema: "lovedmemory",
                table: "gallery");

            migrationBuilder.DropPrimaryKey(
                name: "pk_event_details",
                schema: "lovedmemory",
                table: "eventdetails");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role_permissions",
                schema: "lovedmemory",
                table: "role_permissions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cover_photo",
                schema: "lovedmemory",
                table: "cover_photo");

            migrationBuilder.RenameTable(
                name: "role_permissions",
                schema: "lovedmemory",
                newName: "rolepermissions",
                newSchema: "lovedmemory");

            migrationBuilder.RenameTable(
                name: "cover_photo",
                schema: "lovedmemory",
                newName: "coverphoto",
                newSchema: "lovedmemory");

            migrationBuilder.RenameColumn(
                name: "view_count",
                schema: "lovedmemory",
                table: "tributes",
                newName: "viewcount");

            migrationBuilder.RenameColumn(
                name: "run_date",
                schema: "lovedmemory",
                table: "tributes",
                newName: "rundate");

            migrationBuilder.RenameColumn(
                name: "personal_phrase",
                schema: "lovedmemory",
                table: "tributes",
                newName: "personalphrase");

            migrationBuilder.RenameColumn(
                name: "other_names",
                schema: "lovedmemory",
                table: "tributes",
                newName: "othernames");

            migrationBuilder.RenameColumn(
                name: "main_image_url",
                schema: "lovedmemory",
                table: "tributes",
                newName: "mainimageurl");

            migrationBuilder.RenameColumn(
                name: "last_name",
                schema: "lovedmemory",
                table: "tributes",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "last_modified_by_user_id",
                schema: "lovedmemory",
                table: "tributes",
                newName: "lastmodifiedbyuserid");

            migrationBuilder.RenameColumn(
                name: "last_modified",
                schema: "lovedmemory",
                table: "tributes",
                newName: "lastmodified");

            migrationBuilder.RenameColumn(
                name: "is_private",
                schema: "lovedmemory",
                table: "tributes",
                newName: "isprivate");

            migrationBuilder.RenameColumn(
                name: "first_name",
                schema: "lovedmemory",
                table: "tributes",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "created_by_user_id",
                schema: "lovedmemory",
                table: "tributes",
                newName: "createdbyuserid");

            migrationBuilder.RenameColumn(
                name: "cover_photo_id",
                schema: "lovedmemory",
                table: "tributes",
                newName: "coverphotoid");

            migrationBuilder.RenameIndex(
                name: "ix_tributes_created_by_user_id",
                schema: "lovedmemory",
                table: "tributes",
                newName: "IX_tributes_createdbyuserid");

            migrationBuilder.RenameIndex(
                name: "ix_tributes_cover_photo_id",
                schema: "lovedmemory",
                table: "tributes",
                newName: "IX_tributes_coverphotoid");

            migrationBuilder.RenameColumn(
                name: "nick_name",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "life_story",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "lifestory");

            migrationBuilder.RenameColumn(
                name: "death_country",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "deathcountry");

            migrationBuilder.RenameColumn(
                name: "date_of_death",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "dateofdeath");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "dateofbirth");

            migrationBuilder.RenameColumn(
                name: "birth_country",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "birthcountry");

            migrationBuilder.RenameColumn(
                name: "tribute_id",
                schema: "lovedmemory",
                table: "tributedetails",
                newName: "tributeid");

            migrationBuilder.RenameColumn(
                name: "story_section",
                schema: "tributes",
                table: "lifestory",
                newName: "storysection");

            migrationBuilder.RenameColumn(
                name: "tribute_id",
                schema: "tributes",
                table: "lifestory",
                newName: "tributeid");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "lovedmemory",
                table: "gallery",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "media_url",
                schema: "lovedmemory",
                table: "gallery",
                newName: "mediaurl");

            migrationBuilder.RenameColumn(
                name: "media_type",
                schema: "lovedmemory",
                table: "gallery",
                newName: "mediatype");

            migrationBuilder.RenameColumn(
                name: "media_title",
                schema: "lovedmemory",
                table: "gallery",
                newName: "mediatitle");

            migrationBuilder.RenameColumn(
                name: "added_by_id",
                schema: "lovedmemory",
                table: "gallery",
                newName: "addedbyid");

            migrationBuilder.RenameColumn(
                name: "tribute_id",
                schema: "lovedmemory",
                table: "gallery",
                newName: "tributeid");

            migrationBuilder.RenameIndex(
                name: "ix_gallery_added_by_id",
                schema: "lovedmemory",
                table: "gallery",
                newName: "IX_gallery_addedbyid");

            migrationBuilder.RenameColumn(
                name: "tribute_id",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "tributeid");

            migrationBuilder.RenameColumn(
                name: "event_location",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "eventlocation");

            migrationBuilder.RenameColumn(
                name: "event_date",
                schema: "lovedmemory",
                table: "eventdetails",
                newName: "eventdate");

            migrationBuilder.RenameColumn(
                name: "tribute_id",
                schema: "lovedmemory",
                table: "comments",
                newName: "tributeid");

            migrationBuilder.RenameColumn(
                name: "tree_level",
                schema: "lovedmemory",
                table: "comments",
                newName: "treelevel");

            migrationBuilder.RenameColumn(
                name: "parent_comment_id",
                schema: "lovedmemory",
                table: "comments",
                newName: "parentcommentid");

            migrationBuilder.RenameColumn(
                name: "last_modified_by_user_id",
                schema: "lovedmemory",
                table: "comments",
                newName: "lastmodifiedbyuserid");

            migrationBuilder.RenameColumn(
                name: "last_modified",
                schema: "lovedmemory",
                table: "comments",
                newName: "lastmodified");

            migrationBuilder.RenameColumn(
                name: "created_by_user_id",
                schema: "lovedmemory",
                table: "comments",
                newName: "createdbyuserid");

            migrationBuilder.RenameColumn(
                name: "comment_id",
                schema: "lovedmemory",
                table: "comments",
                newName: "commentid");

            migrationBuilder.RenameIndex(
                name: "ix_comments_tribute_id",
                schema: "lovedmemory",
                table: "comments",
                newName: "IX_comments_tributeid");

            migrationBuilder.RenameIndex(
                name: "ix_comments_comment_id",
                schema: "lovedmemory",
                table: "comments",
                newName: "IX_comments_commentid");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "lovedmemory",
                table: "audio",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "tribute_id",
                schema: "lovedmemory",
                table: "audio",
                newName: "tributeid");

            migrationBuilder.RenameColumn(
                name: "added_by_id",
                schema: "lovedmemory",
                table: "audio",
                newName: "addedbyid");

            migrationBuilder.RenameIndex(
                name: "ix_audio_tribute_id",
                schema: "lovedmemory",
                table: "audio",
                newName: "IX_audio_tributeid");

            migrationBuilder.RenameIndex(
                name: "ix_audio_added_by_id",
                schema: "lovedmemory",
                table: "audio",
                newName: "IX_audio_addedbyid");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                newName: "loginprovider");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "lovedmemory",
                table: "aspnetusertokens",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "user_name",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "two_factor_enabled",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "twofactorenabled");

            migrationBuilder.RenameColumn(
                name: "security_stamp",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "securitystamp");

            migrationBuilder.RenameColumn(
                name: "phone_number_confirmed",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "phonenumberconfirmed");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "passwordhash");

            migrationBuilder.RenameColumn(
                name: "other_name",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "othername");

            migrationBuilder.RenameColumn(
                name: "normalized_user_name",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "normalizedusername");

            migrationBuilder.RenameColumn(
                name: "normalized_email",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "normalizedemail");

            migrationBuilder.RenameColumn(
                name: "nick_name",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "lockout_end",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "lockoutend");

            migrationBuilder.RenameColumn(
                name: "lockout_enabled",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "lockoutenabled");

            migrationBuilder.RenameColumn(
                name: "last_name",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "first_name",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "email_confirmed",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "emailconfirmed");

            migrationBuilder.RenameColumn(
                name: "country_code",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "countrycode");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "access_failed_count",
                schema: "lovedmemory",
                table: "aspnetusers",
                newName: "accessfailedcount");

            migrationBuilder.RenameColumn(
                name: "role_id",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetuserroles_role_id",
                schema: "lovedmemory",
                table: "aspnetuserroles",
                newName: "IX_aspnetuserroles_roleid");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "provider_display_name",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "providerdisplayname");

            migrationBuilder.RenameColumn(
                name: "provider_key",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "providerkey");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "loginprovider");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetuserlogins_user_id",
                schema: "lovedmemory",
                table: "aspnetuserlogins",
                newName: "IX_aspnetuserlogins_userid");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "claimtype");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetuserclaims_user_id",
                schema: "lovedmemory",
                table: "aspnetuserclaims",
                newName: "IX_aspnetuserclaims_userid");

            migrationBuilder.RenameColumn(
                name: "normalized_name",
                schema: "lovedmemory",
                table: "aspnetroles",
                newName: "normalizedname");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                schema: "lovedmemory",
                table: "aspnetroles",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "role_id",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "claimtype");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetroleclaims_role_id",
                schema: "lovedmemory",
                table: "aspnetroleclaims",
                newName: "IX_aspnetroleclaims_roleid");

            migrationBuilder.RenameColumn(
                name: "role_id",
                schema: "lovedmemory",
                table: "rolepermissions",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "permission_id",
                schema: "lovedmemory",
                table: "rolepermissions",
                newName: "permissionid");

            migrationBuilder.RenameIndex(
                name: "ix_role_permissions_permission_id",
                schema: "lovedmemory",
                table: "rolepermissions",
                newName: "IX_rolepermissions_permissionid");

            migrationBuilder.RenameColumn(
                name: "image_url",
                schema: "lovedmemory",
                table: "coverphoto",
                newName: "imageurl");

            migrationBuilder.RenameColumn(
                name: "cover_photo_id",
                schema: "lovedmemory",
                table: "coverphoto",
                newName: "coverphotoid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tributedetails",
                schema: "lovedmemory",
                table: "tributedetails",
                column: "tributeid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lifestory",
                schema: "tributes",
                table: "lifestory",
                column: "tributeid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gallery",
                schema: "lovedmemory",
                table: "gallery",
                column: "tributeid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_eventdetails",
                schema: "lovedmemory",
                table: "eventdetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_rolepermissions",
                schema: "lovedmemory",
                table: "rolepermissions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_coverphoto",
                schema: "lovedmemory",
                table: "coverphoto",
                column: "coverphotoid");

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
                name: "fk_audio_aspnetusers_addedbyid",
                schema: "lovedmemory",
                table: "audio",
                column: "addedbyid",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_audio_tributes_tributeid",
                schema: "lovedmemory",
                table: "audio",
                column: "tributeid",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
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

            migrationBuilder.AddForeignKey(
                name: "fk_gallary_aspnetusers_addedbyid",
                schema: "lovedmemory",
                table: "gallery",
                column: "addedbyid",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_gallary_tributes_tributeid",
                schema: "lovedmemory",
                table: "gallery",
                column: "tributeid",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_lifestory_tributes_tributeid",
                schema: "tributes",
                table: "lifestory",
                column: "tributeid",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_rolepermissions_permissions_permissionid",
                schema: "lovedmemory",
                table: "rolepermissions",
                column: "permissionid",
                principalSchema: "lovedmemory",
                principalTable: "permissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tributedetails_tributes_tributeid",
                schema: "lovedmemory",
                table: "tributedetails",
                column: "tributeid",
                principalSchema: "lovedmemory",
                principalTable: "tributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tributes_aspnetusers_createdbyuserid",
                schema: "lovedmemory",
                table: "tributes",
                column: "createdbyuserid",
                principalSchema: "lovedmemory",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_tributes_coverphoto_coverphotoid",
                schema: "lovedmemory",
                table: "tributes",
                column: "coverphotoid",
                principalSchema: "lovedmemory",
                principalTable: "coverphoto",
                principalColumn: "coverphotoid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
