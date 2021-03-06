using JobAPI.Data;
using JobAPI.Models.JobModel;
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
    public class JobExchangesController : ControllerBase
    {
            private readonly JobDbContext _context;

            public JobExchangesController(JobDbContext context)
            {
                _context = context;
            }

        // GET: JobExchanges/GetAll
        [Authorize]
        [HttpGet("GetAll")]
        [SwaggerOperation("GetAllJobExchanges")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetExchanges()
        {

            var jobExchange = await _context.JobExchangesDB
                              .Include(i => i.Offers)
                                  .ThenInclude(l => l.CompanyBranch)
                              .Include(i => i.Offers)
                                  .ThenInclude(l => l.CompanyBranch)
                                      .ThenInclude(o => o.Company)
                              .Include(i => i.Offers)
                                  .ThenInclude(l => l.Job)
                              .Include(i => i.Offers)
                                  .ThenInclude(l => l.Application)
                              .ToListAsync();
            if (jobExchange == null)
            {
                return NotFound();
            }

            return new JsonResult(jobExchange);
        }


        // GET: JobExchanges/Get/5
        [Authorize]
            [HttpGet("Get/{id}")]
            [SwaggerOperation("GetJobExchange")]
            [SwaggerResponse((int)HttpStatusCode.OK)]
            [SwaggerResponse((int)HttpStatusCode.NotFound)]
             public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var jobExchange = await _context.JobExchangesDB
                                  .Include(i => i.Offers)
                                      .ThenInclude(l => l.CompanyBranch)
                                  .Include(i => i.Offers)
                                      .ThenInclude(l => l.CompanyBranch)
                                          .ThenInclude(o => o.Company)
                                  .Include(i => i.Offers)
                                      .ThenInclude(l => l.Job)
                                  .Include(i => i.Offers)
                                      .ThenInclude(l => l.Application)
                                  .FirstOrDefaultAsync(m => m.Id == id);
                if (jobExchange == null)
                {
                    return NotFound();
                }

                return new JsonResult(jobExchange);
            }


            // POST: JobExchanges/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [Authorize(Roles = "SuperAdmin")]
            [HttpPost("Create")]
            [SwaggerOperation("CreateJobExchange")]
            [SwaggerResponse((int)HttpStatusCode.OK)]
            [SwaggerResponse((int)HttpStatusCode.NotFound)]
            [SwaggerResponse((int)HttpStatusCode.Created)]
    //[ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Url,Current")] JobExchange jobExchange)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(jobExchange);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return new JsonResult(jobExchange);
            }




            // PUT: JobExchanges/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [Authorize(Roles = "SuperAdmin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditJobExchange")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url,Current")] JobExchange jobExchange)
            {
                if (id != jobExchange.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(jobExchange);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!JobExchangeExists(jobExchange.Id))
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
                return new JsonResult(jobExchange);
            }



            // DELETE: JobExchanges/Delete/5
            [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteJobExchange")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var jobExchange = await _context.JobExchangesDB.FindAsync(id);
                _context.JobExchangesDB.Remove(jobExchange);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            private bool JobExchangeExists(int id)
            {
                return _context.JobExchangesDB.Any(e => e.Id == id);
            }
        }
}
