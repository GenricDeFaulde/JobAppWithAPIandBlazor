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
  public class ApplicationFootersController : Controller
  {
    private readonly JobDbContext _context;

    public ApplicationFootersController(JobDbContext context)
    {
      _context = context;
    }

    [Authorize]
    // GET: ApplicationFooters
    public async Task<IActionResult> Index()
    {
      return View(await _context.ApplicationFootersDB.ToListAsync());
    }

    [Authorize]
    // GET: ApplicationFooters/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationFooter = await _context.ApplicationFootersDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (applicationFooter == null)
      {
        return NotFound();
      }

      return View(applicationFooter);
    }

    [Authorize]
    // GET: ApplicationFooters/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: ApplicationFooters/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ApplicationnId,Title,Content")] ApplicationFooter applicationFooter)
    {
      if (ModelState.IsValid)
      {
        _context.Add(applicationFooter);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(applicationFooter);
    }

    [Authorize]
    // GET: ApplicationFooters/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationFooter = await _context.ApplicationFootersDB.FindAsync(id);
      if (applicationFooter == null)
      {
        return NotFound();
      }
      return View(applicationFooter);
    }

    // POST: ApplicationFooters/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationnId,Title,Content")] ApplicationFooter applicationFooter)
    {
      if (id != applicationFooter.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(applicationFooter);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ApplicationFooterExists(applicationFooter.Id))
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
      return View(applicationFooter);
    }

    [Authorize]
    // GET: ApplicationFooters/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationFooter = await _context.ApplicationFootersDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (applicationFooter == null)
      {
        return NotFound();
      }

      return View(applicationFooter);
    }

    // POST: ApplicationFooters/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var applicationFooter = await _context.ApplicationFootersDB.FindAsync(id);
      _context.ApplicationFootersDB.Remove(applicationFooter);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ApplicationFooterExists(int id)
    {
      return _context.ApplicationFootersDB.Any(e => e.Id == id);
    }
  }
}
