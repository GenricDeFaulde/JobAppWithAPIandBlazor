using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApp.Migrations.JobDb
{
    public partial class InitialCreat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "JobOffer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyBranchId = table.Column<int>(nullable: true),
                    JobId = table.Column<int>(nullable: true),
                    HeadHunterId = table.Column<int>(nullable: true),
                    JobExchangeId = table.Column<int>(nullable: true),
                    ApplicationnId = table.Column<int>(nullable: true),
                    SalaryOffered = table.Column<decimal>(type: "decimal(5,3)", nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Releasedate = table.Column<DateTime>(nullable: false),
                    JobOfferUrl = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<string>(maxLength: 20, nullable: false),
                    Religion = table.Column<string>(maxLength: 50, nullable: true),
                    Sex = table.Column<string>(maxLength: 20, nullable: true),
                    Gender = table.Column<string>(maxLength: 20, nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    PictureAlt = table.Column<byte[]>(nullable: true),
                    Nationality = table.Column<string>(maxLength: 50, nullable: false),
                    Nationality2 = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: false),
                    Current = table.Column<bool>(nullable: false),
                    Logo = table.Column<byte[]>(nullable: true),
                    LogoBig = table.Column<byte[]>(nullable: true),
                    JobOfferCompany_Id = table.Column<int>(name: "JobOffer.Company_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_JobOffer_JobOffer.Company_Id",
                        column: x => x.JobOfferCompany_Id,
                        principalSchema: "dbo",
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Headhunter",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    JobOfferHeadHunter_Id = table.Column<int>(name: "JobOffer.HeadHunter_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headhunter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Headhunter_JobOffer_JobOffer.HeadHunter_Id",
                        column: x => x.JobOfferHeadHunter_Id,
                        principalSchema: "dbo",
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobOfferId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    TitleAlt = table.Column<string>(maxLength: 30, nullable: true),
                    TitleAlt2 = table.Column<string>(maxLength: 50, nullable: true),
                    JobOfferJob_Id = table.Column<int>(name: "JobOffer.Job_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_JobOffer_JobOffer.Job_Id",
                        column: x => x.JobOfferJob_Id,
                        principalSchema: "dbo",
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobExchange",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Url = table.Column<string>(maxLength: 50, nullable: true),
                    Current = table.Column<bool>(nullable: false),
                    JobOfferJobExchange_Id = table.Column<int>(name: "JobOffer.JobExchange_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobExchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobExchange_JobOffer_JobOffer.JobExchange_Id",
                        column: x => x.JobOfferJobExchange_Id,
                        principalSchema: "dbo",
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    JobOfferId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Answer = table.Column<string>(maxLength: 500, nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false),
                    DateAnswered = table.Column<DateTime>(nullable: false),
                    Current = table.Column<byte[]>(nullable: true),
                    JobOfferApplication_Id = table.Column<int>(name: "JobOffer.Application_Id", nullable: false),
                    UserApplications_Id = table.Column<int>(name: "User.Applications_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_JobOffer_JobOffer.Application_Id",
                        column: x => x.JobOfferApplication_Id,
                        principalSchema: "dbo",
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_User_User.Applications_Id",
                        column: x => x.UserApplications_Id,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobsuche",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    JobOfferId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    JobId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 20, nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false),
                    DateAnswered = table.Column<DateTime>(nullable: false),
                    Proof = table.Column<byte[]>(nullable: true),
                    JobOfferJobsuche_Id = table.Column<int>(name: "JobOffer.Jobsuche_Id", nullable: false),
                    UserJobsGesucht_Id = table.Column<int>(name: "User.JobsGesucht_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobsuche", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobsuche_JobOffer_JobOffer.Jobsuche_Id",
                        column: x => x.JobOfferJobsuche_Id,
                        principalSchema: "dbo",
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobsuche_User_User.JobsGesucht_Id",
                        column: x => x.UserJobsGesucht_Id,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserContactData",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    AddressNation = table.Column<string>(maxLength: 50, nullable: false),
                    AddressCity = table.Column<string>(maxLength: 50, nullable: false),
                    AddressStreet = table.Column<string>(maxLength: 50, nullable: false),
                    AddressState = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumberAlt = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    EmailAddressAlt = table.Column<string>(maxLength: 50, nullable: true),
                    Current = table.Column<bool>(nullable: false),
                    UserContactData_Id = table.Column<int>(name: "User.ContactData_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactData_User_User.ContactData_Id",
                        column: x => x.UserContactData_Id,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEducation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Facility = table.Column<string>(maxLength: 50, nullable: false),
                    AddressNation = table.Column<string>(maxLength: 50, nullable: false),
                    FacilityAddressCity = table.Column<string>(maxLength: 50, nullable: false),
                    FacilityAddressStreet = table.Column<string>(maxLength: 50, nullable: false),
                    FacilityAddressState = table.Column<string>(maxLength: 50, nullable: false),
                    Graduation = table.Column<string>(maxLength: 50, nullable: false),
                    TestimonyUrl = table.Column<string>(maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserEducationHistory_Id = table.Column<int>(name: "User.EducationHistory_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEducation_User_User.EducationHistory_Id",
                        column: x => x.UserEducationHistory_Id,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJobHistory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    SkillSummary = table.Column<string>(maxLength: 250, nullable: false),
                    TestimonyUrl = table.Column<string>(maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Current = table.Column<bool>(nullable: false),
                    UserJobHistory_Id = table.Column<int>(name: "User.JobHistory_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserJobHistory_User_User.JobHistory_Id",
                        column: x => x.UserJobHistory_Id,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    SkillName = table.Column<string>(maxLength: 30, nullable: false),
                    SkillDescritpion = table.Column<string>(maxLength: 100, nullable: false),
                    SelfRating = table.Column<int>(nullable: false),
                    Current = table.Column<bool>(nullable: false),
                    UserSkills_Id = table.Column<int>(name: "User.Skills_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkill_User_User.Skills_Id",
                        column: x => x.UserSkills_Id,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWebsite",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Content = table.Column<string>(maxLength: 150, nullable: true),
                    Url = table.Column<string>(maxLength: 50, nullable: false),
                    UserWebsites_Id = table.Column<int>(name: "User.Websites_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWebsite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWebsite_User_User.Websites_Id",
                        column: x => x.UserWebsites_Id,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBranch",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    AddressNation = table.Column<string>(maxLength: 50, nullable: false),
                    AddressCity = table.Column<string>(maxLength: 50, nullable: false),
                    AddressStreet = table.Column<string>(maxLength: 50, nullable: false),
                    AddressState = table.Column<string>(maxLength: 30, nullable: false),
                    CompanyBranches_Id = table.Column<int>(name: "Company.Branches_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyBranch_Company_Company.Branches_Id",
                        column: x => x.CompanyBranches_Id,
                        principalSchema: "dbo",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyHistory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(maxLength: 250, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CompanyHistoryList_Id = table.Column<int>(name: "Company.HistoryList_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyHistory_Company_Company.HistoryList_Id",
                        column: x => x.CompanyHistoryList_Id,
                        principalSchema: "dbo",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeadhuntercontactData",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: true),
                    JobExchangeId = table.Column<int>(nullable: true),
                    AddressNation = table.Column<string>(maxLength: 50, nullable: true),
                    AddressCity = table.Column<string>(maxLength: 50, nullable: true),
                    AddressStreet = table.Column<string>(maxLength: 50, nullable: true),
                    AddressState = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumberAlt = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 30, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    HeadHunterName_Id = table.Column<int>(name: "HeadHunter.Name_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadhuntercontactData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadhuntercontactData_Headhunter_HeadHunter.Name_Id",
                        column: x => x.HeadHunterName_Id,
                        principalSchema: "dbo",
                        principalTable: "Headhunter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobData",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(nullable: false),
                    DescriptionShort = table.Column<string>(maxLength: 50, nullable: false),
                    DescriptionLong = table.Column<string>(maxLength: 250, nullable: true),
                    Nation = table.Column<string>(maxLength: 50, nullable: false),
                    Region = table.Column<string>(maxLength: 50, nullable: false),
                    MinSalary = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
                    MaxSalary = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
                    Current = table.Column<bool>(nullable: false),
                    JobJobData_Id = table.Column<int>(name: "Job.JobData_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobData_Job_Job.JobData_Id",
                        column: x => x.JobJobData_Id,
                        principalSchema: "dbo",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobSkill",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Content = table.Column<string>(maxLength: 250, nullable: false),
                    JobJobSkillz_Id = table.Column<int>(name: "Job.JobSkillz_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSkill_Job_Job.JobSkillz_Id",
                        column: x => x.JobJobSkillz_Id,
                        principalSchema: "dbo",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationBody",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationnId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Content = table.Column<string>(maxLength: 1500, nullable: false),
                    ApplicationBody_Id = table.Column<int>(name: "Application.Body_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationBody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationBody_Application_Application.Body_Id",
                        column: x => x.ApplicationBody_Id,
                        principalSchema: "dbo",
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationFooter",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationnId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Content = table.Column<string>(maxLength: 1500, nullable: false),
                    ApplicationFooter_Id = table.Column<int>(name: "Application.Footer_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFooter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFooter_Application_Application.Footer_Id",
                        column: x => x.ApplicationFooter_Id,
                        principalSchema: "dbo",
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationHeader",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationnId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Content = table.Column<string>(maxLength: 1500, nullable: false),
                    ApplicationHeader_Id = table.Column<int>(name: "Application.Header_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationHeader_Application_Application.Header_Id",
                        column: x => x.ApplicationHeader_Id,
                        principalSchema: "dbo",
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContactData",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    CompanyBranchId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumberAlt = table.Column<string>(maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    EmailAddressAlt = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CompanyBranchContacts_Id = table.Column<int>(name: "CompanyBranch.Contacts_Id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContactData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContactData_CompanyBranch_CompanyBranch.Contacts_Id",
                        column: x => x.CompanyBranchContacts_Id,
                        principalSchema: "dbo",
                        principalTable: "CompanyBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobOffer.Application_Id",
                schema: "dbo",
                table: "Application",
                column: "JobOffer.Application_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_User.Applications_Id",
                schema: "dbo",
                table: "Application",
                column: "User.Applications_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationBody_Application.Body_Id",
                schema: "dbo",
                table: "ApplicationBody",
                column: "Application.Body_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFooter_Application.Footer_Id",
                schema: "dbo",
                table: "ApplicationFooter",
                column: "Application.Footer_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationHeader_Application.Header_Id",
                schema: "dbo",
                table: "ApplicationHeader",
                column: "Application.Header_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_JobOffer.Company_Id",
                schema: "dbo",
                table: "Company",
                column: "JobOffer.Company_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_Company.Branches_Id",
                schema: "dbo",
                table: "CompanyBranch",
                column: "Company.Branches_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContactData_CompanyBranch.Contacts_Id",
                schema: "dbo",
                table: "CompanyContactData",
                column: "CompanyBranch.Contacts_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHistory_Company.HistoryList_Id",
                schema: "dbo",
                table: "CompanyHistory",
                column: "Company.HistoryList_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Headhunter_JobOffer.HeadHunter_Id",
                schema: "dbo",
                table: "Headhunter",
                column: "JobOffer.HeadHunter_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeadhuntercontactData_HeadHunter.Name_Id",
                schema: "dbo",
                table: "HeadhuntercontactData",
                column: "HeadHunter.Name_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobOffer.Job_Id",
                schema: "dbo",
                table: "Job",
                column: "JobOffer.Job_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobData_Job.JobData_Id",
                schema: "dbo",
                table: "JobData",
                column: "Job.JobData_Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobExchange_JobOffer.JobExchange_Id",
                schema: "dbo",
                table: "JobExchange",
                column: "JobOffer.JobExchange_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_Job.JobSkillz_Id",
                schema: "dbo",
                table: "JobSkill",
                column: "Job.JobSkillz_Id");

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
                name: "IX_UserContactData_User.ContactData_Id",
                schema: "dbo",
                table: "UserContactData",
                column: "User.ContactData_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEducation_User.EducationHistory_Id",
                schema: "dbo",
                table: "UserEducation",
                column: "User.EducationHistory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobHistory_User.JobHistory_Id",
                schema: "dbo",
                table: "UserJobHistory",
                column: "User.JobHistory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_User.Skills_Id",
                schema: "dbo",
                table: "UserSkill",
                column: "User.Skills_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserWebsite_User.Websites_Id",
                schema: "dbo",
                table: "UserWebsite",
                column: "User.Websites_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationBody",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationFooter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationHeader",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CompanyContactData",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CompanyHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HeadhuntercontactData",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobData",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobExchange",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobSkill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Jobsuche",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserContactData",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserEducation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserJobHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserSkill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserWebsite",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Application",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CompanyBranch",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Headhunter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobOffer",
                schema: "dbo");
        }
    }
}
