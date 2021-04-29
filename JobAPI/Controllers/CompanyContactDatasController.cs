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
    public class CompanyContactDatasController : ControllerBase
    {
        private readonly JobDbContext _context;

        public CompanyContactDatasController(JobDbContext context)
        {
            _context = context;
        }


        // GET: CompanyContactDatas/Details/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetCompanyContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CompanyContactData>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyContactData = await _context.CompanyContactdatasDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyContactData == null)
            {
                return NotFound();
            }

            return companyContactData;
        }


        // POST: CompanyContactDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateCompanyContactData")]
        [SwaggerOperation("CreateCompanyContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CompanyContactData>> Create([Bind("Id,CompanyId,CompanyBranchId,Name,PhoneNumber,PhoneNumberAlt,EmailAddress,EmailAddressAlt,IsActive")] CompanyContactData companyContactData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyContactData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return companyContactData;
        }


        // PUT: CompanyContactDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditCompanyContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CompanyContactData>> Edit(int id, [Bind("Id,CompanyId,CompanyBranchId,Name,PhoneNumber,PhoneNumberAlt,EmailAddress,EmailAddressAlt,IsActive")] CompanyContactData companyContactData)
        {
            if (id != companyContactData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyContactData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyContactDataExists(companyContactData.Id))
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
            return companyContactData;
        }




        // DELETE: CompanyContactDatas/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteCompanyContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CompanyContactData>> DeleteConfirmed(int id)
        {
            var companyContactData = await _context.CompanyContactdatasDB.FindAsync(id);
            _context.CompanyContactdatasDB.Remove(companyContactData);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CompanyContactDataExists(int id)
        {
            return _context.CompanyContactdatasDB.Any(e => e.Id == id);
        }
    }
}
