using Microsoft.EntityFrameworkCore.Migrations;

namespace Wikification.Data.Migrations
{
    public partial class AddedEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Systems_SystemId",
                schema: "wikifi",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                schema: "wikifi",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                schema: "wikifi",
                newName: "Events",
                newSchema: "wikifi");

            migrationBuilder.RenameIndex(
                name: "IX_Event_SystemId",
                schema: "wikifi",
                table: "Events",
                newName: "IX_Events_SystemId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "wikifi",
                table: "Events",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                schema: "wikifi",
                table: "Events",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "wikifi",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                schema: "wikifi",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Systems_SystemId",
                schema: "wikifi",
                table: "Events",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Systems_SystemId",
                schema: "wikifi",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                schema: "wikifi",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                schema: "wikifi",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "wikifi",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                schema: "wikifi",
                newName: "Event",
                newSchema: "wikifi");

            migrationBuilder.RenameIndex(
                name: "IX_Events_SystemId",
                schema: "wikifi",
                table: "Event",
                newName: "IX_Event_SystemId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "wikifi",
                table: "Event",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                schema: "wikifi",
                table: "Event",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Systems_SystemId",
                schema: "wikifi",
                table: "Event",
                column: "SystemId",
                principalSchema: "wikifi",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
