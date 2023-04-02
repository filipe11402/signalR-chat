using SignalRChat.Web.Domain;

namespace SignalRChat.Web.Infrastructure;

public sealed class UserRepository : IUserRepository
{
    private static IEnumerable<User> _users = new List<User>() 
    {
        new(Guid.NewGuid(), "Dummy User", "DummyPassword", Guid.NewGuid().ToString()),
        new(Guid.NewGuid(), "Dummy User2", "DummyPassword", Guid.NewGuid().ToString()),
    };

    public IQueryable<User> Users =
        _users.AsQueryable();

    public UserRepository()
    {
    }

    public Task<(Guid userId, string username)> AuthenticateAsync(string username, string password)
    {
        var user = _users
            .FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));

        return user is null ?
            Task.FromResult((Guid.Empty, string.Empty)) :
            Task.FromResult((user.Id, user.Username));
    }

    public Task<User?> GetUserByIdAsync(Guid id)
    {
        return Task.FromResult(_users
            .FirstOrDefault(user => user.Id == id));
    }

    public Task<IEnumerable<User>> ListAsync()
    {
        return Task.FromResult(_users);
    }
}