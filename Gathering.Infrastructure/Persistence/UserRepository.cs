using Gathering.Application.Common.Interfaces.Persistence;
using Gathering.Domain.User;

namespace Gathering.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public User? GetByEmail(string email)
    {
        return _users.FirstOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}