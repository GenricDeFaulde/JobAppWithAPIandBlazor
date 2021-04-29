using JobAPI.Models.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.ApplicationModel
{
    public class Application
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
        /// FK to the joboffer this application was used for
        /// </summary>
        public int? JobOfferId { get; set; }

        /// <summary>
        /// Required, Max length = 30
        /// Required, Max length = 30
        /// </summary>
        [Required]
        [MaxLength(30)]
        [StringLength(30)]
        public string Title { get; set; }

        /// <summary>
        /// Required, Max length = 500
        /// Max length = 500     Falls eine Antwort vorliegt, hier speichern
        /// </summary>
        [Required]
        [MaxLength(500)]
        [StringLength(500)]
        public string Answer { get; set; }

        /// <summary>
        /// Required
        /// Required
        /// </summary>
        [Required]
        public DateTime DateSent { get; set; }

        /// <summary>
        /// Required
        /// date when answer arrived, if application was answered
        /// </summary>
        [Required]
        public DateTime DateAnswered { get; set; }

        /// <summary>
        /// Required     Historic retention property
        /// </summary>
        public byte[] Current { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/

        /// <summary>
        /// summary
        /// </summary>
        public virtual global::JobAPI.Models.ApplicationModel.ApplicationHeader Header { get; set; }

        /// <summary>
        /// summary
        /// </summary>
        public virtual global::JobAPI.Models.ApplicationModel.ApplicationBody Body { get; set; }

        /// <summary>
        /// summary
        /// </summary>
        public virtual global::JobAPI.Models.ApplicationModel.ApplicationFooter Footer { get; set; }
        public User User { get; set; }
    }
}
