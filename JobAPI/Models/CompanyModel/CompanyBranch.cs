using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.CompanyModel
{
    public class CompanyBranch
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
        /// Required
        /// </summary>
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Required, Max length = 150
        /// </summary>
        [MaxLength(150)]
        [StringLength(150)]
        public string Description { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string AddressNation { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string AddressCity { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string AddressStreet { get; set; }

        /// <summary>
        /// Required, Max length = 30
        /// </summary>
        [Required]
        [MaxLength(30)]
        [StringLength(30)]
        public string AddressState { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/

        /// <summary>
        /// company deletes branch deletes contactdata
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.CompanyModel.CompanyContactData> Contacts { get; protected set; }

        public Company Company { get; set; }
        public virtual ICollection<global::JobAPI.Models.JobModel.JobOffer> Offers { get; protected set; }
    }
}
