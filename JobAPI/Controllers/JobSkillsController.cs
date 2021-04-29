using JobAPI.Data;
using JobAPI.Models.JobModel;
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
    public class JobSkillsController : ControllerBase
    {
        private readonly JobDbContext _context;

        public JobSkillsController(JobDbContext context)
        {
            _context = context;
        }



        // GET: JobSkills/Details/5
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation("GetJobSkill")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<JobSkill>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSkill = await _context.JobSkillsDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobSkill == null)
            {
                return NotFound();
            }

            return jobSkill;
        }



        // POST: JobSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateJobSkill")]
        [SwaggerOperation("CreateJobSkill")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<JobSkill>> Create([Bind("Id,JobId,Name,Content")] JobSkill jobSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return jobSkill;
        }


        // PuT: JobSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditJobSkill")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<JobSkill>> Edit(int id, [Bind("Id,JobId,Name,Content")] JobSkill jobSkill)
        {
            if (id != jobSkill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobSkillExists(jobSkill.Id))
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
            return jobSkill;
        }





        // DELETE JobSkills/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteJobSkill")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<JobSkill>> DeleteConfirmed(int id)
        {
            var jobSkill = await _context.JobSkillsDB.FindAsync(id);
            _context.JobSkillsDB.Remove(jobSkill);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool JobSkillExists(int id)
        {
            return _context.JobSkillsDB.Any(e => e.Id == id);
        }
    }
}
