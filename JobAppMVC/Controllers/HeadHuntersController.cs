using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApp;
using JobApp.Models.HeadHunterModel;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Controllers
{
  public class HeadHuntersController : Controller
  {
    private readonly JobDbContext _context;

    public HeadHuntersController(JobDbContext context)
    {
      _context = context;
    }


    // GET: HeadHunters
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.HeadHunter.ToListAsync());
    }


    // GET: HeadHunters/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var headHunter = await _context.HeadHunter
          .Include(i => i.ContactInfos)
          .Include(i => i.Offers)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (headHunter == null)
      {
        return NotFound();
      }

      return View(headHunter);
    }


    // GET: HeadHunters/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }

    // POST: HeadHunters/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,IsActive")] HeadHunter headHunter)
    {
      if (ModelState.IsValid)
      {
        _context.Add(headHunter);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(headHunter);
    }


    // GET: HeadHunters/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var headHunter = await _context.HeadHunter.FindAsync(id);
      if (headHunter == null)
      {
        return NotFound();
      }
      return View(headHunter);
    }


    // POST: HeadHunters/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,IsActive")] HeadHunter headHunter)
    {
      if (id != headHunter.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(headHunter);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!HeadHunterExists(headHunter.Id))
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
      return View(headHunter);
    }


    // GET: HeadHunters/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var headHunter = await _context.HeadHunter
          .FirstOrDefaultAsync(m => m.Id == id);
      if (headHunter == null)
      {
        return NotFound();
      }

      return View(headHunter);
    }


    // POST: HeadHunters/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var headHunter = await _context.HeadHunter.FindAsync(id);
      _context.HeadHunter.Remove(headHunter);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool HeadHunterExists(int id)
    {
      return _context.HeadHunter.Any(e => e.Id == id);
    }
  }
}
