using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Controllers
{
  // [Authorize]
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }


    [Authorize]
    public IActionResult Index()
    {
      return View();
    }


    [Authorize]
    public IActionResult Privacy()
    {
      return View();
    }


    [Authorize]
    public IActionResult Jobsuche()
    {
      return View();
    }


    [Authorize]
    public IActionResult CV()
    {
      return View();
    }


    [Authorize]
    public IActionResult EGV()
    {
      return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
