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
    public class JobsController : ControllerBase
    {
        private readonly JobDbContext _context;

        public JobsController(JobDbContext context)
        {
            _context = context;
        }


        // GET: Jobs/Details/5

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation("GetJob")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Job>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.JobsDB
                .Include(i => i.JobData)
                .Include(i => i.JobSkillz)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return job;
        }


        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateJob")]
        [SwaggerOperation("CreateJob")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Job>> Create([Bind("Id,JobOfferId,Title,TitleAlt,TitleAlt2")] Job job)
        {


            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return job;
        }


        // PUT: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditJob")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Job>> Edit(int id, [Bind("Id,JobOfferId,Title,TitleAlt,TitleAlt2")] Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Id))
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
            return job;
        }




        // DELETE: Jobs/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteJob")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Job>> DeleteConfirmed(int id)
        {
            var job = await _context.JobsDB.FindAsync(id);
            _context.JobsDB.Remove(job);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool JobExists(int id)
        {
            return _context.JobsDB.Any(e => e.Id == id);
        }
    }
}
