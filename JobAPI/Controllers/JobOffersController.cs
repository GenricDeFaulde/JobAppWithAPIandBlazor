using JobAPI.Data;
using JobAPI.Models.JobModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class JobOffersController : ControllerBase
    {
        private readonly JobDbContext _context;

        public JobOffersController(JobDbContext context)
        {
            _context = context;
        }



        //  TODO Make this work for dotnet 5.0 
        //// GET: JobOffers by company
        //[Authorize]
        //public async Task<IActionResult> CompanyIndex(int id)
        //{
        //    //  TODO implement ApplicationCount

        //    var offerInfo = await _context.CompanyBranchDB
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.JobExchange)
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.HeadHunter)
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.Application)
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.CompanyBranch)
        //                .ThenInclude(j => j.Company)
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.Job)
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.Jobsuche)
        //            .FirstOrDefaultAsync(m => m.CompanyId == id);

        //    return offerInfo;
        //}


        //// GET: JobOffers by Job
        //[Authorize]
        //public async Task<IActionResult> JobIndex(int id)
        //{

        //    var offerInfo = await _context.JobsDB
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.JobExchange)
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.HeadHunter)
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.Application)
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.CompanyBranch)
        //                .ThenInclude(j => j.Company)
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.Job)
        //            .Include(i => i.Offers)
        //              .ThenInclude(l => l.Jobsuche)
        //            .FirstOrDefaultAsync(m => m.Id == id);

        //    return offerInfo;
        //}


        //// GET: JobOffers by exchange
        //[Authorize]
        //public async Task<IActionResult> ExchangeIndex(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var jobExchange = await _context.JobExchangesDB
        //                      .Include(i => i.Offers)
        //                          .ThenInclude(l => l.CompanyBranch)
        //                      .Include(i => i.Offers)
        //                          .ThenInclude(l => l.CompanyBranch)
        //                              .ThenInclude(o => o.Company)
        //                      .Include(i => i.Offers)
        //                          .ThenInclude(l => l.Job)
        //                      .Include(i => i.Offers)
        //                          .ThenInclude(l => l.Application)
        //                      .FirstOrDefaultAsync(m => m.Id == id);
        //    if (jobExchange == null)
        //    {
        //        return NotFound();
        //    }

        //    return jobExchange;
        //}


        //// GET: Jobs by Headhunter
        //[Authorize]
        //public async Task<IActionResult> HunterIndex(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var headHunter = await _context.HeadHunter
        //        .Include(i => i.ContactInfos)
        //        .Include(i => i.Offers)
        //          .ThenInclude(l => l.CompanyBranch)
        //            .ThenInclude(m => m.Company)
        //        .Include(i => i.Offers)
        //          .ThenInclude(m => m.Job)
        //        .Include(i => i.Offers)
        //          .ThenInclude(m => m.Application)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (headHunter == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(headHunter);
        //}



        // GET: JobOffers/Get/5
        [Authorize]
        [HttpGet("Get/{id}")]
        [SwaggerOperation("GetJobOffer")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffersDB
            .Include(i => i.JobExchange)
                .Include(i => i.HeadHunter)
                .Include(i => i.Application)
                .Include(i => i.CompanyBranch)
                  .ThenInclude(l => l.Company)
                .Include(i => i.Job)
                .Include(i => i.Jobsuche)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            return new JsonResult(jobOffer);
        }


        // POST: JobOffers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("Create")]
        [SwaggerOperation("CreateJobOffer")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyBranchId,JobId,HeadHunterId,JobExchangeId,ApplicationnId,SalaryOffered,IsActive,Releasedate,JobOfferUrl")] JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobOffer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return new JsonResult(jobOffer);
        }



        // PUT: JobOffers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditJobOffer")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyBranchId,JobId,HeadHunterId,JobExchangeId,ApplicationnId,SalaryOffered,IsActive,Releasedate,JobOfferUrl")] JobOffer jobOffer)
        {
            if (id != jobOffer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobOffer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobOfferExists(jobOffer.Id))
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
            return new JsonResult(jobOffer);
        }


       

        // DELETE: JobOffers/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteJobOffer")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobOffer = await _context.JobOffersDB.FindAsync(id);
            _context.JobOffersDB.Remove(jobOffer);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool JobOfferExists(int id)
        {
            return _context.JobOffersDB.Any(e => e.Id == id);
        }
    }
}
