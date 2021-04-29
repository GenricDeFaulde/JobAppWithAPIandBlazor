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
    public class UserJobHistoriesController : ControllerBase
    {
        private readonly JobDbContext _context;

        public UserJobHistoriesController(JobDbContext context)
        {
            _context = context;
        }



        // GET: UserJobHistories/Details/5
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation("GetUserJobHistories")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<UserJobHistory>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userJobHistory = await _context.UserPastJobs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userJobHistory == null)
            {
                return NotFound();
            }

            return userJobHistory;
        }



        // POST: UserJobHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateUserJobHistories")]
        [SwaggerOperation("CreateUserJobHistories")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserJobHistory>> Create([Bind("Id,UserId,Title,Description,SkillSummary,TestimonyUrl,Salary,StartDate,EndDate,Current")] UserJobHistory userJobHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userJobHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return userJobHistory;
        }



        // PUT: UserJobHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditUserJobHistories")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserJobHistory>> Edit(int id, [Bind("Id,UserId,Title,Description,SkillSummary,TestimonyUrl,Salary,StartDate,EndDate,Current")] UserJobHistory userJobHistory)
        {
            if (id != userJobHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userJobHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserJobHistoryExists(userJobHistory.Id))
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
            return userJobHistory;
        }



        // DELETE: UserJobHistories/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteUserJobHistories")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserJobHistory>> DeleteConfirmed(int id)
        {
            var userJobHistory = await _context.UserPastJobs.FindAsync(id);
            _context.UserPastJobs.Remove(userJobHistory);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UserJobHistoryExists(int id)
        {
            return _context.UserPastJobs.Any(e => e.Id == id);
        }
    }
}
