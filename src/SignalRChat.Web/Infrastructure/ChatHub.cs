using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Web.Infrastructure;

public class ChatHub : Hub
{
    public Task SendMessageToUser(string connectionId, string message)
    {
        return Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
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
