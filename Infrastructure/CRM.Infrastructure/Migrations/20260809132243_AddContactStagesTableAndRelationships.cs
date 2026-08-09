using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContactStagesTableAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "Leads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ContactStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactStages_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactStages_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactStages_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactStages_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_StageId",
                table: "Leads",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactStages_CreatedById",
                table: "ContactStages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContactStages_DeletedById",
                table: "ContactStages",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContactStages_ModifiedById",
                table: "ContactStages",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContactStages_OrganizationId",
                table: "ContactStages",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_ContactStages_StageId",
                table: "Leads",
                column: "StageId",
                principalTable: "ContactStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_ContactStages_StageId",
                table: "Leads");

            migrationBuilder.DropTable(
                name: "ContactStages");

            migrationBuilder.DropIndex(
                name: "IX_Leads_StageId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "Leads");
        }
    }
}
