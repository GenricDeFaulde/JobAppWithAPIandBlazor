using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApp;
using JobApp.Models.CompanyModel;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Controllers
{
  public class CompaniesController : Controller
  {
    private readonly JobDbContext _context;
    private readonly IWebHostEnvironment _hostEnvironment;

    public CompaniesController(JobDbContext context, IWebHostEnvironment hostEnvironment)
    {
      _context = context;
      this._hostEnvironment = hostEnvironment;
    }


    // GET: Companies
    [Authorize]
    public async Task<IActionResult> Index()
    {
      var company = await _context.CompaniesDB
                      .Include(i => i.Branches)
                          .ThenInclude(t => t.Contacts)
                      .Include(i => i.Branches)
                          .ThenInclude(t => t.Offers)
                      .Include(l => l.HistoryList)
                      .ToListAsync();
      return View(company);
    }


    // GET: Companies/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var company = await _context.CompaniesDB
                      .Include(i => i.Branches)
                          .ThenInclude(t => t.Contacts)
                      .Include(i => i.Branches)
                          .ThenInclude(t => t.Offers)
                      .Include(l => l.HistoryList)
                      .FirstOrDefaultAsync(m => m.Id == id);
      if (company == null)
      {
        return NotFound();
      }

      return View(company);
    }


    // GET: Companies/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: Companies/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,CompanyName,Current, Description")] Company company)
    {
      if (ModelState.IsValid)
      {
        _context.Add(company);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(company);
    }


    // GET: Companies/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }



      var company = await _context.CompaniesDB.FindAsync(id);
      if (company == null)
      {
        return NotFound();
      }
      return View(company);
    }


    // POST: Companies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Current, Description")] Company company)
    {
      if (id != company.Id)
      {
        return NotFound();
      }
      // company.Id = id;

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(company);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CompanyExists(company.Id))
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
      return View(company);
    }


    // GET: Companies/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var company = await _context.CompaniesDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (company == null)
      {
        return NotFound();
      }

      return View(company);
    }


    // POST: Companies/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var company = await _context.CompaniesDB.FindAsync(id);
      _context.CompaniesDB.Remove(company);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CompanyExists(int id)
    {
      return _context.CompaniesDB.Any(e => e.Id == id);
    }
  }
}
