using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableAddColumnCurrencyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "Leads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CurrencyId",
                table: "Leads",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Currencies_CurrencyId",
                table: "Leads",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Currencies_CurrencyId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_CurrencyId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Leads");
        }
    }
}
