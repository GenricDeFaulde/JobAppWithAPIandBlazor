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
  public class UserJobHistoriesController : Controller
  {
    private readonly JobDbContext _context;

    public UserJobHistoriesController(JobDbContext context)
    {
      _context = context;
    }


    // GET: UserJobHistories
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.UserPastJobs.ToListAsync());
    }


    // GET: UserJobHistories/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userJobHistory = await _context.UserPastJobs
          .FirstOrDefaultAsync(m => m.Id == id);
      if (userJobHistory == null)
      {
        return NotFound();
      }

      return View(userJobHistory);
    }


    // GET: UserJobHistories/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: UserJobHistories/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UserId,Title,Description,SkillSummary,TestimonyUrl,Salary,StartDate,EndDate,Current")] UserJobHistory userJobHistory)
    {
      if (ModelState.IsValid)
      {
        _context.Add(userJobHistory);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(userJobHistory);
    }


    // GET: UserJobHistories/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userJobHistory = await _context.UserPastJobs.FindAsync(id);
      if (userJobHistory == null)
      {
        return NotFound();
      }
      return View(userJobHistory);
    }


    // POST: UserJobHistories/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Title,Description,SkillSummary,TestimonyUrl,Salary,StartDate,EndDate,Current")] UserJobHistory userJobHistory)
    {
      if (id != userJobHistory.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(userJobHistory);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!UserJobHistoryExists(userJobHistory.Id))
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
      return View(userJobHistory);
    }


    // GET: UserJobHistories/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userJobHistory = await _context.UserPastJobs
          .FirstOrDefaultAsync(m => m.Id == id);
      if (userJobHistory == null)
      {
        return NotFound();
      }

      return View(userJobHistory);
    }


    // POST: UserJobHistories/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var userJobHistory = await _context.UserPastJobs.FindAsync(id);
      _context.UserPastJobs.Remove(userJobHistory);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool UserJobHistoryExists(int id)
    {
      return _context.UserPastJobs.Any(e => e.Id == id);
    }
  }
}
