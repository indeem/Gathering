using ErrorOr;

namespace Gathering.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials =>
            Error.Conflict("Authentication.InvalidCredentials", "Invalid credentials");
    }
}