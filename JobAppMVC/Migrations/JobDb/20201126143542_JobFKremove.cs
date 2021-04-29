using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApp.Migrations.JobDb
{
    public partial class JobFKremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobExchange_JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange");

            migrationBuilder.DropIndex(
                name: "IX_Job_JobOffer.Job_Id",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Headhunter_JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter");

            migrationBuilder.DropIndex(
                name: "IX_Company_JobOffer.Company_Id",
                schema: "dbo",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationHeader_Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationFooter_Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationBody_Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody");

            migrationBuilder.DropIndex(
                name: "IX_Application_JobOffer.Application_Id",
                schema: "dbo",
                table: "Application");

            migrationBuilder.AlterColumn<int>(
                name: "JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobOffer.Job_Id",
                schema: "dbo",
                table: "Job",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HeadHunter.Name_Id",
                schema: "dbo",
                table: "HeadhuntercontactData",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyBranch.Contacts_Id",
                schema: "dbo",
                table: "CompanyContactData",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobOffer.Company_Id",
                schema: "dbo",
                table: "Company",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobOffer.Application_Id",
                schema: "dbo",
                table: "Application",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_JobExchange_JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange",
                column: "JobOffer.JobExchange_Id",
                unique: true,
                filter: "[JobOffer.JobExchange_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobOffer.Job_Id",
                schema: "dbo",
                table: "Job",
                column: "JobOffer.Job_Id",
                unique: true,
                filter: "[JobOffer.Job_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Headhunter_JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter",
                column: "JobOffer.HeadHunter_Id",
                unique: true,
                filter: "[JobOffer.HeadHunter_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Company_JobOffer.Company_Id",
                schema: "dbo",
                table: "Company",
                column: "JobOffer.Company_Id",
                unique: true,
                filter: "[JobOffer.Company_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationHeader_Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader",
                column: "Application.Header_Id",
                unique: true,
                filter: "[Application.Header_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFooter_Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter",
                column: "Application.Footer_Id",
                unique: true,
                filter: "[Application.Footer_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationBody_Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody",
                column: "Application.Body_Id",
                unique: true,
                filter: "[Application.Body_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobOffer.Application_Id",
                schema: "dbo",
                table: "Application",
                column: "JobOffer.Application_Id",
                unique: true,
                filter: "[JobOffer.Application_Id] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobExchange_JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange");

            migrationBuilder.DropIndex(
                name: "IX_Job_JobOffer.Job_Id",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Headhunter_JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter");

            migrationBuilder.DropIndex(
                name: "IX_Company_JobOffer.Company_Id",
                schema: "dbo",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationHeader_Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationFooter_Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationBody_Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody");

            migrationBuilder.DropIndex(
                name: "IX_Application_JobOffer.Application_Id",
                schema: "dbo",
                table: "Application");

            migrationBuilder.AlterColumn<int>(
                name: "JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobOffer.Job_Id",
                schema: "dbo",
                table: "Job",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HeadHunter.Name_Id",
                schema: "dbo",
                table: "HeadhuntercontactData",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyBranch.Contacts_Id",
                schema: "dbo",
                table: "CompanyContactData",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobOffer.Company_Id",
                schema: "dbo",
                table: "Company",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobOffer.Application_Id",
                schema: "dbo",
                table: "Application",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobExchange_JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange",
                column: "JobOffer.JobExchange_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobOffer.Job_Id",
                schema: "dbo",
                table: "Job",
                column: "JobOffer.Job_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Headhunter_JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter",
                column: "JobOffer.HeadHunter_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_JobOffer.Company_Id",
                schema: "dbo",
                table: "Company",
                column: "JobOffer.Company_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationHeader_Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader",
                column: "Application.Header_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFooter_Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter",
                column: "Application.Footer_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationBody_Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody",
                column: "Application.Body_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobOffer.Application_Id",
                schema: "dbo",
                table: "Application",
                column: "JobOffer.Application_Id",
                unique: true);
        }
    }
}
