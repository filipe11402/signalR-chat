namespace SignalRChat.Web.Domain;

public sealed class Message
{
    public Guid Id { get; set; }

    public string From { get; set; }

    public string Content { get; set; }

    public DateTime SentAt { get; set; }

    private Message()
    {
    }

    public Message(
        Guid id,
        string from,
        string content)
    {
        Id = id;
        From = from;
        Content = content;
        SentAt = DateTime.UtcNow;
    }
}
