using Microsoft.AspNetCore.Mvc;

namespace SignalRChat.Web.Controllers;

public class ChatController : Controller
{


    public IActionResult Index()
    {
        return View();
    }
}
