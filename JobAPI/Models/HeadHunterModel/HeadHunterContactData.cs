using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.HeadHunterModel
{
    public class HeadHunterContactData
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
