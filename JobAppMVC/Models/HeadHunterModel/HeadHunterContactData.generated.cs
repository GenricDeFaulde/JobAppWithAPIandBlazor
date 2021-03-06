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
   /// Contact data of a Headhunter
   /// </summary>
   public class HeadHunterContactData
   {
      //partial void Init();

      ///// <summary>
      ///// Default constructor. Protected due to required properties, but present because EF needs it.
      ///// </summary>
      //protected HeadHunterContactData()
      //{
      //   Init();
      //}

      ///// <summary>
      ///// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      ///// </summary>
      //public static HeadHunterContactData CreateHeadHunterContactDataUnsafe()
      //{
      //   return new HeadHunterContactData();
      //}

      ///// <summary>
      ///// Public constructor with required data
      ///// </summary>
      ///// <param name="isactive">Required</param>
      ///// <param name="_headhunter0"></param>
      //public HeadHunterContactData(bool isactive, global::JobApp.Models.HeadHunterModel.HeadHunter _headhunter0)
      //{
      //   this.IsActive = isactive;

      //   if (_headhunter0 == null) throw new ArgumentNullException(nameof(_headhunter0));
      //   _headhunter0.Name.Add(this);


      //   Init();
      //}

      ///// <summary>
      ///// Static create function (for use in LINQ queries, etc.)
      ///// </summary>
      ///// <param name="isactive">Required</param>
      ///// <param name="_headhunter0"></param>
      //public static HeadHunterContactData Create(bool isactive, global::JobApp.Models.HeadHunterModel.HeadHunter _headhunter0)
      //{
      //   return new HeadHunterContactData(isactive, _headhunter0);
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
      /// FK to company
      /// </summary>
      public int? CompanyId { get; set; }

      /// <summary>
      /// linkback to Jobexchange if Headhunter is associated with one
      /// </summary>
      public int? JobExchangeId { get; set; }

      /// <summary>
      /// Max length = 50
      /// Max length = 50
      /// </summary>
      [MaxLength(50)]
      [StringLength(50)]
      public string AddressNation { get; set; }

      /// <summary>
      /// Max length = 50
      /// Max length = 50
      /// </summary>
      [MaxLength(50)]
      [StringLength(50)]
      public string AddressCity { get; set; }

      /// <summary>
      /// Max length = 50
      /// Max length = 50
      /// </summary>
      [MaxLength(50)]
      [StringLength(50)]
      public string AddressStreet { get; set; }

      /// <summary>
      /// Max length = 50
      /// Max length = 50
      /// </summary>
      [MaxLength(50)]
      [StringLength(50)]
      public string AddressState { get; set; }

      /// <summary>
      /// Max length = 50
      /// Max length = 50
      /// </summary>
      [MaxLength(50)]
      [StringLength(50)]
      public string PhoneNumber { get; set; }

      /// <summary>
      /// Max length = 50
      /// Max length = 50
      /// </summary>
      [MaxLength(50)]
      [StringLength(50)]
      public string PhoneNumberAlt { get; set; }

      /// <summary>
      /// Min length = 5, Max length = 30
      /// Min length = 5, Max length = 30
      /// </summary>
      [MinLength(5)]
      [MaxLength(30)]
      [StringLength(30)]
      public string EmailAddress { get; set; }

      /// <summary>
      /// Required
      /// Required
      /// </summary>
      [Required]
      public bool IsActive { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/
      public HeadHunter Hunter { get; set; }
   }
}

