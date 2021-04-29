using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApp.Models
{
  public class UserRolesViewModel
  {
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UName { get; set; }


    public bool IsAdmin { get; set; }
    public string Email { get; set; }
    public IEnumerable<string> Roles { get; set; }
  }
}