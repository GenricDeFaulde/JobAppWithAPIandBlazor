using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApp;
using JobApp.Models.JobModel;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis;
using System.Net.NetworkInformation;
using SQLitePCL;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Controllers
{
  public class JobOffersController : Controller
  {
    private readonly JobDbContext _context;

    public JobOffersController(JobDbContext context)
    {
      _context = context;
    }


    // GET: JobOffers
    [Authorize]
    public async Task<IActionResult> Index()
    {
      // TODO unfug! aufräumen! es wird nichts geladen

      var offerInfo = await _context.JobOffersDB
          .Include(i => i.JobExchange)
          .Include(i => i.HeadHunter)
          .Include(i => i.Application)
          .Include(i => i.CompanyBranch)
            .ThenInclude(l => l.Company)
          .Include(i => i.Job)
          .Include(i => i.Jobsuche)
          .ToListAsync();

      return View(offerInfo);
    }


    // GET: JobOffers by company
    [Authorize]
    public async Task<IActionResult> CompanyIndex(int id)
    {
      //  TODO implement ApplicationCount

      var offerInfo = await _context.CompanyBranchDB
              .Include(i => i.Offers)
                .ThenInclude(l => l.JobExchange)
              .Include(i => i.Offers)
                .ThenInclude(l => l.HeadHunter)
              .Include(i => i.Offers)
                .ThenInclude(l => l.Application)
              .Include(i => i.Offers)
                .ThenInclude(l => l.CompanyBranch)
                  .ThenInclude(j => j.Company)
              .Include(i => i.Offers)
                .ThenInclude(l => l.Job)
              .Include(i => i.Offers)
                .ThenInclude(l => l.Jobsuche)
              .FirstOrDefaultAsync(m => m.CompanyId == id);

      return View(offerInfo);
    }


    // GET: JobOffers by Job
    [Authorize]
    public async Task<IActionResult> JobIndex(int id)
    {

      var offerInfo = await _context.JobsDB
              .Include(i => i.Offers)
                .ThenInclude(l => l.JobExchange)
              .Include(i => i.Offers)
                .ThenInclude(l => l.HeadHunter)
              .Include(i => i.Offers)
                .ThenInclude(l => l.Application)
              .Include(i => i.Offers)
                .ThenInclude(l => l.CompanyBranch)
                  .ThenInclude(j => j.Company)
              .Include(i => i.Offers)
                .ThenInclude(l => l.Job)
              .Include(i => i.Offers)
                .ThenInclude(l => l.Jobsuche)
              .FirstOrDefaultAsync(m => m.Id == id);

      return View(offerInfo);
    }


    // GET: JobOffers by exchange
    [Authorize]
    public async Task<IActionResult> ExchangeIndex(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobExchange = await _context.JobExchangesDB
                        .Include(i => i.Offers)
                            .ThenInclude(l => l.CompanyBranch)
                        .Include(i => i.Offers)
                            .ThenInclude(l => l.CompanyBranch)
                                .ThenInclude(o => o.Company)
                        .Include(i => i.Offers)
                            .ThenInclude(l => l.Job)
                        .Include(i => i.Offers)
                            .ThenInclude(l => l.Application)
                        .FirstOrDefaultAsync(m => m.Id == id);
      if (jobExchange == null)
      {
        return NotFound();
      }

      return View(jobExchange);
    }


    // GET: Jobs by Headhunter
    [Authorize]
    public async Task<IActionResult> HunterIndex(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var headHunter = await _context.HeadHunter
          .Include(i => i.ContactInfos)
          .Include(i => i.Offers)
            .ThenInclude(l => l.CompanyBranch)
              .ThenInclude(m => m.Company)
          .Include(i => i.Offers)
            .ThenInclude(m => m.Job)
          .Include(i => i.Offers)
            .ThenInclude(m => m.Application)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (headHunter == null)
      {
        return NotFound();
      }

      return View(headHunter);
    }



    // GET: JobOffers/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobOffer = await _context.JobOffersDB
      .Include(i => i.JobExchange)
          .Include(i => i.HeadHunter)
          .Include(i => i.Application)
          .Include(i => i.CompanyBranch)
            .ThenInclude(l => l.Company)
          .Include(i => i.Job)
          .Include(i => i.Jobsuche)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (jobOffer == null)
      {
        return NotFound();
      }

      return View(jobOffer);
    }


    // GET: JobOffers/Create
    [Authorize]
    public async Task<IActionResult> Create()
    {
      var jobOffer = new JobOffer();
      jobOffer.CompanyBranchesList = new List<SelectListItem>
      {

      };
      jobOffer.JobsList = new List<SelectListItem>
      {

      };
      jobOffer.HeadHuntersList = new List<SelectListItem>
      {

      };
      jobOffer.JobExchangesList = new List<SelectListItem>
      {

      };

      var companies = await _context.CompaniesDB
      .Include(i => i.Branches)
      .ToListAsync()
      ;

      foreach (var companie in companies)
      {
        foreach (var item in companie.Branches)
        {
          var text = companie.CompanyName + " " + item.Name;
          jobOffer.CompanyBranchesList.Add(new SelectListItem { Value = item.Id.ToString(), Text = text });
        }
      };

      foreach (var Item in _context.JobsDB)
      {
        jobOffer.JobsList.Add(new SelectListItem { Value = Item.Id.ToString(), Text = Item.Title });
      };
      foreach (var Item in _context.HeadHunter)
      {
        jobOffer.HeadHuntersList.Add(new SelectListItem { Value = Item.Id.ToString(), Text = (Item.FirstName + Item.LastName) });
      };

      foreach (var Item in _context.JobExchangesDB)
      {
        jobOffer.JobExchangesList.Add(new SelectListItem { Value = Item.Id.ToString(), Text = Item.Name });
      };

      return View(jobOffer);
    }


    // POST: JobOffers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,CompanyBranchId,JobId,HeadHunterId,JobExchangeId,ApplicationnId,SalaryOffered,IsActive,Releasedate,JobOfferUrl")] JobOffer jobOffer)
    {
      if (ModelState.IsValid)
      {
        _context.Add(jobOffer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(jobOffer);
    }


    // GET: JobOffers/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobOffer = await _context.JobOffersDB
                .Include(i => i.CompanyBranch)
                  .ThenInclude(l => l.Company)
                .Include(i => i.Application)
                .Include(i => i.HeadHunter)
                .Include(i => i.JobExchange)
                .FirstOrDefaultAsync(m => m.Id == id);

      jobOffer.CompanyBranchesList = new List<SelectListItem>
      {

      };
      jobOffer.JobsList = new List<SelectListItem>
      {

      };
      jobOffer.HeadHuntersList = new List<SelectListItem>
      {

      };
      jobOffer.JobExchangesList = new List<SelectListItem>
      {

      };

      var companies = _context.CompaniesDB
      .Include(i => i.Branches)
      ;

      foreach (var companie in companies)
      {
        foreach (var item in companie.Branches)
        {
          var text = companie.CompanyName + " " + item.Name;
          jobOffer.CompanyBranchesList.Add(new SelectListItem { Value = item.Id.ToString(), Text = text });
        }
      };

      foreach (var Item in _context.JobsDB)
      {
        jobOffer.JobsList.Add(new SelectListItem { Value = Item.Id.ToString(), Text = Item.Title });
      };
      foreach (var Item in _context.HeadHunter)
      {
        jobOffer.HeadHuntersList.Add(new SelectListItem { Value = Item.Id.ToString(), Text = (Item.FirstName + Item.LastName) });
      };

      foreach (var Item in _context.JobExchangesDB)
      {
        jobOffer.JobExchangesList.Add(new SelectListItem { Value = Item.Id.ToString(), Text = Item.Name });
      };

      if (jobOffer == null)
      {
        return NotFound();
      }
      return View(jobOffer);
    }


    // POST: JobOffers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyBranchId,JobId,HeadHunterId,JobExchangeId,ApplicationnId,SalaryOffered,IsActive,Releasedate,JobOfferUrl")] JobOffer jobOffer)
    {
      if (id != jobOffer.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(jobOffer);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!JobOfferExists(jobOffer.Id))
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
      return View(jobOffer);
    }


    // GET: JobOffers/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var jobOffer = await _context.JobOffersDB
          .FirstOrDefaultAsync(m => m.Id == id);
      if (jobOffer == null)
      {
        return NotFound();
      }

      return View(jobOffer);
    }

    // POST: JobOffers/Delete/5
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var jobOffer = await _context.JobOffersDB.FindAsync(id);
      _context.JobOffersDB.Remove(jobOffer);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool JobOfferExists(int id)
    {
      return _context.JobOffersDB.Any(e => e.Id == id);
    }
  }
}
