using Application.Persons.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class PersonController : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePersonCommand cmd, CancellationToken cancellationToken) => Ok(await Mediator.Send(cmd, cancellationToken));

}