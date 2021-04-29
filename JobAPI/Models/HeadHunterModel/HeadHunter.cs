using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.HeadHunterModel
{
    public class HeadHunter
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
        public virtual ICollection<global::JobAPI.Models.HeadHunterModel.HeadHunterContactData> ContactInfos { get; protected set; }
        public virtual ICollection<global::JobAPI.Models.JobModel.JobOffer> Offers { get; protected set; }
    }
}
