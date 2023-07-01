namespace Gathering.Application.Generic;

public interface IGenericRepository<TEntity> where TEntity : class
{
    public Task<List<TEntity>> Get();
    public Task<TEntity> GetById(Guid id);
}