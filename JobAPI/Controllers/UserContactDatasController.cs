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
    public class UserContactDatasController : ControllerBase
    {
        private readonly JobDbContext _context;

        public UserContactDatasController(JobDbContext context)
        {
            _context = context;
        }


        // GET: UserContactDatas/Details/5
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation("GetUserContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<UserContactData>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userContactData = await _context.UserContactDatasDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userContactData == null)
            {
                return NotFound();
            }

            return userContactData;
        }



        // POST: UserContactDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("CreateUserContactData")]
        [SwaggerOperation("CreateUserContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserContactData>> Create([Bind("Id,UserId,AddressNation,AddressCity,AddressStreet,AddressState,PhoneNumber,PhoneNumberAlt,EmailAddress,EmailAddressAlt,Current")] UserContactData userContactData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userContactData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return userContactData;
        }



        // PUT: UserContactDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        [SwaggerOperation("EditUserContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserContactData>> Edit(int id, [Bind("Id,UserId,AddressNation,AddressCity,AddressStreet,AddressState,PhoneNumber,PhoneNumberAlt,EmailAddress,EmailAddressAlt,Current")] UserContactData userContactData)
        {
            if (id != userContactData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userContactData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserContactDataExists(userContactData.Id))
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
            return userContactData;
        }


        // DELETE: UserContactDatas/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteUserContactData")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserContactData>> DeleteConfirmed(int id)
        {
            var userContactData = await _context.UserContactDatasDB.FindAsync(id);
            _context.UserContactDatasDB.Remove(userContactData);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UserContactDataExists(int id)
        {
            return _context.UserContactDatasDB.Any(e => e.Id == id);
        }
    }
}
