using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wikification.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "wikifi");

            migrationBuilder.CreateTable(
                name: "Systems",
                schema: "wikifi",
                columns: table => new
                {
                    CallbackUrl = table.Column<string>(maxLength: 200, nullable: true),
                    ExternalId = table.Column<string>(maxLength: 50, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                schema: "wikifi",
                columns: table => new
                {
                    AwardedXp = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    SymbolUrl = table.Column<string>(maxLength: 150, nullable: true),
                    SystemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badges_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "wikifi",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "wikifi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SystemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "wikifi",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                schema: "wikifi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    SystemId = table.Column<int>(nullable: false),
                    XpThreshold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Levels_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "wikifi",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "wikifi",
                columns: table => new
                {
                    AwardedXp = table.Column<int>(nullable: false),
                    BadgeId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SystemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Badges_BadgeId",
                        column: x => x.BadgeId,
                        principalSchema: "wikifi",
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "wikifi",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentPages",
                schema: "wikifi",
                columns: table => new
                {
                    BadgeId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SystemId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentPages_Badges_BadgeId",
                        column: x => x.BadgeId,
                        principalSchema: "wikifi",
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentPages_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "wikifi",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "wikifi",
                columns: table => new
                {
                    ExternalId = table.Column<string>(maxLength: 50, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelId = table.Column<int>(nullable: true),
                    SystemId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Levels_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "wikifi",
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Systems_SystemId",
                        column: x => x.SystemId,
                        principalSchema: "wikifi",
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Edition",
                schema: "wikifi",
                columns: table => new
                {
                    AwardedXp = table.Column<int>(nullable: false),
                    Contents = table.Column<string>(nullable: true),
                    DateCreated = table.Column<long>(nullable: false),
                    EditionDescription = table.Column<string>(maxLength: 150, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    Version_Major = table.Column<int>(nullable: false),
                    Version_Minor = table.Column<int>(nullable: false),
                    Version_Change = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edition_ContentPages_PageId",
                        column: x => x.PageId,
                        principalSchema: "wikifi",
                        principalTable: "ContentPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageCategory",
                schema: "wikifi",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    PageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageCategory", x => new { x.CategoryId, x.PageId });
                    table.ForeignKey(
                        name: "FK_PageCategory_ContentPages_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "wikifi",
                        principalTable: "ContentPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageCategory_Categories_PageId",
                        column: x => x.PageId,
                        principalSchema: "wikifi",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBadge",
                schema: "wikifi",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BadgeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBadge", x => new { x.BadgeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserBadge_Users_BadgeId",
                        column: x => x.BadgeId,
                        principalSchema: "wikifi",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBadge_Badges_UserId",
                        column: x => x.UserId,
                        principalSchema: "wikifi",
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEdition",
                schema: "wikifi",
                columns: table => new
                {
                    EditionId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEdition", x => new { x.EditionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserEdition_Users_EditionId",
                        column: x => x.EditionId,
                        principalSchema: "wikifi",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEdition_Edition_UserId",
                        column: x => x.UserId,
                        principalSchema: "wikifi",
                        principalTable: "Edition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badges_SystemId",
                schema: "wikifi",
                table: "Badges",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BadgeId",
                schema: "wikifi",
                table: "Categories",
                column: "BadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SystemId",
                schema: "wikifi",
                table: "Categories",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPages_BadgeId",
                schema: "wikifi",
                table: "ContentPages",
                column: "BadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPages_SystemId",
                schema: "wikifi",
                table: "ContentPages",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Edition_PageId",
                schema: "wikifi",
                table: "Edition",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_SystemId",
                schema: "wikifi",
                table: "Event",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_SystemId",
                schema: "wikifi",
                table: "Levels",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_PageCategory_PageId",
                schema: "wikifi",
                table: "PageCategory",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBadge_UserId",
                schema: "wikifi",
                table: "UserBadge",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEdition_UserId",
                schema: "wikifi",
                table: "UserEdition",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LevelId",
                schema: "wikifi",
                table: "Users",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SystemId",
                schema: "wikifi",
                table: "Users",
                column: "SystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event",
                schema: "wikifi");

            migrationBuilder.DropTable(
                name: "PageCategory",
                schema: "wikifi");

            migrationBuilder.DropTable(
                name: "UserBadge",
                schema: "wikifi");

            migrationBuilder.DropTable(
                name: "UserEdition",
                schema: "wikifi");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "wikifi");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "wikifi");

            migrationBuilder.DropTable(
                name: "Edition",
                schema: "wikifi");

            migrationBuilder.DropTable(
                name: "Levels",
                schema: "wikifi");

            migrationBuilder.DropTable(
                name: "ContentPages",
                schema: "wikifi");

            migrationBuilder.DropTable(
                name: "Badges",
                schema: "wikifi");

            migrationBuilder.DropTable(
                name: "Systems",
                schema: "wikifi");
        }
    }
}
