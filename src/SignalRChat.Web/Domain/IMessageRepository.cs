namespace SignalRChat.Web.Domain;

public interface IMessageRepository
{
    Task CreateAsync(Message message);

    Task<IEnumerable<Message>> GetAllAsync();
}

public class MessageRepository : IMessageRepository
{
    private static IEnumerable<Message> _messages = new List<Message>();

    public MessageRepository()
    {
    }

    public Task CreateAsync(Message message)
    {
        _messages = _messages.Append(message);

        return Task.CompletedTask;
    }

    public Task<IEnumerable<Message>> GetAllAsync()
    {
        return Task.FromResult(_messages);
    }
}
