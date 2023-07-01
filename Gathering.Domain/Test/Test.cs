using Gathering.Domain.Models;
using Gathering.Domain.Test.ValueObjects;

namespace Gathering.Domain.Test;

public class Test : AggregateRoot<TestId>
{
    public Test(TestId id) : base(id)
    {
    }

    public TestId TestId { get; set; }

    public string Message { get; set; } = "Hello World!";
}