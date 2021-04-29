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
  public class UsersController : Controller
  {
    private readonly JobDbContext _context;

    public UsersController(JobDbContext context)
    {
      _context = context;
    }


    // GET: Users
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.UserDB.ToListAsync());
    }


    // GET: Users/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var user = await _context.UserDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (user == null)
      {
        return NotFound();
      }

      return View(user);
    }


    // GET: Users/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: Users/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDate,Religion,Sex,Gender,Picture,PictureAlt,Nationality,Nationality2")] User user)
    {
      if (ModelState.IsValid)
      {
        _context.Add(user);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(user);
    }


    // GET: Users/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var user = await _context.UserDB.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }
      return View(user);
    }


    // POST: Users/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BirthDate,Religion,Sex,Gender,Picture,PictureAlt,Nationality,Nationality2")] User user)
    {
      if (id != user.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(user);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!UserExists(user.Id))
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
      return View(user);
    }


    // GET: Users/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var user = await _context.UserDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (user == null)
      {
        return NotFound();
      }

      return View(user);
    }


    // POST: Users/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var user = await _context.UserDB.FindAsync(id);
      _context.UserDB.Remove(user);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool UserExists(int id)
    {
      return _context.UserDB.Any(e => e.Id == id);
    }
  }
}
