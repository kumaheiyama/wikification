using Microsoft.EntityFrameworkCore.Migrations;

namespace Wikification.Data.Migrations
{
    public partial class MovedobjectsintoExternalSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Systems_SystemId",
                schema: "wikifi",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Badges_BadgeId",
                schema: "wikifi",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Systems_SystemId",
                schema: "wikifi",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentPages_Badges_BadgeId",
                schema: "wikifi",
                table: "ContentPages");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentPages_Systems_SystemId",
                schema: "wikifi",
                table: "ContentPages");

            migrationBuilder.DropForeignKey(
                name: "FK_Edition_ContentPages_PageId",
                schema: "wikifi",
                table: "Edition");

            migrationBuilder.DropForeignKey(
                name: "FK_Levels_Systems_SystemId",
                schema: "wikifi",
                table: "Levels");

            migrationBuilder.DropForeignKey(
                name: "FK_PageCategory_ContentPages_CategoryId",
                schema: "wikifi",
                table: "PageCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PageCategory_Categories_PageId",
                schema: "wikifi",
                table: "PageCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_Users_BadgeId",
                schema: "wikifi",
                table: "UserBadge");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_Badges_UserId",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "wikifi",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Levels",
                schema: "wikifi",
                table: "Levels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentPages",
                schema: "wikifi",
                table: "ContentPages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                schema: "wikifi",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Badges",
                schema: "wikifi",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "AwardedXp",
                schema: "wikifi",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "wikifi",
                newName: "User",
                newSchema: "wikifi");

            migrationBuilder.RenameTable(
                name: "Levels",
                schema: "wikifi",
                newName: "Level",
                newSchema: "wikifi");

            migrationBuilder.RenameTable(
                name: "ContentPages",
                schema: "wikifi",
                newName: "ContentPage",
                newSchema: "wikifi");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "wikifi",
                newName: "Category",
                newSchema: "wikifi");

            migrationBuilder.RenameTable(
                name: "Badges",
                schema: "wikifi",
                newName: "Badge",
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

            migrationBuilder.RenameIndex(
                name: "IX_Levels_SystemId",
                schema: "wikifi",
                table: "Level",
                newName: "IX_Level_SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentPages_SystemId",
                schema: "wikifi",
                table: "ContentPage",
                newName: "IX_ContentPage_SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentPages_BadgeId",
                schema: "wikifi",
                table: "ContentPage",
                newName: "IX_ContentPage_BadgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_SystemId",
                schema: "wikifi",
                table: "Category",
                newName: "IX_Category_SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_BadgeId",
                schema: "wikifi",
                table: "Category",
                newName: "IX_Category_BadgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Badges_SystemId",
                schema: "wikifi",
                table: "Badge",
                newName: "IX_Badge_SystemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "wikifi",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Level",
                schema: "wikifi",
                table: "Level",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentPage",
                schema: "wikifi",
                table: "ContentPage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "wikifi",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Badge",
                schema: "wikifi",
                table: "Badge",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Badge_Systems_SystemId",
                schema: "wikifi",
                table: "Badge",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Badge_BadgeId",
                schema: "wikifi",
                table: "Category",
                column: "BadgeId",
                principalSchema: "wikifi",
                principalTable: "Badge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Systems_SystemId",
                schema: "wikifi",
                table: "Category",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPage_Badge_BadgeId",
                schema: "wikifi",
                table: "ContentPage",
                column: "BadgeId",
                principalSchema: "wikifi",
                principalTable: "Badge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPage_Systems_SystemId",
                schema: "wikifi",
                table: "ContentPage",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Edition_ContentPage_PageId",
                schema: "wikifi",
                table: "Edition",
                column: "PageId",
                principalSchema: "wikifi",
                principalTable: "ContentPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Level_Systems_SystemId",
                schema: "wikifi",
                table: "Level",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PageCategory_ContentPage_CategoryId",
                schema: "wikifi",
                table: "PageCategory",
                column: "CategoryId",
                principalSchema: "wikifi",
                principalTable: "ContentPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PageCategory_Category_PageId",
                schema: "wikifi",
                table: "PageCategory",
                column: "PageId",
                principalSchema: "wikifi",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Level_LevelId",
                schema: "wikifi",
                table: "User",
                column: "LevelId",
                principalSchema: "wikifi",
                principalTable: "Level",
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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Badge_UserId",
                schema: "wikifi",
                table: "UserBadge",
                column: "UserId",
                principalSchema: "wikifi",
                principalTable: "Badge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badge_Systems_SystemId",
                schema: "wikifi",
                table: "Badge");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Badge_BadgeId",
                schema: "wikifi",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Systems_SystemId",
                schema: "wikifi",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentPage_Badge_BadgeId",
                schema: "wikifi",
                table: "ContentPage");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentPage_Systems_SystemId",
                schema: "wikifi",
                table: "ContentPage");

            migrationBuilder.DropForeignKey(
                name: "FK_Edition_ContentPage_PageId",
                schema: "wikifi",
                table: "Edition");

            migrationBuilder.DropForeignKey(
                name: "FK_Level_Systems_SystemId",
                schema: "wikifi",
                table: "Level");

            migrationBuilder.DropForeignKey(
                name: "FK_PageCategory_ContentPage_CategoryId",
                schema: "wikifi",
                table: "PageCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PageCategory_Category_PageId",
                schema: "wikifi",
                table: "PageCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Level_LevelId",
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
                name: "FK_UserBadge_Badge_UserId",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Level",
                schema: "wikifi",
                table: "Level");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentPage",
                schema: "wikifi",
                table: "ContentPage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "wikifi",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Badge",
                schema: "wikifi",
                table: "Badge");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "wikifi",
                newName: "Users",
                newSchema: "wikifi");

            migrationBuilder.RenameTable(
                name: "Level",
                schema: "wikifi",
                newName: "Levels",
                newSchema: "wikifi");

            migrationBuilder.RenameTable(
                name: "ContentPage",
                schema: "wikifi",
                newName: "ContentPages",
                newSchema: "wikifi");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "wikifi",
                newName: "Categories",
                newSchema: "wikifi");

            migrationBuilder.RenameTable(
                name: "Badge",
                schema: "wikifi",
                newName: "Badges",
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

            migrationBuilder.RenameIndex(
                name: "IX_Level_SystemId",
                schema: "wikifi",
                table: "Levels",
                newName: "IX_Levels_SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentPage_SystemId",
                schema: "wikifi",
                table: "ContentPages",
                newName: "IX_ContentPages_SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentPage_BadgeId",
                schema: "wikifi",
                table: "ContentPages",
                newName: "IX_ContentPages_BadgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_SystemId",
                schema: "wikifi",
                table: "Categories",
                newName: "IX_Categories_SystemId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_BadgeId",
                schema: "wikifi",
                table: "Categories",
                newName: "IX_Categories_BadgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Badge_SystemId",
                schema: "wikifi",
                table: "Badges",
                newName: "IX_Badges_SystemId");

            migrationBuilder.AddColumn<int>(
                name: "AwardedXp",
                schema: "wikifi",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "wikifi",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Levels",
                schema: "wikifi",
                table: "Levels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentPages",
                schema: "wikifi",
                table: "ContentPages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                schema: "wikifi",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Badges",
                schema: "wikifi",
                table: "Badges",
                column: "Id");

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
                name: "FK_Categories_Badges_BadgeId",
                schema: "wikifi",
                table: "Categories",
                column: "BadgeId",
                principalSchema: "wikifi",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ContentPages_Badges_BadgeId",
                schema: "wikifi",
                table: "ContentPages",
                column: "BadgeId",
                principalSchema: "wikifi",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPages_Systems_SystemId",
                schema: "wikifi",
                table: "ContentPages",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Edition_ContentPages_PageId",
                schema: "wikifi",
                table: "Edition",
                column: "PageId",
                principalSchema: "wikifi",
                principalTable: "ContentPages",
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
                name: "FK_PageCategory_ContentPages_CategoryId",
                schema: "wikifi",
                table: "PageCategory",
                column: "CategoryId",
                principalSchema: "wikifi",
                principalTable: "ContentPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PageCategory_Categories_PageId",
                schema: "wikifi",
                table: "PageCategory",
                column: "PageId",
                principalSchema: "wikifi",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Users_BadgeId",
                schema: "wikifi",
                table: "UserBadge",
                column: "BadgeId",
                principalSchema: "wikifi",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Badges_UserId",
                schema: "wikifi",
                table: "UserBadge",
                column: "UserId",
                principalSchema: "wikifi",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
