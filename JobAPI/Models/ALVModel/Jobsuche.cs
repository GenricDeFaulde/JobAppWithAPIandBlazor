using JobAPI.Models.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.ALVModel
{
    public class Jobsuche
    {
        /*************************************************************************
       * Properties
       *************************************************************************/

        /// <summary>
        /// Identity, Required
        /// Identity of Jobsuche class
        /// </summary>
        [Key]
        [Required]
        public int Id { get; protected set; }

        /// <summary>
        /// Required
        /// FK to the user
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Required
        /// FK to an offered job
        /// </summary>
        [Required]
        public int JobOfferId { get; set; }

        /// <summary>
        /// FK to a company
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Max length = 50
        /// if application was sent by email
        /// </summary>
        [MaxLength(50)]
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Required
        /// FK to the job master class
        /// </summary>
        [Required]
        public int JobId { get; set; }

        /// <summary>
        /// Required, Max length = 20
        /// status of send application request
        /// </summary>
        [Required]
        [MaxLength(20)]
        [StringLength(20)]
        public string Status { get; set; }

        /// <summary>
        /// Required
        /// when was the application request sent
        /// </summary>
        [Required]
        public DateTime DateSent { get; set; }

        /// <summary>
        /// Required
        /// Date when answer arrived if application was answered
        /// </summary>
        [Required]
        public DateTime DateAnswered { get; set; }

        /// <summary>
        /// Proof of application
        /// </summary>
        public byte[] Proof { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/
        public User User { get; set; }
    }
}
