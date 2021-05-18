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
        [Required]
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

        //additional properties
        //
        // applicationusermodel

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Dictionary<string, string> Roles { get; set; } = new Dictionary<string, string>();

        // jobappuser

        public bool IsAdmin { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/


    }
}
