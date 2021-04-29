using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.JobModel
{
    public class JobSkill
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
        /// Required, Max length = 30
        /// Required, Max length = 30
        /// </summary>
        [Required]
        [MaxLength(30)]
        [StringLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// Required, Max length = 250
        /// Required, Max length = 250
        /// </summary>
        [Required]
        [MaxLength(250)]
        [StringLength(250)]
        public string Content { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/
        public Job Job { get; set; }
    }
}
