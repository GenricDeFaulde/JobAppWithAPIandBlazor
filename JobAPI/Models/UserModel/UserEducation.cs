using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models.UserModel
{
    public class UserEducation
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
        /// Required, Max length = 50
        /// Required, Max length = 50     Name of educational phase
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     Name of educational facility
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Facility { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     Nation where this Facility is located
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string AddressNation { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     City address of this facility (including PO number)
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string FacilityAddressCity { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     Street address of this facility (including house number)
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string FacilityAddressStreet { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     Stateaddress of this facility
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string FacilityAddressState { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Required, Max length = 50     Type of graduation achieved in this facility
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Graduation { get; set; }

        /// <summary>
        /// Required, Max length = 50
        /// Max length = 50     Url to the testimony
        /// </summary>
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string TestimonyUrl { get; set; }

        /// <summary>
        /// Required
        /// Required     Start date of education in this facility
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Required
        /// Required     End date of education in this facility
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /*************************************************************************
         * Navigation properties
         *************************************************************************/
        public User User { get; set; }
    }
}
