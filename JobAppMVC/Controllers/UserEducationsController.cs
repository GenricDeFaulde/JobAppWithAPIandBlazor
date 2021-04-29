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
  public class UserEducationsController : Controller
  {
    private readonly JobDbContext _context;

    public UserEducationsController(JobDbContext context)
    {
      _context = context;
    }


    // GET: UserEducations
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.UserEducationsDB.ToListAsync());
    }


    // GET: UserEducations/Details/5
    [Authorize]
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

      return View(userEducation);
    }


    // GET: UserEducations/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }

    // POST: UserEducations/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UserId,Title,Facility,AddressNation,FacilityAddressCity,FacilityAddressStreet,FacilityAddressState,Graduation,TestimonyUrl,StartDate,EndDate")] UserEducation userEducation)
    {
      if (ModelState.IsValid)
      {
        _context.Add(userEducation);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(userEducation);
    }


    // GET: UserEducations/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userEducation = await _context.UserEducationsDB.FindAsync(id);
      if (userEducation == null)
      {
        return NotFound();
      }
      return View(userEducation);
    }


    // POST: UserEducations/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
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
        return RedirectToAction(nameof(Index));
      }
      return View(userEducation);
    }


    // GET: UserEducations/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
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

      return View(userEducation);
    }


    // POST: UserEducations/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var userEducation = await _context.UserEducationsDB.FindAsync(id);
      _context.UserEducationsDB.Remove(userEducation);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool UserEducationExists(int id)
    {
      return _context.UserEducationsDB.Any(e => e.Id == id);
    }
  }
}
