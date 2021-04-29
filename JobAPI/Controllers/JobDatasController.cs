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
    public class JobDatasController : ControllerBase
    {
        private readonly JobDbContext _context;

        public JobDatasController(JobDbContext context)
        {
            _context = context;
        }




        // GET: JobDatas/Details/5
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation("GetJobData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<JobData>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobData = await _context.JobDataDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobData == null)
            {
                return NotFound();
            }

            return jobData;
        }




        // POST: JobDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateJobData")]
        [SwaggerOperation("CreateJobData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<JobData>> Create([Bind("Id,JobId,DescriptionShort,DescriptionLong,Nation,Region,MinSalary,MaxSalary,Current")] JobData jobData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return jobData;
        }




        // PUT: JobDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditJobData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<JobData>> Edit(int id, [Bind("Id,JobId,DescriptionShort,DescriptionLong,Nation,Region,MinSalary,MaxSalary,Current")] JobData jobData)
        {
            if (id != jobData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobDataExists(jobData.Id))
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
            return jobData;
        }


        // DELETE: JobDatas/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteJobData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<JobData>> DeleteConfirmed(int id)
        {
            var jobData = await _context.JobDataDB.FindAsync(id);
            _context.JobDataDB.Remove(jobData);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool JobDataExists(int id)
        {
            return _context.JobDataDB.Any(e => e.Id == id);
        }
    }
}
