using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.JobModel
{
    public class JobOffer
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
        /// FK to a companies branch
        /// </summary>
        public int? CompanyBranchId { get; set; }

        /// <summary>
        /// linkback to the details of an offered job
        /// </summary>
        public int? JobId { get; set; }

        /// <summary>
        /// FK to Headhunter
        /// </summary>
        public int? HeadHunterId { get; set; }

        /// <summary>
        /// FK to Jobexchange
        /// </summary>
        public int? JobExchangeId { get; set; }

        /// <summary>
        /// wich aplication was sent
        /// </summary>
        public int? ApplicationnId { get; set; }

        /// <summary>
        /// Offered salary for Job
        /// </summary>
        public decimal? SalaryOffered { get; set; }

        /// <summary>
        /// Required
        /// Required
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Required
        /// Required
        /// </summary>
        [Required]
        public DateTime Releasedate { get; set; }

        /// <summary>
        /// Max length = 50
        /// URL to the joboffer, if avialable
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        public string JobOfferUrl { get; set; }


        /*************************************************************************
         * Create selectlists
         *************************************************************************/
        [NotMapped]
        public List<SelectListItem> CompanyBranchesList { get; set; }
        [NotMapped]
        public List<SelectListItem> JobsList { get; set; }
        [NotMapped]
        public List<SelectListItem> HeadHuntersList { get; set; }
        [NotMapped]
        public List<SelectListItem> JobExchangesList { get; set; }


        /*************************************************************************
         * Navigation properties
         *************************************************************************/

        /// <summary>
        /// summary
        /// </summary>
        public virtual global::JobAPI.Models.ApplicationModel.Application Application { get; set; }

        /// <summary>
        /// summary
        /// </summary>
        public virtual global::JobAPI.Models.ALVModel.Jobsuche Jobsuche { get; set; }

        /// <summary>
        /// summary
        /// </summary>
        public virtual global::JobAPI.Models.JobModel.Job Job { get; set; }

        /// <summary>
        /// summary
        /// </summary>
        public virtual global::JobAPI.Models.JobModel.JobExchange JobExchange { get; set; }

        /// <summary>
        /// summary
        /// </summary>
        public virtual global::JobAPI.Models.CompanyModel.CompanyBranch CompanyBranch { get; set; }

        /// <summary>
        /// summary
        /// </summary>
        public virtual global::JobAPI.Models.HeadHunterModel.HeadHunter HeadHunter { get; set; }
    }
}
