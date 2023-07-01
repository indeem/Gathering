using ErrorOr;
using Gathering.Application.Generic.Common;
using MediatR;

namespace Gathering.Application.Gathering.Queries;

public record GetGatheringQuery : IRequest<ErrorOr<List<GetResult>>>;