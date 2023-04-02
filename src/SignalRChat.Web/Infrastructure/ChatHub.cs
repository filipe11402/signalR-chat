using Microsoft.AspNetCore.SignalR;
using SignalRChat.Web.Domain;

namespace SignalRChat.Web.Infrastructure;

public class ChatHub : Hub
{
    private readonly IMessageRepository _messageRepository;

    public ChatHub(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task SendMessage(string user, string message)
    {
        var messageToPersist = new Message(
            Guid.NewGuid(),
            user,
            message);

        await _messageRepository.CreateAsync(messageToPersist);

        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("UserConnected", Context.ConnectionId);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception ex)
    {
        await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
        await base.OnDisconnectedAsync(ex);
    }
}
