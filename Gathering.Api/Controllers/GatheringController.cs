using Gathering.Application.Gathering.Queries;
using Gathering.Application.Generic.Common;
using Gathering.Contracts.Generic;
using MapsterMapper;
using MediatR;

namespace Gathering.Api.Controllers;

public class GatheringController : GenericApiController<GetGatheringQuery, GetResult, GetResponse>
{
    public GatheringController(ISender mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
}