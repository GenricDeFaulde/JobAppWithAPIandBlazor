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
  /// User main class
  /// </summary>
  public class User
  {
    //partial void Init();

    ///// <summary>
    ///// Default constructor. Protected due to required properties, but present because EF needs it.
    ///// </summary>
    //protected User()
    //{
    //   EducationHistory = new System.Collections.Generic.HashSet<global::JobApp.Models.UserModel.UserEducation>();
    //   JobHistory = new System.Collections.Generic.HashSet<global::JobApp.Models.UserModel.UserJobHistory>();
    //   Skills = new System.Collections.Generic.HashSet<global::JobApp.Models.UserModel.UserSkill>();
    //   Websites = new System.Collections.Generic.HashSet<global::JobApp.Models.UserModel.UserWebsite>();
    //   Applications = new System.Collections.Generic.HashSet<global::JobApp.Models.ApplicationModel.Application>();
    //   JobsGesucht = new System.Collections.Generic.HashSet<global::JobApp.Models.ALVModel.Jobsuche>();

    //   Init();
    //}

    ///// <summary>
    ///// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
    ///// </summary>
    //public static User CreateUserUnsafe()
    //{
    //   return new User();
    //}

    ///// <summary>
    ///// Public constructor with required data
    ///// </summary>
    ///// <param name="firstname">Required, Min length = 3, Max length = 30</param>
    ///// <param name="lastname">Required, Max length = 50</param>
    ///// <param name="birthdate">Required, Max length = 20</param>
    ///// <param name="nationality">Required, Max length = 50     Nationality</param>
    //public User(string firstname, string lastname, string birthdate, string nationality)
    //{
    //   if (string.IsNullOrEmpty(firstname)) throw new ArgumentNullException(nameof(firstname));
    //   this.FirstName = firstname;

    //   if (string.IsNullOrEmpty(lastname)) throw new ArgumentNullException(nameof(lastname));
    //   this.LastName = lastname;

    //   if (string.IsNullOrEmpty(birthdate)) throw new ArgumentNullException(nameof(birthdate));
    //   this.BirthDate = birthdate;

    //   if (string.IsNullOrEmpty(nationality)) throw new ArgumentNullException(nameof(nationality));
    //   this.Nationality = nationality;

    //   this.EducationHistory = new System.Collections.Generic.HashSet<global::JobApp.Models.UserModel.UserEducation>();
    //   this.JobHistory = new System.Collections.Generic.HashSet<global::JobApp.Models.UserModel.UserJobHistory>();
    //   this.Skills = new System.Collections.Generic.HashSet<global::JobApp.Models.UserModel.UserSkill>();
    //   this.Websites = new System.Collections.Generic.HashSet<global::JobApp.Models.UserModel.UserWebsite>();
    //   this.Applications = new System.Collections.Generic.HashSet<global::JobApp.Models.ApplicationModel.Application>();
    //   this.JobsGesucht = new System.Collections.Generic.HashSet<global::JobApp.Models.ALVModel.Jobsuche>();

    //   Init();
    //}

    ///// <summary>
    ///// Static create function (for use in LINQ queries, etc.)
    ///// </summary>
    ///// <param name="firstname">Required, Min length = 3, Max length = 30</param>
    ///// <param name="lastname">Required, Max length = 50</param>
    ///// <param name="birthdate">Required, Max length = 20</param>
    ///// <param name="nationality">Required, Max length = 50     Nationality</param>
    //public static User Create(string firstname, string lastname, string birthdate, string nationality)
    //{
    //   return new User(firstname, lastname, birthdate, nationality);
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
    public int Id { get; set; }

    /// <summary>
    /// Required, Min length = 3, Max length = 30
    /// Required, Min length = 3, Max length = 30
    /// </summary>
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    [StringLength(30)]
    public string FirstName { get; set; }

    /// <summary>
    /// Required, Max length = 50
    /// Required, Max length = 50
    /// </summary>
    [Required]
    [MaxLength(50)]
    [StringLength(50)]
    public string LastName { get; set; }

    /// <summary>
    /// Required, Max length = 20
    /// Required, Max length = 20
    /// </summary>
    [Required]
    [MaxLength(20)]
    [StringLength(20)]
    public string BirthDate { get; set; }

    /// <summary>
    /// Max length = 50
    /// Max length = 50
    /// </summary>
    [MaxLength(50)]
    [StringLength(50)]
    public string Religion { get; set; }

    /// <summary>
    /// Max length = 20
    /// Max length = 20     Biological Sex of User
    /// </summary>
    [MaxLength(20)]
    [StringLength(20)]
    public string Sex { get; set; }

    /// <summary>
    /// Max length = 20
    /// Max length = 20     Gender of User
    /// </summary>
    [MaxLength(20)]
    [StringLength(20)]
    public string Gender { get; set; }

    /// <summary>
    /// Regular Picture representing the User
    /// </summary>
    public byte[] Picture { get; set; }

    /// <summary>
    /// Alternative Picture representing the User
    /// </summary>
    public byte[] PictureAlt { get; set; }

    /// <summary>
    /// Required, Max length = 50
    /// Required, Max length = 50     Nationality
    /// </summary>
    [Required]
    [MaxLength(50)]
    [StringLength(50)]
    public string Nationality { get; set; }

    /// <summary>
    /// Max length = 50
    /// Max length = 50     2nd Nationality if applicant
    /// </summary>
    [MaxLength(50)]
    [StringLength(50)]
    public string Nationality2 { get; set; }

    /*************************************************************************
     * Navigation properties
     *************************************************************************/

    /// <summary>
    /// summary
    /// </summary>
    public virtual global::JobApp.Models.UserModel.UserContactData ContactData { get; set; }

    /// <summary>
    /// user deletes educationhistory
    /// </summary>
    public virtual ICollection<global::JobApp.Models.UserModel.UserEducation> EducationHistory { get; protected set; }

    /// <summary>
    /// user deletes userjobhistory
    /// </summary>
    public virtual ICollection<global::JobApp.Models.UserModel.UserJobHistory> JobHistory { get; protected set; }

    /// <summary>
    /// user deletes skills
    /// </summary>
    public virtual ICollection<global::JobApp.Models.UserModel.UserSkill> Skills { get; protected set; }

    /// <summary>
    /// user deletes userwebsites
    /// </summary>
    public virtual ICollection<global::JobApp.Models.UserModel.UserWebsite> Websites { get; protected set; }

    /// <summary>
    /// summary
    /// </summary>
    public virtual ICollection<global::JobApp.Models.ApplicationModel.Application> Applications { get; protected set; }

    /// <summary>
    /// summary
    /// </summary>
    public virtual ICollection<global::JobApp.Models.ALVModel.Jobsuche> JobsGesucht { get; protected set; }

  }
}

