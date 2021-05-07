using JobAPI.Data;
using JobAPI.Models.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class UserWebsitesController : ControllerBase
    {
        private readonly JobDbContext _context;

        public UserWebsitesController(JobDbContext context)
        {
            _context = context;
        }


        // GET: Api/Get/5
        [Authorize]
        [HttpGet("Get/{id}")]
        [SwaggerOperation("GetUserWebsite")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<UserWebsite>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWebsite = await _context.UserWebSitesDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userWebsite == null)
            {
                return NotFound();
            }

            return userWebsite;
        }



        // POST: UserWebsites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("Create")]
        [SwaggerOperation("CreateUserWebsite")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserWebsite>> Create([Bind("Id,UserId,Name,Content,Url")] UserWebsite userWebsite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userWebsite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return userWebsite;
        }


        // PUT: UserWebsites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditUserWebsite")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserWebsite>> Edit(int id, [Bind("Id,UserId,Name,Content,Url")] UserWebsite userWebsite)
        {
            if (id != userWebsite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userWebsite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserWebsiteExists(userWebsite.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return userWebsite;
        }



        // DELETE: UserWebsites/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteUserWebsite")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserWebsite>> DeleteConfirmed(int id)
        {
            var userWebsite = await _context.UserWebSitesDB.FindAsync(id);
            _context.UserWebSitesDB.Remove(userWebsite);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UserWebsiteExists(int id)
        {
            return _context.UserWebSitesDB.Any(e => e.Id == id);
        }
    }
}
