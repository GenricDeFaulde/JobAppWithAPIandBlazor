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
  public class CompanyBranchesController : Controller
  {
    private readonly JobDbContext _context;

    public CompanyBranchesController(JobDbContext context)
    {
      _context = context;
    }


    // GET: CompanyBranches
    [Authorize]
    public async Task<IActionResult> Index(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyBranch = await _context.CompanyBranchDB
      .Where(m => m.CompanyId == id)
                        .Include(i => i.Company)
                        .Include(i => i.Offers)
          .ToListAsync();
      if (companyBranch.Count() == 0)
      {
        return RedirectToAction("Create", new { id });
      }

      return View(companyBranch);
    }


    // GET: CompanyBranches/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyBranch = await _context.CompanyBranchDB
                        .Include(i => i.Company)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (companyBranch == null)
      {
        return NotFound();
      }

      return View(companyBranch);
    }


    // GET: CompanyBranches/Create
    [Authorize]
    public IActionResult Create(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyBranch = new CompanyBranch();

      companyBranch.Company = _context.CompaniesDB
                          .FirstOrDefault(m => m.Id == id);

      if (companyBranch.Company.Id != id)
      {
        return NotFound();
      }

      return View(companyBranch);
    }


    // POST: CompanyBranches/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CompanyId,Name,Description,AddressNation,AddressCity,AddressStreet,AddressState")] CompanyBranch companyBranch)
    {
      if (ModelState.IsValid)
      {
        _context.Add(companyBranch);
        await _context.SaveChangesAsync();
        // TODO fix redirect
        // return RedirectToAction(nameof(Index), new { companyBranch.CompanyId });
        return RedirectToRoute(new
        {
          controller = "CompanyBranches",
          action = "Index",
          id = companyBranch.CompanyId
        });
      }
      return View(companyBranch);
    }


    // GET: CompanyBranches/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyBranch = await _context.CompanyBranchDB.FindAsync(id);
      if (companyBranch == null)
      {
        return NotFound();
      }
      return View(companyBranch);
    }


    // POST: CompanyBranches/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, CompanyId,Name,Description,AddressNation,AddressCity,AddressStreet,AddressState")] CompanyBranch companyBranch)
    {
      companyBranch.CompanyId = id;

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(companyBranch);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CompanyBranchExists(companyBranch.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index), new { id = companyBranch.Id });
      }
      return View(companyBranch);
    }


    // GET: CompanyBranches/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyBranch = await _context.CompanyBranchDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (companyBranch == null)
      {
        return NotFound();
      }

      return View(companyBranch);
    }


    // POST: CompanyBranches/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var companyBranch = await _context.CompanyBranchDB.FindAsync(id);
      _context.CompanyBranchDB.Remove(companyBranch);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CompanyBranchExists(int id)
    {
      return _context.CompanyBranchDB.Any(e => e.Id == id);
    }

    private bool CompanyExists(int id)
    {
      return _context.CompaniesDB.Any(e => e.Id == id);
    }
  }
}
