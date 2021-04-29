using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApp;
using JobApp.Models.JobModel;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Controllers
{
  public class JobsController : Controller
  {
    private readonly JobDbContext _context;

    public JobsController(JobDbContext context)
    {
      _context = context;
    }


    // GET: Jobs
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.JobsDB
      .Include(i => i.Offers)
      .ToListAsync());
    }

    // GET: Jobs/Details/5

    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var job = await _context.JobsDB
          .Include(i => i.JobData)
          .Include(i => i.JobSkillz)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (job == null)
      {
        return NotFound();
      }

      return View(job);
    }


    // GET: Jobs/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: Jobs/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,JobOfferId,Title,TitleAlt,TitleAlt2")] Job job)
    {


      if (ModelState.IsValid)
      {
        _context.Add(job);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(job);
    }


    // GET: Jobs/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var job = await _context.JobsDB
          .Include(i => i.Offers)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (job == null)
      {
        return NotFound();
      }
      return View(job);
    }


    // POST: Jobs/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,JobOfferId,Title,TitleAlt,TitleAlt2")] Job job)
    {
      if (id != job.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(job);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!JobExists(job.Id))
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
      return View(job);
    }


    // GET: Jobs/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var job = await _context.JobsDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (job == null)
      {
        return NotFound();
      }

      return View(job);
    }


    // POST: Jobs/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var job = await _context.JobsDB.FindAsync(id);
      _context.JobsDB.Remove(job);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool JobExists(int id)
    {
      return _context.JobsDB.Any(e => e.Id == id);
    }
  }
}
