using Gathering.Domain.Models;

namespace Gathering.Domain.Test.ValueObjects;

public class TestId : IdObject<TestId>
{
    protected TestId(Guid value) : base(value)
    {
    }
}