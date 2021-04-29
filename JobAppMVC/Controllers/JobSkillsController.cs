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
  public class JobSkillsController : Controller
  {
    private readonly JobDbContext _context;

    public JobSkillsController(JobDbContext context)
    {
      _context = context;
    }


    // GET: JobSkills
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.JobSkillsDB.ToListAsync());
    }


    // GET: JobSkills/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobSkill = await _context.JobSkillsDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (jobSkill == null)
      {
        return NotFound();
      }

      return View(jobSkill);
    }


    // GET: JobSkills/Create
    [Authorize]
    public IActionResult Create()
    {

      return View();
    }


    // POST: JobSkills/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,JobId,Name,Content")] JobSkill jobSkill)
    {
      if (ModelState.IsValid)
      {
        _context.Add(jobSkill);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(jobSkill);
    }


    // GET: JobSkills/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobSkill = await _context.JobSkillsDB.FindAsync(id);
      if (jobSkill == null)
      {
        return NotFound();
      }
      return View(jobSkill);
    }


    // POST: JobSkills/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,JobId,Name,Content")] JobSkill jobSkill)
    {
      if (id != jobSkill.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(jobSkill);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!JobSkillExists(jobSkill.Id))
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
      return View(jobSkill);
    }


    // GET: JobSkills/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobSkill = await _context.JobSkillsDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (jobSkill == null)
      {
        return NotFound();
      }

      return View(jobSkill);
    }


    // POST: JobSkills/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var jobSkill = await _context.JobSkillsDB.FindAsync(id);
      _context.JobSkillsDB.Remove(jobSkill);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool JobSkillExists(int id)
    {
      return _context.JobSkillsDB.Any(e => e.Id == id);
    }
  }
}
