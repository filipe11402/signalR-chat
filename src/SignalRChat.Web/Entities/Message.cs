namespace SignalRChat.Web.Entities;

public sealed class Message
{
    public Guid Id { get; set; }

    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }

    public string Content { get; set; }

    public DateTime SentAt { get; set; }

    public DateTime? ReadAt { get; set; }

    private Message()
    {
    }

    public Message(
        Guid id,
        Guid senderId, 
        Guid receiverId, 
        string content, 
        DateTime sentAt,
        DateTime? readAt)
    {
        Id = id;
        SenderId = senderId;
        ReceiverId = receiverId;
        Content = content;
        SentAt = sentAt;
        ReadAt = readAt;
    }
}
