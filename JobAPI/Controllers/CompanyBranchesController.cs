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
    //[Authorize]
    public class CompanyBranchesController : ControllerBase
    {
        private readonly JobDbContext _context;

        public CompanyBranchesController(JobDbContext context)
        {
            _context = context;
        }


        // GET: CompanyBranches
        //[Authorize]
        [HttpGet("GetCompanyBranches/{id}")]
        [SwaggerOperation("GetCompanyBranchesByCompanyId")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<CompanyBranch>>> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyBranch = await _context.CompanyBranchDB
                              .Where(m => m.CompanyId == id)
                              .Include(i => i.Company)
                              .Include(i => i.Offers)
                              .ToListAsync();

            if (companyBranch.Count == 0)
            {
                return RedirectToAction("Create", new { id });
            }

            return companyBranch;
        }


        // GET: CompanyBranches/Details/5
        //[Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation("GetCompanyBranch")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CompanyBranch>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyBranch = await _context.CompanyBranchDB
                              .Include(i => i.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyBranch == null)
            {
                return NotFound();
            }

            return companyBranch;
        }



        // POST: CompanyBranches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateCompanyBranch")]
        [SwaggerOperation("CreateCompanyBranch")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CompanyBranch>> Create([Bind("CompanyId,Name,Description,AddressNation,AddressCity,AddressStreet,AddressState")] CompanyBranch companyBranch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyBranch);
                await _context.SaveChangesAsync();
                // TODO fix redirect
                // return RedirectToAction(nameof(Index), new { companyBranch.CompanyId });
                return RedirectToRoute(new
                {
                    controller = "CompanyBranches",
                    action = "Index",
                    id = companyBranch.CompanyId
                });
            }
            return companyBranch;
        }


        // PUT: CompanyBranches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditCompanyBranch")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CompanyBranch>> Edit(int id, [Bind("Id, CompanyId,Name,Description,AddressNation,AddressCity,AddressStreet,AddressState")] CompanyBranch companyBranch)
        {
            companyBranch.CompanyId = id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyBranch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyBranchExists(companyBranch.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = companyBranch.Id });
            }
            return companyBranch;
        }


        // DELETE: CompanyBranches/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteCompanyBranch")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CompanyBranch>> DeleteConfirmed(int id)
        {
            var companyBranch = await _context.CompanyBranchDB.FindAsync(id);
            _context.CompanyBranchDB.Remove(companyBranch);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CompanyBranchExists(int id)
        {
            return _context.CompanyBranchDB.Any(e => e.Id == id);
        }

        private bool CompanyExists(int id)
        {
            return _context.CompaniesDB.Any(e => e.Id == id);
        }
    }
}
