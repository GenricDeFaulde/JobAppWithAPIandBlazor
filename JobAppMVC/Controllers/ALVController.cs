using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApp;
using JobApp.Models.ALVModel;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Controllers
{
  public class ALVController : Controller
  {
    private readonly JobDbContext _context;

    public ALVController(JobDbContext context)
    {
      _context = context;
    }

    [Authorize]
    // GET: ALV
    public async Task<IActionResult> Index()
    {
      return View(await _context.ALVDB.ToListAsync());
    }

    [Authorize]
    // GET: ALV/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobsuche = await _context.ALVDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (jobsuche == null)
      {
        return NotFound();
      }

      return View(jobsuche);
    }

    [Authorize]
    // GET: ALV/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: ALV/Create
    // TODO overposting protection? Check ALL controllers!
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UserId,JobOfferId,CompanyId,Email,JobId,Status,DateSent,DateAnswered,Proof")] Jobsuche jobsuche)
    {
      if (ModelState.IsValid)
      {
        _context.Add(jobsuche);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(jobsuche);
    }

    [Authorize]
    // GET: ALV/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobsuche = await _context.ALVDB.FindAsync(id);
      if (jobsuche == null)
      {
        return NotFound();
      }
      return View(jobsuche);
    }

    // POST: ALV/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,JobOfferId,CompanyId,Email,JobId,Status,DateSent,DateAnswered,Proof")] Jobsuche jobsuche)
    {
      if (id != jobsuche.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(jobsuche);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!JobsucheExists(jobsuche.Id))
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
      return View(jobsuche);
    }

    [Authorize]
    // GET: ALV/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobsuche = await _context.ALVDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (jobsuche == null)
      {
        return NotFound();
      }

      return View(jobsuche);
    }

    // POST: ALV/Delete/5

    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var jobsuche = await _context.ALVDB.FindAsync(id);
      _context.ALVDB.Remove(jobsuche);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool JobsucheExists(int id)
    {
      return _context.ALVDB.Any(e => e.Id == id);
    }
  }
}
