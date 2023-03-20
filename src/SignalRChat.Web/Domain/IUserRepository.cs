namespace SignalRChat.Web.Domain;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid id);

    Task<(Guid userId, string username)> AuthenticateAsync(string username, string password);
}