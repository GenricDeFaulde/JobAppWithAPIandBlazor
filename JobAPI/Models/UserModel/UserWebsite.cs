using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.UserModel
{
    public class UserWebsite
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
        /// Required, Max length = 30
        /// </summary>
        [Required]
        [MaxLength(30)]
        [StringLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// Max length = 150
        /// Max length = 150
        /// </summary>
        [MaxLength(150)]
        [StringLength(150)]
        public string Content { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Url { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/
        public User User { get; set; }
    }
}
