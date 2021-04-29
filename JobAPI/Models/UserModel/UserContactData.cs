using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.UserModel
{
    public class UserContactData
    {
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
        /// Required, Max length = 50
        /// Required, Max length = 50     Address of User - Nation
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string AddressNation { get; set; }

        /// <summary>
        /// Required, Min length = 5, Max length = 50
        /// Required, Min length = 5, Max length = 50     Address of User - City including PO
        /// number
        /// </summary>
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [StringLength(50)]
        public string AddressCity { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     Address of User - Street including house number
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string AddressStreet { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     Address of User - State if applicable
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string AddressState { get; set; }

        /// <summary>
        /// Required, Max length = 30
        /// Required, Max length = 30     Users main phone number
        /// </summary>
        [Required]
        [MaxLength(30)]
        [StringLength(30)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Max length = 50
        /// Max length = 50     Users alternative phone number
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        public string PhoneNumberAlt { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     Users main email address
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Max length = 50
        /// Required, Max length = 50     Users alternative email address
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        public string EmailAddressAlt { get; set; }

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
