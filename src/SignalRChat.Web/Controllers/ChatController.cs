using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Web.Infrastructure;

namespace SignalRChat.Web.Controllers;

public class ChatController : Controller
{
    private readonly IHubContext<ChatHub> _chatContext;

    public ChatController(
        IHubContext<ChatHub> chatContext)
    {
        _chatContext = chatContext;
    }

    public IActionResult Index()
    {
        return View();
    }
}
