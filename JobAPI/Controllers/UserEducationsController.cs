using JobAPI.Data;
using JobAPI.Models.UserModel;
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
    public class UserEducationsController : ControllerBase
    {
        private readonly JobDbContext _context;

        public UserEducationsController(JobDbContext context)
        {
            _context = context;
        }



        // GET: UserEducations/Get/5
        [Authorize]
        [HttpGet("Get/{id}")]
        [SwaggerOperation("GetUserEducation")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEducation = await _context.UserEducationsDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEducation == null)
            {
                return NotFound();
            }

            return new JsonResult(userEducation);
        }



        // POST: UserEducations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("Create")]
        [SwaggerOperation("CreateUserEducation")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Title,Facility,AddressNation,FacilityAddressCity,FacilityAddressStreet,FacilityAddressState,Graduation,TestimonyUrl,StartDate,EndDate")] UserEducation userEducation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userEducation);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return new JsonResult(userEducation);
        }



        // PUT: UserEducations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("Edit/{id}")]
        [SwaggerOperation("EditUserEducation")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Title,Facility,AddressNation,FacilityAddressCity,FacilityAddressStreet,FacilityAddressState,Graduation,TestimonyUrl,StartDate,EndDate")] UserEducation userEducation)
        {
            if (id != userEducation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEducation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEducationExists(userEducation.Id))
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
            return new JsonResult(userEducation);
        }


        // DELETE: UserEducations/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation("DeleteUserEducation")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
//[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userEducation = await _context.UserEducationsDB.FindAsync(id);
            _context.UserEducationsDB.Remove(userEducation);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UserEducationExists(int id)
        {
            return _context.UserEducationsDB.Any(e => e.Id == id);
        }
    }
}
