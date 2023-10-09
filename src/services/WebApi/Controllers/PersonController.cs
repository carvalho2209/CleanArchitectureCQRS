using Application.Persons.Commands;
using Application.Persons.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class PersonController : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePersonCommand cmd, CancellationToken cancellationToken) => Ok(await Mediator.Send(cmd, cancellationToken));

    [HttpGet]
    [ProducesResponseType(typeof(PersonVm), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonVm[]>> List(CancellationToken cancellationToken) => Ok(await Mediator.Send(new PersonQuery(), cancellationToken));

}