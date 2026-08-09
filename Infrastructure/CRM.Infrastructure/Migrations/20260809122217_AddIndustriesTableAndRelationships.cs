using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndustriesTableAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IndustryId",
                table: "Leads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IndustryId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("04333d8d-f676-41d9-b4e7-b9ded1eee930"), "Üretim", true },
                    { new Guid("2363cc8c-4f2b-4104-a375-6f5f66235e33"), "Sağlık", true },
                    { new Guid("4e2fe32d-d574-46d2-89b9-6dc4b5aba976"), "Gayrimenkul", true },
                    { new Guid("77b7e8e7-a371-49d6-8db1-895baaaa991e"), "Turizm", true },
                    { new Guid("97a92ec2-44cb-4c51-bde8-30e59c80f136"), "Perakende E-Ticaret", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_IndustryId",
                table: "Leads",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IndustryId",
                table: "Companies",
                column: "IndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Industries_IndustryId",
                table: "Companies",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Industries_IndustryId",
                table: "Leads",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Industries_IndustryId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Industries_IndustryId",
                table: "Leads");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropIndex(
                name: "IX_Leads_IndustryId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Companies_IndustryId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "Companies");
        }
    }
}
