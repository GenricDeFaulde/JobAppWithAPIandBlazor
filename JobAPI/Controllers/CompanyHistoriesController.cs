using JobAPI.Data;
using JobAPI.Models.CompanyModel;
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
    public class CompanyHistoriesController : ControllerBase
    {
        private readonly JobDbContext _context;

        public CompanyHistoriesController(JobDbContext context)
        {
            _context = context;
        }

        // GET: CompanyHistories/Get/5
        [Authorize]
        [HttpGet("Get/{id}")]
        [SwaggerOperation("GetCompanyHistory")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CompanyHistory>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyHistory = await _context.CompanyHistoriesDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyHistory == null)
            {
                return NotFound();
            }

            return companyHistory;
        }


        // POST: CompanyHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("Create")]
        [SwaggerOperation("CreateCompanyHistory")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CompanyHistory>> Create([Bind("Id,CompanyId,Name,Content,Date")] CompanyHistory companyHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return companyHistory;
        }


        // PUT: CompanyHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditCompanyHistory")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CompanyHistory>> Edit(int id, [Bind("Id,CompanyId,Name,Content,Date")] CompanyHistory companyHistory)
        {
            if (id != companyHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyHistoryExists(companyHistory.Id))
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
            return companyHistory;
        }


        // DELETE: CompanyHistories/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteCompanyHistory")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CompanyHistory>> DeleteConfirmed(int id)
        {
            var companyHistory = await _context.CompanyHistoriesDB.FindAsync(id);
            _context.CompanyHistoriesDB.Remove(companyHistory);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CompanyHistoryExists(int id)
        {
            return _context.CompanyHistoriesDB.Any(e => e.Id == id);
        }
    }
}
