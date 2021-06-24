using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JobAPI.Data
{
    public class JobDbContext : DbContext
    {
        #region DbSets

        /// <summary>
        /// Repository for global::JobAPI.Models.ApplicationModel.Application - Main Application
        /// class
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.ApplicationModel.Application> ApplicationsDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.ApplicationModel.ApplicationBody - Main content
        /// of an application
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.ApplicationModel.ApplicationBody> ApplicationBodiesDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.ApplicationModel.ApplicationFooter - an applications
        /// footer
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.ApplicationModel.ApplicationFooter> ApplicationFootersDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.ApplicationModel.ApplicationHeader - Header
        /// of an application
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.ApplicationModel.ApplicationHeader> ApplicationHeadersDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.CompanyModel.Company - Company masterclass
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.CompanyModel.Company> CompaniesDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.CompanyModel.CompanyBranch - Info on branch
        /// of company
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.CompanyModel.CompanyBranch> CompanyBranchDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.CompanyModel.CompanyContactData - Ways to contact
        /// a given company
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.CompanyModel.CompanyContactData> CompanyContactdatasDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.CompanyModel.CompanyHistory - The companies
        /// important dates
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.CompanyModel.CompanyHistory> CompanyHistoriesDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.HeadHunterModel.HeadHunter - Headhunters and
        /// private sources
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.HeadHunterModel.HeadHunter> HeadHunter { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.HeadHunterModel.HeadHunterContactData - Contact
        /// data of a Headhunter
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData> HHContactDatas { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.JobModel.Job - Job masterclass
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.JobModel.Job> JobsDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.JobModel.JobData - General Data about a job
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.JobModel.JobData> JobDataDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.JobModel.JobExchange - Data about a Jobexchange
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.JobModel.JobExchange> JobExchangesDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.JobModel.JobOffer - An offered Job
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.JobModel.JobOffer> JobOffersDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.JobModel.JobSkill - Skills asked for in the
        /// joboffer
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.JobModel.JobSkill> JobSkillsDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.ALVModel.Jobsuche - Has all information to generate
        /// ALV view
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.ALVModel.Jobsuche> ALVDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.UserModel.User - User main class
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.UserModel.User> UserDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.UserModel.UserContactData - Contact data of
        /// the user
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.UserModel.UserContactData> UserContactDatasDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.UserModel.UserEducation - Summary of the users
        /// education
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.UserModel.UserEducation> UserEducationsDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.UserModel.UserJobHistory - History of the users
        /// former jobs
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.UserModel.UserJobHistory> UserPastJobs { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.UserModel.UserSkill - description of a particular
        /// skill the user has
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.UserModel.UserSkill> UserSkillsDB { get; set; }

        /// <summary>
        /// Repository for global::JobAPI.Models.UserModel.UserWebsite - Name and URL of the
        /// users websites
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<global::JobAPI.Models.UserModel.UserWebsite> UserWebSitesDB { get; set; }
        #endregion DbSets

        

        /// <inheritdoc />
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");


            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.Application>()
                        .ToTable("Application")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.Application>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.Application>()
                        .Property(t => t.UserId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.Application>()
                        .Property(t => t.Title)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.Application>()
                        .Property(t => t.Answer)
                        .HasMaxLength(500)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.Application>()
                        .Property(t => t.DateSent)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.Application>()
                        .Property(t => t.DateAnswered)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.Application>()
                        .HasOne(x => x.Header)
                        .WithMany(b => b.Applications)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.Application>()
                        .HasOne(x => x.Body)
                        .WithMany(b => b.Applications)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.Application>()
                        .HasOne(x => x.Footer)
                        .WithMany(b => b.Applications)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationBody>()
                        .ToTable("ApplicationBody")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationBody>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationBody>()
                        .Property(t => t.ApplicationnId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationBody>()
                        .Property(t => t.Title)
                        .HasMaxLength(20)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationBody>()
                        .Property(t => t.Content)
                        .HasMaxLength(1500)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationBody>()
                        .HasMany(b => b.Applications)
                        .WithOne(t => t.Body)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationFooter>()
                        .ToTable("ApplicationFooter")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationFooter>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationFooter>()
                        .Property(t => t.ApplicationnId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationFooter>()
                        .Property(t => t.Title)
                        .HasMaxLength(20)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationFooter>()
                        .Property(t => t.Content)
                        .HasMaxLength(1500)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationFooter>()
                        .HasMany(b => b.Applications)
                        .WithOne(t => t.Footer)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationHeader>()
                        .ToTable("ApplicationHeader")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationHeader>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationHeader>()
                        .Property(t => t.ApplicationnId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationHeader>()
                        .Property(t => t.Title)
                        .HasMaxLength(20)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationHeader>()
                        .Property(t => t.Content)
                        .HasMaxLength(1500)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ApplicationModel.ApplicationHeader>()
                        .HasMany(b => b.Applications)
                        .WithOne(t => t.Header)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.Company>()
                        .ToTable("Company")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.Company>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.Company>()
                        .Property(t => t.CompanyName)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.Company>()
                        .Property(t => t.Current)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.Company>()
                        .Property(t => t.Description)
                        .HasMaxLength(250)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.Company>()
                        .HasMany(x => x.Branches)
                        .WithOne(u => u.Company)

                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.Company>()
                        .HasMany(x => x.HistoryList)
                        .WithOne(u => u.Company)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyBranch>()
                        .ToTable("CompanyBranch")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyBranch>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyBranch>()
                        .Property(t => t.CompanyId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyBranch>()
                        .Property(t => t.Name)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyBranch>()
                        .Property(t => t.Description)
                        .HasMaxLength(150);
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyBranch>()
                        .Property(t => t.AddressNation)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyBranch>()
                        .Property(t => t.AddressCity)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyBranch>()
                        .Property(t => t.AddressStreet)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyBranch>()
                        .Property(t => t.AddressState)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyBranch>()
                        .HasMany(x => x.Contacts)
                        .WithOne(u => u.CompanyBranch)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyContactData>()
                        .ToTable("CompanyContactData")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyContactData>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyContactData>()
                        .Property(t => t.CompanyId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyContactData>()
                        .Property(t => t.Name)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyContactData>()
                        .Property(t => t.PhoneNumber)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyContactData>()
                        .Property(t => t.PhoneNumberAlt)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyContactData>()
                        .Property(t => t.EmailAddress)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyContactData>()
                        .Property(t => t.EmailAddressAlt)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyContactData>()
                        .Property(t => t.IsActive)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyContactData>()
                        .HasOne(t => t.CompanyBranch)
                        .WithMany(u => u.Contacts);

            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyHistory>()
                        .ToTable("CompanyHistory")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyHistory>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyHistory>()
                        .Property(t => t.CompanyId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyHistory>()
                        .Property(t => t.Name)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyHistory>()
                        .Property(t => t.Content)
                        .HasMaxLength(250);
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyHistory>()
                        .Property(t => t.Date)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.CompanyModel.CompanyHistory>()
                        .HasOne(t => t.Company)
                        .WithMany(u => u.HistoryList);

            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunter>()
                        .ToTable("Headhunter")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunter>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunter>()
                        .Property(t => t.FirstName)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunter>()
                        .Property(t => t.LastName)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunter>()
                        .Property(t => t.IsActive)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunter>()
                        .HasMany(x => x.ContactInfos)
                        .WithOne(u => u.Hunter)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .ToTable("HeadhuntercontactData")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .Property(t => t.AddressNation)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .Property(t => t.AddressCity)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .Property(t => t.AddressStreet)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .Property(t => t.AddressState)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .Property(t => t.PhoneNumber)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .Property(t => t.PhoneNumberAlt)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .Property(t => t.EmailAddress)
                        .HasMaxLength(30);
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .Property(t => t.IsActive)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData>()
                        .HasOne(u => u.Hunter)
                        .WithMany(x => x.ContactInfos)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<global::JobAPI.Models.JobModel.Job>()
                        .ToTable("Job")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.Job>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.Job>()
                        .Property(t => t.Title)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.Job>()
                        .Property(t => t.TitleAlt)
                        .HasMaxLength(30);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.Job>()
                        .Property(t => t.TitleAlt2)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.Job>()
                        .HasMany(x => x.JobData)
                        .WithOne(u => u.Job)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<global::JobAPI.Models.JobModel.Job>()
                        .HasMany(x => x.JobSkillz)
                        .WithOne(u => u.Job)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .ToTable("JobData")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .Property(t => t.JobId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .Property(t => t.DescriptionShort)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .Property(t => t.DescriptionLong)
                        .HasMaxLength(250);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .Property(t => t.Nation)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .Property(t => t.Region)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .Property(t => t.MinSalary)
                        .IsRequired()
                        .HasColumnType("decimal(9,3)");
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .Property(t => t.MaxSalary)
                        .IsRequired()
                        .HasColumnType("decimal(9,3)");
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .Property(t => t.Current)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobData>()
                        .HasOne(u => u.Job)
                        .WithMany(x => x.JobData)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobExchange>()
                        .ToTable("JobExchange")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobExchange>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobExchange>()
                        .Property(t => t.Name)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobExchange>()
                        .Property(t => t.Url)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobExchange>()
                        .Property(t => t.Current)
                        .IsRequired();

            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .ToTable("JobOffer")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .Property(t => t.SalaryOffered)
                        .HasColumnType("decimal(9,3)");
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .Property(t => t.IsActive)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .Property(t => t.Releasedate)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .Property(t => t.JobOfferUrl)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .HasOne(x => x.Application)
                        .WithOne()

                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .HasOne(x => x.Jobsuche)
                        .WithOne()

                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .HasOne(x => x.Job)
                        .WithMany(u => u.Offers)

                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .HasOne(x => x.JobExchange)
                        .WithMany(u => u.Offers)

                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .HasOne(x => x.CompanyBranch)
                        .WithMany(u => u.Offers)

                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobOffer>()
                        .HasOne(x => x.HeadHunter)
                        .WithMany(u => u.Offers)

                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobSkill>()
                        .ToTable("JobSkill")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobSkill>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobSkill>()
                        .Property(t => t.JobId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobSkill>()
                        .Property(t => t.Name)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobSkill>()
                        .Property(t => t.Content)
                        .HasMaxLength(250)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.JobModel.JobSkill>()
                        .HasOne(x => x.Job)
                        .WithMany(u => u.JobSkillz)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<global::JobAPI.Models.ALVModel.Jobsuche>()
                        .ToTable("Jobsuche")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.ALVModel.Jobsuche>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.ALVModel.Jobsuche>()
                        .Property(t => t.UserId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ALVModel.Jobsuche>()
                        .Property(t => t.JobOfferId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ALVModel.Jobsuche>()
                        .Property(t => t.Email)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.ALVModel.Jobsuche>()
                        .Property(t => t.JobId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ALVModel.Jobsuche>()
                        .Property(t => t.Status)
                        .HasMaxLength(20)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ALVModel.Jobsuche>()
                        .Property(t => t.DateSent)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.ALVModel.Jobsuche>()
                        .Property(t => t.DateAnswered)
                        .IsRequired();

            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .ToTable("User")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .Property(t => t.ProfileId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .Property(t => t.FirstName)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .Property(t => t.LastName)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .Property(t => t.BirthDate)
                        .HasMaxLength(20)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .Property(t => t.Religion)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .Property(t => t.Sex)
                        .HasMaxLength(20);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .Property(t => t.Gender)
                        .HasMaxLength(20);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .Property(t => t.Nationality)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .Property(t => t.Nationality2)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .HasOne(x => x.ContactData)
                        .WithOne(u => u.User)

                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .HasMany(x => x.EducationHistory)
                        .WithOne(u => u.User)

                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .HasMany(x => x.JobHistory)
                        .WithOne(u => u.User)

                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .HasMany(x => x.Skills)
                        .WithOne(u => u.User)

                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .HasMany(x => x.Websites)
                        .WithOne(u => u.User)

                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .HasMany(x => x.Applications)
                        .WithOne(u => u.User)

                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.User>()
                        .HasMany(x => x.JobsGesucht)
                        .WithOne(u => u.User)

                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .ToTable("UserContactData")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.UserId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.AddressNation)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.AddressCity)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.AddressStreet)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.AddressState)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.PhoneNumber)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.PhoneNumberAlt)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.EmailAddress)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.EmailAddressAlt)
                        .HasMaxLength(50);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .Property(t => t.Current)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserContactData>()
                        .HasOne(u => u.User)
                        .WithOne(x => x.ContactData)

                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .ToTable("UserEducation")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.UserId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.Title)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.Facility)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.AddressNation)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.FacilityAddressCity)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.FacilityAddressStreet)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.FacilityAddressState)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.Graduation)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.TestimonyUrl)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.StartDate)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .Property(t => t.EndDate)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserEducation>()
                        .HasOne(u => u.User)
                        .WithMany(x => x.EducationHistory)

                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .ToTable("UserJobHistory")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .Property(t => t.UserId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .Property(t => t.Title)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .Property(t => t.Description)
                        .HasMaxLength(250);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .Property(t => t.SkillSummary)
                        .HasMaxLength(250)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .Property(t => t.TestimonyUrl)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .Property(t => t.Salary)
                        .IsRequired()
                        .HasColumnType("decimal(5,3)");
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .Property(t => t.StartDate)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .Property(t => t.EndDate)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                        .Property(t => t.Current)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserJobHistory>()
                         .HasOne(u => u.User)
                         .WithMany(x => x.JobHistory)
                         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserSkill>()
                        .ToTable("UserSkill")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserSkill>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserSkill>()
                        .Property(t => t.UserId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserSkill>()
                        .Property(t => t.SkillName)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserSkill>()
                        .Property(t => t.SkillDescritpion)
                        .HasMaxLength(100)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserSkill>()
                        .Property(t => t.SelfRating)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserSkill>()
                        .Property(t => t.Current)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserSkill>()
                         .HasOne(u => u.User)
                         .WithMany(x => x.Skills)
                         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserWebsite>()
                        .ToTable("UserWebsite")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserWebsite>()
                        .Property(t => t.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserWebsite>()
                        .Property(t => t.UserId)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserWebsite>()
                        .Property(t => t.Name)
                        .HasMaxLength(30)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserWebsite>()
                        .Property(t => t.Content)
                        .HasMaxLength(150);
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserWebsite>()
                        .Property(t => t.Url)
                        .HasMaxLength(50)
                        .IsRequired();
            modelBuilder.Entity<global::JobAPI.Models.UserModel.UserWebsite>()
                         .HasOne(u => u.User)
                         .WithMany(x => x.Websites)
                         .OnDelete(DeleteBehavior.Restrict);

            //OnModelCreatedImpl(modelBuilder);
        }
    }
}
