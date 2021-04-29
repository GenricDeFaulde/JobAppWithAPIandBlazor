using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApp.Migrations.JobDb
{
    public partial class CompanyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Company_CompanyId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_CompanyId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "Logo",
                schema: "dbo",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LogoBig",
                schema: "dbo",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Company",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CompanyBranchId",
                schema: "dbo",
                table: "JobOffer",
                column: "CompanyBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_CompanyBranch_CompanyBranchId",
                schema: "dbo",
                table: "JobOffer",
                column: "CompanyBranchId",
                principalSchema: "dbo",
                principalTable: "CompanyBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_CompanyBranch_CompanyBranchId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_CompanyBranchId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "dbo",
                table: "JobOffer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                schema: "dbo",
                table: "Company",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "LogoBig",
                schema: "dbo",
                table: "Company",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CompanyId",
                schema: "dbo",
                table: "JobOffer",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Company_CompanyId",
                schema: "dbo",
                table: "JobOffer",
                column: "CompanyId",
                principalSchema: "dbo",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
