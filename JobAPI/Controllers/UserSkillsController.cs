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
    public class UserSkillsController : ControllerBase
    {
        private readonly JobDbContext _context;

        public UserSkillsController(JobDbContext context)
        {
            _context = context;
        }


        // GET: UserSkills/Get/5
        [Authorize]
        [HttpGet("Get/{id}")]
        [SwaggerOperation("GetUserSkill")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<UserSkill>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSkill = await _context.UserSkillsDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSkill == null)
            {
                return NotFound();
            }

            return userSkill;
        }



        // POST: UserSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("Create")]
        [SwaggerOperation("CreateUserSkill")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserSkill>> Create([Bind("Id,UserId,SkillName,SkillDescritpion,SelfRating,Current")] UserSkill userSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return userSkill;
        }


        // PUT: UserSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditUserSkill")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserSkill>> Edit(int id, [Bind("Id,UserId,SkillName,SkillDescritpion,SelfRating,Current")] UserSkill userSkill)
        {
            if (id != userSkill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSkillExists(userSkill.Id))
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
            return userSkill;
        }



        // DELETE: UserSkills/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteUserSkill")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserSkill>> DeleteConfirmed(int id)
        {
            var userSkill = await _context.UserSkillsDB.FindAsync(id);
            _context.UserSkillsDB.Remove(userSkill);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UserSkillExists(int id)
        {
            return _context.UserSkillsDB.Any(e => e.Id == id);
        }
    }
}
