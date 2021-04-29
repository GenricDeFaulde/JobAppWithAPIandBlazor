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

namespace JobApp.Models.JobModel
{
   /// <summary>
   /// Skills asked for in the joboffer
   /// </summary>
   public partial class JobSkill
   {
      //partial void Init();

      ///// <summary>
      ///// Default constructor. Protected due to required properties, but present because EF needs it.
      ///// </summary>
      //protected JobSkill()
      //{
      //   Init();
      //}

      ///// <summary>
      ///// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      ///// </summary>
      //public static JobSkill CreateJobSkillUnsafe()
      //{
      //   return new JobSkill();
      //}

      ///// <summary>
      ///// Public constructor with required data
      ///// </summary>
      ///// <param name="jobid">Required</param>
      ///// <param name="name">Required, Max length = 30</param>
      ///// <param name="content">Required, Max length = 250</param>
      ///// <param name="_job0"></param>
      //public JobSkill(int jobid, string name, string content, global::JobApp.Models.JobModel.Job _job0)
      //{
      //   this.JobId = jobid;

      //   if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
      //   this.Name = name;

      //   if (string.IsNullOrEmpty(content)) throw new ArgumentNullException(nameof(content));
      //   this.Content = content;

      //   if (_job0 == null) throw new ArgumentNullException(nameof(_job0));
      //   _job0.JobSkillz.Add(this);


      //   Init();
      //}

      ///// <summary>
      ///// Static create function (for use in LINQ queries, etc.)
      ///// </summary>
      ///// <param name="jobid">Required</param>
      ///// <param name="name">Required, Max length = 30</param>
      ///// <param name="content">Required, Max length = 250</param>
      ///// <param name="_job0"></param>
      //public static JobSkill Create(int jobid, string name, string content, global::JobApp.Models.JobModel.Job _job0)
      //{
      //   return new JobSkill(jobid, name, content, _job0);
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
      public int JobId { get; set; }

      /// <summary>
      /// Required, Max length = 30
      /// Required, Max length = 30
      /// </summary>
      [Required]
      [MaxLength(30)]
      [StringLength(30)]
      public string Name { get; set; }

      /// <summary>
      /// Required, Max length = 250
      /// Required, Max length = 250
      /// </summary>
      [Required]
      [MaxLength(250)]
      [StringLength(250)]
      public string Content { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/
      public Job Job { get; set; }
   }
}

