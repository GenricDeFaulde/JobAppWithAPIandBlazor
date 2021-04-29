using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.UserModel
{
    public class UserSkill
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
        public string SkillName { get; set; }

        /// <summary>
        /// Required, Max length = 100
        /// Required, Max length = 100
        /// </summary>
        [Required]
        [MaxLength(100)]
        [StringLength(100)]
        public string SkillDescritpion { get; set; }

        /// <summary>
        /// Required
        /// Required
        /// </summary>
        [Required]
        public int SelfRating { get; set; }

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
