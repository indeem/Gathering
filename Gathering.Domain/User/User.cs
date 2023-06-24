using Gathering.Domain.Models;
using Gathering.Domain.User.ValueObjects;

namespace Gathering.Domain.User;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    private User(UserId id, string firstName, string lastName, string email, string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(UserId.Create(), firstName, lastName, email, password);
    }
}