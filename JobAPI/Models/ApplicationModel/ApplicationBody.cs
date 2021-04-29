using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.ApplicationModel
{
    public class ApplicationBody
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
        public int ApplicationnId { get; set; }

        /// <summary>
        /// Required, Max length = 20
        /// Required, Max length = 20
        /// </summary>
        [Required]
        [MaxLength(20)]
        [StringLength(20)]
        public string Title { get; set; }

        /// <summary>
        /// Required, Max length = 1500
        /// Required, Max length = 1500
        /// </summary>
        [Required]
        [MaxLength(1500)]
        [StringLength(1500)]
        public string Content { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/
        public List<Application> Applications { get; set; }
    }
}
