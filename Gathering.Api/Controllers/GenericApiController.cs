using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gathering.Api.Controllers;

[AllowAnonymous]
public class GenericApiController<TGetQuery, TGetResult, TGetResponse> : ApiController
    where TGetQuery : IRequest<ErrorOr<List<TGetResult>>>, new()
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public GenericApiController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new TGetQuery();

        var authResult = await _mediator.Send(query);

        return authResult.Match(
            authResult => Ok(_mapper.Map<TGetResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id)
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok();
    }
}