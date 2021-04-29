using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApp.Migrations.JobDb
{
    public partial class JobFKremoveALL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_JobOffer_JobOffer.Application_Id",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_User_User.Applications_Id",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationBody_Application_Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationFooter_Application_Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationHeader_Application_Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_JobOffer_JobOffer.Company_Id",
                schema: "dbo",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_Company_Company.Branches_Id",
                schema: "dbo",
                table: "CompanyBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyContactData_CompanyBranch_CompanyBranch.Contacts_Id",
                schema: "dbo",
                table: "CompanyContactData");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyHistory_Company_Company.HistoryList_Id",
                schema: "dbo",
                table: "CompanyHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Headhunter_JobOffer_JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter");

            migrationBuilder.DropForeignKey(
                name: "FK_HeadhuntercontactData_Headhunter_HeadHunter.Name_Id",
                schema: "dbo",
                table: "HeadhuntercontactData");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobOffer_JobOffer.Job_Id",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobData_Job_Job.JobData_Id",
                schema: "dbo",
                table: "JobData");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExchange_JobOffer_JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_Job_Job.JobSkillz_Id",
                schema: "dbo",
                table: "JobSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobsuche_JobOffer_JobOffer.Jobsuche_Id",
                schema: "dbo",
                table: "Jobsuche");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobsuche_User_User.JobsGesucht_Id",
                schema: "dbo",
                table: "Jobsuche");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContactData_User_User.ContactData_Id",
                schema: "dbo",
                table: "UserContactData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEducation_User_User.EducationHistory_Id",
                schema: "dbo",
                table: "UserEducation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserJobHistory_User_User.JobHistory_Id",
                schema: "dbo",
                table: "UserJobHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_User_User.Skills_Id",
                schema: "dbo",
                table: "UserSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWebsite_User_User.Websites_Id",
                schema: "dbo",
                table: "UserWebsite");

            migrationBuilder.DropIndex(
                name: "IX_UserWebsite_User.Websites_Id",
                schema: "dbo",
                table: "UserWebsite");

            migrationBuilder.DropIndex(
                name: "IX_UserSkill_User.Skills_Id",
                schema: "dbo",
                table: "UserSkill");

            migrationBuilder.DropIndex(
                name: "IX_UserJobHistory_User.JobHistory_Id",
                schema: "dbo",
                table: "UserJobHistory");

            migrationBuilder.DropIndex(
                name: "IX_UserEducation_User.EducationHistory_Id",
                schema: "dbo",
                table: "UserEducation");

            migrationBuilder.DropIndex(
                name: "IX_UserContactData_User.ContactData_Id",
                schema: "dbo",
                table: "UserContactData");

            migrationBuilder.DropIndex(
                name: "IX_Jobsuche_JobOffer.Jobsuche_Id",
                schema: "dbo",
                table: "Jobsuche");

            migrationBuilder.DropIndex(
                name: "IX_Jobsuche_User.JobsGesucht_Id",
                schema: "dbo",
                table: "Jobsuche");

            migrationBuilder.DropIndex(
                name: "IX_JobSkill_Job.JobSkillz_Id",
                schema: "dbo",
                table: "JobSkill");

            migrationBuilder.DropIndex(
                name: "IX_JobExchange_JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange");

            migrationBuilder.DropIndex(
                name: "IX_JobData_Job.JobData_Id",
                schema: "dbo",
                table: "JobData");

            migrationBuilder.DropIndex(
                name: "IX_Job_JobOffer.Job_Id",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_HeadhuntercontactData_HeadHunter.Name_Id",
                schema: "dbo",
                table: "HeadhuntercontactData");

            migrationBuilder.DropIndex(
                name: "IX_Headhunter_JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter");

            migrationBuilder.DropIndex(
                name: "IX_CompanyHistory_Company.HistoryList_Id",
                schema: "dbo",
                table: "CompanyHistory");

            migrationBuilder.DropIndex(
                name: "IX_CompanyContactData_CompanyBranch.Contacts_Id",
                schema: "dbo",
                table: "CompanyContactData");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranch_Company.Branches_Id",
                schema: "dbo",
                table: "CompanyBranch");

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

            migrationBuilder.DropIndex(
                name: "IX_Application_User.Applications_Id",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "User.Websites_Id",
                schema: "dbo",
                table: "UserWebsite");

            migrationBuilder.DropColumn(
                name: "User.Skills_Id",
                schema: "dbo",
                table: "UserSkill");

            migrationBuilder.DropColumn(
                name: "User.JobHistory_Id",
                schema: "dbo",
                table: "UserJobHistory");

            migrationBuilder.DropColumn(
                name: "User.EducationHistory_Id",
                schema: "dbo",
                table: "UserEducation");

            migrationBuilder.DropColumn(
                name: "User.ContactData_Id",
                schema: "dbo",
                table: "UserContactData");

            migrationBuilder.DropColumn(
                name: "JobOffer.Jobsuche_Id",
                schema: "dbo",
                table: "Jobsuche");

            migrationBuilder.DropColumn(
                name: "User.JobsGesucht_Id",
                schema: "dbo",
                table: "Jobsuche");

            migrationBuilder.DropColumn(
                name: "Job.JobSkillz_Id",
                schema: "dbo",
                table: "JobSkill");

            migrationBuilder.DropColumn(
                name: "JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange");

            migrationBuilder.DropColumn(
                name: "Job.JobData_Id",
                schema: "dbo",
                table: "JobData");

            migrationBuilder.DropColumn(
                name: "JobOffer.Job_Id",
                schema: "dbo",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "HeadHunter.Name_Id",
                schema: "dbo",
                table: "HeadhuntercontactData");

            migrationBuilder.DropColumn(
                name: "JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter");

            migrationBuilder.DropColumn(
                name: "Company.HistoryList_Id",
                schema: "dbo",
                table: "CompanyHistory");

            migrationBuilder.DropColumn(
                name: "CompanyBranch.Contacts_Id",
                schema: "dbo",
                table: "CompanyContactData");

            migrationBuilder.DropColumn(
                name: "Company.Branches_Id",
                schema: "dbo",
                table: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "JobOffer.Company_Id",
                schema: "dbo",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader");

            migrationBuilder.DropColumn(
                name: "Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter");

            migrationBuilder.DropColumn(
                name: "Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody");

            migrationBuilder.DropColumn(
                name: "JobOffer.Application_Id",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "User.Applications_Id",
                schema: "dbo",
                table: "Application");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "dbo",
                table: "JobOffer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HunterId",
                schema: "dbo",
                table: "HeadhuntercontactData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BodyId",
                schema: "dbo",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FooterId",
                schema: "dbo",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeaderId",
                schema: "dbo",
                table: "Application",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserWebsite_UserId",
                schema: "dbo",
                table: "UserWebsite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserId",
                schema: "dbo",
                table: "UserSkill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobHistory_UserId",
                schema: "dbo",
                table: "UserJobHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducation_UserId",
                schema: "dbo",
                table: "UserEducation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactData_UserId",
                schema: "dbo",
                table: "UserContactData",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobsuche_JobOfferId",
                schema: "dbo",
                table: "Jobsuche",
                column: "JobOfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobsuche_UserId",
                schema: "dbo",
                table: "Jobsuche",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_JobId",
                schema: "dbo",
                table: "JobSkill",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CompanyId",
                schema: "dbo",
                table: "JobOffer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_HeadHunterId",
                schema: "dbo",
                table: "JobOffer",
                column: "HeadHunterId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_JobExchangeId",
                schema: "dbo",
                table: "JobOffer",
                column: "JobExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_JobId",
                schema: "dbo",
                table: "JobOffer",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobData_JobId",
                schema: "dbo",
                table: "JobData",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadhuntercontactData_HunterId",
                schema: "dbo",
                table: "HeadhuntercontactData",
                column: "HunterId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHistory_CompanyId",
                schema: "dbo",
                table: "CompanyHistory",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContactData_CompanyBranchId",
                schema: "dbo",
                table: "CompanyContactData",
                column: "CompanyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_CompanyId",
                schema: "dbo",
                table: "CompanyBranch",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_BodyId",
                schema: "dbo",
                table: "Application",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_FooterId",
                schema: "dbo",
                table: "Application",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_HeaderId",
                schema: "dbo",
                table: "Application",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobOfferId",
                schema: "dbo",
                table: "Application",
                column: "JobOfferId",
                unique: true,
                filter: "[JobOfferId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Application_UserId",
                schema: "dbo",
                table: "Application",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_ApplicationBody_BodyId",
                schema: "dbo",
                table: "Application",
                column: "BodyId",
                principalSchema: "dbo",
                principalTable: "ApplicationBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_ApplicationFooter_FooterId",
                schema: "dbo",
                table: "Application",
                column: "FooterId",
                principalSchema: "dbo",
                principalTable: "ApplicationFooter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_ApplicationHeader_HeaderId",
                schema: "dbo",
                table: "Application",
                column: "HeaderId",
                principalSchema: "dbo",
                principalTable: "ApplicationHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_JobOffer_JobOfferId",
                schema: "dbo",
                table: "Application",
                column: "JobOfferId",
                principalSchema: "dbo",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_User_UserId",
                schema: "dbo",
                table: "Application",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_Company_CompanyId",
                schema: "dbo",
                table: "CompanyBranch",
                column: "CompanyId",
                principalSchema: "dbo",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyContactData_CompanyBranch_CompanyBranchId",
                schema: "dbo",
                table: "CompanyContactData",
                column: "CompanyBranchId",
                principalSchema: "dbo",
                principalTable: "CompanyBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyHistory_Company_CompanyId",
                schema: "dbo",
                table: "CompanyHistory",
                column: "CompanyId",
                principalSchema: "dbo",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HeadhuntercontactData_Headhunter_HunterId",
                schema: "dbo",
                table: "HeadhuntercontactData",
                column: "HunterId",
                principalSchema: "dbo",
                principalTable: "Headhunter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobData_Job_JobId",
                schema: "dbo",
                table: "JobData",
                column: "JobId",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Company_CompanyId",
                schema: "dbo",
                table: "JobOffer",
                column: "CompanyId",
                principalSchema: "dbo",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Headhunter_HeadHunterId",
                schema: "dbo",
                table: "JobOffer",
                column: "HeadHunterId",
                principalSchema: "dbo",
                principalTable: "Headhunter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_JobExchange_JobExchangeId",
                schema: "dbo",
                table: "JobOffer",
                column: "JobExchangeId",
                principalSchema: "dbo",
                principalTable: "JobExchange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Job_JobId",
                schema: "dbo",
                table: "JobOffer",
                column: "JobId",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_Job_JobId",
                schema: "dbo",
                table: "JobSkill",
                column: "JobId",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobsuche_JobOffer_JobOfferId",
                schema: "dbo",
                table: "Jobsuche",
                column: "JobOfferId",
                principalSchema: "dbo",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobsuche_User_UserId",
                schema: "dbo",
                table: "Jobsuche",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserContactData_User_UserId",
                schema: "dbo",
                table: "UserContactData",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEducation_User_UserId",
                schema: "dbo",
                table: "UserEducation",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserJobHistory_User_UserId",
                schema: "dbo",
                table: "UserJobHistory",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_User_UserId",
                schema: "dbo",
                table: "UserSkill",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWebsite_User_UserId",
                schema: "dbo",
                table: "UserWebsite",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_ApplicationBody_BodyId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_ApplicationFooter_FooterId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_ApplicationHeader_HeaderId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_JobOffer_JobOfferId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_User_UserId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_Company_CompanyId",
                schema: "dbo",
                table: "CompanyBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyContactData_CompanyBranch_CompanyBranchId",
                schema: "dbo",
                table: "CompanyContactData");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyHistory_Company_CompanyId",
                schema: "dbo",
                table: "CompanyHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_HeadhuntercontactData_Headhunter_HunterId",
                schema: "dbo",
                table: "HeadhuntercontactData");

            migrationBuilder.DropForeignKey(
                name: "FK_JobData_Job_JobId",
                schema: "dbo",
                table: "JobData");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Company_CompanyId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Headhunter_HeadHunterId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_JobExchange_JobExchangeId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Job_JobId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_Job_JobId",
                schema: "dbo",
                table: "JobSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobsuche_JobOffer_JobOfferId",
                schema: "dbo",
                table: "Jobsuche");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobsuche_User_UserId",
                schema: "dbo",
                table: "Jobsuche");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContactData_User_UserId",
                schema: "dbo",
                table: "UserContactData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEducation_User_UserId",
                schema: "dbo",
                table: "UserEducation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserJobHistory_User_UserId",
                schema: "dbo",
                table: "UserJobHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_User_UserId",
                schema: "dbo",
                table: "UserSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWebsite_User_UserId",
                schema: "dbo",
                table: "UserWebsite");

            migrationBuilder.DropIndex(
                name: "IX_UserWebsite_UserId",
                schema: "dbo",
                table: "UserWebsite");

            migrationBuilder.DropIndex(
                name: "IX_UserSkill_UserId",
                schema: "dbo",
                table: "UserSkill");

            migrationBuilder.DropIndex(
                name: "IX_UserJobHistory_UserId",
                schema: "dbo",
                table: "UserJobHistory");

            migrationBuilder.DropIndex(
                name: "IX_UserEducation_UserId",
                schema: "dbo",
                table: "UserEducation");

            migrationBuilder.DropIndex(
                name: "IX_UserContactData_UserId",
                schema: "dbo",
                table: "UserContactData");

            migrationBuilder.DropIndex(
                name: "IX_Jobsuche_JobOfferId",
                schema: "dbo",
                table: "Jobsuche");

            migrationBuilder.DropIndex(
                name: "IX_Jobsuche_UserId",
                schema: "dbo",
                table: "Jobsuche");

            migrationBuilder.DropIndex(
                name: "IX_JobSkill_JobId",
                schema: "dbo",
                table: "JobSkill");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_CompanyId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_HeadHunterId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_JobExchangeId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_JobId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_JobData_JobId",
                schema: "dbo",
                table: "JobData");

            migrationBuilder.DropIndex(
                name: "IX_HeadhuntercontactData_HunterId",
                schema: "dbo",
                table: "HeadhuntercontactData");

            migrationBuilder.DropIndex(
                name: "IX_CompanyHistory_CompanyId",
                schema: "dbo",
                table: "CompanyHistory");

            migrationBuilder.DropIndex(
                name: "IX_CompanyContactData_CompanyBranchId",
                schema: "dbo",
                table: "CompanyContactData");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranch_CompanyId",
                schema: "dbo",
                table: "CompanyBranch");

            migrationBuilder.DropIndex(
                name: "IX_Application_BodyId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_FooterId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_HeaderId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_JobOfferId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_UserId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "dbo",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "HunterId",
                schema: "dbo",
                table: "HeadhuntercontactData");

            migrationBuilder.DropColumn(
                name: "BodyId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "FooterId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.AddColumn<int>(
                name: "User.Websites_Id",
                schema: "dbo",
                table: "UserWebsite",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User.Skills_Id",
                schema: "dbo",
                table: "UserSkill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User.JobHistory_Id",
                schema: "dbo",
                table: "UserJobHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User.EducationHistory_Id",
                schema: "dbo",
                table: "UserEducation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User.ContactData_Id",
                schema: "dbo",
                table: "UserContactData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobOffer.Jobsuche_Id",
                schema: "dbo",
                table: "Jobsuche",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User.JobsGesucht_Id",
                schema: "dbo",
                table: "Jobsuche",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Job.JobSkillz_Id",
                schema: "dbo",
                table: "JobSkill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Job.JobData_Id",
                schema: "dbo",
                table: "JobData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobOffer.Job_Id",
                schema: "dbo",
                table: "Job",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeadHunter.Name_Id",
                schema: "dbo",
                table: "HeadhuntercontactData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company.HistoryList_Id",
                schema: "dbo",
                table: "CompanyHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyBranch.Contacts_Id",
                schema: "dbo",
                table: "CompanyContactData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Company.Branches_Id",
                schema: "dbo",
                table: "CompanyBranch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobOffer.Company_Id",
                schema: "dbo",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobOffer.Application_Id",
                schema: "dbo",
                table: "Application",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User.Applications_Id",
                schema: "dbo",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserWebsite_User.Websites_Id",
                schema: "dbo",
                table: "UserWebsite",
                column: "User.Websites_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_User.Skills_Id",
                schema: "dbo",
                table: "UserSkill",
                column: "User.Skills_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobHistory_User.JobHistory_Id",
                schema: "dbo",
                table: "UserJobHistory",
                column: "User.JobHistory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducation_User.EducationHistory_Id",
                schema: "dbo",
                table: "UserEducation",
                column: "User.EducationHistory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactData_User.ContactData_Id",
                schema: "dbo",
                table: "UserContactData",
                column: "User.ContactData_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobsuche_JobOffer.Jobsuche_Id",
                schema: "dbo",
                table: "Jobsuche",
                column: "JobOffer.Jobsuche_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobsuche_User.JobsGesucht_Id",
                schema: "dbo",
                table: "Jobsuche",
                column: "User.JobsGesucht_Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_Job.JobSkillz_Id",
                schema: "dbo",
                table: "JobSkill",
                column: "Job.JobSkillz_Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobExchange_JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange",
                column: "JobOffer.JobExchange_Id",
                unique: true,
                filter: "[JobOffer.JobExchange_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobData_Job.JobData_Id",
                schema: "dbo",
                table: "JobData",
                column: "Job.JobData_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobOffer.Job_Id",
                schema: "dbo",
                table: "Job",
                column: "JobOffer.Job_Id",
                unique: true,
                filter: "[JobOffer.Job_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HeadhuntercontactData_HeadHunter.Name_Id",
                schema: "dbo",
                table: "HeadhuntercontactData",
                column: "HeadHunter.Name_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Headhunter_JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter",
                column: "JobOffer.HeadHunter_Id",
                unique: true,
                filter: "[JobOffer.HeadHunter_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHistory_Company.HistoryList_Id",
                schema: "dbo",
                table: "CompanyHistory",
                column: "Company.HistoryList_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContactData_CompanyBranch.Contacts_Id",
                schema: "dbo",
                table: "CompanyContactData",
                column: "CompanyBranch.Contacts_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_Company.Branches_Id",
                schema: "dbo",
                table: "CompanyBranch",
                column: "Company.Branches_Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Application_User.Applications_Id",
                schema: "dbo",
                table: "Application",
                column: "User.Applications_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_JobOffer_JobOffer.Application_Id",
                schema: "dbo",
                table: "Application",
                column: "JobOffer.Application_Id",
                principalSchema: "dbo",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_User_User.Applications_Id",
                schema: "dbo",
                table: "Application",
                column: "User.Applications_Id",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationBody_Application_Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody",
                column: "Application.Body_Id",
                principalSchema: "dbo",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFooter_Application_Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter",
                column: "Application.Footer_Id",
                principalSchema: "dbo",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationHeader_Application_Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader",
                column: "Application.Header_Id",
                principalSchema: "dbo",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_JobOffer_JobOffer.Company_Id",
                schema: "dbo",
                table: "Company",
                column: "JobOffer.Company_Id",
                principalSchema: "dbo",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_Company_Company.Branches_Id",
                schema: "dbo",
                table: "CompanyBranch",
                column: "Company.Branches_Id",
                principalSchema: "dbo",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyContactData_CompanyBranch_CompanyBranch.Contacts_Id",
                schema: "dbo",
                table: "CompanyContactData",
                column: "CompanyBranch.Contacts_Id",
                principalSchema: "dbo",
                principalTable: "CompanyBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyHistory_Company_Company.HistoryList_Id",
                schema: "dbo",
                table: "CompanyHistory",
                column: "Company.HistoryList_Id",
                principalSchema: "dbo",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Headhunter_JobOffer_JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter",
                column: "JobOffer.HeadHunter_Id",
                principalSchema: "dbo",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HeadhuntercontactData_Headhunter_HeadHunter.Name_Id",
                schema: "dbo",
                table: "HeadhuntercontactData",
                column: "HeadHunter.Name_Id",
                principalSchema: "dbo",
                principalTable: "Headhunter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobOffer_JobOffer.Job_Id",
                schema: "dbo",
                table: "Job",
                column: "JobOffer.Job_Id",
                principalSchema: "dbo",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobData_Job_Job.JobData_Id",
                schema: "dbo",
                table: "JobData",
                column: "Job.JobData_Id",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExchange_JobOffer_JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange",
                column: "JobOffer.JobExchange_Id",
                principalSchema: "dbo",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_Job_Job.JobSkillz_Id",
                schema: "dbo",
                table: "JobSkill",
                column: "Job.JobSkillz_Id",
                principalSchema: "dbo",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobsuche_JobOffer_JobOffer.Jobsuche_Id",
                schema: "dbo",
                table: "Jobsuche",
                column: "JobOffer.Jobsuche_Id",
                principalSchema: "dbo",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobsuche_User_User.JobsGesucht_Id",
                schema: "dbo",
                table: "Jobsuche",
                column: "User.JobsGesucht_Id",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserContactData_User_User.ContactData_Id",
                schema: "dbo",
                table: "UserContactData",
                column: "User.ContactData_Id",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEducation_User_User.EducationHistory_Id",
                schema: "dbo",
                table: "UserEducation",
                column: "User.EducationHistory_Id",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserJobHistory_User_User.JobHistory_Id",
                schema: "dbo",
                table: "UserJobHistory",
                column: "User.JobHistory_Id",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_User_User.Skills_Id",
                schema: "dbo",
                table: "UserSkill",
                column: "User.Skills_Id",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWebsite_User_User.Websites_Id",
                schema: "dbo",
                table: "UserWebsite",
                column: "User.Websites_Id",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
