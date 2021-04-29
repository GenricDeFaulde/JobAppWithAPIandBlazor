using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using JobApp.Models.CompanyModel;

// !note port to blazor!!!

namespace JobApp.Areas.Finder.Pages.JobFinder
{
  [AllowAnonymous]
  public class CompanyInfoModel : PageModel
  {
    private readonly JobDbContext _context;
    private readonly IWebHostEnvironment _hostEnvironment;

    public CompanyInfoModel(JobDbContext context, IWebHostEnvironment hostEnvironment)
    {
      _context = context;
      this._hostEnvironment = hostEnvironment;
    }


    [BindProperty]
    public InputModel Input { get; set; }

    public string ReturnUrl { get; set; }

    /*************************************************************************
     * Navigation properties
     *************************************************************************/

    /// <summary>
    /// company deletes branches
    /// </summary>
    public virtual ICollection<global::JobApp.Models.CompanyModel.CompanyBranch> Branches { get; protected set; }

    /// <summary>
    /// summary
    /// </summary>
    public virtual ICollection<global::JobApp.Models.CompanyModel.CompanyHistory> HistoryList { get; protected set; }

    public class InputModel
    {
      /*************************************************************************
      * Properties
      *************************************************************************/

      /// <summary>
      /// Identity, Required
      /// Identity, Required
      /// </summary>
      // [Key]
      // [Required]
      // public int Id { get; internal set; }

      /// <summary>
      /// Required, Max length = 50
      /// Required, Max length = 50
      /// </summary>
      [Required]
      [MaxLength(50)]
      [StringLength(50)]
      public string CompanyName { get; set; }

      /// <summary>
      /// Required
      /// Historic retention property
      /// </summary>
      [Required]
      public bool Current { get; set; }
      // public byte[] LogoBig { get; set; }

      [Required]
      [MaxLength(250)]
      [StringLength(250)]
      public string Description { get; set; }
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
      return Page();
    }


    public async Task<List<Company>> GetCompaniesAsync()
    {
      var company = await _context.CompaniesDB
                          .Include(i => i.Branches)
                              .ThenInclude(t => t.Contacts)
                          .Include(i => i.Branches)
                              .ThenInclude(t => t.Offers)
                          .Include(l => l.HistoryList)
                          .ToListAsync();

      return company;
    }

    // // GET: Companies/Details/5
    // [Authorize]
    // public async Task<IActionResult> Details(int? id)
    // {
    //   if (id == null)
    //   {
    //     return NotFound();
    //   }

    //   var company = await _context.CompaniesDB
    //                   .Include(i => i.Branches)
    //                       .ThenInclude(t => t.Contacts)
    //                   .Include(i => i.Branches)
    //                       .ThenInclude(t => t.Offers)
    //                   .Include(l => l.HistoryList)
    //                   .FirstOrDefaultAsync(m => m.Id == id);
    //   if (company == null)
    //   {
    //     return NotFound();
    //   }

    //   return View(company);
    // }


    // // GET: Companies/Create
    // [Authorize]
    // public IActionResult Create()
    // {
    //   return View();
    // }


    // // POST: Companies/Create
    // // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [Authorize(Roles = "SuperAdmin")]
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Create([Bind("Id,CompanyName,Current, Description")] Company company)
    // {
    //   if (ModelState.IsValid)
    //   {
    //     _context.Add(company);
    //     await _context.SaveChangesAsync();
    //     return RedirectToAction(nameof(Index));
    //   }
    //   return View(company);
    // }


    // // GET: Companies/Edit/5
    // [Authorize]
    // public async Task<IActionResult> Edit(int? id)
    // {
    //   if (id == null)
    //   {
    //     return NotFound();
    //   }



    //   var company = await _context.CompaniesDB.FindAsync(id);
    //   if (company == null)
    //   {
    //     return NotFound();
    //   }
    //   return View(company);
    // }


    // // POST: Companies/Edit/5
    // // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [Authorize(Roles = "SuperAdmin")]
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Current, Description")] Company company)
    // {
    //   //if (id != company.Id)
    //   //{
    //   //    return NotFound();
    //   //}
    //   company.Id = id;

    //   if (ModelState.IsValid)
    //   {
    //     try
    //     {
    //       _context.Update(company);
    //       await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //       if (!CompanyExists(company.Id))
    //       {
    //         return NotFound();
    //       }
    //       else
    //       {
    //         throw;
    //       }
    //     }
    //     return RedirectToAction(nameof(Index));
    //   }
    //   return View(company);
    // }


    // // GET: Companies/Delete/5
    // [Authorize]
    // public async Task<IActionResult> Delete(int? id)
    // {
    //   if (id == null)
    //   {
    //     return NotFound();
    //   }

    //   var company = await _context.CompaniesDB
    //       .FirstOrDefaultAsync(m => m.Id == id);
    //   if (company == null)
    //   {
    //     return NotFound();
    //   }

    //   return View(company);
    // }


    // // POST: Companies/Delete/5
    // [Authorize(Roles = "SuperAdmin")]
    // [HttpPost, ActionName("Delete")]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> DeleteConfirmed(int id)
    // {
    //   var company = await _context.CompaniesDB.FindAsync(id);
    //   _context.CompaniesDB.Remove(company);
    //   await _context.SaveChangesAsync();
    //   return RedirectToAction(nameof(Index));
    // }

    // private bool CompanyExists(int id)
    // {
    //   return _context.CompaniesDB.Any(e => e.Id == id);
    // }

  }
}