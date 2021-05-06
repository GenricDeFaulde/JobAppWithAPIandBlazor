using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Areas.Identity.Data
{
    public class UserRolePairModel
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
