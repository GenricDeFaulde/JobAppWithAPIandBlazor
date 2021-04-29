using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.JobModel
{
    public class Job
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
        public int Id { get; set; }

        /// <summary>
        /// FK to an offered job
        /// </summary>
        public int? JobOfferId { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Max length = 30
        /// Max length = 30
        /// </summary>
        [MaxLength(30)]
        [StringLength(30)]
        public string TitleAlt { get; set; }

        /// <summary>
        /// Max length = 50
        /// Required, Max length = 50
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        public string TitleAlt2 { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/

        /// <summary>
        /// summary
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.JobModel.JobData> JobData { get; protected set; }

        /// <summary>
        /// job deletes associated skills
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.JobModel.JobSkill> JobSkillz { get; protected set; }
        public virtual ICollection<global::JobAPI.Models.JobModel.JobOffer> Offers { get; protected set; }
    }
}
