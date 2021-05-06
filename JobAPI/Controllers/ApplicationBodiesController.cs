using JobAPI.Data;
using JobAPI.Models.ApplicationModel;
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
    public class ApplicationBodiesController : ControllerBase
    {
        private readonly JobDbContext _context;

        public ApplicationBodiesController(JobDbContext context)
        {
            _context = context;
        }



        [Authorize]
        // GET: ApplicationBodies/Details/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetApplicationBody")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ApplicationBody>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationBody = await _context.ApplicationBodiesDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationBody == null)
            {
                return NotFound();
            }

            return applicationBody;
        }


        // POST: ApplicationBodies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateApplicationBody")]
        [SwaggerOperation("CreateApplicationBody")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApplicationBody>> Create([Bind("Id,ApplicationnId,Title,Content")] ApplicationBody applicationBody)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationBody);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return applicationBody;
        }


        // PUT: ApplicationBodies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditApplicationBody")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApplicationBody>> Edit(int id, [Bind("Id,ApplicationnId,Title,Content")] ApplicationBody applicationBody)
        {
            if (id != applicationBody.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationBody);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationBodyExists(applicationBody.Id))
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
            return applicationBody;
        }


        // DELETE: ApplicationBodies/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteApplicationBody")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApplicationBody>> DeleteConfirmed(int id)
        {
            var applicationBody = await _context.ApplicationBodiesDB.FindAsync(id);
            _context.ApplicationBodiesDB.Remove(applicationBody);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ApplicationBodyExists(int id)
        {
            return _context.ApplicationBodiesDB.Any(e => e.Id == id);
        }
    }
}
