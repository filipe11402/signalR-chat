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

    //TODO: use filter if not valid, go to Login page otherwise let it pass
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [JwtAuthorizationFilter]
    public IActionResult Index()
    {
        return View();
    }

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