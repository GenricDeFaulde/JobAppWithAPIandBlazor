using JobAPI.Data;
using JobAPI.Models.CompanyModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class CompaniesController : ControllerBase
    {
        private readonly JobDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CompaniesController(JobDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Companies/GetAll/
        [Authorize]
        [HttpGet("GetAll")]
        [SwaggerOperation("GetAllCompanies")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task <IActionResult> Details()
        {

            var company = await _context.CompaniesDB
                            .Include(i => i.Branches)
                                .ThenInclude(t => t.Contacts)
                            .Include(i => i.Branches)
                                .ThenInclude(t => t.Offers)
                            .Include(l => l.HistoryList)
                            .ToListAsync() ;
            if (company == null)
            {
                return NotFound();
            }


            return new JsonResult(company);
        }


        // GET: Companies/Get/5
        //[Authorize]
        [HttpGet("Get/{id}")]
        [SwaggerOperation("GetCompanyById")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.CompaniesDB
                            .Include(i => i.Branches)
                                .ThenInclude(t => t.Contacts)
                            .Include(i => i.Branches)
                                .ThenInclude(t => t.Offers)
                            .Include(l => l.HistoryList)
                            .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }


            return new JsonResult(company);
        }



        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        [SwaggerOperation("CreateCompany")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
//[ValidateAntiForgeryToken]

        public async Task<IActionResult> Create( Company company)
        {
            // TODO: implement
            return Ok();
        }




        // PUT: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditCompany")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Current, Description")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }
            // company.Id = id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                    return Ok(new JsonResult(company));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return BadRequest();
        }


        // DELETE Companies/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteCompany")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.CompaniesDB.FindAsync(id);
            _context.CompaniesDB.Remove(company);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return _context.CompaniesDB.Any(e => e.Id == id);
        }
    }
}
