using ErrorOr;
using Gathering.Application.Generic.Common;
using MediatR;

namespace Gathering.Application.Generic.Queries.GetQuery;

public record GetQuery : IRequest<ErrorOr<List<GetResult>>>;