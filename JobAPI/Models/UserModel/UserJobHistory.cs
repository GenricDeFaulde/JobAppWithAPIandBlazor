using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.UserModel
{
    public class UserJobHistory
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
        /// Required, Max length = 30
        /// Required, Max length = 30     Name of past,current or future Job
        /// </summary>
        [Required]
        [MaxLength(30)]
        [StringLength(30)]
        public string Title { get; set; }

        /// <summary>
        /// Max length = 250
        /// Required, Max length = 250     Description of past,current or future Job
        /// </summary>
        [MaxLength(250)]
        [StringLength(250)]
        public string Description { get; set; }

        /// <summary>
        /// Required, Max length = 250
        /// Required, Max length = 250     Summary of skills used or learned on job
        /// </summary>
        [Required]
        [MaxLength(250)]
        [StringLength(250)]
        public string SkillSummary { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     Url to the testimony
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string TestimonyUrl { get; set; }

        /// <summary>
        /// Required
        /// Required     Salary of Job
        /// </summary>
        [Required]
        public decimal Salary { get; set; }

        /// <summary>
        /// Required
        /// Required     (planned) Start date of  past,current or future Job
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Required
        /// Required     (planned) End date of  past or current Job
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

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
