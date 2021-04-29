using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApp;
using JobApp.Models.ApplicationModel;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Controllers
{
  public class ApplicationsController : Controller
  {
    private readonly JobDbContext _context;

    public ApplicationsController(JobDbContext context)
    {
      _context = context;
    }


    // GET: Applications
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.ApplicationsDB.ToListAsync());
    }


    // GET: Applications/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var application = await _context.ApplicationsDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (application == null)
      {
        return NotFound();
      }

      return View(application);
    }


    // GET: Applications/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: Applications/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UserId,JobOfferId,Title,Answer,DateSent,DateAnswered,Current")] Application application)
    {
      if (ModelState.IsValid)
      {
        _context.Add(application);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(application);
    }


    // GET: Applications/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var application = await _context.ApplicationsDB.FindAsync(id);
      if (application == null)
      {
        return NotFound();
      }
      return View(application);
    }


    // POST: Applications/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,JobOfferId,Title,Answer,DateSent,DateAnswered,Current")] Application application)
    {
      if (id != application.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(application);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ApplicationExists(application.Id))
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
      return View(application);
    }


    // GET: Applications/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var application = await _context.ApplicationsDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (application == null)
      {
        return NotFound();
      }

      return View(application);
    }


    // POST: Applications/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var application = await _context.ApplicationsDB.FindAsync(id);
      _context.ApplicationsDB.Remove(application);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ApplicationExists(int id)
    {
      return _context.ApplicationsDB.Any(e => e.Id == id);
    }
  }
}
