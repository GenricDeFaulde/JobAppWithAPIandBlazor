using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JobApp.Areas.Identity.Data
{
  // TODO Add profile data for application users by adding properties to the JobAppUser class
  public class JobAppUser : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsAdmin { get; set; }
  }
}
