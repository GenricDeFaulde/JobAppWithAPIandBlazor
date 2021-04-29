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
  public class UserWebsitesController : Controller
  {
    private readonly JobDbContext _context;

    public UserWebsitesController(JobDbContext context)
    {
      _context = context;
    }


    // GET: UserWebsites
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.UserWebSitesDB.ToListAsync());
    }


    // GET: UserWebsites/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userWebsite = await _context.UserWebSitesDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (userWebsite == null)
      {
        return NotFound();
      }

      return View(userWebsite);
    }


    // GET: UserWebsites/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: UserWebsites/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UserId,Name,Content,Url")] UserWebsite userWebsite)
    {
      if (ModelState.IsValid)
      {
        _context.Add(userWebsite);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(userWebsite);
    }


    // GET: UserWebsites/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userWebsite = await _context.UserWebSitesDB.FindAsync(id);
      if (userWebsite == null)
      {
        return NotFound();
      }
      return View(userWebsite);
    }


    // POST: UserWebsites/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Name,Content,Url")] UserWebsite userWebsite)
    {
      if (id != userWebsite.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(userWebsite);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!UserWebsiteExists(userWebsite.Id))
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
      return View(userWebsite);
    }


    // GET: UserWebsites/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userWebsite = await _context.UserWebSitesDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (userWebsite == null)
      {
        return NotFound();
      }

      return View(userWebsite);
    }


    // POST: UserWebsites/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var userWebsite = await _context.UserWebSitesDB.FindAsync(id);
      _context.UserWebSitesDB.Remove(userWebsite);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool UserWebsiteExists(int id)
    {
      return _context.UserWebSitesDB.Any(e => e.Id == id);
    }
  }
}
