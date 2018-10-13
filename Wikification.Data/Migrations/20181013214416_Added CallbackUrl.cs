using Microsoft.EntityFrameworkCore.Migrations;

namespace Wikification.Data.Migrations
{
    public partial class AddedCallbackUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentPages_ExternalSystem_SystemId",
                schema: "wikifi",
                table: "ContentPages");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_ExternalSystem_SystemId",
                schema: "wikifi",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ExternalSystem_SystemId",
                schema: "wikifi",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExternalSystem",
                schema: "wikifi",
                table: "ExternalSystem");

            migrationBuilder.RenameTable(
                name: "ExternalSystem",
                schema: "wikifi",
                newName: "Systems",
                newSchema: "wikifi");

            migrationBuilder.AddColumn<string>(
                name: "CallbackUrl",
                schema: "wikifi",
                table: "Systems",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                schema: "wikifi",
                table: "Systems",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "wikifi",
                table: "Systems",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Systems",
                schema: "wikifi",
                table: "Systems",
                column: "Id");

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
                name: "FK_Event_Systems_SystemId",
                schema: "wikifi",
                table: "Event",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Systems_SystemId",
                schema: "wikifi",
                table: "User",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentPages_Systems_SystemId",
                schema: "wikifi",
                table: "ContentPages");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Systems_SystemId",
                schema: "wikifi",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Systems_SystemId",
                schema: "wikifi",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Systems",
                schema: "wikifi",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "CallbackUrl",
                schema: "wikifi",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                schema: "wikifi",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "wikifi",
                table: "Systems");

            migrationBuilder.RenameTable(
                name: "Systems",
                schema: "wikifi",
                newName: "ExternalSystem",
                newSchema: "wikifi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExternalSystem",
                schema: "wikifi",
                table: "ExternalSystem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPages_ExternalSystem_SystemId",
                schema: "wikifi",
                table: "ContentPages",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "ExternalSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_ExternalSystem_SystemId",
                schema: "wikifi",
                table: "Event",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "ExternalSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ExternalSystem_SystemId",
                schema: "wikifi",
                table: "User",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "ExternalSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
