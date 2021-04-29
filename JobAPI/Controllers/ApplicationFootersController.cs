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
    public class ApplicationFootersController : ControllerBase
    {
        private readonly JobDbContext _context;

        public ApplicationFootersController(JobDbContext context)
        {
            _context = context;
        }



        [Authorize]
        // GET: ApplicationFooters/Details/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetApplicationFooter")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ApplicationFooter>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationFooter = await _context.ApplicationFootersDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationFooter == null)
            {
                return NotFound();
            }

            return applicationFooter;
        }



        // POST: ApplicationFooters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateApplicationFooter")]
        [SwaggerOperation("CreateApplicationFooter")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApplicationFooter>> Create([Bind("Id,ApplicationnId,Title,Content")] ApplicationFooter applicationFooter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationFooter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return applicationFooter;
        }



        // PUT: ApplicationFooters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditApplicationFooter")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApplicationFooter>> Edit(int id, [Bind("Id,ApplicationnId,Title,Content")] ApplicationFooter applicationFooter)
        {
            if (id != applicationFooter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationFooter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationFooterExists(applicationFooter.Id))
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
            return applicationFooter;
        }



        // DELETE: ApplicationFooters/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteApplicationFooter")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApplicationFooter>> DeleteConfirmed(int id)
        {
            var applicationFooter = await _context.ApplicationFootersDB.FindAsync(id);
            _context.ApplicationFootersDB.Remove(applicationFooter);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ApplicationFooterExists(int id)
        {
            return _context.ApplicationFootersDB.Any(e => e.Id == id);
        }
    }
}
