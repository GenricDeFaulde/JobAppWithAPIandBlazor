using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using IdentityModel;

// TODO check for duplicate role name
namespace JobApp.Areas.Identity.Data
{
  public class AdditionalUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<JobAppUser, IdentityRole>
  {
    public AdditionalUserClaimsPrincipalFactory(
        UserManager<JobAppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
    { }

    public async override Task<ClaimsPrincipal> CreateAsync(JobAppUser user)
    {
      var principal = await base.CreateAsync(user);
      var identity = (ClaimsIdentity)principal.Identity;

      var claims = new List<Claim>();
      if (user.IsAdmin)
      {
        claims.Add(new Claim(JwtClaimTypes.Role, "admin"));
      }
      else
      {
        claims.Add(new Claim(JwtClaimTypes.Role, "user"));
      }

      identity.AddClaims(claims);
      return principal;
    }
  }
}
