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
  public class HeadHunterContactDatasController : Controller
  {
    private readonly JobDbContext _context;

    public HeadHunterContactDatasController(JobDbContext context)
    {
      _context = context;
    }


    // GET: HeadHunterContactDatas
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.HHContactDatas.ToListAsync());
    }


    // GET: HeadHunterContactDatas/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var headHunterContactData = await _context.HHContactDatas
          .FirstOrDefaultAsync(m => m.Id == id);
      if (headHunterContactData == null)
      {
        return NotFound();
      }

      return View(headHunterContactData);
    }


    // GET: HeadHunterContactDatas/Create
    [Authorize]
    public IActionResult Create()
    {
      return View();
    }


    // POST: HeadHunterContactDatas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,CompanyId,JobExchangeId,AddressNation,AddressCity,AddressStreet,AddressState,PhoneNumber,PhoneNumberAlt,EmailAddress,IsActive")] HeadHunterContactData headHunterContactData)
    {
      if (ModelState.IsValid)
      {
        _context.Add(headHunterContactData);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(headHunterContactData);
    }


    // GET: HeadHunterContactDatas/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var headHunterContactData = await _context.HHContactDatas.FindAsync(id);
      if (headHunterContactData == null)
      {
        return NotFound();
      }
      return View(headHunterContactData);
    }


    // POST: HeadHunterContactDatas/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,JobExchangeId,AddressNation,AddressCity,AddressStreet,AddressState,PhoneNumber,PhoneNumberAlt,EmailAddress,IsActive")] HeadHunterContactData headHunterContactData)
    {
      if (id != headHunterContactData.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(headHunterContactData);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!HeadHunterContactDataExists(headHunterContactData.Id))
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
      return View(headHunterContactData);
    }


    // GET: HeadHunterContactDatas/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var headHunterContactData = await _context.HHContactDatas
          .FirstOrDefaultAsync(m => m.Id == id);
      if (headHunterContactData == null)
      {
        return NotFound();
      }

      return View(headHunterContactData);
    }


    // POST: HeadHunterContactDatas/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var headHunterContactData = await _context.HHContactDatas.FindAsync(id);
      _context.HHContactDatas.Remove(headHunterContactData);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool HeadHunterContactDataExists(int id)
    {
      return _context.HHContactDatas.Any(e => e.Id == id);
    }
  }
}
