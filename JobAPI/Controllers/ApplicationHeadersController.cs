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
    public class ApplicationHeadersController : ControllerBase
    {
        private readonly JobDbContext _context;

        public ApplicationHeadersController(JobDbContext context)
        {
            _context = context;
        }


        // GET: ApplicationHeaders/Details/5
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation("GetApplicationHeader")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ApplicationHeader>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationHeader = await _context.ApplicationHeadersDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationHeader == null)
            {
                return NotFound();
            }

            return applicationHeader;
        }



        // POST: ApplicationHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateApplicationHeader")]
        [SwaggerOperation("CreateApplicationHeader")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApplicationHeader>> Create([Bind("Id,ApplicationnId,Title,Content")] ApplicationHeader applicationHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return applicationHeader;
        }



        // PUT: ApplicationHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditApplicationHeader")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApplicationHeader>> Edit(int id, [Bind("Id,ApplicationnId,Title,Content")] ApplicationHeader applicationHeader)
        {
            if (id != applicationHeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationHeaderExists(applicationHeader.Id))
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
            return applicationHeader;
        }




        // DELETE: ApplicationHeaders/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteApplicationHeader")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ApplicationHeader>> DeleteConfirmed(int id)
        {
            var applicationHeader = await _context.ApplicationHeadersDB.FindAsync(id);
            _context.ApplicationHeadersDB.Remove(applicationHeader);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ApplicationHeaderExists(int id)
        {
            return _context.ApplicationHeadersDB.Any(e => e.Id == id);
        }
    }
}
