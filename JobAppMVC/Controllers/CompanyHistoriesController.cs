using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApp;
using JobApp.Models.CompanyModel;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Controllers
{
  public class CompanyHistoriesController : Controller
  {
    private readonly JobDbContext _context;

    public CompanyHistoriesController(JobDbContext context)
    {
      _context = context;
    }


    // GET: CompanyHistories
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.CompanyHistoriesDB.ToListAsync());
    }


    // GET: CompanyHistories/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyHistory = await _context.CompanyHistoriesDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (companyHistory == null)
      {
        return NotFound();
      }

      return View(companyHistory);
    }


    // GET: CompanyHistories/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: CompanyHistories/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,CompanyId,Name,Content,Date")] CompanyHistory companyHistory)
    {
      if (ModelState.IsValid)
      {
        _context.Add(companyHistory);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(companyHistory);
    }


    // GET: CompanyHistories/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyHistory = await _context.CompanyHistoriesDB.FindAsync(id);
      if (companyHistory == null)
      {
        return NotFound();
      }
      return View(companyHistory);
    }


    // POST: CompanyHistories/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,Name,Content,Date")] CompanyHistory companyHistory)
    {
      if (id != companyHistory.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(companyHistory);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CompanyHistoryExists(companyHistory.Id))
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
      return View(companyHistory);
    }


    // GET: CompanyHistories/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyHistory = await _context.CompanyHistoriesDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (companyHistory == null)
      {
        return NotFound();
      }

      return View(companyHistory);
    }


    // POST: CompanyHistories/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var companyHistory = await _context.CompanyHistoriesDB.FindAsync(id);
      _context.CompanyHistoriesDB.Remove(companyHistory);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CompanyHistoryExists(int id)
    {
      return _context.CompanyHistoriesDB.Any(e => e.Id == id);
    }
  }
}
