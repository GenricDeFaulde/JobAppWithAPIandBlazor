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
  public class JobDatasController : Controller
  {
    private readonly JobDbContext _context;

    public JobDatasController(JobDbContext context)
    {
      _context = context;
    }


    // GET: JobDatas
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.JobDataDB.ToListAsync());
    }


    // GET: JobDatas/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobData = await _context.JobDataDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (jobData == null)
      {
        return NotFound();
      }

      return View(jobData);
    }


    // GET: JobDatas/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: JobDatas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,JobId,DescriptionShort,DescriptionLong,Nation,Region,MinSalary,MaxSalary,Current")] JobData jobData)
    {
      if (ModelState.IsValid)
      {
        _context.Add(jobData);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(jobData);
    }


    // GET: JobDatas/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobData = await _context.JobDataDB.FindAsync(id);
      if (jobData == null)
      {
        return NotFound();
      }
      return View(jobData);
    }


    // POST: JobDatas/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,JobId,DescriptionShort,DescriptionLong,Nation,Region,MinSalary,MaxSalary,Current")] JobData jobData)
    {
      if (id != jobData.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(jobData);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!JobDataExists(jobData.Id))
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
      return View(jobData);
    }


    // GET: JobDatas/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobData = await _context.JobDataDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (jobData == null)
      {
        return NotFound();
      }

      return View(jobData);
    }


    // POST: JobDatas/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var jobData = await _context.JobDataDB.FindAsync(id);
      _context.JobDataDB.Remove(jobData);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool JobDataExists(int id)
    {
      return _context.JobDataDB.Any(e => e.Id == id);
    }
  }
}
