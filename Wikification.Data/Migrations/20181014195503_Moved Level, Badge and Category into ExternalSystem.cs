using Microsoft.EntityFrameworkCore.Migrations;

namespace Wikification.Data.Migrations
{
    public partial class MovedLevelBadgeandCategoryintoExternalSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Levels_LevelId",
                schema: "wikifi",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Systems_SystemId",
                schema: "wikifi",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_User_BadgeId",
                schema: "wikifi",
                table: "UserBadge");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEdition_User_EditionId",
                schema: "wikifi",
                table: "UserEdition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "wikifi",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "wikifi",
                newName: "Users",
                newSchema: "wikifi");

            migrationBuilder.RenameIndex(
                name: "IX_User_SystemId",
                schema: "wikifi",
                table: "Users",
                newName: "IX_Users_SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LevelId",
                schema: "wikifi",
                table: "Users",
                newName: "IX_Users_LevelId");

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "wikifi",
                table: "Levels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "wikifi",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                schema: "wikifi",
                table: "Badges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "wikifi",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_SystemId",
                schema: "wikifi",
                table: "Levels",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SystemId",
                schema: "wikifi",
                table: "Categories",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_SystemId",
                schema: "wikifi",
                table: "Badges",
                column: "SystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_Systems_SystemId",
                schema: "wikifi",
                table: "Badges",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Systems_SystemId",
                schema: "wikifi",
                table: "Categories",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Levels_Systems_SystemId",
                schema: "wikifi",
                table: "Levels",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Users_BadgeId",
                schema: "wikifi",
                table: "UserBadge",
                column: "BadgeId",
                principalSchema: "wikifi",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEdition_Users_EditionId",
                schema: "wikifi",
                table: "UserEdition",
                column: "EditionId",
                principalSchema: "wikifi",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Levels_LevelId",
                schema: "wikifi",
                table: "Users",
                column: "LevelId",
                principalSchema: "wikifi",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Systems_SystemId",
                schema: "wikifi",
                table: "Users",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Systems_SystemId",
                schema: "wikifi",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Systems_SystemId",
                schema: "wikifi",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Levels_Systems_SystemId",
                schema: "wikifi",
                table: "Levels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_Users_BadgeId",
                schema: "wikifi",
                table: "UserBadge");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEdition_Users_EditionId",
                schema: "wikifi",
                table: "UserEdition");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Levels_LevelId",
                schema: "wikifi",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Systems_SystemId",
                schema: "wikifi",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Levels_SystemId",
                schema: "wikifi",
                table: "Levels");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SystemId",
                schema: "wikifi",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Badges_SystemId",
                schema: "wikifi",
                table: "Badges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "wikifi",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "wikifi",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "wikifi",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SystemId",
                schema: "wikifi",
                table: "Badges");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "wikifi",
                newName: "User",
                newSchema: "wikifi");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SystemId",
                schema: "wikifi",
                table: "User",
                newName: "IX_User_SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LevelId",
                schema: "wikifi",
                table: "User",
                newName: "IX_User_LevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "wikifi",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Levels_LevelId",
                schema: "wikifi",
                table: "User",
                column: "LevelId",
                principalSchema: "wikifi",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Systems_SystemId",
                schema: "wikifi",
                table: "User",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_User_BadgeId",
                schema: "wikifi",
                table: "UserBadge",
                column: "BadgeId",
                principalSchema: "wikifi",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEdition_User_EditionId",
                schema: "wikifi",
                table: "UserEdition",
                column: "EditionId",
                principalSchema: "wikifi",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
