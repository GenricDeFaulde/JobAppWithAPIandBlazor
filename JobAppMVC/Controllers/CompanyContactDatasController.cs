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
  public class CompanyContactDatasController : Controller
  {
    private readonly JobDbContext _context;

    public CompanyContactDatasController(JobDbContext context)
    {
      _context = context;
    }


    // GET: CompanyContactDatas
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.CompanyContactdatasDB.ToListAsync());
    }

    // GET: CompanyContactDatas/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyContactData = await _context.CompanyContactdatasDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (companyContactData == null)
      {
        return NotFound();
      }

      return View(companyContactData);
    }


    // GET: CompanyContactDatas/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: CompanyContactDatas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,CompanyId,CompanyBranchId,Name,PhoneNumber,PhoneNumberAlt,EmailAddress,EmailAddressAlt,IsActive")] CompanyContactData companyContactData)
    {
      if (ModelState.IsValid)
      {
        _context.Add(companyContactData);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(companyContactData);
    }


    // GET: CompanyContactDatas/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyContactData = await _context.CompanyContactdatasDB.FindAsync(id);
      if (companyContactData == null)
      {
        return NotFound();
      }
      return View(companyContactData);
    }


    // POST: CompanyContactDatas/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,CompanyBranchId,Name,PhoneNumber,PhoneNumberAlt,EmailAddress,EmailAddressAlt,IsActive")] CompanyContactData companyContactData)
    {
      if (id != companyContactData.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(companyContactData);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CompanyContactDataExists(companyContactData.Id))
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
      return View(companyContactData);
    }


    // GET: CompanyContactDatas/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var companyContactData = await _context.CompanyContactdatasDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (companyContactData == null)
      {
        return NotFound();
      }

      return View(companyContactData);
    }


    // POST: CompanyContactDatas/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var companyContactData = await _context.CompanyContactdatasDB.FindAsync(id);
      _context.CompanyContactdatasDB.Remove(companyContactData);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CompanyContactDataExists(int id)
    {
      return _context.CompanyContactdatasDB.Any(e => e.Id == id);
    }
  }
}
