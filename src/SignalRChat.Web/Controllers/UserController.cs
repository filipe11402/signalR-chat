using Microsoft.AspNetCore.Mvc;

namespace SignalRChat.Web.Controllers;

public class UserController : Controller
{
    //TODO: page to register user

    //return only user info, nothing else

    public IActionResult Index()
    {
        return View();
    }
}
