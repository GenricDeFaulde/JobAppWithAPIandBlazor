using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobAPI.Migrations.JobDb
{
    public partial class InitialReCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "dbo");

            //migrationBuilder.CreateTable(
            //    name: "ApplicationBody",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ApplicationnId = table.Column<int>(type: "int", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ApplicationBody", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ApplicationFooter",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ApplicationnId = table.Column<int>(type: "int", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ApplicationFooter", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ApplicationHeader",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ApplicationnId = table.Column<int>(type: "int", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ApplicationHeader", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Company",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Current = table.Column<bool>(type: "bit", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Company", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Headhunter",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Headhunter", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Job",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        JobOfferId = table.Column<int>(type: "int", nullable: true),
            //        Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        TitleAlt = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
            //        TitleAlt2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Job", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "JobExchange",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        Url = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Current = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_JobExchange", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "User",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AuthId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        BirthDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Religion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Sex = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
            //        Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
            //        Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
            //        PictureAlt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
            //        Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Nationality2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_User", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CompanyBranch",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CompanyId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        AddressNation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        AddressCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        AddressStreet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        AddressState = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CompanyBranch", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CompanyBranch_Company_CompanyId",
            //            column: x => x.CompanyId,
            //            principalSchema: "dbo",
            //            principalTable: "Company",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CompanyHistory",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CompanyId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        Date = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CompanyHistory", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CompanyHistory_Company_CompanyId",
            //            column: x => x.CompanyId,
            //            principalSchema: "dbo",
            //            principalTable: "Company",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HeadhuntercontactData",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CompanyId = table.Column<int>(type: "int", nullable: true),
            //        JobExchangeId = table.Column<int>(type: "int", nullable: true),
            //        AddressNation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        AddressCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        AddressStreet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        AddressState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        PhoneNumberAlt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        EmailAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        HunterId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HeadhuntercontactData", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_HeadhuntercontactData_Headhunter_HunterId",
            //            column: x => x.HunterId,
            //            principalSchema: "dbo",
            //            principalTable: "Headhunter",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "JobData",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        JobId = table.Column<int>(type: "int", nullable: false),
            //        DescriptionShort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        DescriptionLong = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        Nation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        MinSalary = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
            //        MaxSalary = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
            //        Current = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_JobData", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_JobData_Job_JobId",
            //            column: x => x.JobId,
            //            principalSchema: "dbo",
            //            principalTable: "Job",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "JobSkill",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        JobId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_JobSkill", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_JobSkill_Job_JobId",
            //            column: x => x.JobId,
            //            principalSchema: "dbo",
            //            principalTable: "Job",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserContactData",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        AddressNation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        AddressCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        AddressStreet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        AddressState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        PhoneNumberAlt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        EmailAddressAlt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Current = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserContactData", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserContactData_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "User",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserEducation",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Facility = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        AddressNation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        FacilityAddressCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        FacilityAddressStreet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        FacilityAddressState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Graduation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        TestimonyUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserEducation", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserEducation_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "User",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserJobHistory",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        SkillSummary = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        TestimonyUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Salary = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Current = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserJobHistory", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserJobHistory_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "User",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserSkill",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        SkillName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        SkillDescritpion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        SelfRating = table.Column<int>(type: "int", nullable: false),
            //        Current = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserSkill", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserSkill_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "User",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserWebsite",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        Content = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        Url = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserWebsite", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserWebsite_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "User",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CompanyContactData",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CompanyId = table.Column<int>(type: "int", nullable: false),
            //        CompanyBranchId = table.Column<int>(type: "int", nullable: true),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        PhoneNumberAlt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        EmailAddressAlt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CompanyContactData", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CompanyContactData_CompanyBranch_CompanyBranchId",
            //            column: x => x.CompanyBranchId,
            //            principalSchema: "dbo",
            //            principalTable: "CompanyBranch",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "JobOffer",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CompanyBranchId = table.Column<int>(type: "int", nullable: true),
            //        JobId = table.Column<int>(type: "int", nullable: true),
            //        HeadHunterId = table.Column<int>(type: "int", nullable: true),
            //        JobExchangeId = table.Column<int>(type: "int", nullable: true),
            //        ApplicationnId = table.Column<int>(type: "int", nullable: true),
            //        SalaryOffered = table.Column<decimal>(type: "decimal(9,3)", nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        Releasedate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        JobOfferUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_JobOffer", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_JobOffer_CompanyBranch_CompanyBranchId",
            //            column: x => x.CompanyBranchId,
            //            principalSchema: "dbo",
            //            principalTable: "CompanyBranch",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_JobOffer_Headhunter_HeadHunterId",
            //            column: x => x.HeadHunterId,
            //            principalSchema: "dbo",
            //            principalTable: "Headhunter",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_JobOffer_Job_JobId",
            //            column: x => x.JobId,
            //            principalSchema: "dbo",
            //            principalTable: "Job",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_JobOffer_JobExchange_JobExchangeId",
            //            column: x => x.JobExchangeId,
            //            principalSchema: "dbo",
            //            principalTable: "JobExchange",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Application",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        JobOfferId = table.Column<int>(type: "int", nullable: true),
            //        Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //        DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DateAnswered = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Current = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
            //        HeaderId = table.Column<int>(type: "int", nullable: true),
            //        BodyId = table.Column<int>(type: "int", nullable: true),
            //        FooterId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Application", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Application_ApplicationBody_BodyId",
            //            column: x => x.BodyId,
            //            principalSchema: "dbo",
            //            principalTable: "ApplicationBody",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Application_ApplicationFooter_FooterId",
            //            column: x => x.FooterId,
            //            principalSchema: "dbo",
            //            principalTable: "ApplicationFooter",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Application_ApplicationHeader_HeaderId",
            //            column: x => x.HeaderId,
            //            principalSchema: "dbo",
            //            principalTable: "ApplicationHeader",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Application_JobOffer_JobOfferId",
            //            column: x => x.JobOfferId,
            //            principalSchema: "dbo",
            //            principalTable: "JobOffer",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Application_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "User",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Jobsuche",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        JobOfferId = table.Column<int>(type: "int", nullable: false),
            //        CompanyId = table.Column<int>(type: "int", nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        JobId = table.Column<int>(type: "int", nullable: false),
            //        Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DateAnswered = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Proof = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Jobsuche", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Jobsuche_JobOffer_JobOfferId",
            //            column: x => x.JobOfferId,
            //            principalSchema: "dbo",
            //            principalTable: "JobOffer",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Jobsuche_User_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "dbo",
            //            principalTable: "User",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Application_BodyId",
        //        schema: "dbo",
        //        table: "Application",
        //        column: "BodyId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Application_FooterId",
        //        schema: "dbo",
        //        table: "Application",
        //        column: "FooterId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Application_HeaderId",
        //        schema: "dbo",
        //        table: "Application",
        //        column: "HeaderId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Application_JobOfferId",
        //        schema: "dbo",
        //        table: "Application",
        //        column: "JobOfferId",
        //        unique: true,
        //        filter: "[JobOfferId] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Application_UserId",
        //        schema: "dbo",
        //        table: "Application",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CompanyBranch_CompanyId",
        //        schema: "dbo",
        //        table: "CompanyBranch",
        //        column: "CompanyId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CompanyContactData_CompanyBranchId",
        //        schema: "dbo",
        //        table: "CompanyContactData",
        //        column: "CompanyBranchId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CompanyHistory_CompanyId",
        //        schema: "dbo",
        //        table: "CompanyHistory",
        //        column: "CompanyId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_HeadhuntercontactData_HunterId",
        //        schema: "dbo",
        //        table: "HeadhuntercontactData",
        //        column: "HunterId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_JobData_JobId",
        //        schema: "dbo",
        //        table: "JobData",
        //        column: "JobId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_JobOffer_CompanyBranchId",
        //        schema: "dbo",
        //        table: "JobOffer",
        //        column: "CompanyBranchId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_JobOffer_HeadHunterId",
        //        schema: "dbo",
        //        table: "JobOffer",
        //        column: "HeadHunterId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_JobOffer_JobExchangeId",
        //        schema: "dbo",
        //        table: "JobOffer",
        //        column: "JobExchangeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_JobOffer_JobId",
        //        schema: "dbo",
        //        table: "JobOffer",
        //        column: "JobId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_JobSkill_JobId",
        //        schema: "dbo",
        //        table: "JobSkill",
        //        column: "JobId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Jobsuche_JobOfferId",
        //        schema: "dbo",
        //        table: "Jobsuche",
        //        column: "JobOfferId",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Jobsuche_UserId",
        //        schema: "dbo",
        //        table: "Jobsuche",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UserContactData_UserId",
        //        schema: "dbo",
        //        table: "UserContactData",
        //        column: "UserId",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UserEducation_UserId",
        //        schema: "dbo",
        //        table: "UserEducation",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UserJobHistory_UserId",
        //        schema: "dbo",
        //        table: "UserJobHistory",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UserSkill_UserId",
        //        schema: "dbo",
        //        table: "UserSkill",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UserWebsite_UserId",
        //        schema: "dbo",
        //        table: "UserWebsite",
        //        column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application",
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
                name: "ApplicationBody",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationFooter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationHeader",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobOffer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
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
                name: "JobExchange",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "dbo");
        }
    }
}
