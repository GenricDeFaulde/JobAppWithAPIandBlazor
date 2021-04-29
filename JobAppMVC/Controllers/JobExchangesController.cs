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
  public class JobExchangesController : Controller
  {
    private readonly JobDbContext _context;

    public JobExchangesController(JobDbContext context)
    {
      _context = context;
    }


    // GET: JobExchanges
    [Authorize]
    public async Task<IActionResult> Index()
    {
      var exchanges = await _context.JobExchangesDB
                      .Include(i => i.Offers)
                      .ToListAsync();

      return View(exchanges);
    }


    // GET: JobExchanges/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobExchange = await _context.JobExchangesDB
                        .Include(i => i.Offers)
                            .ThenInclude(l => l.CompanyBranch)
                        .Include(i => i.Offers)
                            .ThenInclude(l => l.CompanyBranch)
                                .ThenInclude(o => o.Company)
                        .Include(i => i.Offers)
                            .ThenInclude(l => l.Job)
                        .Include(i => i.Offers)
                            .ThenInclude(l => l.Application)
                        .FirstOrDefaultAsync(m => m.Id == id);
      if (jobExchange == null)
      {
        return NotFound();
      }

      return View(jobExchange);
    }


    // GET: JobExchanges/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: JobExchanges/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Url,Current")] JobExchange jobExchange)
    {
      if (ModelState.IsValid)
      {
        _context.Add(jobExchange);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(jobExchange);
    }


    // GET: JobExchanges/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobExchange = await _context.JobExchangesDB.FindAsync(id);
      if (jobExchange == null)
      {
        return NotFound();
      }
      return View(jobExchange);
    }


    // POST: JobExchanges/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url,Current")] JobExchange jobExchange)
    {
      if (id != jobExchange.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(jobExchange);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!JobExchangeExists(jobExchange.Id))
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
      return View(jobExchange);
    }


    // GET: JobExchanges/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobExchange = await _context.JobExchangesDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (jobExchange == null)
      {
        return NotFound();
      }

      return View(jobExchange);
    }


    // POST: JobExchanges/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var jobExchange = await _context.JobExchangesDB.FindAsync(id);
      _context.JobExchangesDB.Remove(jobExchange);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool JobExchangeExists(int id)
    {
      return _context.JobExchangesDB.Any(e => e.Id == id);
    }
  }
}
