using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.CompanyModel
{
    public class Company
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
        public int Id { get; internal set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Required
        /// Historic retention property
        /// </summary>
        [Required]
        public bool Current { get; set; }
        // public byte[] LogoBig { get; set; }

        [Required]
        [MaxLength(250)]
        [StringLength(250)]
        public string Description { get; set; }



        /*************************************************************************
         * Navigation properties
         *************************************************************************/

        /// <summary>
        /// company deletes branches
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.CompanyModel.CompanyBranch> Branches { get; protected set; }

        /// <summary>
        /// summary
        /// </summary>
        public virtual ICollection<global::JobAPI.Models.CompanyModel.CompanyHistory> HistoryList { get; protected set; }
    }
}
