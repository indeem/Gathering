using ErrorOr;
using Gathering.Application.Generic.Common;
using MediatR;

namespace Gathering.Application.Gathering.Queries;

public class GetGatheringQueryHandler : IRequestHandler<GetGatheringQuery, ErrorOr<List<GetResult>>>
{
    public Task<ErrorOr<List<GetResult>>> Handle(GetGatheringQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}