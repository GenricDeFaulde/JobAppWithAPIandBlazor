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


        // GET: ApplicationHeaders/Get/5
        [Authorize]
        [HttpGet("Get/{id}")]
        [SwaggerOperation("GetApplicationHeader")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Details(int? id)
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

            return new JsonResult(applicationHeader);
        }



        // POST: ApplicationHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("Create")]
        [SwaggerOperation("CreateApplicationHeader")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationnId,Title,Content")] ApplicationHeader applicationHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationHeader);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return new JsonResult(applicationHeader);
        }



        // PUT: ApplicationHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditApplicationHeader")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationnId,Title,Content")] ApplicationHeader applicationHeader)
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
                return Ok();
            }
            return new JsonResult(applicationHeader);
        }




        // DELETE: ApplicationHeaders/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteApplicationHeader")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
