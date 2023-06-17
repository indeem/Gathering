using Gathering.Application.Common.Interfaces.Services;

namespace Gathering.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}