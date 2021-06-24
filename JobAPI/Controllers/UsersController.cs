using JobAPI.Areas.Identity.Data;
using JobAPI.Data;
using JobAPI.Models.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly JobDbContext _context;
        private readonly UserManager<JobAppUser> _userManager;

        public UsersController(JobDbContext context,
            UserManager<JobAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Users/GetAll
        [Authorize]
        [HttpGet("GetAll")]
        [SwaggerOperation("GetAllUsers")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Details()
        {

            var user = await _context.UserDB
                .ToListAsync();
            if (user == null)
            {
                return NotFound();
            }

            return new JsonResult(user);
        }



        // GET: Users/Get/5
        [Authorize]
        [HttpGet("Get/{id}")]
        [SwaggerOperation("GetUser")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.UserDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return new JsonResult(user);
        }

        public record UserRegistrationModel(
            string FirstName,
            string LastName,
            string Email,
            string Password);

        // POST: Users/Register
        [AllowAnonymous]
        [HttpPost, Route("Register")]
        [SwaggerOperation("RegisterUser")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if(existingUser is null)
                {
                    JobAppUser newUser = new()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EmailConfirmed = true,
                        UserName = user.Email
                    };

                    IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                    if (result.Succeeded) return Ok();
                }
            }
            return BadRequest("Model is not matching");
        }


        // POST: Users/Create
        [Authorize(Roles = "Admin")]
        [HttpPost, Route("Create")]
        [SwaggerOperation("CreateUser")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.Id, user);
            }
            return BadRequest("Model is not matching");
        }



        // PUT: Users/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditUser")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            //TODO: add roles

            if (id != user.Id)
            {
                return BadRequest("Id not matching");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound("No user with this id in database");
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok($"User {user.FirstName} {user.LastName} was succesfully edited");
            }
            return BadRequest("Bad model");
        }



        // DELETE: Users/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteUser")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.UserDB.FindAsync(id);
            _context.UserDB.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.UserDB.Any(e => e.Id == id);
        }
    }
}
