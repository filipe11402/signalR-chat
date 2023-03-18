namespace SignalRChat.Web.Entities;

public sealed class User
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Salt { get; set; }

    private User() { }

    public User(Guid id,
        string username,
        string password, 
        string salt)
    {
        Id = id;
        Username = username;
        Password = password;
        Salt = salt;
    }
}
