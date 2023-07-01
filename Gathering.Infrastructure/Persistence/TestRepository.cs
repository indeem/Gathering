using Gathering.Application.Generic;
using Gathering.Domain.Test;

namespace Gathering.Infrastructure.Persistence;

public class TestRepository : IGenericRepository<Test>
{
    public Task<List<Test>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Test> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}