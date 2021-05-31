using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAppPortal.Models
{
    public class EditUserModel
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
        /// AuthProfileIdentity to match ApplicationUser, Required
        /// </summary>
        [Key]
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Link to Auth profile")]
        public string ProfileId { get; set; }

        /// <summary>
        /// Required, Min length = 3, Max length = 30
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [StringLength(30)]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        /// <summary>
        /// Required, Max length = 20
        /// </summary>
        [Required]
        [MaxLength(20)]
        [StringLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "Birthdate")]
        public string BirthDate { get; set; }

        /// <summary>
        /// Max length = 50
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Faith")]
        public string Religion { get; set; }

        /// <summary>
        /// Max length = 20     Biological Sex of User
        /// </summary>
        [MaxLength(20)]
        [StringLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "Sex")]
        public string Sex { get; set; }

        /// <summary>
        /// Max length = 20     Gender of User
        /// </summary>
        [MaxLength(20)]
        [StringLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Regular Picture representing the User
        /// </summary>
        [DataType(DataType.Upload)]
        [Display(Name = "User picture")]
        public byte[] Picture { get; set; }

        /// <summary>
        /// Alternative Picture representing the User
        /// </summary>
        [DataType(DataType.Upload)]
        [Display(Name = "alternative User picture")]
        public byte[] PictureAlt { get; set; }

        /// <summary>
        /// Required, Max length = 50     Nationality
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "User nationality")]
        public string Nationality { get; set; }

        /// <summary>
        /// Max length = 50     2nd Nationality if applicant
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "User nationality2")]
        public string Nationality2 { get; set; }

        //additional properties
        //
        // applicationusermodel

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User email")]
        public string Email { get; set; }


        public Dictionary<string, string> Roles { get; set; } = new Dictionary<string, string>();

        // jobappuser

        [Required]
        [Display(Name = "Is user admin")]
        public bool IsAdmin { get; set; }

        [Required]
        [Display(Name = "is user superadmin")]
        public bool IsSuperAdmin { get; set; }

        [Required]
        [Display(Name = "is user moderator")]
        public bool IsModerator { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/


    }
}
