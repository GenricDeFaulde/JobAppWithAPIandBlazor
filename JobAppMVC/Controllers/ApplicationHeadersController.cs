using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApp;
using JobApp.Models.ApplicationModel;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Controllers
{
  public class ApplicationHeadersController : Controller
  {
    private readonly JobDbContext _context;

    public ApplicationHeadersController(JobDbContext context)
    {
      _context = context;
    }

    // GET: ApplicationHeaders
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.ApplicationHeadersDB.ToListAsync());
    }


    // GET: ApplicationHeaders/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationHeader = await _context.ApplicationHeadersDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (applicationHeader == null)
      {
        return NotFound();
      }

      return View(applicationHeader);
    }



    // GET: ApplicationHeaders/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }

    // POST: ApplicationHeaders/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ApplicationnId,Title,Content")] ApplicationHeader applicationHeader)
    {
      if (ModelState.IsValid)
      {
        _context.Add(applicationHeader);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(applicationHeader);
    }



    // GET: ApplicationHeaders/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationHeader = await _context.ApplicationHeadersDB.FindAsync(id);
      if (applicationHeader == null)
      {
        return NotFound();
      }
      return View(applicationHeader);
    }

    // POST: ApplicationHeaders/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationnId,Title,Content")] ApplicationHeader applicationHeader)
    {
      if (id != applicationHeader.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(applicationHeader);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ApplicationHeaderExists(applicationHeader.Id))
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
      return View(applicationHeader);
    }


    // GET: ApplicationHeaders/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationHeader = await _context.ApplicationHeadersDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (applicationHeader == null)
      {
        return NotFound();
      }

      return View(applicationHeader);
    }


    // POST: ApplicationHeaders/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var applicationHeader = await _context.ApplicationHeadersDB.FindAsync(id);
      _context.ApplicationHeadersDB.Remove(applicationHeader);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ApplicationHeaderExists(int id)
    {
      return _context.ApplicationHeadersDB.Any(e => e.Id == id);
    }
  }
}
