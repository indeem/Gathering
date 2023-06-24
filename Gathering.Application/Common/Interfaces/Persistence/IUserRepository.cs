using Gathering.Domain.User;

namespace Gathering.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetByEmail(string email);
    void Add(User user);
}