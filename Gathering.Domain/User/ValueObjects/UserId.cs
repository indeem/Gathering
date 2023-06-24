using Gathering.Domain.Models;

namespace Gathering.Domain.User.ValueObjects;

public class UserId : IdObject<UserId>
{
    protected UserId(Guid value) : base(value)
    {
    }
}