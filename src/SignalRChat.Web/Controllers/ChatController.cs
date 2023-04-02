using Microsoft.AspNetCore.Mvc;
using SignalRChat.Web.Domain;

namespace SignalRChat.Web.Controllers;

public class ChatController : Controller
{
    private readonly IMessageRepository _messageRepository;

    public ChatController(
        IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<IActionResult> Index()
    {
        var oldMessages = await _messageRepository
            .GetAllAsync();

        return View(oldMessages);
    }
}
