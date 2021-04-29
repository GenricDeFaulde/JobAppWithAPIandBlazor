using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.JobModel
{
    public class JobData
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
        public int JobId { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string DescriptionShort { get; set; }

        /// <summary>
        /// Max length = 250
        /// Max length = 250
        /// </summary>
        [MaxLength(250)]
        [StringLength(250)]
        public string DescriptionLong { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     What nation this data applies to
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Nation { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     What region this data applies to
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Region { get; set; }

        /// <summary>
        /// Required
        /// Required     Minimum Salary one could expect for this Job in this Region
        /// </summary>
        [Required]
        public decimal MinSalary { get; set; }

        /// <summary>
        /// Required
        /// Required     Maximum Salary one could expect for this Job in this Region
        /// </summary>
        [Required]
        public decimal MaxSalary { get; set; }

        /// <summary>
        /// Required
        /// Historic retention property
        /// </summary>
        [Required]
        public bool Current { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/
        public Job Job { get; set; }
    }
}
