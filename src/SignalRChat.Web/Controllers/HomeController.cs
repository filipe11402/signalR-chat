using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalRChat.Web.Helpers;
using SignalRChat.Web.Models;
using System.Diagnostics;

namespace SignalRChat.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}