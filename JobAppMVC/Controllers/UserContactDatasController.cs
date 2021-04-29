using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApp;
using JobApp.Models.UserModel;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Controllers
{
  public class UserContactDatasController : Controller
  {
    private readonly JobDbContext _context;

    public UserContactDatasController(JobDbContext context)
    {
      _context = context;
    }


    // GET: UserContactDatas
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.UserContactDatasDB.ToListAsync());
    }


    // GET: UserContactDatas/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
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

      return View(userContactData);
    }


    // GET: UserContactDatas/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: UserContactDatas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UserId,AddressNation,AddressCity,AddressStreet,AddressState,PhoneNumber,PhoneNumberAlt,EmailAddress,EmailAddressAlt,Current")] UserContactData userContactData)
    {
      if (ModelState.IsValid)
      {
        _context.Add(userContactData);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(userContactData);
    }


    // GET: UserContactDatas/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userContactData = await _context.UserContactDatasDB.FindAsync(id);
      if (userContactData == null)
      {
        return NotFound();
      }
      return View(userContactData);
    }


    // POST: UserContactDatas/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,AddressNation,AddressCity,AddressStreet,AddressState,PhoneNumber,PhoneNumberAlt,EmailAddress,EmailAddressAlt,Current")] UserContactData userContactData)
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
      return View(userContactData);
    }


    // GET: UserContactDatas/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
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

      return View(userContactData);
    }


    // POST: UserContactDatas/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var userContactData = await _context.UserContactDatasDB.FindAsync(id);
      _context.UserContactDatasDB.Remove(userContactData);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool UserContactDataExists(int id)
    {
      return _context.UserContactDatasDB.Any(e => e.Id == id);
    }
  }
}
