using JobAPI.Data;
using JobAPI.Models.ALVModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace JobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ALVController : ControllerBase
    {
        private readonly JobDbContext _context;

        public ALVController(JobDbContext context)
        {
            _context = context;
        }


        [Authorize]
        // GET: ALV/Details/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetJobsearch")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]

        public ActionResult<Jobsuche> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobsuche = _context.ALVDB
                .FirstOrDefault(m => m.Id == id);
            if (jobsuche == null)
            {
                return NoContent();
            }

            return new JsonResult(jobsuche);
        }

        // POST: ALV/Create
        // TODO overposting protection? Check ALL controllers!
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateJobsearch")]
        [SwaggerOperation("CreateJobsearch")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Jobsuche>> Create([Bind("Id,UserId,JobOfferId,CompanyId,Email,JobId,Status,DateSent,DateAnswered,Proof")] Jobsuche jobsuche)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobsuche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return jobsuche;
        }



        // PUT: ALV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditJobsearch")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Jobsuche>> Edit(int id, [Bind("Id,UserId,JobOfferId,CompanyId,Email,JobId,Status,DateSent,DateAnswered,Proof")] Jobsuche jobsuche)
        {
            if (id != jobsuche.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobsuche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobsucheExists(jobsuche.Id))
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
            return jobsuche;
        }

        // POST: ALV/Delete/5

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteJobsearch")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Jobsuche>> DeleteConfirmed(int id)
        {
            var jobsuche = await _context.ALVDB.FindAsync(id);
            _context.ALVDB.Remove(jobsuche);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool JobsucheExists(int id)
        {
            return _context.ALVDB.Any(e => e.Id == id);
        }
    }
}
