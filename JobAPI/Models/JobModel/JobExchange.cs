using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.JobModel
{
    public class JobExchange
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
        /// Required, Min length = 3, Max length = 30
        /// Required, Min length = 3, Max length = 30
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [StringLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// Max length = 50
        /// Required, Max length = 50
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        public string Url { get; set; }

        /// <summary>
        /// Required
        /// Historic retention property
        /// </summary>
        [Required]
        public bool Current { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/
        public virtual ICollection<global::JobAPI.Models.JobModel.JobOffer> Offers { get; protected set; }
    }
}
