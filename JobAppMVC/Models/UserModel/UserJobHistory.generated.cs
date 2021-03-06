//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v2.0.5.6
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace JobApp.Models.UserModel
{
   /// <summary>
   /// History of the users former jobs
   /// </summary>
   public class UserJobHistory
   {
      //partial void Init();

      ///// <summary>
      ///// Default constructor. Protected due to required properties, but present because EF needs it.
      ///// </summary>
      //protected UserJobHistory()
      //{
      //   Init();
      //}

      ///// <summary>
      ///// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      ///// </summary>
      //public static UserJobHistory CreateUserJobHistoryUnsafe()
      //{
      //   return new UserJobHistory();
      //}

      ///// <summary>
      ///// Public constructor with required data
      ///// </summary>
      ///// <param name="userid">Required</param>
      ///// <param name="title">Required, Max length = 30     Name of past,current or future Job</param>
      ///// <param name="skillsummary">Required, Max length = 250     Summary of skills used or learned on job</param>
      ///// <param name="testimonyurl">Required, Max length = 50     Url to the testimony</param>
      ///// <param name="salary">Required     Salary of Job</param>
      ///// <param name="startdate">Required     (planned) Start date of  past,current or future Job</param>
      ///// <param name="enddate">Required     (planned) End date of  past or current Job</param>
      ///// <param name="current">Historic retention property</param>
      ///// <param name="_user0"></param>
      //public UserJobHistory(int userid, string title, string skillsummary, string testimonyurl, decimal salary, DateTime startdate, DateTime enddate, bool current, global::JobApp.Models.UserModel.User _user0)
      //{
      //   this.UserId = userid;

      //   if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
      //   this.Title = title;

      //   if (string.IsNullOrEmpty(skillsummary)) throw new ArgumentNullException(nameof(skillsummary));
      //   this.SkillSummary = skillsummary;

      //   if (string.IsNullOrEmpty(testimonyurl)) throw new ArgumentNullException(nameof(testimonyurl));
      //   this.TestimonyUrl = testimonyurl;

      //   this.Salary = salary;

      //   this.StartDate = startdate;

      //   this.EndDate = enddate;

      //   this.Current = current;

      //   if (_user0 == null) throw new ArgumentNullException(nameof(_user0));
      //   _user0.JobHistory.Add(this);


      //   Init();
      //}

      ///// <summary>
      ///// Static create function (for use in LINQ queries, etc.)
      ///// </summary>
      ///// <param name="userid">Required</param>
      ///// <param name="title">Required, Max length = 30     Name of past,current or future Job</param>
      ///// <param name="skillsummary">Required, Max length = 250     Summary of skills used or learned on job</param>
      ///// <param name="testimonyurl">Required, Max length = 50     Url to the testimony</param>
      ///// <param name="salary">Required     Salary of Job</param>
      ///// <param name="startdate">Required     (planned) Start date of  past,current or future Job</param>
      ///// <param name="enddate">Required     (planned) End date of  past or current Job</param>
      ///// <param name="current">Historic retention property</param>
      ///// <param name="_user0"></param>
      //public static UserJobHistory Create(int userid, string title, string skillsummary, string testimonyurl, decimal salary, DateTime startdate, DateTime enddate, bool current, global::JobApp.Models.UserModel.User _user0)
      //{
      //   return new UserJobHistory(userid, title, skillsummary, testimonyurl, salary, startdate, enddate, current, _user0);
      //}

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Identity, Required
      /// Identity, Required
      /// </summary>
      [Key]
      [Required]
      public int Id { get; protected set; }

      /// <summary>
      /// Required
      /// Required
      /// </summary>
      [Required]
      public int UserId { get; set; }

      /// <summary>
      /// Required, Max length = 30
      /// Required, Max length = 30     Name of past,current or future Job
      /// </summary>
      [Required]
      [MaxLength(30)]
      [StringLength(30)]
      public string Title { get; set; }

      /// <summary>
      /// Max length = 250
      /// Required, Max length = 250     Description of past,current or future Job
      /// </summary>
      [MaxLength(250)]
      [StringLength(250)]
      public string Description { get; set; }

      /// <summary>
      /// Required, Max length = 250
      /// Required, Max length = 250     Summary of skills used or learned on job
      /// </summary>
      [Required]
      [MaxLength(250)]
      [StringLength(250)]
      public string SkillSummary { get; set; }

      /// <summary>
      /// Required, Max length = 50
      /// Required, Max length = 50     Url to the testimony
      /// </summary>
      [Required]
      [MaxLength(50)]
      [StringLength(50)]
      public string TestimonyUrl { get; set; }

      /// <summary>
      /// Required
      /// Required     Salary of Job
      /// </summary>
      [Required]
      public decimal Salary { get; set; }

      /// <summary>
      /// Required
      /// Required     (planned) Start date of  past,current or future Job
      /// </summary>
      [Required]
      public DateTime StartDate { get; set; }

      /// <summary>
      /// Required
      /// Required     (planned) End date of  past or current Job
      /// </summary>
      [Required]
      public DateTime EndDate { get; set; }

      /// <summary>
      /// Required
      /// Historic retention property
      /// </summary>
      [Required]
      public bool Current { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/
      public User User { get; set; }
   }
}

