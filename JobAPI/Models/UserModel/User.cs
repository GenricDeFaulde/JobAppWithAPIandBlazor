using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.UserModel
{
    public class User
    {
        /*************************************************************************
     * Properties
     *************************************************************************/

        /// <summary>
        /// Identity, Required
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// AuthProfileIdentity, Required
        /// </summary>
        [Key]
        [Required]
        public string ProfileId { get; set; }

        /// <summary>
        /// Required, Min length = 3, Max length = 30
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [StringLength(30)]
        public string FirstName { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Required, Max length = 20
        /// </summary>
        [MaxLength(20)]
        [StringLength(20)]
        public string BirthDate { get; set; }

        /// <summary>
        /// Max length = 50
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        public string Religion { get; set; }

        /// <summary>
        /// Max length = 20     Biological Sex of User
        /// </summary>
        [MaxLength(20)]
        [StringLength(20)]
        public string Sex { get; set; }

        /// <summary>
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
        /// Required, Max length = 50     Nationality
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Nationality { get; set; }

        /// <summary>
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
        public virtual global::JobAPI.Models.UserModel.UserContactData ContactData { get; protected set; }

        /// <summary>
        /// user deletes educationhistory
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.UserModel.UserEducation> EducationHistory { get; protected set; }

        /// <summary>
        /// user deletes userjobhistory
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.UserModel.UserJobHistory> JobHistory { get; protected set; }

        /// <summary>
        /// user deletes skills
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.UserModel.UserSkill> Skills { get; protected set; }

        /// <summary>
        /// user deletes userwebsites
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.UserModel.UserWebsite> Websites { get; protected set; }

        /// <summary>
        /// summary
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.ApplicationModel.Application> Applications { get; protected set; }

        /// <summary>
        /// summary
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.ALVModel.Jobsuche> JobsGesucht { get; protected set; }
    }
}
