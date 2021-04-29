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
  public class UserSkillsController : Controller
  {
    private readonly JobDbContext _context;

    public UserSkillsController(JobDbContext context)
    {
      _context = context;
    }


    // GET: UserSkills
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.UserSkillsDB.ToListAsync());
    }


    // GET: UserSkills/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userSkill = await _context.UserSkillsDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (userSkill == null)
      {
        return NotFound();
      }

      return View(userSkill);
    }


    // GET: UserSkills/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: UserSkills/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UserId,SkillName,SkillDescritpion,SelfRating,Current")] UserSkill userSkill)
    {
      if (ModelState.IsValid)
      {
        _context.Add(userSkill);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(userSkill);
    }


    // GET: UserSkills/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userSkill = await _context.UserSkillsDB.FindAsync(id);
      if (userSkill == null)
      {
        return NotFound();
      }
      return View(userSkill);
    }


    // POST: UserSkills/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,SkillName,SkillDescritpion,SelfRating,Current")] UserSkill userSkill)
    {
      if (id != userSkill.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(userSkill);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!UserSkillExists(userSkill.Id))
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
      return View(userSkill);
    }


    // GET: UserSkills/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var userSkill = await _context.UserSkillsDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (userSkill == null)
      {
        return NotFound();
      }

      return View(userSkill);
    }


    // POST: UserSkills/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var userSkill = await _context.UserSkillsDB.FindAsync(id);
      _context.UserSkillsDB.Remove(userSkill);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool UserSkillExists(int id)
    {
      return _context.UserSkillsDB.Any(e => e.Id == id);
    }
  }
}
