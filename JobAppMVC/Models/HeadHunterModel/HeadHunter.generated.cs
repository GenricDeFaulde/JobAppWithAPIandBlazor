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

namespace JobApp.Models.HeadHunterModel
{
   /// <summary>
   /// Headhunters and private sources
   /// </summary>
   public class HeadHunter
   {
      //partial void Init();

      ///// <summary>
      ///// Default constructor. Protected due to required properties, but present because EF needs it.
      ///// </summary>
      //protected HeadHunter()
      //{
      //   Name = new System.Collections.Generic.HashSet<global::JobApp.Models.HeadHunterModel.HeadHunterContactData>();

      //   Init();
      //}

      ///// <summary>
      ///// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      ///// </summary>
      //public static HeadHunter CreateHeadHunterUnsafe()
      //{
      //   return new HeadHunter();
      //}

      ///// <summary>
      ///// Public constructor with required data
      ///// </summary>
      ///// <param name="firstname">Required, Max length = 30</param>
      ///// <param name="lastname">Required, Max length = 30</param>
      ///// <param name="isactive">Required</param>
      ///// <param name="_joboffer0"></param>
      //public HeadHunter(string firstname, string lastname, bool isactive, global::JobApp.Models.JobModel.JobOffer _joboffer0)
      //{
      //   if (string.IsNullOrEmpty(firstname)) throw new ArgumentNullException(nameof(firstname));
      //   this.FirstName = firstname;

      //   if (string.IsNullOrEmpty(lastname)) throw new ArgumentNullException(nameof(lastname));
      //   this.LastName = lastname;

      //   this.IsActive = isactive;

      //   if (_joboffer0 == null) throw new ArgumentNullException(nameof(_joboffer0));
      //   _joboffer0.HeadHunter = this;

      //   this.Name = new System.Collections.Generic.HashSet<global::JobApp.Models.HeadHunterModel.HeadHunterContactData>();

      //   Init();
      //}

      ///// <summary>
      ///// Static create function (for use in LINQ queries, etc.)
      ///// </summary>
      ///// <param name="firstname">Required, Max length = 30</param>
      ///// <param name="lastname">Required, Max length = 30</param>
      ///// <param name="isactive">Required</param>
      ///// <param name="_joboffer0"></param>
      //public static HeadHunter Create(string firstname, string lastname, bool isactive, global::JobApp.Models.JobModel.JobOffer _joboffer0)
      //{
      //   return new HeadHunter(firstname, lastname, isactive, _joboffer0);
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
      /// Required, Max length = 30
      /// Required, Max length = 30
      /// </summary>
      [Required]
      [MaxLength(30)]
      [StringLength(30)]
      public string FirstName { get; set; }

      /// <summary>
      /// Required, Max length = 30
      /// Required, Max length = 30
      /// </summary>
      [Required]
      [MaxLength(30)]
      [StringLength(30)]
      public string LastName { get; set; }

      /// <summary>
      /// Required
      /// Required
      /// </summary>
      [Required]
      public bool IsActive { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// Headhunter deletes headhuntercontactdata
      /// </summary>
      public virtual ICollection<global::JobApp.Models.HeadHunterModel.HeadHunterContactData> ContactInfos { get; protected set; }
        public virtual ICollection<global::JobApp.Models.JobModel.JobOffer> Offers { get; protected set; }
    }
}

