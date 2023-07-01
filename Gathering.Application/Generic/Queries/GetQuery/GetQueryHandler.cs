using ErrorOr;
using Gathering.Application.Generic.Common;
using MapsterMapper;
using MediatR;

namespace Gathering.Application.Generic.Queries.GetQuery;

public class GetQueryHandler<TEntity> : IRequestHandler<GetQuery, ErrorOr<List<GetResult>>>
    where TEntity : class
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<TEntity> _repository;

    public GetQueryHandler(IGenericRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    //https://stackoverflow.com/questions/73760859/mediatr-generic-handlers

    public async Task<ErrorOr<List<GetResult>>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.Get();

        return _mapper.Map<List<GetResult>>(entities);
    }
}