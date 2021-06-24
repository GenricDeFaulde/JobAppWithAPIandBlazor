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
    public class HeadHunterContactDatasController : ControllerBase
    {
        private readonly JobDbContext _context;

        public HeadHunterContactDatasController(JobDbContext context)
        {
            _context = context;
        }




        // GET: HeadHunterContactDatas/Get/5
        [Authorize]
        [HttpGet("Get/{id}")]
        [SwaggerOperation("GetHeadHunterContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headHunterContactData = await _context.HHContactDatas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headHunterContactData == null)
            {
                return NotFound();
            }

            return new JsonResult(headHunterContactData);
        }



        // POST: HeadHunterContactDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("Create")]
        [SwaggerOperation("CreateHeadHunterContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,JobExchangeId,AddressNation,AddressCity,AddressStreet,AddressState,PhoneNumber,PhoneNumberAlt,EmailAddress,IsActive")] HeadHunterContactData headHunterContactData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headHunterContactData);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return new JsonResult(headHunterContactData);
        }


        // PUT: HeadHunterContactDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditHeadHunterContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,JobExchangeId,AddressNation,AddressCity,AddressStreet,AddressState,PhoneNumber,PhoneNumberAlt,EmailAddress,IsActive")] HeadHunterContactData headHunterContactData)
        {
            if (id != headHunterContactData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headHunterContactData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeadHunterContactDataExists(headHunterContactData.Id))
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
            return new JsonResult(headHunterContactData);
        }




        // DELETE: HeadHunterContactDatas/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteHeadHunterContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var headHunterContactData = await _context.HHContactDatas.FindAsync(id);
            _context.HHContactDatas.Remove(headHunterContactData);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool HeadHunterContactDataExists(int id)
        {
            return _context.HHContactDatas.Any(e => e.Id == id);
        }
    }
}
