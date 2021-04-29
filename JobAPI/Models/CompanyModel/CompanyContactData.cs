using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.CompanyModel
{
    public class CompanyContactData
    {
        /*************************************************************************
       * Properties
       *************************************************************************/

        /// <summary>
        /// Identity, Required
        /// </summary>
        [Key]
        [Required]
        public int Id { get; protected set; }

        /// <summary>
        /// Required
        /// </summary>
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// FK to a companies branch
        /// </summary>
        public int? CompanyBranchId { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Required, Max length = 30
        /// </summary>
        [Required]
        [MaxLength(30)]
        [StringLength(30)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string PhoneNumberAlt { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string EmailAddressAlt { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/
        public CompanyBranch CompanyBranch { get; set; }
    }
}
