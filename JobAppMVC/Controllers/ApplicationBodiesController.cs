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
  public class ApplicationBodiesController : Controller
  {
    private readonly JobDbContext _context;

    public ApplicationBodiesController(JobDbContext context)
    {
      _context = context;
    }

    [Authorize]
    // GET: ApplicationBodies
    public async Task<IActionResult> Index()
    {
      return View(await _context.ApplicationBodiesDB.ToListAsync());
    }

    [Authorize]
    // GET: ApplicationBodies/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationBody = await _context.ApplicationBodiesDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (applicationBody == null)
      {
        return NotFound();
      }

      return View(applicationBody);
    }

    [Authorize]
    // GET: ApplicationBodies/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: ApplicationBodies/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ApplicationnId,Title,Content")] ApplicationBody applicationBody)
    {
      if (ModelState.IsValid)
      {
        _context.Add(applicationBody);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(applicationBody);
    }

    [Authorize]
    // GET: ApplicationBodies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationBody = await _context.ApplicationBodiesDB.FindAsync(id);
      if (applicationBody == null)
      {
        return NotFound();
      }
      return View(applicationBody);
    }

    // POST: ApplicationBodies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationnId,Title,Content")] ApplicationBody applicationBody)
    {
      if (id != applicationBody.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(applicationBody);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ApplicationBodyExists(applicationBody.Id))
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
      return View(applicationBody);
    }

    [Authorize]
    // GET: ApplicationBodies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationBody = await _context.ApplicationBodiesDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (applicationBody == null)
      {
        return NotFound();
      }

      return View(applicationBody);
    }

    // POST: ApplicationBodies/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var applicationBody = await _context.ApplicationBodiesDB.FindAsync(id);
      _context.ApplicationBodiesDB.Remove(applicationBody);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ApplicationBodyExists(int id)
    {
      return _context.ApplicationBodiesDB.Any(e => e.Id == id);
    }
  }
}
