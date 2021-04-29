using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApp.Areas.Identity.Data;

namespace JobApp.Data
{
  public static class ContextSeed
  {
    public static async Task SeedRolesAsync(UserManager<JobAppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      //Seed Roles
      await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
      await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
      await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Moderator.ToString()));
      await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
    }

    public static async Task SeedSuperAdminAsync(UserManager<JobAppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      //Seed Default User
      var defaultUser = new JobAppUser
      {
        UserName = "Master",
        Email = "genric.defaulde@gmail.com",
        FirstName = "Jan",
        LastName = "Okrongli",
        IsAdmin = true,
        EmailConfirmed = true,
        PhoneNumberConfirmed = true
      };
      if (userManager.Users.All(u => u.Id != defaultUser.Id))
      {
        var user = await userManager.FindByEmailAsync(defaultUser.Email);
        if (user == null)
        {
          await userManager.CreateAsync(defaultUser, "Passw123$");
          await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Basic.ToString());
          await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Moderator.ToString());
          await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
          await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SuperAdmin.ToString());
        }

      }
    }
  }
}