using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAppPortal.Models
{
    public class AuthenticatedUserModel
    {
        public string Access_Token { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
    }
}
