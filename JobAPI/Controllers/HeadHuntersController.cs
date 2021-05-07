using JobAPI.Data;
using JobAPI.Models.HeadHunterModel;
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
    public class HeadHuntersController : ControllerBase
    {
        private readonly JobDbContext _context;

        public HeadHuntersController(JobDbContext context)
        {
            _context = context;
        }



        // GET: HeadHunters/Get/5
        [Authorize]
        [HttpGet("Get/{id}")]
        [SwaggerOperation("GetHeadHunter")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<HeadHunter>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headHunter = await _context.HeadHunter
                .Include(i => i.ContactInfos)
                .Include(i => i.Offers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headHunter == null)
            {
                return NotFound();
            }

            return headHunter;
        }



        // POST: HeadHunters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("Create")]
        [SwaggerOperation("CreateHeadHunter")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<HeadHunter>> Create([Bind("Id,FirstName,LastName,IsActive")] HeadHunter headHunter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headHunter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return headHunter;
        }




        // PUT: HeadHunters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditHeadHunter")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<HeadHunter>> Edit(int id, [Bind("Id,FirstName,LastName,IsActive")] HeadHunter headHunter)
        {
            if (id != headHunter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headHunter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeadHunterExists(headHunter.Id))
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
            return headHunter;
        }




        // DELETE: HeadHunters/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteHeadHunter")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<HeadHunter>> DeleteConfirmed(int id)
        {
            var headHunter = await _context.HeadHunter.FindAsync(id);
            _context.HeadHunter.Remove(headHunter);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool HeadHunterExists(int id)
        {
            return _context.HeadHunter.Any(e => e.Id == id);
        }
    }
}
