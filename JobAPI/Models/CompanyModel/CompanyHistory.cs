using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.CompanyModel
{
    public class CompanyHistory
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
        public int CompanyId { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Max length = 250
        /// Max length = 50
        /// </summary>
        [MaxLength(250)]
        [StringLength(250)]
        public string Content { get; set; }

        /// <summary>
        /// Required
        /// Required
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/
        public Company Company { get; set; }
    }
}
