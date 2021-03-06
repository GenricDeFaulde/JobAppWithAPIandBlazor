using JobAPI.Areas.Identity.Data;
using JobAPI.Data;
using JobApp.Library.DataAccess;
using JobApp.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class _AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<JobAppUser> _userManager;
        private readonly IConfiguration _config;

        //TODO build better UserController for authentication purposes.
        public _AdminController(ApplicationDbContext context, UserManager<JobAppUser> userManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }

        //[HttpGet]
        //[Route("Users/Get")]
        //public UserModel GetById()
        //{
        //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    UserData data = new UserData(_config);

        //    return data.GetUserById(userId).First();
        //}



        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Users/GetAllUsers")]
        public List<ApplicationUserModel> GetAllUsers()
        {
            List<ApplicationUserModel> output = new List<ApplicationUserModel>();

            var users = _context.Users.ToList();
            var userRoles = from ur in _context.UserRoles
                            join r in _context.Roles on ur.RoleId equals r.Id
                            select new { ur.UserId, ur.RoleId, r.Name };

            foreach (var user in users)
            {
                ApplicationUserModel u = new ApplicationUserModel
                {
                    Id = user.Id,
                    Email = user.Email
                };

                u.Roles = userRoles.Where(x => x.UserId == u.Id).ToDictionary(key => key.RoleId, val => val.Name);


                output.Add(u);
            }
            return output;
        }


        // !TODO change to stored procedure!
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Users/GetAllAuthUsers")]
        public List<JobAppUser> GetAllAuthUsers()
        {
            List<JobAppUser> output = new List<JobAppUser>();

            output = _context.Users.ToList();
            
            return output;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Users/GetAllRoles")]
        public Dictionary<string, string> GetAllRoles()
        {
            var roles = _context.Roles.ToDictionary(x => x.Id, x => x.Name);

            return roles;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Users/AddRole")]
        public async Task AddRole(UserRolePairModel pairing)
        {
            var user = await _userManager.FindByIdAsync(pairing.UserId);
            await _userManager.AddToRoleAsync(user, pairing.RoleName);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Users/RemoveRole")]
        public async Task RemoveRole(UserRolePairModel pairing)
        {
            var user = await _userManager.FindByIdAsync(pairing.UserId);
            await _userManager.RemoveFromRoleAsync(user, pairing.RoleName);
        }

    }
}
